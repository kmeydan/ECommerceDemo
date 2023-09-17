using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;

namespace ECommerceWebUI.ViewComponents
{
	public class NewestProductsViewComponent:ViewComponent
	{
		private readonly IUrunlerServices urunlerServices;

		public NewestProductsViewComponent(IUrunlerServices urunlerServices)
		{
			this.urunlerServices = urunlerServices;
		}

		public ViewViewComponentResult Invoke()
		{


			var model = new IndexBestSellerProductsListModel
			{
				Urunler = urunlerServices.GetAll().Where(x=>x.Sonlandi==true).OrderByDescending(x=>x.UrunID).ToList(),
			};
			
			return View(model);
		}
	}
}
