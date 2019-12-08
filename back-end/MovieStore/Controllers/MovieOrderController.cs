using Microsoft.AspNetCore.Mvc;
using MovieStore.DataAccess;
using MovieStore.Services;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieOrderController : BaseController<MovieOrder>
    {
        public MovieOrderController(IMovieOrderService service)
            : base(service)
        {
        }

        [HttpGet("{id}")]
        public override IActionResult Get(int id)
        {
            var value = (_service as IMovieOrderService).GetByUserId(id);
            return Ok(value);
        }

        [HttpGet("movieId={movieId}&userId={userId}")]
        public IActionResult OrderExists(int movieId, int userId)
        {
            var value = (_service as IMovieOrderService).OrderExists(movieId, userId);
            return Ok(value);
        }
    }
}