using Dados;

namespace ModoADMIN;

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
            Console.WriteLine("4 - Criar conta");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                opcao = 0;
            }

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Você escolheu ver as contas criadas!");
                    Bancodedados banco = new Bancodedados();
                    banco.InfoConta();
                    break;

                case 2:
                    Console.WriteLine("Você escolheu ver as contas existentes!");
                    break;

                case 3:
                    Console.WriteLine("Saindo do programa...");
                    return;

                case 4:
                    Console.WriteLine("Você escolheu criar uma nova conta!");
                    Bancodedados conta = new Bancodedados();
                    conta.Armazenamentoinfo();
                    break;


                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        } while (true);
    }
}
