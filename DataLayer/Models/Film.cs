using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Film
    {
        // Film table PK.
        public int FilmId { get; set; }
        // Rest of the columns.
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int Length { get; set; }

        // Relationships
        // We are returning as general type as possible, ICollection is more general than IList but as opposed to IEnumerable has a Count property as well.
        public ICollection<FilmActor> ActorsLink { get; set; }
        public ICollection<FilmCategory> CategoriesLink { get; set; }
    }
}
