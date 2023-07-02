using DataAccess.Entities.Nwind;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel
{
	public class AdminProductListViewModel
	{
		public List<Urunler> Urunler { get; set; }
		public string UrunAdi { get; set; }
		public List<SelectListItem> Kategoriler { get; set; }
		public List<string> UrunGorseli { get; set; }
		public string UrunBarkod { get; set; }
		public decimal BirimFiyati { get; set; }
		public List<string> YayınlanmaDurumu { get; set; }

		
	}
}
