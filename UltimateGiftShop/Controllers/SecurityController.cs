using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using UltimateGiftShop.Services.Abstractions;
using AppDataModels.Models;

namespace UltimateGiftShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IRedisRepositoryService _redisService;

        public SecurityController(IRedisRepositoryService serv)
        {
            _redisService = serv;
        }

        //public ActionResult gE
        [HttpGet]
        public string Get(string userId)
        {
            return GenerateJSONWebToken(new LoginUser { UserName=userId});
        }
        
        private string GenerateJSONWebToken(LoginUser loginUser)
        {
            var securityKey = new  SymmetricSecurityKey(Encoding.UTF8.GetBytes("Das_ist_my_secret_key"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Issuer",loginUser.UserName),
                new Claim("Admin",""),
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
