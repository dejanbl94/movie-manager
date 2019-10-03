using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public CategoryModel FromCategory(Category category)
        {
            return new CategoryModel()
            {
                Id = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
    }
}
