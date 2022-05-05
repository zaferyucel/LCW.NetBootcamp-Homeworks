using DataAccess.Repositories;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IBaseRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
