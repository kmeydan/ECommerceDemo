using Business.Abstract.IServices;
using DataAccess.Abstract.Repository.ClassRepository;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;

namespace ECommerceWebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly ICategoryServices categoryServices;

        public CategoryListViewComponent(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new IndexCategoryListModel
            {
                Kategori = categoryServices.GetAll(),
            };
            return View(model);
        }
    }
}
