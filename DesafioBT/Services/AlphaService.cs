using System;
using System.Net;
using System.Web.Script.Serialization;

namespace DesafioBT.Services
{
    public class AlphaService
    {
        private static dynamic AlphaServiceClient(string ativo)
        {
            string URL = $"www.alphavantage.co/query?function=SMA&symbol={ativo.ToUpper()}&interval=weekly&time_period=10&series_type=open&apikey=demo";
            Uri query = new Uri(URL);

            using(WebClient client = new WebClient())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic data = js.Deserialize(client.DownloadString(query), typeof(object));
                return data;   
            }

        }

    }
}
