using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Entities.Dtos.Incoming
{
    public class InfoCardDto
    {
        public List<int> FactsId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public List<int> CertificatesId { get; set; }

        public int PhotoId { get; set; }
        public int WorkoutId { get; set; }

    }
}
