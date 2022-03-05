using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Entities.DbSet
{
    public class Workout : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<PhotoURL> Photos { get; set; }
        public virtual List<InfoCard> Cards { get; set; }
    }
}
