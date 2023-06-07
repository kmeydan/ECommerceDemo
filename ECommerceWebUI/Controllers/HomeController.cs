using Business.Abstract.IServices;
using DataAccess.Entities.Nwind;
using ECommerceWebUI.Models.ViewModels.HomeViewModels;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
		private readonly ICategoryServices categoryServices;
        private readonly IUrunlerServices urunlerServices;

        public HomeController(ICategoryServices categoryServices, IUrunlerServices urunlerServices)
        {
            this.categoryServices = categoryServices;
            this.urunlerServices = urunlerServices;
        }

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
		[Route("/{productName}")]
		public IActionResult ProductDetail(string productName)
		{
			var result=urunlerServices.GetProductByName(productName);
			if (result==null)
			{
				ModelState.AddModelError("", $"{productName}' ismine sahip ürün stokta kalmamıştır.");
				return View();
			}
			var model = new ProductDetailViewModel
			{
				UrunID = result.UrunID,
				BirimFiyati= result.BirimFiyati,
				UrunAdi= result.UrunAdi,
				YeniSatis= result.YeniSatis,
			};

			return View(model);
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
