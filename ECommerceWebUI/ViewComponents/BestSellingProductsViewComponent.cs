using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

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
				Urunler = urunlerServices.GetAll()
			};
			
			return View(model);
		}
	}
}
