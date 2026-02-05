namespace Dados
{
    internal class Bancodedados
    {
        public void Armazenamentoinfo()
        {
            Console.WriteLine("Criar conta");
            Console.Write("Nome: ");
            string nomeConta = Console.ReadLine();

            Console.Write("Sobrenome: ");
            string sobrenome = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();


            Console.WriteLine("Estado civil: 1-Solteiro | 2-Casado | 3-Divorciado | 4-Viúvo");
            int estadoCivil = int.Parse(Console.ReadLine());
            if (estadoCivil < 1 || estadoCivil > 4)
            {
                Console.WriteLine("Opção inválida para estado civil, selecione novamente.");


            }
            Console.WriteLine("Tipo de conta: 1-Corrente | 2-Poupança | 3-Salário");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a sua senha de 8 digitos");
            int senha = int.Parse(Console.ReadLine());
            File.WriteAllText(
                "conta.txt",
                $"Nome: {nomeConta} {sobrenome}\nCPF: {cpf}\nTelefone: {telefone}\nEstado Civil: {estadoCivil}\nTipo de Conta: {tipoConta}\nSenha:{senha}  " 

            );
            Console.WriteLine("Dados salvos");
            if (File.Exists("conta.txt"))
            {
                string dadosConta = File.ReadAllText("conta.txt");
                Console.WriteLine("Dados da conta criada:");
                Console.WriteLine(dadosConta);
            }

        }
            public void InfoConta() {
                if (File.Exists("conta.txt"))
                {
                    string dadosConta = File.ReadAllText("conta.txt");
                    Console.WriteLine("Dados da conta criada:");
                    Console.WriteLine(dadosConta);
            }
        }
}


}
