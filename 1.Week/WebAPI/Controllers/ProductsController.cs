using Business.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var addedProduct = _productService.GetAll().SingleOrDefault(p => p.ProductId == product.ProductId);
            if (addedProduct != null)
                return BadRequest();

            _productService.Add(product);
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
        public IActionResult Update(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }
            var updatedProduct = _productService.GetAll().SingleOrDefault(p => p.ProductId == id);
            if (updatedProduct == null)
                return BadRequest();

            _productService.Update(product);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return Ok(result);
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
                _products = _products.Where(e => e.ProductName.ToLower().Contains(search.ProductName.ToLower())).ToList();  
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
    }
}