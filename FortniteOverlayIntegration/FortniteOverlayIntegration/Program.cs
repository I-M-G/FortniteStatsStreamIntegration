using System;
using System.Collections.Generic;

namespace FortniteOverlayIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            List<Stat> getData = data.GetData();
            data.WriteData(getData);
            

            // FOR TESTING. Leave console open to view data.
            Console.ReadLine();
        }
    }
}
