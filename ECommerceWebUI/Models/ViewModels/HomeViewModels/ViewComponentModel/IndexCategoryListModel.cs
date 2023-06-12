using DataAccess.Entities.Nwind;
using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel
{
    public class IndexCategoryListModel
    {
        public List<Kategori> Kategori{ get; set; }
        public int SelectedKategori { get; set; }
        public List<Urunler> Urunler { get; set; }
    }
}
