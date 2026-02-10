using System.Diagnostics;

namespace ModoADMIN
{
    internal class AdminAcess
    {
        public void Admin()
        {
            int opcao;
            do
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Acessar contas");
                Console.WriteLine("2 - Ver contas");
                Console.WriteLine("3 - Sair do programa");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

               

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Você escolheu ver as contas criadas!");
                        try
                        {
                            BancoService banco = new BancoService();
                           //banco.InfoConta;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao acessar contas: {ex.Message}");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Você escolheu ver as contas existentes!");
                        Console.WriteLine("Funcionalidade futura para múltiplas contas.");
                        break;

                    case 3:
                        Console.WriteLine("Saindo do programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (true);
        }
    }
}
