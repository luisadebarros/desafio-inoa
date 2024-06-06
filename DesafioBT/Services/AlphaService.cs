using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Net;

namespace DesafioBT.Services
{
    public class AlphaService
    {
        public dynamic AlphaServiceClient(string Symbol)
        {
            string URL = generenteURI(Symbol);

            using (WebClient client = new WebClient())
            {
                try
                {
                    Uri query = new Uri(URL);
                    string response = client.DownloadString(query);
                    dynamic jsonData = JObject.Parse(response);
                    return jsonData;
                } catch (Exception err){
                    throw new Exception(err.ToString());
                }
                    
            }
        }

        private String generenteURI(string Symbol) {
            string url = ConfigurationManager.AppSettings["urlBase"] + $"function=TIME_SERIES_INTRADAY&symbol={Symbol}&interval=1min&apikey=" + ConfigurationManager.AppSettings["AppKey"];
            return url;
        }

    }
}
