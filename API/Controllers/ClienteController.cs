using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly IClienteRepository repo;

        public ClienteController(IClienteRepository _repo)
        {
            this.repo = _repo;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = repo.Get(id);
            if (model != null)
                return Ok(model);
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var lista = repo.GetList();

            if (lista != null)
                return Ok(lista);

            return NotFound();
        }

        [HttpPut]
        public IActionResult Set(Cliente model)
        {
            if (model != null)
            {
                return Ok(repo.Set(model));
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Update(Cliente model)
        {
            if (model != null)
            {
                repo.Update(model);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                repo.Delete(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
