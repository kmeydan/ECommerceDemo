using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;

namespace ECommerceWebUI.ViewComponents
{
	public class BestSellingProductsViewComponent:ViewComponent
	{
		private readonly IUrunlerServices urunlerServices;

		public BestSellingProductsViewComponent(IUrunlerServices urunlerServices)
		{
			this.urunlerServices = urunlerServices;
		}

		public ViewViewComponentResult Invoke()
		{


			var model = new IndexBestSellerProductsListModel
			{
				Urunler = urunlerServices.EnCokSatanlar().Take(12).ToList()
			};
			
			return View(model);
		}
	}
}
