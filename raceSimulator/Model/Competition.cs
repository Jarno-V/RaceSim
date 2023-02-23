using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Competition 
    {
        List<IParticipant> Participants;
        Queue<Track> Tracks;

        public Track NextTrack()
        {
            return Track;
        }
    }
}
