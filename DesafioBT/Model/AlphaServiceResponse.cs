using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBT.Model
{
     public class AlphaServiceResponse
     {
        public String Ativo { get; set; }
        public String Open {  get; set; }
        public String High {  get; set; }
        public String Low { get; set; }
        public String Close { get; set; }
        public String Volume { get; set; }
        public String Date {  get; set; }

        public AlphaServiceResponse MapToResponse(dynamic ResponseAlphaService, String ativo)
        {
            AlphaServiceResponse response =  new AlphaServiceResponse();

            var timeSeries = ResponseAlphaService["Time Series (1min)"];
            if(timeSeries == null)
            {
                Console.WriteLine("Não existem dados referentes a esse ativo, tente novamente!");
                Environment.Exit(0);

            } else
            {
                JObject responseService = JObject.Parse(timeSeries.ToString());
                var firstEntry = responseService.Properties().First();
                var data = firstEntry.Value;
                response.Date = firstEntry.Path.Replace("[", "").Replace("]", "");

                response.Ativo = ativo;
                response.Open = Convert.ToString(data["1. open"]).Replace(".", ",");
                response.High = Convert.ToString(data["2. high"]).Replace(".", ",");
                response.Low = Convert.ToString(data["3. low"]).Replace(".", ",");
                response.Close = Convert.ToString(data["4. close"]).Replace(".", ",");
                response.Volume = Convert.ToString(data["5. volume"]).Replace(".", ",");
            }
            
            return response;

        }
    }
}
