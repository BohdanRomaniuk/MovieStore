using Microsoft.AspNetCore.Mvc;
using MovieStore.Services;
using System;

namespace MovieStore.Controllers
{
    public abstract class BaseController<TEntity> : Controller
    {
        protected IService<TEntity> _service;

        public BaseController(IService<TEntity> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            try
            {
                var value = _service.Get();
                return Ok(value);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var value = _service.Get(id);
            return Ok(value);
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody]TEntity entity)
        {
            if (ModelState.IsValid)
            {
                _service.Add(entity);
                return CreatedAtRoute(Url, entity);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            _service.Remove(id);
            return Ok();
        }

        [HttpPut]
        public virtual IActionResult Put([FromBody]TEntity entity)
        {
            if (ModelState.IsValid)
            {
                _service.Update(entity);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
