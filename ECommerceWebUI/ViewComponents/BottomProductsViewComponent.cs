using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;

namespace ECommerceWebUI.ViewComponents
{
	public class BottomProductsViewComponent:ViewComponent
	{
		private readonly IUrunlerServices urunlerServices;

		public BottomProductsViewComponent(IUrunlerServices urunlerServices)
		{
			this.urunlerServices = urunlerServices;
		}

		public ViewViewComponentResult Invoke()
		{
			var model = new IndexBestSellerProductsListModel
			{
				Urunler=urunlerServices.GetAll().OrderByDescending(x=>x.UrunID).Take(12).ToList(),
			};
			return View(model);
		}
	}
}
