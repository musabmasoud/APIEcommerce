using APIEcommerce.Domain.Models;
using APIEcommerce.Domain.Models.DTOs;
using APIEcommerce.Infrastructure.Data;
using APIEcommerce.Infrastructure.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace APIEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct productRepository;
        private readonly IMapper mapper;
        private readonly APIEcommerceDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IProduct productRepository ,IMapper mapper,APIEcommerceDbContext dbContext,
            IWebHostEnvironment webHostEnvironment)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddProductDTO addProductDTO , List<IFormFile> files)
        //public async Task<IActionResult> Create(AddProductDTO addProductDTO, [FromForm] List<IFormFile> files)
        {
            var productModel = mapper.Map<Product>(addProductDTO);
            var product = new Product();
            if (files != null)
            {
                foreach(IFormFile file in files)
                {
                    var imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var imagePath = Path.Combine("uploads", imageName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var image = new ProductImage
                    {

                        ProductId = productModel.Id,
                    };

                    dbContext.ProductImages.Add(image);
                }
            }
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
//[HttpPost("{productId}/images")]
//public async Task<ActionResult> UploadImage(int productId, [FromForm] List<Microsoft.AspNetCore.Http.IFormFile> files)
//{
//    var product = await _context.Products.FindAsync(productId);
//    if (product == null)
//    {
//        return NotFound();
//    }

//    foreach (var file in files)
//    {
//        var imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
//        var imagePath = Path.Combine("uploads", imageName);

//        using (var stream = new FileStream(imagePath, FileMode.Create))
//        {
//            await file.CopyToAsync(stream);
//        }

//        var image = new Image
//        {
//            FileName = imageName,
//            FilePath = imagePath,
//            ProductId = productId
//        };

//        _context.Images.Add(image);
//    }

//    await _context.SaveChangesAsync();

//    return Ok();
//}

//// Helper method to retrieve a product by ID
//private async Task<Product> GetProductById(int id)
//{
//    return await _context.Products.Include(p => p.Images).FirstOrDefaultAsync(p => p.ProductId == id);
//}
//}