using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class WatchListDto : IDto
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int contentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double IMDbRating { get; set; }
        public string Genre { get; set; }
        public string PosterPath { get; set; }
        public bool watched { get; set; }

    }
}
