using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : BaseRepository<Product>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (Context context = new Context())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailDto
                             {
                                 ProductName = p.Name,
                                 CategoryName = c.Name,
                             };
                return result.ToList();
            }
        }
    }
}
