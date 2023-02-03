using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int contentId { get; set; }
        public int userId { get; set; }
        public string Message { get; set; }
        public bool Display { get; set; }
    }
}
