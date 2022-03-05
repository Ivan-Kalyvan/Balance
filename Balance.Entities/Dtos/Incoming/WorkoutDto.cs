using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Entities.Dtos.Incoming
{
    public class WorkoutDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<int> PhotosIds { get; set; }
        public List<int> CardsIds { get; set; }
    }
}
