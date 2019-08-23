using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Relationships.
        public ICollection<FilmCategory> FilmsLinke { get; set; }
    }
}
