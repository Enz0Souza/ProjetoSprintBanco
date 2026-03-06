namespace ModoADMIN
{
    internal class AdminAcess
    {
        private readonly BancoService _banco;

        public AdminAcess(BancoService banco)
        {
            _banco = banco;
        }

        public void Admin()
        {
            int opcao;
            do
            {
                Console.Clear();
                logoadm();
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Ver contas");
                Console.WriteLine("2 - Deletar contas");
                Console.WriteLine("3 - Sair do modo admin");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {

                    case 1:
                        Console.Clear();
                        logoadm();
                        Console.WriteLine("Você escolheu ver as contas criadas!");
                        _banco.ListarContas();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        logoadm();
                        Console.WriteLine("Qual conta será deletada?");
                        _banco.ListarContas();

                        Console.WriteLine("Digite o número da conta a ser deletada:");
                        if (int.TryParse(Console.ReadLine(), out int numeroConta))
                        {
                            try
                            {
                                _banco.DeletarConta(numeroConta);
                                Thread.Sleep(2000);
                                Console.WriteLine("Conta deletada com sucesso!");
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Erro ao deletar conta: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número de conta inválido!");
                        }
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

        public void logoadm()
        {
            Console.WriteLine("Bem-vindo ao modo admin!");

        }
    }
}