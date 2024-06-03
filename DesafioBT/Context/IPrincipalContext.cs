using DesafioBT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBT.Context
{
    public interface IPrincipalContext
    {
        dynamic ConsultarAlphaService(string ativo);
       
    }
}
