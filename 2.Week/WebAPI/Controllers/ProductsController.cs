using AutoMapper;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        private readonly IMapper _mapper;
        ICategoryService _categoryService;

        public ProductsController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Add(ProductAddDto product)
        {
            if (!CheckCategoryExist(product.CategoryId))
            {
                return NotFound("Category value does not exist");
            }
            Product addedProduct = new Product()
            {
                Id = null,   // Id value will be assign automatically
                Name = product.Name,
                CategoryId = product.CategoryId,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                Description = product.Description,
            };

            _productService.Add(addedProduct);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted_item = _productService.GetById(id);
            if (deleted_item == null)
            {
                return NotFound();
            }
            _productService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductAddDto product)
        {

            var result = _productService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            if (!CheckCategoryExist(product.CategoryId))
            {
                return NotFound("Category value does not exist");
            }
            Product updatedProduct = new Product()
            {
                Id = id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                Description = product.Description,
            };

            _productService.Update(updatedProduct);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> producs = _productService.GetAll();
            List<ProductResultsViewModel> productCategoryName = new List<ProductResultsViewModel>();
            foreach (var product in producs)
            {
                productCategoryName.Add(_mapper.Map<ProductResultsViewModel>(product));
            }
            return Ok(productCategoryName);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Search")]
        public IActionResult Search([FromQuery] SomeQuery search)
        {
            List<Product> _products = _productService.GetAll();
            if (search.CategoryId != null)
            {
                _products = _products.Where(e => e.CategoryId == search.CategoryId).ToList();
            }
            if (!string.IsNullOrEmpty(search.ProductName))
            {
                _products = _products.Where(e => e.Name.ToLower().Contains(search.ProductName.ToLower())).ToList();
            }

            if (search.MinUnitPrice != null || search.MaxUnitPrice != null)
            {
                if (search.MinUnitPrice != null && search.MaxUnitPrice != null)
                {
                    _products = _products.Where(p => p.UnitPrice >= search.MinUnitPrice && p.UnitPrice <= search.MaxUnitPrice).ToList();
                }
                else if (search.MinUnitPrice != null)
                {
                    _products = _products.Where(p => p.UnitPrice >= search.MinUnitPrice).ToList();
                }
                else
                {
                    _products = _products.Where(p => p.UnitPrice <= search.MaxUnitPrice).ToList();
                }
            }

            if (!string.IsNullOrEmpty(search.Description))
            {
                _products = _products.Where(e => e.Description.ToLower().Contains(search.Description.ToLower())).ToList();

            }
            return Ok(_products);

        }
        [HttpGet("productandcategoryname")]
        public IActionResult GetByCategoryName()
        {
            List<ProductDetailDto> _products = _productService.GetProductDetails();
            List<ProductAndCategoryNameViewModel> productCategoryName = new List<ProductAndCategoryNameViewModel>();
            foreach (var product in _products)
            {
                productCategoryName.Add(_mapper.Map<ProductAndCategoryNameViewModel>(product));
            }
            
            return Ok(productCategoryName);
        }

        [HttpGet("productCountByCategory")]
        public IActionResult GetByCount()
        {
            List<ProductCountViewModel> productCountViewModel = _productService.GetProductCount();
            return Ok(productCountViewModel);
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
