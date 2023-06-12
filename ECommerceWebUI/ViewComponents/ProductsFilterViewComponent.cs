using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;

namespace ECommerceWebUI.ViewComponents
{
	public class ProductsFilterViewComponent:ViewComponent
	{
		private readonly IUrunlerServices urunlerServices;
		private readonly ICategoryServices categoryServices;
		private readonly ITedarikciServices tedarikciServices;


		public ProductsFilterViewComponent(IUrunlerServices urunlerServices,ICategoryServices categoryServices, ITedarikciServices tedarikciServices)
		{
			this.urunlerServices = urunlerServices;
			this.categoryServices = categoryServices;
			this.tedarikciServices = tedarikciServices;
		}

		public ViewViewComponentResult Invoke()
		{
			var model = new ProductFilterListModel
			{
				Kategoriler = categoryServices.GetAll(),
				Urunler = urunlerServices.GetAll(),
				Tedarikciler = tedarikciServices.GetAll()
			};

			return View(model);
		}
	}
}
