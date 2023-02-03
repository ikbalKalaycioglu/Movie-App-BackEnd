using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class ContentDetailDto :IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DirectorName { get; set; }
        public double IMDbRating { get; set; }
        public string Writer { get; set; }
        public string StarName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string PosterPath { get; set; }
        public string Genre { get; set; }
        public string PlaybackURL { get; set; }

    }
}
