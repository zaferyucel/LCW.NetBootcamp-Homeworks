using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        public List<ProductCountViewModel> GetProductCount()
        {
            List<ProductDetailDto> producs = _productDal.GetProductDetails();
            var Query = from p in producs.GroupBy(p => p.CategoryName)
                        select new ProductCountViewModel
                        {
                            CategoryName = p.First().CategoryName,
                            NumberOfProduct = p.Count(),
                        };
            return Query.ToList();
        }
    }
}
