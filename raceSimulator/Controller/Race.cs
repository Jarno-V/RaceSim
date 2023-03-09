using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class Race
    {
        public Track Track;
        public List<IParticipant> participants;
        public DateTime StartTime;
        private Random _random;

        private Dictionary<Section, SectionData> _positions;
        
        public Race(Track track, List<IParticipant> participants)
        {
            this.Track = track;
            this.participants = participants;
            this.StartTime = DateTime.Now;
            this._random = new Random(DateTime.Now.Millisecond);
        }
        public SectionData GetSectionData(Section section)
        {
            SectionData sectiondata = _positions[section];
            if (sectiondata == null) { _positions[section] = new SectionData(); }

            return sectiondata;
        }

        public void RandomizeEquipment()
        {
            foreach(IParticipant participant in participants)
            {
                participant.Equipment.Performance = _random.Next();
                participant.Equipment.Quility= _random.Next();
            }
        }

    }
}
