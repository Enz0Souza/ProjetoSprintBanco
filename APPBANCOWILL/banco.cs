public class BancoService
{

    private double saldo = 0;
    public void Depositar(double valor)
    {
        if (valor <= 0)
            throw new Exception("Valor inválido.");

        saldo += valor;
        Console.WriteLine($"Depósito realizado com sucesso! Saldo atual: R$ {saldo}");
    }

    public void Sacar(double valor)
    {
        if (valor <= 0)
            throw new Exception("Valor inválido.");

        if (valor > saldo)
            throw new Exception("Saldo insuficiente.");

        saldo -= valor;
        Console.WriteLine($"Saque realizado com sucesso! Saldo atual: R$ {saldo}");
    }

    public double VerSaldo()
    {
        return saldo;
    }

    public ContaBancaria CriarConta()
    {
        Console.Write("Nome completo: ");
        string? nome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("Nome do titular não informado.");

        Console.Write("CPF: ");
        string? cpf = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(cpf))
            throw new Exception("CPF não informado.");

        if (!Validador.CPFValido(cpf))
            throw new Exception("CPF inválido");

        Console.Write("Senha (8 dígitos): ");
        string? senha = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(senha))
            throw new Exception("Senha não informada.");

        if (!Validador.SenhaValida(senha))
            throw new Exception("Senha inválida");

        Console.WriteLine("Tipo de conta: 1-Corrente | 2-Poupança | 3-Empresarial");
        string? tipoInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(tipoInput))
            throw new Exception("Tipo de conta não informado.");

        int tipo = int.Parse(tipoInput);

        ContaBancaria conta = tipo switch
        {
            1 => new ContaCorrente(nome, cpf),
            2 => new ContaPoupanca(nome, cpf),
            3 => new ContaEmpresarial(nome, cpf),
            _ => throw new Exception("Tipo inválido")
        };

        File.WriteAllText(
            "conta.txt",
            $"{conta.NumeroConta};{conta.Titular};{conta.CPF};{senha}"
        );

        Console.WriteLine($"Conta criada com sucesso! Nº {conta.NumeroConta}");
        return conta;
    }

    public void InfoConta()
    {
        if (!File.Exists("conta.txt"))
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
            return;
        }

        Console.WriteLine("Dados da conta criada:");
        string dados = File.ReadAllText("conta.txt");
        Console.WriteLine(dados);
    }
    public bool Login(string cpf, string senha)
    {
        if (!File.Exists("conta.txt"))
            throw new Exception("Nenhuma conta cadastrada.");

        string dados = File.ReadAllText("conta.txt");
        string[] partes = dados.Split(';');

        return cpf == partes[2] && senha == partes[3];
    }


}
