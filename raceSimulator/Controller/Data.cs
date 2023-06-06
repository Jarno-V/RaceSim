using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition competition;
        public static Race CurrentRace;

        static public void Initialize()
        {
            competition = new Competition();
            addParticipants();
            addTracks();
        }

        static public void addParticipants()
        {
            Driver player1 = new Driver();
            player1.Name = "bob";
            competition.Participants.Add(player1);

            Driver player2 = new Driver();
            player2.Name = "henk";
            competition.Participants.Add(player2);

            Driver player3 = new Driver();
            player3.Name = "ties";
            competition.Participants.Add(player3);
        }

        static public void addTracks()
        {
            SectionTypes[] sections = new SectionTypes[]
            {
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.RightCorner,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.StartGrid
            };
            Track track1 = new Track("Zwolle", sections);
            Track track2 = new Track("Ede", sections);
            competition.Tracks.Enqueue(track1);
            competition.Tracks.Enqueue(track2);
        }

        static public Track NextRace()
        {
            Track track = competition.NextTrack();
            if(track != null) { CurrentRace = new Race(track, competition.Participants); }
            return track;
        }
    }

    
}
