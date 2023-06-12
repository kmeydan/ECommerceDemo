using DataAccess.Entities.Nwind;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.HomeViewModels.ListModel
{
    public class UrunlerListViewModel
    {
        public List<Urunler> Urunlers{ get; set; }

		public int PageSize { get; set; }
		public int PageCount { get; set; }
		public int CurrentCategory { get; set; }
		public int CurrentPage { get; set; }
	}
}
