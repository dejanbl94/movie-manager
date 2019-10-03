using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels
{
    public class ActorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ActorModel FromActor(Actor actor)
        {
            return new ActorModel()
            {
                Id = actor.ActorId,
                FirstName = actor.FirstName,
                LastName = actor.LastName
            };
        }
    }
}
