using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DataAccess;
using MovieStore.Services;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseController<Movie>
    {
        public MovieController(IMovieService service)
            : base(service)
        {
        }
    }
}
