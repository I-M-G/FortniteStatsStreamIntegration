using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace FortniteOverlayIntegration
{
    class GetData
    {
        public void UpdateData()
        {
            // Update platform (pc, xbl, psn) and epic username
            var client = new RestClient("https://api.fortnitetracker.com/v1/profile/pc/ninja");
            var request = new RestRequest(Method.GET);
            //request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("TRN-Api-Key", Credentials.ApiKey);

            IRestResponse response = client.Execute(request);

            var responseData = response.Content;

            var data = JsonConvert.DeserializeObject<dynamic>(responseData);

            Console.WriteLine(data);
        }
    }
}
