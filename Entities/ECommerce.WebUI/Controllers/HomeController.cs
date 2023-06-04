﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
	public class HomeController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		[Route("/Sepet")]
		public IActionResult ShoppingCart()
		{
			return View();
		}
		[HttpGet]
		[Route("/Detay")]
		public IActionResult ProductDetail()
		{
			return View();
		}
		[HttpGet]
		[Route("/Urunler")]
		public IActionResult Products()
		{
			return View();
		}
		[HttpGet]
		[Route("/Iletisim")]
		public IActionResult Contact()
		{
			return View();
		}
	}
}
