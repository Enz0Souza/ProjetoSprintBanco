public class BancoService
{
    private List<ContaBancaria> contas = new();
    private const string arquivo = "contas.txt";

    public BancoService()
    {
        CarregarContas();
    }

    public void CriarConta()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine()!;

        if (contas.Any(c => c.CPF == cpf))
            throw new Exception("Já existe uma conta com esse CPF.");

        Console.Write("Senha: ");
        string senha = Console.ReadLine()!;

        Console.WriteLine("1-Corrente | 2-Poupança | 3-Empresarial");
        int tipo = int.Parse(Console.ReadLine()!);

        ContaBancaria conta = tipo switch
        {
            1 => new ContaCorrente(nome, cpf, senha),
            2 => new ContaPoupanca(nome, cpf, senha),
            3 => new ContaEmpresarial(nome, cpf, senha),
            _ => throw new Exception("Tipo inválido")
        };

        contas.Add(conta);
        SalvarContas();

        Console.WriteLine($"Conta criada com sucesso! Nº {conta.NumeroConta}");
    }

    public ContaBancaria Login(string cpf, string senha)
    {
        ContaBancaria? conta =
            contas.FirstOrDefault(c => c.CPF == cpf && c.Senha == senha);

        if (conta == null)
            throw new Exception("CPF ou senha inválidos.");

        return conta;
    }


    private void SalvarContas()
    {
        var linhas = contas.Select(c =>
            $"{c.NumeroConta};{c.Titular};{c.CPF};{c.Senha};{c.Saldo};{c.GetType().Name}"
        );

        File.WriteAllLines(arquivo, linhas);
    }

    private void CarregarContas()
    {
        if (!File.Exists(arquivo))
            return;

        foreach (var linha in File.ReadAllLines(arquivo))
        {
            var p = linha.Split(';');

            string nome = p[1];
            string cpf = p[2];
            string senha = p[3];
            double saldo = double.Parse(p[4]);
            string tipo = p[5];

            ContaBancaria conta = tipo switch
            {
                nameof(ContaCorrente) => new ContaCorrente(nome, cpf, senha),
                nameof(ContaPoupanca) => new ContaPoupanca(nome, cpf, senha),
                nameof(ContaEmpresarial) => new ContaEmpresarial(nome, cpf, senha),
                _ => throw new Exception("Tipo inválido")
            };

            conta.Depositar(saldo);
            contas.Add(conta);
        }
    }
}