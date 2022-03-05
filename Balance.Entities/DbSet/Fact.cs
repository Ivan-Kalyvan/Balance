using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Balance.Entities.DbSet
{
    public class Fact : BaseEntity
    {
        public string FactDesc { get; set; }

        public int InfoCardId { get; set; }
        [JsonIgnore]
        public virtual InfoCard InfoCard { get; set; }
    }
}
