using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class SomeQuery
    {
        public int? CategoryId { get; set; }

        public string? ProductName { get; set; }

        public int? MinUnitPrice { get; set; }

        public int? MaxUnitPrice { get; set; }

        public string? Description { get; set; }
    }
}
