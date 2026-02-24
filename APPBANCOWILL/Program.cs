using ModoADMIN;
using System.Diagnostics;
public class Program
{
    static BancoService banco = new BancoService();//inicia o serviço 

    public static void Main()
    {
        int total = 50;//sistema de animação de carregamento
        Console.WriteLine("Carregando sistema bancário...\n");

        for (int i = 0; i <= total; i++)
        {
            double porcentagem = (double)i / total;
            int progresso = (int)(porcentagem * 30);

            Console.Write("\r[");
            Console.Write(new string('█', progresso));
            Console.Write(new string(' ', 30 - progresso));
            Console.Write($"] {porcentagem:P0}");
            Thread.Sleep(30);
        }
        while (true)
        {
            ExibirLogo();//exibe o logo do banco
            string nomeUsuario = Environment.UserName;
            Console.WriteLine($"\nBem-vindo ao sistema bancário {nomeUsuario}");//saudação que puxa o nome do pc
            Console.WriteLine("\nDigite 1 para entrar na sua conta e 2 para entrar no admin ou pressione 3 para sair do app");

            if (!int.TryParse(Console.ReadLine(), out int entrar))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida!");
                Console.ResetColor();
                Thread.Sleep(1500);
                continue;
            }

            switch (entrar)
            {
                case 1:
                    MenuCliente();//entra no menu do cliente
                    break;

                case 2:
                    Console.Clear();
                    ExibirLogo();
                    MenuAdmin();//entra no menu do admin



                    break;

                case 3:
                    Console.WriteLine(@"
░█████╗░██████╗░██████╗░██╗░██████╗░░█████╗░██████╗░░█████╗░  ██████╗░░█████╗░██████╗░
██╔══██╗██╔══██╗██╔══██╗██║██╔════╝░██╔══██╗██╔══██╗██╔══██╗  ██╔══██╗██╔══██╗██╔══██╗
██║░░██║██████╦╝██████╔╝██║██║░░██╗░███████║██║░░██║██║░░██║  ██████╔╝██║░░██║██████╔╝
██║░░██║██╔══██╗██╔══██╗██║██║░░╚██╗██╔══██║██║░░██║██║░░██║  ██╔═══╝░██║░░██║██╔══██╗
╚█████╔╝██████╦╝██║░░██║██║╚██████╔╝██║░░██║██████╔╝╚█████╔╝  ██║░░░░░╚█████╔╝██║░░██║
░╚════╝░╚═════╝░╚═╝░░╚═╝╚═╝░╚═════╝░╚═╝░░╚═╝╚═════╝░░╚════╝░  ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝

██╗░░░██╗░██████╗░█████╗░██████╗░  ░█████╗░  ░█████╗░██████╗░██████╗░
██║░░░██║██╔════╝██╔══██╗██╔══██╗  ██╔══██╗  ██╔══██╗██╔══██╗██╔══██╗
██║░░░██║╚█████╗░███████║██████╔╝  ██║░░██║  ███████║██████╔╝██████╔╝
██║░░░██║░╚═══██╗██╔══██║██╔══██╗  ██║░░██║  ██╔══██║██╔═══╝░██╔═══╝░
╚██████╔╝██████╔╝██║░░██║██║░░██║  ╚█████╔╝  ██║░░██║██║░░░░░██║░░░░░
░╚═════╝░╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝  ░╚════╝░  ╚═╝░░╚═╝╚═╝░░░░░╚═╝░░░░░");
                    Thread.Sleep(1500);
                    return;

                case 666://easter egg
                    string nomeVideo =
                        "Rick Astley - Never Gonna Give You Up (Official Video) (4K Remaster) - Rick Astley (1080p, h264, youtube).mp4";

                    string videoPath = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "_filedump",
                        "bancowillarquivosimportantes",
                        nomeVideo
                    );

                    try
                    {
                        if (File.Exists(videoPath))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Você encontrou o maior easter egg do mundo ╰(*°▽°*)╯");
                            Console.ResetColor();
                            System.Diagnostics.Process.Start(
                                new System.Diagnostics.ProcessStartInfo(videoPath)
                                {
                                    UseShellExecute = true
                                }
                            );
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Erro: Vídeo não encontrado.");
                            Console.ResetColor();
                            Console.WriteLine($"Procurado em: {videoPath}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Erro: {ex.Message}");
                        Console.ResetColor();
                    }

                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case 07072007://Meu Instagram
                    Process.Start(new ProcessStartInfo("https://www.instagram.com/enzoo_souzza/") { UseShellExecute = true });
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida!");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void MenuCliente()//Função do menu do cliente
    {
        int opcao;
        do
        {
            Console.Clear();
            ExibirLogo();
            Console.WriteLine("\n1 - Acessar conta");
            Console.WriteLine("2 - Criar conta");
            Console.WriteLine("3 - Sair do programa");

            if (!int.TryParse(Console.ReadLine(), out opcao))
                continue;

            switch (opcao)
            {
                case 1:
                    LoginConta();
                    break;

                case 2:
                    try
                    {
                        banco.CriarConta();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Erro: {ex.Message}");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                    }
                    break;

                case 3:
                    return;
            }

        } while (true);
    }

    static void LoginConta()//Função para logar na conta do cliente
    {
        try
        {
            Console.Clear();
            ExibirLogo();

            Console.Write("\nDigite seu CPF: ");
            string cpf = Console.ReadLine()!;
            if (cpf.Length != 11)
                throw new Exception("CPF inválido.");


            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine()!;
            if (senha.Length < 6 || senha.Length > 8)
                throw new Exception("Senha inválida.");

            ContaBancaria contaLogada = banco.Login(cpf, senha);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLogin realizado com sucesso!");
            Console.ResetColor();
            Thread.Sleep(1000);

            MenuConta(contaLogada);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nErro: {ex.Message}");
            Console.ResetColor();
            Thread.Sleep(1500);
        }
    }

    static void MenuConta(ContaBancaria conta)//Função do menu da conta do cliente
    {
        int opcaoConta;
        do
        {
            Console.Clear();
            ExibirLogo();
            Console.WriteLine("\n====== MENU DA CONTA ======");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Ver saldo");
            Console.WriteLine("4 - Pedir Emprestimo");
            Console.WriteLine("5 - Pagar Emprestimo");
            Console.WriteLine("6 - Rendimento");
            Console.WriteLine("7 - Ver Divida");
            Console.WriteLine("8 - Tranferencia");
            Console.WriteLine("9 - Sair da conta");
            Console.WriteLine("============================");



            if (!int.TryParse(Console.ReadLine(), out opcaoConta))
                continue;

            try
            {
                switch (opcaoConta)
                {
                    case 1:
                        Console.Write("\nValor para depósito: ");
                        double dep = double.Parse(Console.ReadLine()!);
                        conta.Depositar(dep);
                        banco.Salvar();
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("\nValor para saque: ");
                        double saque = double.Parse(Console.ReadLine()!);
                        conta.Sacar(saque);
                        Console.WriteLine("\nSaque realizado com sucesso!");
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        banco.Salvar();
                        break;

                    case 3:
                        Console.WriteLine($"\nSaldo atual: R$ {conta.Saldo}");
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 4:
                        banco.SolicitarEmprestimo(conta);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();

                        break;

                    case 5:
                        banco.PagarEmprestimo(conta);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;



                    case 6:
                        banco.AplicarRendimento(conta);
                        Thread.Sleep(1500);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();


                        break;

                    case 7:
                        banco.VerDivida(conta);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 8:
                        banco.Pagamento(conta);
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        break;


                    case 9:
                        return;

                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErro: {ex.Message}");
                Console.ResetColor();
                Thread.Sleep(1500);
            }

        } while (true);
    }

    static void MenuAdmin()//Função do menu do admin
    {
        Console.Clear();
        ExibirLogo();
        Console.Write("Digite a senha do admin: ");
        string senha = Console.ReadLine()!;

        if (senha != "123")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Senha incorreta!");
            Console.ResetColor();
            Thread.Sleep(1500);
            return;
        }

        BancoService banco = new BancoService();
        AdminAcess admin = new AdminAcess(banco);
        admin.Admin();

    }

    static void ExibirLogo()//Função para exibir o logo do banco
    {
        Console.Clear();
        Console.WriteLine("===========================================================================");
        Console.WriteLine(@"
██████╗░░█████╗░███╗░░██╗░█████╗░░█████╗░░██╗░░░░░░░██╗██╗██╗░░░░░██╗░░░░░
██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗░██║░░██╗░░██║██║██║░░░░░██║░░░░░
██████╦╝███████║██╔██╗██║██║░░╚═╝██║░░██║░╚██╗████╗██╔╝██║██║░░░░░██║░░░░░
██╔══██╗██╔══██║██║╚████║██║░░██╗██║░░██║░░████╔═████║░██║██║░░░░░██║░░░░░
██████╦╝██║░░██║██║░╚███║╚█████╔╝╚█████╔╝░░╚██╔╝░╚██╔╝░██║███████╗███████╗
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝░╚════╝░░╚════╝░░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚══════╝
");
        Console.WriteLine("Versão: 1.0 beta");
        Console.WriteLine("Desenvolvido por: Enzo Souza/Eleven");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Esse banco nunca vai falir ^o^");
        Console.ResetColor();
        Console.WriteLine("===========================================================================");
    }
}
