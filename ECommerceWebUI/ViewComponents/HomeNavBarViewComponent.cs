using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ListModel;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ECommerceWebUI.ViewComponents
{
	public class HomeNavBarViewComponent:ViewComponent
	{
		private readonly ICategoryServices categoryServices;

		public HomeNavBarViewComponent(ICategoryServices categoryServices)
		{
			this.categoryServices = categoryServices;
		}

		public ViewViewComponentResult Invoke()
		{

			var model = new CategoryListViewModel
			{
				Kategori = categoryServices.GetAll()
			};
			return View(model);
		}
	}
}
