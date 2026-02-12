using ModoADMIN;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    static BancoService banco = new BancoService();

    public static void Main()
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
            Thread.Sleep(30);
        }
        while (true)
        {
            ExibirLogo();
            Console.WriteLine("\nBem-vindo ao sistema bancário!");
            Console.WriteLine("\nDigite 1 para entrar na sua conta e 2 para entrar no admin");

            if (!int.TryParse(Console.ReadLine(), out int entrar))
            {
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(1500);
                continue; // ← volta pro menu inicial
            }

            switch (entrar)
            {
                case 1:
                    MenuCliente();
                    break;

                case 2:
                    MenuAdmin();
                    break;

                case 666:
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
                            Console.WriteLine("Você encontrou o maior easter egg do mundo ╰(*°▽°*)╯");
                            System.Diagnostics.Process.Start(
                                new System.Diagnostics.ProcessStartInfo(videoPath)
                                {
                                    UseShellExecute = true
                                }
                            );
                        }
                        else
                        {
                            Console.WriteLine("Erro: Vídeo não encontrado.");
                            Console.WriteLine($"Procurado em: {videoPath}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }

                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

        static void MenuCliente()
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
                        Console.WriteLine($"Erro: {ex.Message}");
                        Thread.Sleep(1500);
                    }
                    break;

                case 3:
                    return;
            }

        } while (true);
    }

    static void LoginConta()
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

            Console.WriteLine("\nLogin realizado com sucesso!");
            Thread.Sleep(1000);

            MenuConta(contaLogada);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro: {ex.Message}");
            Thread.Sleep(1500);
        }
    }

    static void MenuConta(ContaBancaria conta)
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
            Console.WriteLine("4 - Sair da conta");

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
                        break;

                    case 2:
                        Console.Write("\nValor para saque: ");
                        double saque = double.Parse(Console.ReadLine()!);
                        conta.Sacar(saque);
                        banco.Salvar();
                        break;

                    case 3:
                        Console.WriteLine($"\nSaldo atual: R$ {conta.Saldo}");
                        Console.ReadKey();
                        break;

                    case 4:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
                Thread.Sleep(1500);
            }

        } while (true);
    }

    static void MenuAdmin()
    {
        Console.Clear();
        ExibirLogo();
        Console.Write("Digite a senha do admin: ");
        string senha = Console.ReadLine()!;

        if (senha != "123")
        {
            Console.WriteLine("Senha incorreta!");
            Thread.Sleep(1500);
            return;
        }

        AdminAcess admin = new AdminAcess();
        admin.Admin();
    }

    static void ExibirLogo()
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
        Console.WriteLine("Versão: 0.7 beta");
        Console.WriteLine("===========================================================================");
    }
}
