using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper; 
        }
        [HttpPost]
        public IActionResult Add(CategoryAddDto category)
        {
            Category addedCategory = new Category()
            {
                Id = null,
                Name = category.Name,

            };
            _categoryService.Add(addedCategory);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted_item = _categoryService.GetById(id);
            if (deleted_item == null)
            {
                return NotFound();
            }
            _categoryService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryAddDto category)
        {

            var result = _categoryService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            if (!CheckCategoryExist(id))
            {
                return NotFound("Category value does not exist");
            }
            Category updatedProduct = new Category()
            {
                Id = id,
                Name = category.Name,
                
            };
            _categoryService.Update(updatedProduct);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = _categoryService.GetAll();

            List<CategoryViewModel> categoryViewModel = new List<CategoryViewModel>();

            foreach (Category category in categories)
            {
                categoryViewModel.Add(_mapper.Map<CategoryViewModel>(category));
            }
            return Ok(categoryViewModel);
        }

        private bool CheckCategoryExist(int categoryId)
        {
            var categoryCheck = _categoryService.GetById(categoryId);
            if (categoryCheck == null)
            {
                return false;
            }
            return true;
        }
    }
}
