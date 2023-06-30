using Business.Concrete.Services;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;

namespace ECommerceWebUI.ViewComponents
{
	public class GosterimSiralamaViewComponent:ViewComponent
	{
		public int UrunSayisi = 20;
		public int Kategori = 0;
		public int DefaultSiralama = 0;
		public string SiralamaIsmi = "";

		public string SiralamaTespit(int siralama)
		{
			switch (siralama)
			{
				case 1:
					SiralamaIsmi = "Yeni Ürünler";
					break;
				case 2:
					SiralamaIsmi = "Ucuzdan Pahalıya";
					break;
				case 3:
					SiralamaIsmi = "Pahalıdan Ucuza";
					break;
				case 4:
					SiralamaIsmi = "Çok Satanlar";
					break;
				default:
					SiralamaIsmi = "Önerilen Sıralama";
					break;
			}
			return SiralamaIsmi;
			

		}

		public ViewViewComponentResult Invoke()
		{
			var model = new GosterimSiralamaModel
			{
				UrunSayisi = HttpContext.Request.Query["ps"].Count > 0 ? Convert.ToInt32(HttpContext.Request.Query["ps"]) : 20,
				Kategori = HttpContext.Request.Query["c"].Count > 0 ? Convert.ToInt32(HttpContext.Request.Query["c"]) : 0,
				Sıralama = HttpContext.Request.Query["df"].Count > 0 ? Convert.ToInt32(HttpContext.Request.Query["df"]) : 0,
				SiralamaIsmi = SiralamaTespit(HttpContext.Request.Query["df"].Count > 0 ? Convert.ToInt32(HttpContext.Request.Query["df"]) : 0)

			};
			
			return View(model);
		}
	}
}
