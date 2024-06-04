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
        public String Open {  get; set; }
        public String High {  get; set; }
        public String Low { get; set; }
        public String Close { get; set; }
        public String Volume { get; set; }
        public String Date {  get; set; }

        public AlphaServiceResponse MapToResponse(dynamic ResponseAlphaService)
        {
            AlphaServiceResponse response =  new AlphaServiceResponse();

            var Response = ResponseAlphaService["Time Series (1min)"];

            response.Date = Response[0];
            response.Open = Response[0]["1. open"];
            response.High = Response[0]["2. high"];
            response.Low = Response[0]["3. low"];
            response.Close = Response[0]["4. close"];
            response.Volume = Response[0]["5. volume"];

            return response;

        }
    }
}
