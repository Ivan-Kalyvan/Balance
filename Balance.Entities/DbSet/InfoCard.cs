using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Balance.Entities.DbSet
{
    public class InfoCard : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual List<Certificate> Certificates { get; set; }

        public virtual List<Fact> Facts { get; set; }

        public int? PhotoId { get; set; }
        public virtual PhotoURL Photo { get; set; }

        public int? WorkoutId { get; set; }
        [JsonIgnore]
        public virtual Workout Workout { get; set; }
    }
}
    