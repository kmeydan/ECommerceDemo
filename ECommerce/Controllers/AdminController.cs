using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemo.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		//Katalog
		[Route("/Admin/Product/List")]
		[HttpGet]
		public IActionResult ProductList()
		{
			return View();
		}
		//Orders
		[Route("/Admin/Order/List")]
		[HttpGet]
		public IActionResult OrderList()
		{
			return View();
		}

		//Customer
		[Route("/Admin/Customer/List")]
		[HttpGet]
		public IActionResult List()
		{
			return View();
		}
		//End - Customer
	}
}
