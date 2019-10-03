using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Actor
    {
        // Actor table PK.
        public int ActorId { get; set; }
        // Rest of the tables.
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Relationships
        public ICollection<FilmActor> FilmsLink { get; set; }
        public ICollection<FilmCategory> CategoriesLink { get; set; }
    }
}
