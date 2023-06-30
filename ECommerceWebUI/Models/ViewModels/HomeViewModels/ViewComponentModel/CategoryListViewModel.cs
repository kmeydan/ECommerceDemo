using DataAccess.Entities.Nwind;
using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel
{
    public class CategoryListViewModel
    {
        public int CategoryId { get; set; }
        public int SelectCategory { get; set; }
        public List<Kategori> Kategori { get; set; }
    }
}
