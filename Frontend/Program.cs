using Frontend.Enums;
using Frontend.Models;
using Frontend.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Frontend
{
    class Program
    {
        public static bool Continuar { get; set; } = true;
        static void Main(string[] args)
        {
            Iniciar().GetAwaiter().GetResult();
        }

        public async static Task Iniciar()
        {
            var Continuar = true;
            while (Continuar)
            {
                Console.WriteLine("Digite 1 para bater o ponto de entrada, 2 para saida, 3 para listar ultimos 20 pontos e 4 para encerrar.");
                var escolha = Console.ReadLine();
                int escolhaInt;
                int.TryParse(escolha, out escolhaInt);
                try
                {
                    switch (escolhaInt)
                    {
                        default:
                        case 0:
                            Console.WriteLine("Nenhuma opção foi escolhida.");
                            break;
                        case 1:
                        case 2:
                            Console.WriteLine("Digite o nome do funcionario:");
                            var funcionario = Console.ReadLine();
                            var novoPonto = new Ponto
                            {
                                NomeFuncionario = funcionario,
                                Data = DateTime.Now,
                                Tipo = escolhaInt == 1 ? TipoPonto.Entrada : TipoPonto.Saida
                            };
                            await Api.CriarPonto(novoPonto);
                            Console.WriteLine("Ponto registrado com sucesso.");
                            break;
                        case 3:
                            Console.WriteLine("Mostrando ultimos 20 pontos:");
                            var pontos = await Api.CarregarPontos();
                            if (pontos.Count > 0)
                                foreach (var ponto in pontos)
                                {
                                    Console.WriteLine($"Funcionario : {ponto.NomeFuncionario} - Data : {ponto.Data.ToShortDateString()} - Hora : {ponto.Data.ToShortTimeString()} - Tipo : {(ponto.Tipo == TipoPonto.Entrada ? "Entrada" : "Saida")}");
                                }
                            else
                                Console.WriteLine("Nenhum ponto foi criado.");
                            break;
                        case 4:
                            Continuar = false;
                            break;
                    }
                }catch(Exception e)
                {
                    Console.WriteLine($"Erro! {e.Message}");
                }
            }
        }
    }
}
