﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test101.Models;

namespace test101.Controllers
{
    [Route("userapi/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly EmpDBContext _authContext;

        public UserController( EmpDBContext empDBContext)
        {
            _authContext = empDBContext;

        }

        [HttpPost("authenticate")]

        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _authContext.Users
                .FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password == userObj.Password);
            if (user == null)
                return NotFound(new { Message = "User Not Found" });

            return Ok(new
            {
                Message = "Login Success"
            });
        }


        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered"
            });
        }

    }
}
