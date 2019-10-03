using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public string ReviewRating { get; set; }
        public int FilmId { get; set; }

        public ReviewModel FromReview(Review review)
        {
            return new ReviewModel()
            {
                Id = review.ReviewId,
                ReviewText = review.ReviewText,
                ReviewRating = review.Rating,
                FilmId = review.FilmId
            };
        }
    }
}
