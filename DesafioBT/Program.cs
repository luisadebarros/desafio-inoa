using DesafioBT.Context;
using System;
using System.Threading.Tasks;

namespace DesafioBT
{
    public class Program
    {
        private readonly IPrincipalContext _context;

        public Program(IPrincipalContext context)
        {
            _context = context;
        }

        public async Task Run(string[] args)
        {
            var test = Console.ReadLine();

            double pontoVenda = 0;
            double pontoCompra = 0;
            string ativo = "";

            if (test.ToString().Length == 0)
            {
                Console.WriteLine("Nenhum valor fornecido, por favor tente novamente.");
                Environment.Exit(0);
            }

            string[] valoresSplit = test.ToString().Split(' ');

            if (valoresSplit.Length != 3)
            {
                Console.WriteLine("Foram inseridos mais ou menos argumentos do que o necessário, por favor tente novamente.");
                Environment.Exit(0);
            }

            ativo = valoresSplit[0];
            pontoCompra = Convert.ToDouble(valoresSplit[1]);
            pontoVenda = Convert.ToDouble(valoresSplit[2]);
            while (true)
            {
                var response =  _context.ConsultarAtivo(ativo, pontoCompra, pontoVenda);

                if (response)
                {
                    Console.WriteLine("Monitoramento com sucesso!");
                }
                else
                {
                    Console.WriteLine("Nenhum email enviado!");
                }

                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }

        static async Task Main(string[] args)
        {
            var context = new PrincipalContext();

            var program = new Program(context);

            await program.Run(args);
        }
    }
}
