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
    public class ValuesController : ControllerBase
    {
        public readonly IMovieService unit;
        public ValuesController(IMovieService work)
        {
            unit = work;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var repo = unit.Get();
            return repo.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] Movie value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
