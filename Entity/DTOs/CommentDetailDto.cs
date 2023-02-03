using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class CommentDetailDto : IDto
    {
        public int Id { get; set; }
        public int contentId { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool Display { get; set; }
    }
}
