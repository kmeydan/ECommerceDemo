using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.AdminViewModels.ListModel;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemo.Controllers
{
	public class AdminController : Controller
	{
		private readonly ICategoryServices categoryServices;
		private readonly IUrunlerServices urunlerServices;
		private readonly IMusteriServices musteriServices;
		private readonly ISatısServices satısServices;
		private readonly ITedarikciServices tedarikciServices;

		public AdminController(ICategoryServices categoryServices, IUrunlerServices urunlerServices, IMusteriServices musteriServices, ISatısServices satısServices, ITedarikciServices tedarikciServices)
		{
			this.categoryServices = categoryServices;
			this.urunlerServices = urunlerServices;
			this.musteriServices = musteriServices;
			this.satısServices = satısServices;
			this.tedarikciServices = tedarikciServices;
		}

		public IActionResult Index()
		{
			return View();
		}
		//Katalog
		[Route("/Admin/Product/List")]
		[HttpGet]
		public IActionResult ProductList(int id)
		{
			var model = new ProductListViewModel
			{
				Kategoriler = categoryServices.GetAll(),
				Urunler= urunlerServices.KategoriyeGoreUrunler(id),

			};
			return View(model);
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
