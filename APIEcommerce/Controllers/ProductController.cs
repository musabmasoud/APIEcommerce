using APIEcommerce.Domain.Models;
using APIEcommerce.Domain.Models.DTOs;
using APIEcommerce.Infrastructure.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct productRepository;
        private readonly IMapper mapper;

        public ProductController(IProduct productRepository ,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProductDTO addProductDTO)
        {
            var productModel= mapper.Map<Product>(addProductDTO);
            await productRepository.Create(productModel);
            return Ok(mapper.Map<Product>(productModel));
        }
        [HttpGet]
        public async Task<IActionResult>GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
        {
            var productModel = await productRepository.GetAllProduct(filterOn, filterQuery, sortBy, isAscending ?? true);
            return Ok(mapper.Map<List<Product>>(productModel));
        }
    }
}
