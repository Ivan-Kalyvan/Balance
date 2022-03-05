using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Entities.Dtos.Incoming
{
    public class PhotoURLDto
    {
        public string URLPhoto { get; set; }

        public int InfoCardId { get; set; }
        public int SliderId { get; set; }
        public int WorkoutId { get; set; }
        public int CertificateId { get; set; }
    }
}
