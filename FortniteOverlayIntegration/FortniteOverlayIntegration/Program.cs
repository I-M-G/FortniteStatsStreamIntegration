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

            Data data = new Data();
            // Moving in to the Timer class for now
            List<Stat> getData = data.GetData(epicUserName, platform);
            data.WriteData(getData);
            
            Timer timer = new Timer(epicUserName, platform);
            timer.SetTimer();

            Console.WriteLine("Press Enter to exit program.\n");
            Console.ReadLine();

            timer.StopAndDispose();

            // FOR TESTING. Leave console open to view data.
            //Console.ReadLine();
        }
    }
}
