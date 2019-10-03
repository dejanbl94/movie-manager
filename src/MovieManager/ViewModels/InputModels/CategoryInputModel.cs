using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels
{
    public class CategoryInputModel
    {
        public string CategoryName { get; set; }

        public void MapTo(Category category)
        {
            category.CategoryName = CategoryName;
        }
    }
}
