﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomManagement.Models;
using RoomManagement.ViewModels;

namespace RoomManagement.Controllers
{

    
    public class DetailsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HappyHomeContext _context;

        public DetailsController(ILogger<HomeController> logger, HappyHomeContext context)
        {
            _logger = logger;
            _context = context;
        }
		[Authorize(Roles = "User")]
		public IActionResult Index()
        {
            return View(new IndexDViewModel(_context).GetModel());
        }
		[Authorize(Roles = "adv")]
		public IActionResult Advance()
        {
            return View(new AdvanceViewModel(_context).GetModel());
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Access");
        }
    }
}
