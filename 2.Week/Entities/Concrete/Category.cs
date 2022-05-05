using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        [ForeignKey("Product")]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
