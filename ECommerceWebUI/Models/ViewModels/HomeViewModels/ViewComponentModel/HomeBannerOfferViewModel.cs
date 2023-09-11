using DataAccess.Entities.Nwind;
using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel
{
    public class HomeBannerOfferViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Slider> OfferTop1 { get; set; }
        public List<Slider> OfferTop2 { get; set; }
        public List<Slider> MidOffer1 { get; set; }
        public List<Slider> MidOffer2 { get; set; }
    }
}
