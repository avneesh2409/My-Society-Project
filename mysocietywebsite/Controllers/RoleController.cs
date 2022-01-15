using Microsoft.AspNetCore.Mvc;
using mysocietywebsite.Model.Entities;
using System;
using mysocietywebsite.Service.interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mysocietywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRespository.IRepository<Role> _roleRepository;

        public RoleController(IRespository.IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_roleRepository.GetAll());
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_roleRepository.Get(id));
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult Post(Role role)
        {
            try
            {
                _roleRepository.Insert(role);
                _roleRepository.Save();
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Role role)
        {
            if (id != null)
            {
                _roleRepository.Update(role);
                _roleRepository.Save();
                return Ok(true);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Role role = _roleRepository.Get(id);
            if (role != null)
            {
                _roleRepository.Delete(role);
                _roleRepository.Save();
            }
            return BadRequest();
        }
    }
}
