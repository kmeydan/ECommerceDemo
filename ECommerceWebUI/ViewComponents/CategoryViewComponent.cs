using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ListModel;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;

namespace ECommerceWebUI.ViewComponents
{
	public class CategoryViewComponent : ViewComponent
	{
		private readonly ICategoryServices categoryServices;

		public CategoryViewComponent(ICategoryServices categoryServices)
		{
			this.categoryServices = categoryServices;
		}

		public ViewViewComponentResult Invoke()
		{
			var model = new CategoryListViewModel
			{
				SelectCategory = Convert.ToInt32(HttpContext.Request.Query["c"]),
				Kategori = categoryServices.GetAll()
			};
			return View(model);
		}
	}
}
