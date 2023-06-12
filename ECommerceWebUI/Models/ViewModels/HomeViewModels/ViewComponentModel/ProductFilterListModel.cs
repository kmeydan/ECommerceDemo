using DataAccess.Entities.Nwind;
using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel
{
	public class ProductFilterListModel
	{
		public List<Kategori> Kategoriler { get; set; }
		public List<Urunler> Urunler { get; set; }
		public int KategoriBasınaUrun  { get; set; }
		public List<Tedarikci> Tedarikciler  { get; set; }
		public decimal TedarikciBasınaUrun  { get; set; }
		public decimal FiyataGoreUrunSayisi{ get; set; }
	}
}
