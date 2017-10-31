using Lab23CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab23CoffeeShop.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Registration()
		{
			ViewBag.Message = "Your registration page.";

			return View();
		}

		public ActionResult Success(User u)
		{
			ViewBag.FullName = "Welcome " + u.FullName;

			return View();
		}
	}
}