
using System.Net;

namespace N_Club_Pakkelegs_Assistent
{
    class DataManager
    {
        private string url = "https://n-club.dk/klubben/pakkeleg/";


        // Get the current data from N-Club
        public string GetWebsiteData()
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}
