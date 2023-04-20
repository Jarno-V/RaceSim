using Model;

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
            SetStartPosition(track, participants);
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

        public void SetStartPosition(Track track, List<IParticipant> participants)
        {
            int playerindex = 0;
            int sectionindex = track.Sections.Count - 1;
            while (participants.Count > playerindex)
            {
                SectionData sectionData = GetSectionData(track.Sections.ElementAt(sectionindex));
                if (sectionData.left == null && participants.Count > playerindex)
                {
                    sectionData.left = participants.ElementAt(playerindex);
                    playerindex++;
                }
                if (sectionData.right == null && participants.Count > playerindex)
                {
                    sectionData.right = participants.ElementAt(playerindex);
                    playerindex++;
                }
                sectionindex--;
            }
        }

    }
}
