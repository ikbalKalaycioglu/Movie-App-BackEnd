using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class VerifyResetTokenDto
    {
        public string Email { get; set; }
        public string ResetToken { get; set; }
    }
}
