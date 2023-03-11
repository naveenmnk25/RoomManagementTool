using Microsoft.AspNetCore.Mvc;
using RoomManagement.Models;
using RoomManagement.ViewModels;
using System.Diagnostics;

namespace RoomManagement.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly HappyHomeContext _context;

		public HomeController(ILogger<HomeController> logger, HappyHomeContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			return View(new IndexViewModel(_context).GetModel());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}