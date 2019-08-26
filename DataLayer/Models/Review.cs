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
        // Link to user identity table to show a review by user. Maybe replace this with the foreign key to the Users table.
        // public int ReviewedByUserId { get; set; }
    }
}
