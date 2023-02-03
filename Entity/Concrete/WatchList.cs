using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class WatchList : IEntity
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int UserId { get; set; }
        public bool watched { get; set; }

    }
}
