using DesafioBT.Model;
using DesafioBT.Services;

namespace DesafioBT.Context
{
    public class PrincipalContext : IPrincipalContext
    {
        public bool ConsultarAtivo(string ativo, double valorMaior, double valorMenor)
        {
            AlphaServiceResponse response = ConsultarAlphaService(ativo);
            SMTPService smtpService = new SMTPService();
           
            if(double.Parse(response.High) >= valorMaior)
            {
                return smtpService.SendEmail(true);
            }

            if (double.Parse(response.Low) <= valorMenor)
            {
                return smtpService.SendEmail(false);
            }

            return false;
        }

        private AlphaServiceResponse ConsultarAlphaService(string symbol)
        {
            AlphaService service = new AlphaService();
            var result = service.AlphaServiceClient(symbol);

            AlphaServiceResponse response = new AlphaServiceResponse();
            return response.MapToResponse(result);

        }


    }
}
