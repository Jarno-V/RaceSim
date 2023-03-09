using Controller;

public class Program
{
    static void Main(string[] args)
    {
        Data.Initialize();
        Console.WriteLine(Data.NextRace().Name);

        for (; ; )
        {
            Thread.Sleep(100);
        }
    }
}