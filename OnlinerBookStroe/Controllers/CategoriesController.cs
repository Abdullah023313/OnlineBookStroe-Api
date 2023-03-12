using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStroe.Dtos;
using OnlineBookStroe.Model;
using OnlineBookStroe.Repository;
using System.Net;

namespace OnlineBookStroe.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Create(string CategoryName)
        {
            var category = new Category
            {
                CategoryName = CategoryName,
                IsDelete = false
            };

            await _categoryRepository.AddCategoryAsync(category);
            return CreatedAtRoute("GetCategory", new
            {
                categoryId = category.CategoryId
            }, category);
        }


        [HttpGet("{categoryId}", Name = "GetCategory")]
        public async Task<ActionResult> GetCategory(int categoryId , bool includeBook)
        {
            var category = await _categoryRepository.GetCategoryAsync(categoryId, includeBook);
            if (category == null)
            {
                return NotFound();
            }
            if(includeBook)
                return Ok(_mapper.Map<CategoryWithBook>(category));
            else 
                return Ok(_mapper.Map<CategoryWithoutBook>(category));

        }



        [HttpGet]
        public async Task<ActionResult> GetCategories() 
        {
            var categorise = await _categoryRepository.GetCategoriesAsync();

            return Ok(_mapper.Map<IList<CategoryWithoutBook>>(categorise));

        }

        [HttpDelete("{CategoryId}")]
        public async Task<ActionResult> DeleteCategory(int CategoryId)
        {
            var category = await _categoryRepository.GetCategoryAsync(CategoryId);
            if (category == null)
            {

                return NotFound($"The Category with Id {CategoryId} could not be found!");
            }
            await _categoryRepository.DeleteAsync(category);
            return NoContent();
        }


        [HttpPut("{CategoryId}")]
        public async Task<ActionResult> UpdateCategory(string CategoryName, int CategoryId)
        {
            var category = await _categoryRepository.GetCategoryAsync(CategoryId);
            if (category == null)
            {

                return NotFound($"The Category with Id {CategoryId} could not be found!");
            }
            category.CategoryName = CategoryName;
            await _categoryRepository.UpdateCategoryAsync(category);

            return Ok(_mapper.Map<CategoryWithoutBook>(category));
        }

    }
}
