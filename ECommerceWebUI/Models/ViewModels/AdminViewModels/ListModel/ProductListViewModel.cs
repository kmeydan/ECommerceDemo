using DataAccess.Entities.Nwind;
using ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel;
using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ListModel
{
	public class ProductListViewModel
	{
		public List<Kategori> Kategoriler{ get; set; }
		public List<Urunler> Urunler{ get; set; }
		public List<ProductViewModel> ProductModel { get; set; }
	}
}
