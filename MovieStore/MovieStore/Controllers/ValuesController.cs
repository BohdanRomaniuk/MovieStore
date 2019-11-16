using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DataAccess;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly IUnitOfWork unit;
        public ValuesController(IUnitOfWork work)
        {
            unit = work;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var repo = unit.GetRepository<Movie>();
            return repo.Get().ToList();
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
