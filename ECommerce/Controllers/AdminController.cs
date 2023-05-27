using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemo.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		//Customer
		[Route("/Admin/Customer/List")]
		public IActionResult List()
		{
			return View();
		}
		//End - Customer
	}
}
