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
    }
}
