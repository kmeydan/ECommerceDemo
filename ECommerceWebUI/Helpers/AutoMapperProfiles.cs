using AutoMapper;
using DataAccess.Entities.Nwind;
using ECommerceWebUI.Dtos;

namespace ECommerceWebUI.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Kategori, CategoryListDto>();
            CreateMap<Urunler, ProductListDto>();
        }
    }
}
