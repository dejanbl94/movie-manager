using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public string Rating { get; set; }
        // This is a FK to Film table, creating one-to-many relationship.
        public int FilmId { get; set; }
    }
}
