using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebUI.Controllers
{
	public class CustomerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
