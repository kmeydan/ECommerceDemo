using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
			var model = new AdminProductListViewModel
			{
				Kategoriler = categoryServices.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList(),				
				Urunler = urunlerServices.GetAll(),
				YayınlanmaDurumu=new List<string> { "Seçiniz","Aktif Ürünler","Pasif Ürünler"},
				UrunGorseli= new List<string> { "Seçiniz","Görselli Ürünler","Görselsiz Ürünler"}
			};
			return View(model);
		}
		[Route("/Admin/Product/List")]
		[HttpPost]
		public IActionResult ProductList(AdminProductListViewModel model)
		{
			var response = new AdminProductListViewModel
			{
				Kategoriler = categoryServices.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList(),
				Urunler = urunlerServices.GetAll()
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
