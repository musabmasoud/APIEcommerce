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
    public class CategoryController : ControllerBase
    {
        private readonly ICategory categoryRepostory;
        private readonly IMapper mapper;

        public CategoryController(ICategory categoryRepostory ,IMapper mapper)
        {
            this.categoryRepostory = categoryRepostory;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            var categoryModel= await categoryRepostory.GetAllCategory();
            //return dto
            return Ok(mapper.Map<List<CategoryDTO>>(categoryModel));
            //return Ok(categoryModel);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
  
            var categoryModel = await categoryRepostory.GetCategories(id);
            if (categoryModel == null)
            {
                return NotFound();
            }
            //Map Domain Models To DTOs
            return Ok(mapper.Map<CategoryDTO>(categoryModel));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCategoryDTO addCategoryDTO)
        {
            //Map or Convert DTO to Domain Model
            var categoryModel =mapper.Map<Category>(addCategoryDTO);
            //Use Domain model to create Region
            await categoryRepostory.Create(categoryModel);
            //Map Domain Model back to DTO
            var CategoryDTO=mapper.Map<CategoryDTO>(categoryModel);

            return CreatedAtAction(nameof(GetById), new {id=CategoryDTO.id},CategoryDTO);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            //Map DTO to Model
            var categoryModel=mapper.Map<Category>(updateCategoryDTO);
            //chech if category exists
            categoryModel= await categoryRepostory.Update(id, categoryModel);
            if(categoryModel == null)
            {
                return NotFound();
            }
            //convert model to dto
            var categoryDTO=mapper.Map<CategoryDTO>(categoryModel);
            return Ok(categoryDTO);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var categoryModel = await categoryRepostory.Delete(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model To DTO
            return Ok(mapper.Map<CategoryDTO>(categoryModel));

        }
    }
}
