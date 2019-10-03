using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels
{
    public class FilmInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int Length { get; set; }
        public byte[] Image { get; set; }

        public void MapTo(Film film)
        {
            film.Title = Title;
            film.Description = Description;
            film.ReleaseYear = ReleaseYear;
            film.Length = Length;
            film.Image = Image;
        }
    }


}
