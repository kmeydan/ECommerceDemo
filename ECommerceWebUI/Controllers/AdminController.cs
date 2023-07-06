using Business.Abstract.IServices;
using DataAccess.Concrete.Dal.ClassDal;
using ECommerceWebUI.Models.ViewModels.AdminViewModels.ListModel;
using ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;

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
			var model = new AdminIndexViewModel
			{
				CustomerCount = musteriServices.GetAll().Count(),
				OrderCount = satısServices.GetAll().Where(x => x.SatisTarihi > DateTime.Today).Count(),
				ProductsCount = urunlerServices.GetAll().Count(),
				OrderAll = satısServices.GetAll().Count(),
				SonSiparis = satısServices.GetAll().OrderByDescending(x=>x.SatisTarihi).Select(x => new AdminIndexSonSiparis
				{
					Musteri = x.MusteriID,
					SiparisDurumu = x.SiparisDurumID,
					SiparisId = x.SatisID,
					SiparisTarihi = x.SatisTarihi
				}).Take(5).ToList(),
				//SiparisToplamları = satısServices.GetAll().Select(x=>new SiparisToplamları
				//{
				//	GunlukSiparisTutarı=x.
				//})
			};
			return View(model);
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
				YayınlanmaDurumu = new List<string> { "Seçiniz", "Aktif Ürünler", "Pasif Ürünler" },
				UrunGorseli = new List<string> { "Seçiniz", "Görselli Ürünler", "Görselsiz Ürünler" }
			};
			return View(model);
		}

		//Buraya girip kontrol edilicek
		[Route("/Admin/Product/List")]
		[HttpPost]
		public IActionResult ProductList(AdminProductListViewModel model)
		{

			return View();
		}
		[Route("/Admin/Product/Category")]
		[HttpGet]
		public IActionResult Category()
		{
			var model = new CategoryListViewModel
			{
				Kategori = categoryServices.GetAll()
			};
			return View(model);
		}
		[Route("/Admin/Product/Category")]
		[HttpPost]
		public IActionResult Category(string name)
		{
			if (name == null)
			{
				var standart = new CategoryListViewModel
				{

					Kategori = categoryServices.GetAll()
				};
				return View(standart);
			}
			var model = new CategoryListViewModel
			{

				Kategori = categoryServices.GetAll().Where(x => x.KategoriAdi.ToLower().Contains(name.ToLower())).ToList()
			};
			return View(model);
		}

		[Route("/Admin/Product/Brands")]
		[HttpGet]
		public IActionResult Brands()
		{
			var model = new MarkaListViewModel
			{
				Marka = tedarikciServices.GetAll()
			};
			return View(model);
		}

		[Route("/Admin/Product/Brands")]
		[HttpPost]
		public IActionResult Brands(string brandName)
		{
			if (brandName == null)
			{
				var marka = new MarkaListViewModel
				{
					Marka = tedarikciServices.GetAll()
				};
				return View(marka);
			}
			var model = new MarkaListViewModel
			{
				Marka = tedarikciServices.GetAll().Where(x => x.SirketAdi.ToLower().Contains(brandName.ToLower())).ToList()
			};
			return View(model);
		}




		//Orders
		[Route("/Admin/Order/List")]
		[HttpGet]
		public IActionResult OrderList()
		{
			var model = new OrderListViewModel
			{
				Siparisler = satısServices.GetAll()
			};
			return View(model);
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
			var model = new CustomerListViewModel
			{
				Customers = musteriServices.GetAll()
			};
			return View(model);
		}
		//End - Customer
	}
}
