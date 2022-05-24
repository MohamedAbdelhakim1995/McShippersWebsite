using McShippersWebsite.DTOs;
using McShippersWebsite.Interfaces;
using McShippersWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace McShippersWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;
        private readonly IUserRepository userRepository;

        public AccountController( UserManager<ApplicationUser> userManager, IConfiguration config,IUserRepository userRepository)
        {
            this.userManager = userManager;
            this.config = config;
            this.userRepository = userRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            if (registerDTO.Password != registerDTO.ConfirmPassword)
            {
                return BadRequest("password must match the confirm passowrd");
            }
            IdentityResult result= await userRepository.Insert(registerDTO);
           

            if (result.Succeeded)
            {
               
                return Ok("user Registerd");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);



                }

                return BadRequest(ModelState);

            }




        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = await userManager.FindByEmailAsync(loginDTO.Email);

            if (user != null)

            {
                if (await userManager.CheckPasswordAsync(user, loginDTO.Password))
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                    var roles = await userManager.GetRolesAsync(user);

                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));

                    }

                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
                    var token = new JwtSecurityToken(

                        audience: config["JWT:ValidAudience"],
                        issuer: config["JWT:ValidIssuer"],
                        expires: DateTime.Now.AddHours(5),
                        claims: claims,
                        signingCredentials:
                        new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }

            else
            {

                return Unauthorized();
            }
        }
    }
}
