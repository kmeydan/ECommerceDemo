using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ECommerceWebUI.ViewComponents
{
	public class MidOfferViewComponent:ViewComponent
	{
		private readonly ISliderServices sliderServices;

		public MidOfferViewComponent(ISliderServices sliderServices)
		{
			this.sliderServices = sliderServices;
		}

		public ViewViewComponentResult Invoke()
		{
			var model = new HomeBannerOfferViewModel
			{
				MidOffer1 = sliderServices.SliderPossitionGet(4),
				MidOffer2=sliderServices.SliderPossitionGet(5)
			};
			return View(model);
		}
	}
}
