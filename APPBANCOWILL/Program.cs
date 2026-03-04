using ModoADMIN;
using System.Diagnostics;
using System.Media;
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string('█', progresso));
            Console.ResetColor();
            Console.Write(new string(' ', 30 - progresso));
            Console.Write($"] {porcentagem:P0}");
            Thread.Sleep(30);
            TocarSom();//toca um sonzin legau
        }
        while (true)
        {
            Thread.Sleep(500);
            ExibirLogo();//exibe o logo do banco
            string nomeUsuario = Environment.UserName;//pega o nome do pc para usar na saudação
            Console.WriteLine($"\nBem-vindo ao sistema bancário \x1b[38;5;28m{nomeUsuario}\x1b[0m");//saudação que puxa o nome do pc
            Console.Write("\nDigite ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("1");
            Console.ResetColor();
            Console.Write(" para entrar na sua conta, ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("2");
            Console.ResetColor();
            Console.Write(" para entrar no admin ou pressione ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("3");
            Console.WriteLine(" para sair do app");
            Console.ResetColor();
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

                case 3://mensagem de despedida
                    Console.WriteLine(@"
 █████╗ ██████╗ ██████╗ ██╗ ██████╗  █████╗ ██████╗  █████╗   ██████╗  █████╗ ██████╗ 
██╔══██╗██╔══██╗██╔══██╗██║██╔════╝ ██╔══██╗██╔══██╗██╔══██╗  ██╔══██╗██╔══██╗██╔══██╗
██║  ██║██████╦╝██████╔╝██║██║  ██╗ ███████║██║  ██║██║  ██║  ██████╔╝██║  ██║██████╔╝
██║  ██║██╔══██╗██╔══██╗██║██║  ╚██╗██╔══██║██║  ██║██║  ██║  ██╔═══╝ ██║  ██║██╔══██╗
╚█████╔╝██████╦╝██║  ██║██║╚██████╔╝██║  ██║██████╔╝╚█████╔╝  ██║     ╚█████╔╝██║  ██║
 ╚════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝  ╚════╝   ╚═╝      ╚════╝ ╚═╝  ╚═╝

██╗   ██╗ ██████╗ █████╗ ██████╗    █████╗    █████╗ ██████╗ ██████╗ 
██║   ██║██╔════╝██╔══██╗██╔══██╗  ██╔══██╗  ██╔══██╗██╔══██╗██╔══██╗
██║   ██║╚█████╗ ███████║██████╔╝  ██║  ██║  ███████║██████╔╝██████╔╝
██║   ██║ ╚═══██╗██╔══██║██╔══██╗  ██║  ██║  ██╔══██║██╔═══╝ ██╔═══╝ 
╚██████╔╝██████╔╝██║  ██║██║  ██║  ╚█████╔╝  ██║  ██║██║     ██║     
 ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝   ╚════╝   ╚═╝  ╚═╝╚═╝     ╚═╝     ");
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
                    break;//NAO OLHA ISSO AQ

                case 07072007://Meu Instagram
                    Process.Start(new ProcessStartInfo("https://www.instagram.com/enzoo_souzza/") { UseShellExecute = true });
                    break;//nEM ISSO
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
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n1 - Acessar conta");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("2 - Criar conta");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3 - Sair do programa");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out opcao))
                continue;

            switch (opcao)
            {
                case 1:
                    try
                    {
                        LoginConta();//Parametro de logar conta
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Erro: {ex.Message}");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                    }
                    break;

                case 2:
                    try
                    {
                        banco.CriarConta();//Parametro de criar conta
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
                    try
                    {
                        Console.WriteLine("Saindo do programa...");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Erro: {ex.Message}");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                    }
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
                throw new Exception(" CPF inválido.");


            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine()!;
            if (senha.Length < 1 || senha.Length > 8)
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("9 - Sair da conta");
            Console.ResetColor();
            Console.WriteLine("============================");

            if (!int.TryParse(Console.ReadLine(), out opcaoConta))
                continue;

            try
            {
                switch (opcaoConta)
                {
                    case 1:
                        Console.Clear();
                        ExibirLogo();
                        Console.Write("\nValor para depósito: ");
                        double dep = double.Parse(Console.ReadLine()!);
                        conta.Depositar(dep);
                        banco.Salvar();
                        tocarsomdeposito();
                        Thread.Sleep(2500);
                        if (Confirmar("Deseja gerar o extrato?"))
                        {
                            try
                            {
                                PdfService.GerarExtratoCompleto(conta, "Depósito", dep);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Extrato gerado com sucesso!");
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Erro ao gerar PDF: {ex.Message}");
                            }
                            finally
                            {
                                Console.ResetColor();
                            }
                        }
                        Thread.Sleep(1000);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        ExibirLogo();
                        Console.Write("\nValor para saque: ");
                        double saque = double.Parse(Console.ReadLine()!);
                        TocarSomSaque();
                        Thread.Sleep(7000);
                        conta.Sacar(saque);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSaque realizado com sucesso!");
                        Console.ResetColor();
                        if (Confirmar("Deseja gerar o extrato?"))
                        {
                            try
                            {
                                PdfService.GerarExtratoCompleto(conta, "Saque", saque);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Extrato gerado com sucesso!");
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Erro ao gerar PDF: {ex.Message}");
                            }
                            finally
                            {
                                Console.ResetColor();
                            }
                        }
                        Thread.Sleep(1000);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        banco.Salvar();
                        break;

                    case 3:
                        Console.Clear();
                        ExibirLogo();
                        Console.WriteLine("\n========================================");
                        Console.WriteLine("EXTRATO");
                        Console.WriteLine($"\nNome:{conta.Titular}");
                        Console.WriteLine($"Número da conta: {conta.NumeroConta}");
                        Console.WriteLine($"CPF: {conta.CPF}");
                        Console.WriteLine($"\nSaldo atual: R$ {conta.Saldo:N2}");
                        Console.WriteLine("\n========================================");
                        if (Confirmar("Deseja gerar o extrato?"))
                        {
                            try
                            {
                                PdfService.GerarExtratoCompleto(conta, null, 0);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Extrato gerado com sucesso!");
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Erro ao gerar PDF: {ex.Message}");
                            }
                            finally
                            {
                                Console.ResetColor();
                            }
                        }
                        Thread.Sleep(1500);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        ExibirLogo();
                        banco.SolicitarEmprestimo(conta);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();

                        break;

                    case 5:
                        Console.Clear();
                        ExibirLogo();
                        banco.PagarEmprestimo(conta);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;



                    case 6:
                        Console.Clear();
                        ExibirLogo();
                        banco.AplicarRendimento(conta);
                        Thread.Sleep(1500);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();


                        break;

                    case 7:
                        Console.Clear();
                        ExibirLogo();
                        banco.VerDivida(conta);
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 8:
                        Console.Clear();
                        ExibirLogo();
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
██████╗  █████╗ ███╗  ██╗ █████╗  █████╗  ██╗       ██╗██╗██╗     ██╗
██╔══██╗██╔══██║████╗ ██║██╔══██╗██╔══██╗ ██║  ██╗  ██║██║██║     ██║
██████╦╝███████║██╔██╗██║██║  ╚═╝██║  ██║ ╚██╗████╗██╔╝██║██║     ██║
██╔══██╗██╔══██║██║╚████║██║  ██╗██║  ██║  ████╔═████║ ██║██║     ██║
██████╦╝██║  ██║██║ ╚███║╚█████╔╝╚█████╔╝  ╚██╔╝ ╚██╔╝ ██║███████╗███████╗
╚═════╝ ╚═╝  ╚═╝╚═╝  ╚══╝ ╚════╝  ╚════╝    ╚═╝   ╚═╝  ╚═╝╚══════╝╚══════╝
");
        Console.WriteLine("Versão: 2.0 beta");
        Console.WriteLine("Desenvolvido por: \x1b[38;5;171mEnzo Souza/Eleven\x1b[0m");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Esse banco nunca vai falir ^o^");
        Console.ResetColor();
        Console.WriteLine("===========================================================================");
    }
    static void TocarSom()
    {
        var caminho = Path.Combine(
   "_filedump",
   "bancowillarquivosimportantes",
   "audiowllbank.wav"//tocar audios :)
);

        TocarSom(caminho);
    }

    static void tocarsomdeposito()
    {
        var caminho = Path.Combine(
            "_filedump",
            "bancowillarquivosimportantes",
            "Cash-Register-Sound-Effect-_short-Free-Sound-Effects-On-voice-meme-effects-_youtube_.wav" //somdeposito :)
        );

        TocarSom(caminho);
    }

    static bool Confirmar(string mensagem)//Função para confirmar ações do cliente, como gerar extrato ou não
    {
        while (true)
        {
            Console.WriteLine(mensagem + " (s/n)");
            string? resposta = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(resposta))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite apenas S ou N.");
                Console.ResetColor();
                continue;
            }

            resposta = resposta.Trim().ToLower();

            if (resposta == "s")
                return true;

            if (resposta == "n")
                return false;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida! Digite apenas S ou N.");
            Console.ResetColor();
        }
    }
    static void TocarSomSaque()
    {
        var caminho = Path.Combine(
            "_filedump",
            "bancowillarquivosimportantes",
            "Money Counter - Sound Effect for Editing - Sound Library (youtube).wav" //som saque :)
        );
        TocarSom(caminho);

    }
    public static void TocarSom(string caminho)//Função para tocar sons, recebe o caminho do audio como parametro
    {
#pragma warning disable CA1416  // Validar a compatibilidade da plataforma mas como to no windows n funfa aparecer isso

        SoundPlayer player = new SoundPlayer(caminho);
        player.Play();
#pragma warning restore CA1416 // Validar a compatibilidade da plataforma mas como to no windows n funfa aparecer isso

    }
}