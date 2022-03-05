﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Entities.DbSet
{
    public class Slider : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<PhotoURL> Photos { get; set; } 
    }
}
