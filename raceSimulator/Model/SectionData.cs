using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SectionData
    {
        IParticipant left { get; set; }
        IParticipant right { get; set; }
        int DistanceLeft { get; set; }
        int DistanceRight { get; set; }

    }
}
