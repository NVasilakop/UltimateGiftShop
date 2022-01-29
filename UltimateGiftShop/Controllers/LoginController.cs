using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
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
        private readonly IUserService _userService;
        private readonly IHttpClientFactory _httpFactory;
        private readonly ApiConfiguration _config;

        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        public LoginController(IUserService userService, IHttpClientFactory factory,ApiConfiguration conf)
        {
            _userService = userService;
            _httpFactory = factory;
            _config = conf;
        }

        public ActionResult Index()
        {
            //return response;
            return View();
        }

        //GET: LoginController/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var serviceResult = _userService.LoginUser(loginUser);
            HttpClient client = _httpFactory.CreateClient(nameof(Login));
            var response = await client.GetAsync(
                $"{_config.BaseAddress}/api/security/gettoken?userId={"serviceResult.Data.UserName"}");
            var context = HttpContext;
            var token = await response.Content.ReadAsStringAsync();
            if (serviceResult.Exists && serviceResult.Data.LoggedIn.Value)
            {
                //return RedirectToAction("Subscribe");
                //HttpClient client = _httpFactory.CreateClient(nameof(Login));
                //var response = await client.GetAsync($"/api/security/gettoken?userId={serviceResult.Data.UserName}");
                if (!response.IsSuccessStatusCode)
                {
                    return View("~/Views/Error/Index.cshtml");
                }
            }
            if(!serviceResult.Exists)
            {
                return View("~/Views/Login/Subscribe.cshtml");
            }
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe(SubscribeUser subUser)
        {
            var  result = _userService.CreateUser(subUser);

            if (result.Data && !result.Exists)
            {
                HttpClient client = _httpFactory.CreateClient(nameof(Login));
                var response = await client.GetAsync(
                    $"{_config.BaseAddress}/api/security/gettoken?userId={subUser.UserName}");
            }
            if (result.Exists)
            {
                return View("~/Views/Login/Login.cshtml");
            }

            if (result.HasError)
            {
                return View("~/Views/Error/Index.cshtml");
            }
            return View();
        }

    }
}
