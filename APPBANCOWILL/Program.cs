using ModoADMIN;
using System;
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

            Thread.Sleep(30);
        }

        void ExibirLogo()
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
            Console.WriteLine("Versão:0.7 beta");
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\nBem-vindo ao sistema bancário!");
        }
        ExibirLogo();

        Console.WriteLine("\nDigite 1 para entrar na sua conta e 2 para entrar no admin");

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
                    Console.Clear();
                    ExibirLogo();
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1 - Acessar conta");
                    Console.WriteLine("2 - Criar conta");
                    Console.WriteLine("3 - Sair do programa");

                    if (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Opção inválida!");
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            Thread.Sleep(1000);
                            Console.Clear();
                            ExibirLogo();
                            try
                            {
                                BancoService banco = new BancoService();

                                Console.Write($"\nDigite seu CPF: ");
                                string? cpf = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(cpf) || !Validador.CPFValido(cpf))
                                    throw new Exception("CPF inválido");

                                Console.Write("\nDigite sua senha: ");
                                string? senha = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(senha) || !Validador.SenhaValida(senha))
                                    throw new Exception("Senha inválida");

                                bool logado = banco.Login(cpf, senha);

                                if (logado)
                                {
                                    Console.WriteLine("Login realizado com sucesso!");
                                    Console.WriteLine("Bem-vindo ao sistema bancário!");
                                    Thread.Sleep(1000);


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
                                        {
                                            Console.WriteLine("Opção inválida!");
                                            continue;
                                        }

                                        try
                                        {
                                            switch (opcaoConta)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    ExibirLogo();
                                                    Console.Write("Digite o valor para depósito: ");
                                                    string? inputDeposito = Console.ReadLine();
                                                    if (string.IsNullOrWhiteSpace(inputDeposito) || !double.TryParse(inputDeposito, out double valorDeposito))
                                                        throw new Exception("Valor de depósito inválido.");
                                                    if (valorDeposito <= 0)
                                                        throw new Exception("Valor inválido.");
                                                    banco.Depositar(valorDeposito);
                                                    break;

                                                case 2:
                                                    Console.Clear();
                                                    ExibirLogo();
                                                    Console.Write("Digite o valor para saque: ");
                                                    string? inputSaque = Console.ReadLine();
                                                    if (string.IsNullOrWhiteSpace(inputSaque) || !double.TryParse(inputSaque, out double valorSaque))
                                                        throw new Exception("Valor de saque inválido.");
                                                    if (valorSaque <= 0)
                                                        throw new Exception("Valor inválido.");
                                                    banco.Sacar(valorSaque);
                                                    break;

                                                case 3:
                                                    Console.Clear();
                                                    ExibirLogo();
                                                    Console.WriteLine($"Saldo atual: R$ {banco.VerSaldo()}");
                                                    break;

                                                case 4:
                                                    Console.Clear();
                                                    ExibirLogo();
                                                    Console.WriteLine("Saindo da conta...");
                                                    break;

                                                default:
                                                    Console.Clear();
                                                    ExibirLogo();
                                                    Console.WriteLine("Opção inválida!");
                                                    break;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.Clear();
                                            ExibirLogo();
                                            Console.WriteLine($"Erro: {ex.Message}");
                                        }

                                    } while (opcaoConta != 4);
                                }

                            }
                            catch (Exception ex)

                            {
                                Console.Clear();
                                ExibirLogo();
                                Console.WriteLine($"Erro: {ex.Message}");
                            }


                            break;


                        case 2:
                            Console.Clear();
                            ExibirLogo();
                            Console.WriteLine("Você escolheu criar uma nova conta!");

                            try
                            {
                                BancoService banco = new BancoService();
                                banco.CriarConta();
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                ExibirLogo();
                                Console.WriteLine($"Erro: {ex.Message}");
                            }
                            break;

                        case 3:
                            Console.Clear();
                            ExibirLogo();
                            Console.WriteLine("Saindo do programa...");
                            return;

                        default:
                            Console.Clear();
                            ExibirLogo();
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                } while (true);

            case 2:
                Console.Clear();
                ExibirLogo();
                Console.WriteLine("Você escolheu acessar a conta de administrador!");
                Console.WriteLine("Digite a senha de acesso:");


                string? senhaAdmin = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(senhaAdmin))
                {
                    Console.WriteLine("Senha não pode ser vazia!");
                    return;
                }
                if (senhaAdmin != "123")
                {
                    Console.WriteLine("Senha incorreta!");
                    return;
                }
                Console.Clear();
                ExibirLogo();
                Console.WriteLine("Acesso administrativo concedido.");
                AdminAcess adminAcess = new AdminAcess();
                adminAcess.Admin();
                break;

            case 666:
                Console.Clear();
                ExibirLogo();
                string nomeVideo = "Rick Astley - Never Gonna Give You Up (Official Video) (4K Remaster) - Rick Astley (1080p, h264, youtube).mp4";

                string videoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "_filedump", "bancowillarquivosimportantes", nomeVideo);

                try
                {
                    if (File.Exists(videoPath))
                    {
                        Console.WriteLine("Você encontrou o maior easter egg do mundo╰(*°▽°*)╯");
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(videoPath) { UseShellExecute = true });
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
                break;

            default:
                Console.WriteLine("Opção inválida!");

                break;
        }
    }
}