using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Entities.Dtos.Incoming
{
    public class CertificateDto
    {
        public string Description { get; set; }
        public string Type { get; set; }

        public int CertificatePhotoID { get; set; }
    }
}
