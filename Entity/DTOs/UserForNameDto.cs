using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class UserForNameDto : IDto
    {
        public int userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
