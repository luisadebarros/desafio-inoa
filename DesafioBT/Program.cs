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

            double pontoVenda = 0;
            double pontoCompra = 0;
            string ativo = "";

            if (args == null)
            {
                Console.WriteLine("Nenhum valor fornecido, por favor tente novamente.");
                Environment.Exit(0);
            }

            if (args.Length != 3)
            {
                Console.WriteLine("Foram inseridos mais ou menos argumentos do que o necessário, por favor tente novamente.");
                Environment.Exit(0);
            }

            ativo = args[0];
            pontoVenda = Convert.ToDouble(args[1]);
            pontoCompra = Convert.ToDouble(args[2]);
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
