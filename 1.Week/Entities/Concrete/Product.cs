using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        [Required]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        [MinLength(2)]
        public string ProductName { get; set;}

        [Range(10, 100000, ErrorMessage = "Price must be between $10 and $100000")]
        public int UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public string Description { get; set; }
    }
}
