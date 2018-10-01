using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RestSharp;

namespace FortniteOverlayIntegration
{
    class Data
    {

        public List<Stat> GetData(string epicUserName, string platform)
        {
            List<Stat> stats = new List<Stat>();

            var client = new RestClient($"https://api.fortnitetracker.com/v1/profile/{platform}/{epicUserName}");
            var request = new RestRequest(Method.GET);
            //request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("TRN-Api-Key", Credentials.ApiKey);

            IRestResponse response = client.Execute(request);

            var responseData = response.Content;

            var data = JsonConvert.DeserializeObject<dynamic>(responseData);
            //Console.WriteLine(data);

            // TODO - REMOVE AFTER TESTING
            // Writes all the JSON to a txt file
            //File.WriteAllText(@"D:\Code\Github\FortniteOverlayStats\FortniteOverlayIntegration\FortniteOverlayIntegration\StatFiles\AllData.txt", data.ToString());

            // p2 - Solo stats
            Stat totalSoloWins = new Stat("totalSoloWins", data.stats.p2.top1.value.ToString());
            Stat totalSoloKills = new Stat("totalSoloKills", data.stats.p2.kills.value.ToString());

            // p10 - Duo Stats
            Stat totalDuoWins = new Stat("totalDuoWins", data.stats.p10.top1.value.ToString());
            Stat totalDuoKills = new Stat("totalDuoKills", data.stats.p10.kills.value.ToString());

            // p9 - Squad Stats
            Stat totalSquadWins = new Stat("totalSquadWins", data.stats.p9.top1.value.ToString());
            Stat totalSquadKills = new Stat("totalSquadKills", data.stats.p9.kills.value.ToString());

            // Lifetime Stats
            Stat totalLifetimeWins = new Stat("totalLifetimeWins", data.lifeTimeStats[8].value.ToString());
            Stat totalLifetimeKills = new Stat("totalLifetimeKills", data.lifeTimeStats[10].value.ToString());
            

            // TODO - Probably a better way to do this
            stats.Add(totalLifetimeWins);
            stats.Add(totalLifetimeKills);
            stats.Add(totalSoloWins);
            stats.Add(totalSoloKills);
            stats.Add(totalDuoWins);
            stats.Add(totalDuoKills);
            stats.Add(totalSquadWins);
            stats.Add(totalSquadKills);

            // Calculates a win streak while program is running.
            CalculateStreak(System.Convert.ToInt32(data.lifeTimeStats[8].value));

            return stats;
        }

        public void WriteData(List<Stat> data)
        {

            for(int i = 0; i < data.Count; i++)
            {
                // Update file path to where you want the files to save.
                //File.WriteAllText($@"D:\Code\Github\FortniteOverlayStats\FortniteOverlayIntegration\FortniteOverlayIntegration\StatFiles\{data[i].type}.txt", data[i].value);
            }
        }
        
        private void CalculateStreak(int updatedWins)
        {
            int streak = 0;
            int startingWins = 0;
            // Do not overwrite startingWins, so that we can check the win streak while program is running.
            if(startingWins == 0)
            {
                startingWins = updatedWins;
            }

            streak = Math.Abs(updatedWins - startingWins);
            // Update file path to where you want the win streak file to be saved
            File.WriteAllText($@"D:\Code\Github\FortniteOverlayStats\FortniteOverlayIntegration\FortniteOverlayIntegration\StatFiles\WinStreak.txt", streak.ToString());
        }
    }
}
