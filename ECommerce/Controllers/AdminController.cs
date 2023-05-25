using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemo.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
