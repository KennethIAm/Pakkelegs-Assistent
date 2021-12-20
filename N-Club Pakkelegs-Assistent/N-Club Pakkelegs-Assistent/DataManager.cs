
using System.Net;

namespace N_Club_Pakkelegs_Assistent
{
    class DataManager
    {


        // Get the current data from N-Club
        public string GetWebsiteData(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}
