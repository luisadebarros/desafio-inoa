using DesafioBT.Model;
using DesafioBT.Services;

namespace DesafioBT.Context
{
    public class PrincipalContext : IPrincipalContext
    {
        public bool ConsultarAtivo(string ativo, double valorCompra, double valorVenda)
        {
            AlphaServiceResponse response = ConsultarAlphaService(ativo);
            SMTPService smtpService = new SMTPService();
            bool res = false;

            if (double.Parse(response.Close) <= valorCompra)
            {
                smtpService.SendEmail(false, response);
                res = true;

            }

            if (double.Parse(response.Close) >= valorVenda)
            {
                smtpService.SendEmail(true, response);
                res = true;
            }

            return res;
        }

        private AlphaServiceResponse ConsultarAlphaService(string symbol)
        {
            AlphaService service = new AlphaService();
            var result = service.AlphaServiceClient(symbol);

            AlphaServiceResponse response = new AlphaServiceResponse();
            return response.MapToResponse(result, symbol);

        }


    }
}
