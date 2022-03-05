using Balance.Entities.Dtos.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Balance.Entities.DbSet
{
    public class PhotoURL : BaseEntity
    {
      
        public string URLPhoto { get; set; }

        [JsonIgnore]
        public virtual InfoCard InfoCard { get; set; }

        public int? SliderId { get; set; }
        [JsonIgnore]
        public virtual Slider Slider { get; set; }

        public int? WorkoutId { get; set; }
        [JsonIgnore]
        public virtual Workout Workout { get; set; }

        public int? CertificateId { get; set; }
        [JsonIgnore]
        public virtual Certificate Certificate { get; set; }
    }
}
