using consoleProject;
using Controller;
using Model;

public class Program
{
    static void Main(string[] args)
    {
        Data.Initialize();
        Visualisatie.DrawTrack(Data.NextRace());


        for (; ; )
        {
            Thread.Sleep(100);
        }
    }
}