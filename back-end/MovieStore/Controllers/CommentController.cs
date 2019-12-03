using Microsoft.AspNetCore.Mvc;
using MovieStore.DataAccess;
using MovieStore.Services;
using System;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController<Comment>
    {
        public CommentController(ICommentService service)
            : base(service)
        {
        }

        [HttpPost]
        public override IActionResult Post([FromBody]Comment entity)
        {
            if (ModelState.IsValid)
            {
                entity.ChangeDate = DateTime.Now;
                _service.Add(entity);
                return CreatedAtRoute(Url, entity);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("movieId={movieId}")]
        public IActionResult GetByMovieId(int movieId)
        {
            var value = (_service as ICommentService).GetByMovieId(movieId);
            return Ok(value);
        }
    }
}
