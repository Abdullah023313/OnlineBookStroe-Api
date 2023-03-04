using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinerBookStroe.Dtos;
using OnlinerBookStroe.Model;
using OnlinerBookStroe.Repository;
using System.Net;

namespace OnlinerBookStroe.Controllers
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
            var Category = new Category
            {
                CategoryName = CategoryName,
                IsDelete = false
            };

            var category= await _categoryRepository.AddCategoryAsync(Category);
            return CreatedAtRoute("GetCategory", new
            {
                categoryId = category.CategoryId
            }, category);
        }


        [HttpGet("{categoryId}", Name = "GetCategory")]
        public async Task<ActionResult> GetCategory(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryAsync(categoryId, true);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryWithBook>(category));

        }



        [HttpGet]
        public async Task<ActionResult> GetCategories() //TODO Filter
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

                return NotFound($"The Category with ID {CategoryId} could not be found!");
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

                return NotFound($"The Category with ID {CategoryId} could not be found!");
            }
            category.CategoryName = CategoryName;
            await _categoryRepository.UpdateCategoryAsync(category);

            return Ok(_mapper.Map<CategoryWithoutBook>(category));
        }
    }
}
