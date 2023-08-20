using DataAccess.Entities.Nwind;
using System.Collections.Generic;
using System.IO;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ListModel
{
	public class BannerViewModel
	{
		public List<Slider> Banner { get; set; }
		public List<SliderPossition> BannerPossition { get; set; }
		public List<BannerViewEdit> BannerEdit { get; set; }
	}
	public class BannerViewEdit
	{
		public int SliderID { get; set; }
		public string SliderName { get; set; }
		public string SliderLink { get; set; }
		public string SliderAlt { get; set; }
		public bool SliderActive { get; set; }
		public int? SliderPossition { get; set; }
	}
}
