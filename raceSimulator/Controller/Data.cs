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
        public static Competition Competition;
        public static Race CurrentRace;

        static public void Initialize()
        {
            Competition = new Competition();
            addParticipants();
            addTracks();
        }

        static public void addParticipants()
        {
            Driver player1 = new Driver();
            player1.Name = "bob";
            Competition.Participants.Add(player1);

            Driver player2 = new Driver();
            player2.Name = "henk";
            Competition.Participants.Add(player2);

            Driver player3 = new Driver();
            player3.Name = "ties";
            Competition.Participants.Add(player3);
        }

        static public void addTracks()
        {
            SectionTypes[] sections = new SectionTypes[]
            {
                SectionTypes.StartGrid,
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
                SectionTypes.Straight
            };
            Track track1 = new Track("Zwolle", sections);
            Track track2 = new Track("Ede", sections);
            Competition.Tracks.Enqueue(track1);
            Competition.Tracks.Enqueue(track2);
        }

        static public Track NextRace()
        {
            Track track = Competition.NextTrack();
            if(track != null) { CurrentRace = new Race(track, Competition.Participants); }
            return track;
        }
    }

    
}
