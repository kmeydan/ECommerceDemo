using DataAccess.Entities.Nwind;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel.Product
{
	public class ProductViewModel
	{
		public int UrunID { get; set; }
		public string UrunAdi { get; set; }
		public List<Tedarikci> TedarikciID { get; set; }
		public List<SelectListItem> KategoriID { get; set; }
		public string Barkod { get; set; }
		public decimal BirimFiyati { get; set; }
		public short HedefStokDuzeyi { get; set; }
		public short YeniSatis { get; set; }
		public short EnAzYenidenSatisMikatari { get; set; }
		public string GorselUrl { get; set; }
		public IFormFile Gorsel { get; set; }
		public bool Sonlandi { get; set; }
		public decimal? EskiSatisFiyati { get; set; }
	}
}
