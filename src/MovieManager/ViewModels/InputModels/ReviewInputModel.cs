using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels
{
    public class ReviewInputModel
    {
        public string ReviewText { get; set; }
        public string Rating { get; set; }

        public void MapTo(Review review)
        {
            review.ReviewText = ReviewText;
            review.Rating = Rating;
        }
    }
}
