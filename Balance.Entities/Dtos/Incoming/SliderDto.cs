using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Entities.Dtos.Incoming
{
    public class SliderDto
    {
        public string Name { get; set; }

        public List<int> PhotosURLIds { get; set; }
    }
}
