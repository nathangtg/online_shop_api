using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using online_shop_api.Database;
using online_shop_api.Database.Dto;
using online_shop_api.Models;

namespace online_shop_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
        public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return Ok();
            }

            if (result.IsLockedOut)
            {
                return Unauthorized("User account locked out.");
            }

            return Unauthorized("Invalid login attempt.");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                Role = registerDto.Role
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerDto.Role);
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}