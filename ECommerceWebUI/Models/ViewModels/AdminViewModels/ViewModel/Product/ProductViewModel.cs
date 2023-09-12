using DataAccess.Entities.Nwind;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel.Product
{
	public class ProductViewModel
	{
		public int UrunID { get; set; }
		[Required(ErrorMessage ="İsim Alanı Zorunludur")]
		[MaxLength(100,ErrorMessage ="En Fazla 100 Karakter Girebilirsin!")]
		public string UrunAdi { get; set; }
		public List<Tedarikci> Tedarikci { get; set; }
		public List<Kategori> Kategori { get; set; }
		public string Barkod { get; set; }
		[Required]
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
