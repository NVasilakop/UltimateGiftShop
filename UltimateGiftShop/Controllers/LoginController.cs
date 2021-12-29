using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.IdentityModel.Tokens;
using UltimateGiftShop.Models;
using UltimateGiftShop.Services.Abstractions;

namespace UltimateGiftShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRedisRepositoryService _redisService;

        public LoginController(IRedisRepositoryService serv)
        {
            _redisService = serv;
        }

        public ActionResult Index()
        {
            //return response;
            return View();
        }
        
        // GET: LoginController/Login
        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {
            IActionResult response = Unauthorized();
            var user = _redisService.CheckIfUserExists(loginUser.UserId);
            
            if (user)
            {
                loginUser.LoggedIn = user;
                //var tokenString = GenerateJSONWebToken(loginUser);
                response = Ok(new { token = "" });
            }
           
            return  RedirectToAction("Index",response);
        }
        
    


    }
}
