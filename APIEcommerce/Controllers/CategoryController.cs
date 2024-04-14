using APIEcommerce.Domain.Models;
using APIEcommerce.Infrastructure.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory categoryRepostory;

        public CategoryController(ICategory categoryRepostory)
        {
            this.categoryRepostory = categoryRepostory;
        }
        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            var categoryModel= await categoryRepostory.GetAllCategory();
            return Ok(categoryModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            await categoryRepostory.Create(category);
            return Ok(await categoryRepostory.GetAllCategory());
            //if (await categoryRepostory.Create(model.Category_Name))
            //    return BadRequest(" this Category name is already registred");

            //var categy = new Category
            //{
            //    Category_Name = model.Category_Name,
            //};

            //category.(categy);

            //return Ok(await _categoryService.GetAll());
        }
    }
}
