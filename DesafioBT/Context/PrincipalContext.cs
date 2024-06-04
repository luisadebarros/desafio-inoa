using DesafioBT.Model;
using DesafioBT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesafioBT.Context
{
    public class PrincipalContext : IPrincipalContext
    {
        public void ConsultarAlphaService(string symbol)
        {
            AlphaService service = new AlphaService();
            var result = service.AlphaServiceClient(symbol);

            AlphaServiceResponse response = new AlphaServiceResponse();
            AlphaServiceResponse mapResult = response.MapToResponse(result);
        }
    }
}
