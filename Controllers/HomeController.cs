using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace PartyInvites.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var hour = DateTime.Now.Hour;
			ViewBag.Greeting = hour < 12 ? "GoodMorning" : "GoodAfternoon";
			return View("MyView");
		}

		[HttpGet]
		public ViewResult RsvpForm()
		{
			return View();
		}

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guestResponse)
		{
			if (ModelState.IsValid)
			{
				Repository.AddResponse(guestResponse);
				return View("Thanks", guestResponse);
			}
			else
			{
				return View();
			}
		}

		public IActionResult ListReponses()
		{
			return View(Repository.Responses.Where(r => r.WillAttend == true));
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
