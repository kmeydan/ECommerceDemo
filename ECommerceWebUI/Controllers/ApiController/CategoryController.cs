using AutoMapper;
using Business.Abstract.IServices;
using ECommerceWebUI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceWebUI.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryServices categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            var categories = _categoryService.GetAll();
            var categoriesDto = _mapper.Map<List<CategoryListDto>>(categories);
            return Ok(categoriesDto);
        }
    }
}
