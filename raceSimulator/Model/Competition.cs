using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Competition 
    {
        public List<IParticipant> Participants = new List<IParticipant>();
        public Queue<Track> Tracks = new Queue<Track>();

        public Track NextTrack()
        {
            if (Tracks.Count > 0)
            {
                Track nextTrack = Tracks.Dequeue();
                return nextTrack;
            } else
            {
                return null;
            }

        }
    }
}
