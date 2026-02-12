public class BancoService
{
    private List<ContaBancaria> contas = new();
    private const string arquivo = "contas.txt";

    public BancoService()
    {
        if (!File.Exists(arquivo))
            File.Create(arquivo).Close();

        Carregar();
    }

    public void CriarConta()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine()!;

        if (contas.Any(c => c.CPF == cpf))
            throw new Exception("CPF já cadastrado");

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
        Salvar();

        Console.WriteLine("Conta criada com sucesso!");
        Console.ReadKey();
    }

    public ContaBancaria Login(string cpf, string senha)
    {
        ContaBancaria conta = contas
            .FirstOrDefault(c => c.CPF == cpf && c.Senha == senha)
            ?? throw new Exception("CPF ou senha incorretos");

        return conta;
    }

    public void Salvar()
    {
        File.WriteAllLines(arquivo,
            contas.Select(c =>
                $"{c.NumeroConta};{c.Titular};{c.CPF};{c.Senha};{c.Saldo};{c.GetType().Name}"
            ));
    }

    private void Carregar()
    {
        if (!File.Exists(arquivo))
            return;

        foreach (var linha in File.ReadAllLines(arquivo))
        {
            try
            {
                if (string.IsNullOrWhiteSpace(linha))
                    continue;

                var p = linha.Split(';');
                if (p.Length < 6)
                    continue;

                ContaBancaria conta = p[5] switch
                {
                    nameof(ContaCorrente) => new ContaCorrente(p[1], p[2], p[3]),
                    nameof(ContaPoupanca) => new ContaPoupanca(p[1], p[2], p[3]),
                    nameof(ContaEmpresarial) => new ContaEmpresarial(p[1], p[2], p[3]),
                    _ => throw new Exception("Tipo de conta inválido.")
                };

                if (double.TryParse(p[4], out double saldo))
                    conta.DefinirSaldoInicial(saldo);

                contas.Add(conta);
            }
            catch
            {
                continue;
            }
        }
    }
    public void ListarContas()
    {
        if (contas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
            return;
        }

        foreach (var conta in contas)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Conta: {conta.NumeroConta}");
            Console.WriteLine($"Titular: {conta.Titular}");
            Console.WriteLine($"CPF: {conta.CPF}");
            Console.WriteLine($"Saldo: {conta.Saldo:C}");
            Console.WriteLine($"Tipo: {conta.GetType().Name}");
        }
    }

}


