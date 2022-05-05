using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        void Add(Product product);
        void Delete(int id);
        void Update(Product product);
        List<Product> GetAll();
        Product GetById(int id);
    }
}
