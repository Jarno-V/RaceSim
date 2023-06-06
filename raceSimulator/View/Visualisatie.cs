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
                SectionData sectionData = Data.CurrentRace.GetSectionData(section);

                switch (section.SectionType) {
                    case SectionTypes.StartGrid:
                        ConsoleTrack(_finishHorizontal, sectionData);
                        ChangeCursorPosition(6, -4);
                        break;

                    case SectionTypes.RightCorner:
                        switch (compas)
                        {
                            case 0:
                                ConsoleTrack(_rightCornerNorth, sectionData);
                                ChangeCursorPosition(6, -4);
                                compas = 1;
                                break;
                            case 1:
                                ConsoleTrack(_rightCornerEast, sectionData);
                                ChangeCursorPosition(0, 0);
                                compas= 2;
                                break;
                            case 2:
                                ConsoleTrack(_rightCornerSouth, sectionData);
                                ChangeCursorPosition(-6, -4);
                                compas = 3;
                                break;
                            case 3:
                                ConsoleTrack(_rightCornerWest, sectionData);
                                ChangeCursorPosition(0, -8);
                                compas = 0;
                                break;
                        }
                        break;
                    case SectionTypes.LeftCorner:
                        switch (compas)
                        {
                            case 0:
                                ConsoleTrack(_leftCornerNorth, sectionData);
                                ChangeCursorPosition(-6, -4);
                                compas = 3;
                                break;
                            case 1:
                                ConsoleTrack(_leftCornerEast, sectionData);
                                ChangeCursorPosition(0, -8);
                                compas = 0;
                                break;
                            case 2:
                                ConsoleTrack(_leftCornerSouth, sectionData);
                                ChangeCursorPosition(6, -4);
                                compas = 1;
                                break;
                            case 3:
                                ConsoleTrack(_leftCornerWest, sectionData);
                                ChangeCursorPosition(0, 0);
                                compas = 2;
                                break;
                        }
                        break;
                    case SectionTypes.Straight:
                        switch (compas)
                        {
                            case 0:
                                ConsoleTrack(_straightVerticalNorth, sectionData);
                                ChangeCursorPosition(0, -8);
                                break;
                            case 2:
                                ConsoleTrack(_straightVerticalSouth, sectionData);
                                ChangeCursorPosition(0, 0);
                                break;
                            case 1:
                                ConsoleTrack(_straightHorizontalEast, sectionData);
                                ChangeCursorPosition(6 , -4);
                                break;
                            case 3:
                                ConsoleTrack(_straightHorizontalWest, sectionData);
                                ChangeCursorPosition(-6, -4);
                                break;
                        }
                        break;
                }

            }
            
        }

        public static string[] replaceString(string[] section, IParticipant participantL, IParticipant participantR)
        {
            string[] newString = new string[section.Length];

            for (int i = 0; i < section.Length; i++)
            {
                newString[i] = section[i].Replace("L", participantL.Name[..1]);
                newString[i] = newString[i].Replace("R", participantR.Name[..1]);
            }
            return newString;
        }

        public static string[] replaceString(string[] section, IParticipant participantL)
        {
            string[] newString = new string[section.Length];

            for (int i = 0; i < section.Length; i++)
            {
                newString[i] = section[i].Replace("L", participantL.Name[..1]);
                newString[i] = newString[i].Replace("R", " ");
            }
            return newString;
        }

        public static string[] replaceString(string[] section)
        {
            string[] newString = new string[section.Length];
            

            for(int i = 0; i < section.Length; i++)
            {
                newString[i] = section[i].Replace("L", " ");
                newString[i] = newString[i].Replace("R", " ");
            }
            return newString;
        }



        public static void ConsoleTrack(String[] section, SectionData sectionData) {

            string[] newString = new string[section.Length];

            if (sectionData.left != null && sectionData.right != null)
            {
                newString = replaceString(section, sectionData.left, sectionData.right);
            }
            else if (sectionData.left != null){
                newString = replaceString(section, sectionData.left);
            }
            else
            {
                newString = replaceString(section);
            }

            foreach (String part in newString)
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


        #region graphics
        private static string[] _finishHorizontal = { "------", "  L#", "  R#", "------" };

        private static string[] _straightHorizontalEast = { "------", "  L ", "  R ", "------" };
        private static string[] _straightHorizontalWest = { "------", "  R ", "  L ", "------" };

        private static string[] _straightVerticalSouth = { "|    |", "|    |", "|R  L|", "|    |" };
        private static string[] _straightVerticalNorth = { "|    |", "|    |", "|L  R|", "|    |" };


        private static string[] _rightCornerEast = { @"---\", @"   L\", @" R   |", @"\    |" };
        private static string[] _rightCornerSouth = { @"/    |", " R   |", "   L/", "---/"};
        private static string[] _rightCornerWest = { @"|    \", "|   R ", @" \L", @"  \---"};
        private static string[] _rightCornerNorth =  { "  /---", " /L", "|   R", "|    /" };

        private static string[] _leftCornerNorth = { @"---\", @"   R\", @" L   |", @"\    |" };
        private static string[] _leftCornerEast = { @"/    |", " L   |", "   R/", "---/" };
        private static string[] _leftCornerSouth = { @"|    \", "|   L ", @" \R", @"  \---" };
        private static string[] _leftCornerWest = { "  /---", " /R", "|   L", "|    /" };

        #endregion
    }
}
