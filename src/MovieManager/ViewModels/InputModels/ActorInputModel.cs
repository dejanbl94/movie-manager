using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels
{
    public class ActorInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void MapTo(Actor actor)
        {
            actor.FirstName = FirstName;
            actor.LastName = LastName;
        }
    }
}
