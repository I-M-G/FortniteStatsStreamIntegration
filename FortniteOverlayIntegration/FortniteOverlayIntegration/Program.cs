using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteOverlayIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData data = new GetData();
            data.UpdateData();

            // FOR TESTING. Leave console open to view data.
            Console.ReadLine();
        }
    }
}
