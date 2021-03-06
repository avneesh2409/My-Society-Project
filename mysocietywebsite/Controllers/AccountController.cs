﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mysocietywebsite.Model.Entities;
using static mysocietywebsite.Resource.interfaces.IRespository;

namespace mysocietywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public AccountController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetAll());
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_userRepository.Get(id));
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult Post(User user)
        {
            try {
                _userRepository.Insert(user);
                _userRepository.Save();
                return Ok(true);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
             
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,User user)
        {
            if (id != null) {
                _userRepository.Update(user);
                _userRepository.Save();
                return Ok(true);
            }
            else {
                return BadRequest();
            }
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            User user = _userRepository.Get(id);
            if (user != null) {
                _userRepository.Delete(user);
                _userRepository.Save();
            }
            return BadRequest();
        }
    }
}
