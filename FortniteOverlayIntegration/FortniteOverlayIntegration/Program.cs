using System;
using System.Collections.Generic;

namespace FortniteOverlayIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            string epicUserName = "ninja"; // Add your epic username
            string platform = "pc"; // Update correct platform for the username

            // Gets the initial data
            Data data = new Data();
            data.ClearSessionWinsFile(); // Override the file to Zero if old value is still there.
            List<Stat> getData = data.GetData(epicUserName, platform);
            data.WriteData(getData);

            // Checks for new data
            Timer timer = new Timer(epicUserName, platform);
            timer.SetTimer();

            // Terminates the program on Enter
            Console.WriteLine("Press Enter to exit program.\n");
            Console.ReadLine();

            timer.StopAndDispose();
            
        }
    }
}
