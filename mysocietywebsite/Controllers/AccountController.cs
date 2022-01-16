using Microsoft.AspNetCore.Mvc;
using mysocietywebsite.Attributes;
using mysocietywebsite.Model.Entities;
using mysocietywebsite.Service.interfaces;
using System;

namespace mysocietywebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRespository.IRepository<User> _userRepository;
        private readonly IAccount _account;

        public AccountController(IRespository.IRepository<User> userRepository,IAccount account)
        {
            _userRepository = userRepository;
            _account = account;
        }
        // GET: api/<AccountController>
        [AuthorizeAttribute]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetAll());
        }

        // GET api/<AccountController>/5
        [AuthorizeAttribute]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_userRepository.Get(id));
        }

        // POST api/<AccountController>
        [HttpPost("login")]
        public IActionResult Post(User user)
        {
            try {
                var result = (BaseEntity)_account.Login(user.Email, user.Password);
                if (result != null) {
                    return Ok(result);
                }
                return BadRequest("email or password is incorrect !!");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest("Something went wrong !!");
            }
             
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
                var result = _account.Register(user);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Email already exist !!");
        }


        // PUT api/<AccountController>/5
        [AuthorizeAttribute]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,User user)
        {
            if (id != null) {
                _userRepository.Update(user);
                _userRepository.Save();
                return Ok(true);
            }
            else {
                return BadRequest("Unable to update the user !!");
            }
        }

        // DELETE api/<AccountController>/5
        [AuthorizeAttribute]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            User user = _userRepository.Get(id);
            if (user != null) {
                _userRepository.Delete(user);
                _userRepository.Save();
            }
            return BadRequest("Unable to delete the user");
        }
    }
}
