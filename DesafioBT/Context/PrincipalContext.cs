using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBT.Context
{
    public class PrincipalContext : IPrincipalContext
    {
        public dynamic ConsultarAlphaService(string ativoIncoming)
        {
            var json = ConsultarAlphaService(ativoIncoming);
            return json;
        }
    }
}
