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
using UltimateGiftShop.Services.Abstractions;
using AppDataModels.Models;

namespace UltimateGiftShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRedisRepositoryService _redisService;
        private readonly IUserService _userService;

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
            var user = new User();
            
            //if (user)
            //{
            //    loginUser.LoggedIn = user;
            //    //var tokenString = GenerateJSONWebToken(loginUser);
            //    response = Ok(new { token = "" });
            //}
           
            return  RedirectToAction("Index",response);
        }

        [HttpPost("Subscribe")]
        public IActionResult Subscribe(SubscribeUser subUser)
        {

            var  result = _userService.CreateUser(subUser);

            return View();
        }



    }
}
