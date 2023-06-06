using Model;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Controller
{
    public class Race
    {
        public Track Track;
        public List<IParticipant> participants;
        public SectionTypes[] sections;
        public DateTime StartTime;
        private Random _random;
        private Dictionary<Section, SectionData> _positions = new();

        public Race(Track track, List<IParticipant> participants)
        {
            this.Track = track;
            this.participants = participants;
            this.StartTime = DateTime.Now;
            this._random = new Random(DateTime.Now.Millisecond);
            setStartPosition(track, participants);
        }
        public SectionData GetSectionData(Section section)
        {
            SectionData sectiondata;
            if (_positions.ContainsKey(section))
            {
                sectiondata = _positions[section];
            }
            else
            {
                _positions.Add(section, new SectionData());
                sectiondata = _positions[section];
            }
            return sectiondata;
        }

        public void RandomizeEquipment()
        {
            foreach (IParticipant participant in participants)
            {
                participant.Equipment.Performance = _random.Next();
                participant.Equipment.Quility = _random.Next();
            }
        }

        public void setStartPosition(Track track, List<IParticipant> participants)
        {
            int participantCounter = 0;


            for (LinkedListNode<Section> section = track.Sections.Last; section != null; section = section.Previous)
            {
                SectionData sectionData =  GetSectionData(section.Value);
                
                

                if(participantCounter < participants.Count - 1)
                {
                    sectionData.left = participants[participantCounter];
                    sectionData.right = participants[participantCounter + 1];

                    participantCounter += 2;
                }
                else if (participantCounter == participants.Count - 1)
                {
                    sectionData.left = participants[participantCounter];
                    participantCounter++;
                }
            }
        }

    }
}
