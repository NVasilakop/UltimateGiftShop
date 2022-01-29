using Microsoft.AspNetCore.Mvc;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AppDataModels.Models;
using Microsoft.Extensions.Configuration;

namespace UltimateGiftShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IConfiguration _config;
        public SecurityController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("gettoken")]
        public ActionResult<string> Get(string userId)
        {
            var token =  GenerateJSONWebToken(new LoginUser { UserName=userId});
            return Ok(token);
        }
        
        private string GenerateJSONWebToken(LoginUser loginUser)
        {
            var x = _config.GetSection("KeyJwt").Value;
            var securityKey = new  SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("KeyJwt").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Issuer","nikos"),
                new Claim("Admin","true"),
                new Claim(JwtRegisteredClaimNames.UniqueName,loginUser.UserName),

            };
            var token = new JwtSecurityToken(loginUser.UserName,
                loginUser.UserName,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }


}
