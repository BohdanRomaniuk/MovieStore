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

        [HttpGet("searchQuery={searchQuery}")]
        public IActionResult Search(string searchQuery)
        {
            var value = (_service as IMovieService).Search(searchQuery);
            return Ok(value);
        }
    }
}
