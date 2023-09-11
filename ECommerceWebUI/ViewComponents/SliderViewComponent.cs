using Business.Abstract.IServices;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;

namespace ECommerceWebUI.ViewComponents
{
	public class SliderViewComponent:ViewComponent
	{
		private readonly ISliderServices sliderServices;

		public SliderViewComponent(ISliderServices sliderServices)
		{
			this.sliderServices = sliderServices;
		}

		public ViewViewComponentResult Invoke()
		{
			var model = new HomeBannerOfferViewModel
			{
				Sliders = sliderServices.GetAll().Where(x => x.SliderPossitionID == 1).OrderByDescending(x => x.SliderID).ToList(),
				OfferTop1=sliderServices.GetAll().Where(x=>x.SliderPossitionID==2).OrderBy(x => x.SliderID).ToList(),
				OfferTop2=sliderServices.GetAll().Where(x=>x.SliderPossitionID==3).OrderByDescending(x => x.SliderID).ToList(),

			};
			return View(model);
		}
	}
}
