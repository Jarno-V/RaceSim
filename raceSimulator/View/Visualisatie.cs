using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleProject
{
    public static class Visualisatie
    {
        public static int[] CursorLocation = { 50, 2 };
        public static void Initialize()
        {

        }

        public static void DrawTrack(Track track)
        {
            // 0 == north;  1 == east;  2 == south;  3 == west;
            int compas = 1;
            foreach(Section section in track.Sections)
            {
                switch(section.SectionType) {
                    case SectionTypes.StartGrid:
                        ConsoleTrack(_finishHorizontal);
                        ChangeCursorPosition(6, -4);
                        break;

                    case SectionTypes.RightCorner:
                        switch (compas)
                        {
                            case 0:
                                ConsoleTrack(_rightCornerNorth);
                                ChangeCursorPosition(6, -4);
                                compas = 1;
                                break;
                            case 1:
                                ConsoleTrack(_rightCornerEast);
                                ChangeCursorPosition(0, 0);
                                compas= 2;
                                break;
                            case 2:
                                ConsoleTrack(_rightCornerSouth);
                                ChangeCursorPosition(-6, -4);
                                compas = 3;
                                break;
                            case 3:
                                ConsoleTrack(_rightCornerWest);
                                ChangeCursorPosition(0, -8);
                                compas = 0;
                                break;
                        }
                        break;
                    case SectionTypes.LeftCorner:
                        switch (compas)
                        {
                            case 0:
                                ConsoleTrack(_rightCornerEast);
                                ChangeCursorPosition(-6, -4);
                                compas = 3;
                                break;
                            case 1:
                                ConsoleTrack(_rightCornerSouth);
                                ChangeCursorPosition(0, -8);
                                compas = 0;
                                break;
                            case 2:
                                ConsoleTrack(_rightCornerWest);
                                ChangeCursorPosition(6, -4);
                                compas = 1;
                                break;
                            case 3:
                                ConsoleTrack(_rightCornerWest);
                                ChangeCursorPosition(0, 0);
                                compas = 2;
                                break;
                        }
                        break;
                    case SectionTypes.Straight:
                        switch (compas)
                        {
                            case 0:
                                ConsoleTrack(_straightVertical);
                                ChangeCursorPosition(0, -8);
                                break;
                            case 2: 
                                ConsoleTrack(_straightVertical);
                                ChangeCursorPosition(0, 0);
                                break;
                            case 1:
                                ConsoleTrack(_straightHorizontal);
                                ChangeCursorPosition(6 , -4);
                                break;
                            case 3:
                                ConsoleTrack(_straightHorizontal);
                                ChangeCursorPosition(-6, -4);
                                break;
                        }
                        break;
                }

            }
            
        }

        public static void ConsoleTrack(String[] section) {

            foreach (String part in section)
            {
                Console.SetCursorPosition(CursorLocation[0], CursorLocation[1]);
                Console.WriteLine(part);
                CursorLocation[1]++;
            }
        }

        public static void ChangeCursorPosition(int x, int y)
        {
            CursorLocation[0] += x;
            CursorLocation[1] += y;
        }

        public static string visualizeDrivers(string sectionString, IParticipant driverLeft, IParticipant driverRight)
        {
            
            


            return replacementString;
        }


        #region graphics
        private static string[] _finishHorizontal = { "------", "  # ", "  # ", "------" };
        private static string[] _straightHorizontal = { "------", "    ", "    ", "------" };
        private static string[] _straightVertical = { "|    |", "|    |", "|    |", "|    |" };
        private static string[] _rightCornerEast = { @"---\", @"    \", @"     |", @"\    |" };
        private static string[] _rightCornerSouth = { @"/    |", "     |", "    /", "---/"};
        private static string[] _rightCornerWest = { @"|    \", "|     ", @" \", @"  \---"};
        private static string[] _rightCornerNorth =  { "  /---", " /", "|", "|    /" };
        #endregion
    }
}
