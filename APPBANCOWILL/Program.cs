public class Program
{

    public static void Main(string[] args)
    {
        int total = 50;
        Console.WriteLine("Carregando sistema bancário...\n");

        for (int i = 0; i <= total; i++)
        {
            double porcentagem = (double)i / total;
            int progresso = (int)(porcentagem * 30);

            Console.Write("\r[");
            Console.Write(new string('█', progresso));
            Console.Write(new string(' ', 30 - progresso));
            Console.Write($"] {porcentagem:P0}");

            Thread.Sleep(100);
        }

        Console.Clear();
        Console.WriteLine("=========================================");
        Console.WriteLine(@"
██████╗░░█████╗░███╗░░██╗░█████╗░░█████╗░░██╗░░░░░░░██╗██╗██╗░░░░░██╗░░░░░
██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗░██║░░██╗░░██║██║██║░░░░░██║░░░░░
██████╦╝███████║██╔██╗██║██║░░╚═╝██║░░██║░╚██╗████╗██╔╝██║██║░░░░░██║░░░░░
██╔══██╗██╔══██║██║╚████║██║░░██╗██║░░██║░░████╔═████║░██║██║░░░░░██║░░░░░
██████╦╝██║░░██║██║░╚███║╚█████╔╝╚█████╔╝░░╚██╔╝░╚██╔╝░██║███████╗███████╗
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝░╚════╝░░╚════╝░░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚══════╝
");
        Console.WriteLine("\n Versão:0.5 beta");
        Console.WriteLine("=========================================");

        Console.WriteLine("Bem-vindo ao sistema bancário!");
        Console.WriteLine("Digite 1 para entrar na sua conta e 2 para entrar no admin");

        int entrar;
        if (!int.TryParse(Console.ReadLine(), out entrar))
        {
            Console.WriteLine("Opção inválida!");
            return;
        }

        switch (entrar)
        {
            case 1:
                Console.WriteLine("Você escolheu acessar a conta de cliente!");
                Thread.Sleep(1000);


                int opcao;
                do
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1 - Acessar conta");
                    Console.WriteLine("3 - Criar conta");
                    Console.WriteLine("4 - Sair do programa");

                    if (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Opção inválida!");
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            Thread.Sleep(1000);
                            try
                            {
                                BancoService banco = new BancoService();

                                Console.Write("Digite seu CPF: ");
                                string cpf = Console.ReadLine();

                                Console.Write("Digite sua senha: ");
                                string senha = Console.ReadLine();

                                bool logado = banco.Login(cpf, senha);

                                if (logado)
                                {
                                    Console.WriteLine("Login realizado com sucesso!");
                                    Console.WriteLine("Bem-vindo ao sistema bancário!");
                                    Thread.Sleep(1000);


                                    int opcaoConta;
                                    do
                                    {
                                        Console.WriteLine("\n--- MENU DA CONTA ---");
                                        Console.WriteLine("1 - Depositar");
                                        Console.WriteLine("2 - Sacar");
                                        Console.WriteLine("3 - Ver saldo");
                                        Console.WriteLine("4 - Sair da conta");

                                        if (!int.TryParse(Console.ReadLine(), out opcaoConta))
                                        {
                                            Console.WriteLine("Opção inválida!");
                                            continue;
                                        }

                                        try
                                        {
                                            switch (opcaoConta)
                                            {
                                                case 1:
                                                    Console.Write("Digite o valor para depósito: ");
                                                    double valorDeposito = double.Parse(Console.ReadLine());
                                                    banco.Depositar(valorDeposito);
                                                    break;

                                                case 2:
                                                    Console.Write("Digite o valor para saque: ");
                                                    double valorSaque = double.Parse(Console.ReadLine());
                                                    banco.Sacar(valorSaque);
                                                    break;

                                                case 3:
                                                    Console.WriteLine($"Saldo atual: R$ {banco.VerSaldo()}");
                                                    break;

                                                case 4:
                                                    Console.WriteLine("Saindo da conta...");
                                                    break;

                                                default:
                                                    Console.WriteLine("Opção inválida!");
                                                    break;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Erro: {ex.Message}");
                                        }

                                    } while (opcaoConta != 4);
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }


                            break;


                        case 3:
                            Console.WriteLine("Você escolheu criar uma nova conta!");

                            try
                            {
                                BancoService banco = new BancoService();
                                banco.CriarConta();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Saindo do programa...");
                            return;

                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                } while (true);

            case 2:
                Console.WriteLine("Você escolheu acessar a conta de administrador!");
                Console.WriteLine("Digite a senha de acesso:");

                string senhaAdmin = Console.ReadLine();
                if (senhaAdmin != "123")
                {
                    Console.WriteLine("Senha incorreta!");
                    return;
                }

                Console.WriteLine("Acesso administrativo concedido.");

                
                break;

            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
}
