using Business.Abstract.IServices;
using DataAccess.Entities.Nwind;
using ECommerceWebUI.Models.ViewModels.HomeViewModels;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ListModel;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{

	public class HomeController : Controller
	{
		private readonly ICategoryServices categoryServices;
		private readonly IUrunlerServices urunlerServices;

		public HomeController(ICategoryServices categoryServices, IUrunlerServices urunlerServices)
		{
			this.categoryServices = categoryServices;
			this.urunlerServices = urunlerServices;
		}

		public IActionResult Index()
		{
			var model = new UrunlerListViewModel
			{
				Kategoriler = categoryServices.GetAll()
			};
			return View(model);
		}
		
		[HttpGet]
		[Route("/Sepet")]
		public IActionResult ShoppingCart()
		{
			return View();
		}
		[HttpGet]
		[Route("/Detay")]
		public IActionResult ProductDetail(int id)
		{
			var result = urunlerServices.Get(id);
			if (result == null)
			{
				ModelState.AddModelError("", $"{id}' id ' ye sahip ürün stokta kalmamıştır.");
				return View();
			}
			var model = new ProductDetailViewModel
			{
				UrunID = result.UrunID,
				BirimFiyati = result.BirimFiyati,
				UrunAdi = result.UrunAdi,
				YeniSatis = result.YeniSatis,
			};

			return View(model);
		}
		[HttpGet]
		[Route("/Urunler")]
		public IActionResult Products(int p = 1, int c = 0, int ps = 20 , int df=0)
		{
			var result = urunlerServices.KategoriyeGoreUrunler(c).ToList();
			var pagesize = ps;

			var model = new UrunlerListViewModel
			{
				UrunlerMaksPrice = Convert.ToInt32(result.Max(x => x.BirimFiyati)),
				UrunlerMinPrice = Convert.ToInt32(result.Min(x => x.BirimFiyati)),
				Kategoriler = categoryServices.GetAll(),
				Urunlers = result.Skip((p - 1) * pagesize).Take(pagesize).ToList(),
				PageSize = pagesize,
				PageCount = (int)Math.Ceiling(result.Count / (double)pagesize),
				CurrentCategory = c,
				CurrentPage = p
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult ProductsFilter(int min, int max)
		{
			var model = new UrunlerListViewModel
			{
				Urunlers = urunlerServices.FiyataGoreUrunler(min, max)
			};

			return Json(model);
		}
		[HttpGet]
		public IActionResult JsonUrunGetir(int c = 0, int ps = 20, int p = 1)
		{
			var result = urunlerServices.KategoriyeGoreUrunler(c);
			var pagesize = ps;
			var model = new UrunlerListViewModel
			{
				UrunlerMaksPrice = Convert.ToInt32(result.Max(x => x.BirimFiyati)),
				UrunlerMinPrice = Convert.ToInt32(result.Min(x => x.BirimFiyati)),
				Kategoriler = categoryServices.GetAll(),
				Urunlers = result.Skip((p - 1) * pagesize).Take(pagesize).ToList(),
				PageSize = pagesize,
				PageCount = (int)Math.Ceiling(result.Count / (double)pagesize),
				CurrentCategory = c,
				CurrentPage = p
			};
			var json = JsonConvert.SerializeObject(model);
			return Json(json);
		}
		[HttpGet]
		[Route("/Iletisim")]
		public IActionResult Contact()
		{
			return View();
		}
	}
}
