﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RoomManagement.Models;
using System.Security.Claims;

namespace RoomManagement.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identities.First().Name != null)
            {
                if(claimUser.Claims.First().Value == "User")
				{
                    return RedirectToAction("Index", "Details");
                }
            }
            else if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login modelLogin)
        {
            if (modelLogin.Email =="Admin" && modelLogin.PassWord == "123@")
            {
                List<Claim> Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,modelLogin.Email),
                    new Claim(ClaimTypes.Role,"Admin"),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(Claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent= modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Home");
            }
            if (modelLogin.Email == "User" && modelLogin.PassWord == "User@")
            {
                List<Claim> Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,modelLogin.Email),
                    new Claim(ClaimTypes.Role,"User"),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(Claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Details");
            }

            ViewData["ValiDateMessage"] = "User not Found";
            return View();
        }
    }
}
