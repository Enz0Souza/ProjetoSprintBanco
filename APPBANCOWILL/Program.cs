using Dados;
public class Program
{

    public static void Main(string[] args)
    {
        double divida = 5000;
        double saldo = divida;
        bool quitado = false;

        Console.WriteLine("=========================================");
        Console.WriteLine("Atividade de C# - Versão 0.1 alpha");
        Console.WriteLine("=========================================");

        Console.WriteLine("Bem-vindo ao sistema bancário!");
        Console.WriteLine("Digite 1 para entrar na sua conta e 2 para entrar no admin");
        int entrar = int.Parse(Console.ReadLine());
        switch (entrar)
        {
            case 1: Console.WriteLine("Você escolheu acessar a conta de cliente!");


                int opcao;
                do
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1 - Acessar conta");
                    Console.WriteLine("3 - Criar conta");
                    Console.WriteLine("4 - Sair do programa");

                    if (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        opcao = 0;
                    }

                    switch (opcao)
                    {
                        case 1:
                            //Console.WriteLine("Você escolheu acessar a sua contas");
                            //Bancodedados banco = new Bancodedados();
                            //Console.WriteLine("Digite seu CPF para acessar a conta:");
                            //int Senha = Console.ReadLine();
                            //if (Senha != )
                            //    Console.WriteLine("Digite sua senha de 8 digitos para acessar a conta:");
                            break;

                        case 2:
                            Console.WriteLine("Você escolheu ver as contas existentes!");
                            break;

                        case 4:
                            Console.WriteLine("Saindo do programa...");
                            return;

                        case 3:
                            Console.WriteLine("Você escolheu criar uma nova conta!");
                            Bancodedados conta = new Bancodedados();
                            conta.Armazenamentoinfo();
                            break;


                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                } while (true);
        


                case 2: Console.WriteLine("Você escolheu acessar a conta de administrador!");
                Console.WriteLine("Digite a senha de acesso:");
                if (Console.ReadLine() != "123")
                {
                    Console.WriteLine("Senha incorreta!");

                }
                break;

        }
    }
            
        }


       