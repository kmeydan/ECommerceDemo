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
		[Route("/Admin/Product/Category")]
		[HttpGet]
		public IActionResult Category()
		{
			return View();
		}

		[Route("/Admin/Product/Brands")]
		[HttpGet]
		public IActionResult Brands()
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
		[Route("/Admin/ReturnRequest/List")]
		[HttpGet]
		public IActionResult ReturnRequestList()
		{
			return View();
		}
		[Route("/Admin/Order/ShipmentList")]
		[HttpGet]
		public IActionResult Shipment()
		{
			return View();
		}

		//Customer
		[Route("/Admin/Customer/List")]
		[HttpGet]
		public IActionResult CustomerList()
		{
			return View();
		}
		//End - Customer
	}
}
