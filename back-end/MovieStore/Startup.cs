using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieStore.AuthHelpers;
using MovieStore.DataAccess;
using MovieStore.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace MovieStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("MovieStoreDbConnection");
            services.AddDbContext<MovieStoreContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services (BL)
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();
            //Services (BL)

            // Configure JWT authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false; // For testing only
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = JWTConfigurator.ISSUER,

                            ValidateAudience = false, // Will not validate audience
                            ValidAudience = JWTConfigurator.AUDIENCE,

                            ValidateLifetime = true,

                            IssuerSigningKey = JWTConfigurator.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("MovieStore", new Info { Title = "MovieStore API", Version = "1.0" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // This automatically migrates DB
            // Code to create migration in Package manager console:
            //     PM> add-migration <name> -project MovieStore.DataAccess
            // Migration will be applied automatically!
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MovieStoreContext>();
                context.Database.Migrate();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseAuthentication();

            // Swagger is here: localhost/swagger/index.html
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/MovieStore/swagger.json", "MovieStore API");
            });
        }
    }
}
