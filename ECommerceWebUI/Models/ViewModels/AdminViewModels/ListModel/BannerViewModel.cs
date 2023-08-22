using DataAccess.Entities.Nwind;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ListModel
{
	public class BannerViewModel
	{
		public List<Slider> Banner { get; set; }
		public List<SliderPossition> BannerPossition { get; set; }
		public int PossitionID { get; set; }
	}
	public class BannerView
	{
		public int SliderID { get; set; }
		public string SliderName { get; set; }
		public string SliderLink { get; set; }
		public string SliderAlt { get; set; }
		public bool SliderActive { get; set; }
		public int? SliderPossition { get; set; }
		public IFormFile Img { get; set; }
		public string ImgName { get; set; }
	}
}
