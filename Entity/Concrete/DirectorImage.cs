﻿using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class DirectorImage : IEntity
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public string? ImagePath { get; set; }
    }
}
