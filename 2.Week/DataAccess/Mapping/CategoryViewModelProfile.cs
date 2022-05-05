using AutoMapper;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class CategoryViewModelProfile:Profile
    {
        public CategoryViewModelProfile()
        {
            CreateMap<Category, CategoryViewModel>().
                ForMember(d => d.CategoryName, operation => operation.MapFrom(source => source.Name));
        }
    }
}
