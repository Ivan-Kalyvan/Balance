using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Balance.Entities.DbSet
{
    public class Certificate : BaseEntity
    {
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual PhotoURL PhotoURL { get; set; }
        
        public virtual InfoCard InfoCard { get; set; }
    }
}
