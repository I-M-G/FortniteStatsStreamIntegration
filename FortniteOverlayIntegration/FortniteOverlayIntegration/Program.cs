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
            // TODO: Implement setInterval equivalent in C# for updated stats
            List<Stat> getData = data.GetData(epicUserName, platform);
            data.WriteData(getData);
            

            // FOR TESTING. Leave console open to view data.
            Console.ReadLine();
        }
    }
}
