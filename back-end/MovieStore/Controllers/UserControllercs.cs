using Microsoft.AspNetCore.Mvc;
using MovieStore.DataAccess;
using MovieStore.Services;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        public UserController(IUserService service)
            : base(service)
        {
        }
    }
}
