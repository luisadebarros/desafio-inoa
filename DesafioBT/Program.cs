using DesafioBT.Context;
using System;

namespace DesafioBT
{
    public class Program
    {
        private readonly IPrincipalContext _context;

        public Program(IPrincipalContext context)
        {
            _context = context;
        }

        public void Run(string[] args)
        {
            var test = Console.ReadLine();

            double pontoVenda = 0;
            double pontoCompra = 0;
            string ativo = "";

            if (test.ToString().Length == 0)
            {
                Console.WriteLine("Nenhum valor fornecido, por favor tente novamente.");
                return;
            }

            string[] valoresSplit = test.ToString().Split(' ');

            if (valoresSplit.Length != 3)
            {
                throw new Exception("Foram inseridos mais ou menos argumentos do que o necessário, por favor tente novamente.");
            }

            ativo = valoresSplit[0];
            pontoCompra = Convert.ToDouble(valoresSplit[1]);
            pontoVenda = Convert.ToDouble(valoresSplit[2]);

            _context.ConsultarAlphaService(ativo);
            
        }

        static void Main(string[] args)
        {
            var context = new PrincipalContext();

            var program = new Program(context);

            program.Run(args);
        }
    }
}
