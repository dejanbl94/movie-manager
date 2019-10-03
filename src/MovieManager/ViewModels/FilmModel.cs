using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int Length { get; set; }
        public byte[] Image { get; set; }

        public FilmModel FromFilm(Film film)
        {
            return new FilmModel()
            {
                Id = film.FilmId,
                Title = film.Title,
                Description = film.Description,
                ReleaseYear = film.ReleaseYear,
                Length = film.Length,
                Image = film.Image
            };
        }
    }
}
