using AutoMapper;
using Business.Abstract.IServices;
using DataAccess.Entities.Nwind;
using ECommerceWebUI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceWebUI.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUrunlerServices _urunlerServices;
        private readonly IMapper _mapper;

        public ProductController(IUrunlerServices urunlerServices, IMapper mapper)
        {
            _urunlerServices = urunlerServices;
            _mapper = mapper;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = _urunlerServices.GetAll();
            var productDto = _mapper.Map<List<ProductListDto>> (products);
;           return Ok(productDto);
        }
    }
}
