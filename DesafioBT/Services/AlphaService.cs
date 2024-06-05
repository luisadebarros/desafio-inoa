using System;
using System.Configuration;
using System.Net;

namespace DesafioBT.Services
{
    public class AlphaService
    {
        public dynamic AlphaServiceClient(string Symbol)
        {

            string URL = ConfigurationManager.AppSettings["urlBase"] + $"function=TIME_SERIES_INTRADAY&symbol={Symbol}&interval=1min&apikey=" + ConfigurationManager.AppSettings["AppKey"];
            Uri query = new Uri(URL);

            using (WebClient client = new WebClient())
            {
                try
                {
                    return client.DownloadString(query);
                } catch (Exception err){
                    throw new Exception(err.ToString());
                }
                    
            }
        }

    }
}
