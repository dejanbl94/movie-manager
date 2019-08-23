using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    // This is a linking table, EF Core needs to have these to implement many-to-many relationships, thus we have TWO, one-to-many relationships.
    public class FilmActor
    {
        // Composite key, foreign keys to Film and Actor tables, it has an effect of ensuring that there's only one link between the Film and the Actor.
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        // Link to the Film and Actor side of the relationship.
        public Film Film { get; set; }
        public Actor Actor { get; set; }
    }
}
