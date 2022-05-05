﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Description { get; set; }
        public Category category { get; set; }
    }
}
