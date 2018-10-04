using System;
using System.Collections.Generic;
using System.Timers;

namespace FortniteOverlayIntegration
{
    // Could probably just do this in Program.. Leaving for now
    class Timer
    {
        private System.Timers.Timer timer;
        private readonly int frequency = 1000 * 10; //10 seconds, I would advise against updating faster

        private readonly string epicUserName;
        private readonly string platform;

        public Timer(string epicUserName, string platform)
        {
            this.epicUserName = epicUserName;
            this.platform = platform;
        }

        public void SetTimer()
        {
            // Fortnite Tracker allows 1 request per 2 seconds. 30 requests per minute.
            timer = new System.Timers.Timer(frequency);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        // With each tick, get new data
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Data data = new Data();

            List<Stat> getData = data.GetData(epicUserName, platform);
            data.WriteData(getData);
            
            // TODO: Probably can remove this or refactored to show when data was last updated.
            Console.WriteLine($"Event Fired: {e.SignalTime}");
        }

        // Shutdown timer when program closes
        public void StopAndDispose()
        {
            timer.Stop();
            timer.Dispose();

            Console.WriteLine("Exiting Program...");
        }
        
    }
}
