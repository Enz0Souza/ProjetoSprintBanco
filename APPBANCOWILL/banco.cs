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

        if (string.IsNullOrWhiteSpace(cpf))
            throw new Exception("CPF não pode ser vazio");

        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            throw new Exception("CPF deve conter 11 dígitos numéricos");

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
        Thread.Sleep(500);
        Console.Clear();
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
            {
                if (c is ContaEmpresarial ce)
                {
                    return $"{c.NumeroConta};{c.Titular};{c.CPF};{c.Senha};{c.Saldo};{c.GetType().Name};{ce.ExportarDados()}";
                }

                return $"{c.NumeroConta};{c.Titular};{c.CPF};{c.Senha};{c.Saldo};{c.GetType().Name}";
            })
        );
    }

    private void Carregar()
    {
        foreach (var linha in File.ReadAllLines(arquivo))
        {
            if (string.IsNullOrWhiteSpace(linha))
                continue;

            var p = linha.Split(';');

            ContaBancaria conta = p[5] switch
            {
                nameof(ContaCorrente) => new ContaCorrente(p[1], p[2], p[3]),
                nameof(ContaPoupanca) => new ContaPoupanca(p[1], p[2], p[3]),
                nameof(ContaEmpresarial) => new ContaEmpresarial(p[1], p[2], p[3]),
                _ => throw new Exception("Tipo inválido")
            };

            conta.DefinirSaldoInicial(double.Parse(p[4]));

            if (conta is ContaEmpresarial ce && p.Length >= 8)
            {
                double divida = double.Parse(p[6]);
                DateTime data = DateTime.Parse(p[7]);
                ce.ImportarDados(divida, data);
            }

            contas.Add(conta);
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
            Console.WriteLine("--------------------------------");

        }


    }

    public void SolicitarEmprestimo(ContaBancaria contaLogada)
    {
        if (contaLogada is not ContaEmpresarial contaEmpresarial)
        {
            Console.WriteLine("Apenas contas empresariais podem solicitar empréstimo.");
            Thread.Sleep(1000);

            return;
        }
        Console.WriteLine("Bem - Vindo a área de emprestimo");

        Console.Write("Valor do empréstimo: ");
        double valor = double.Parse(Console.ReadLine()!);

        Console.WriteLine("Processando solicitação...");
        contaEmpresarial.SolicitarEmprestimo(valor);

        Salvar();

        Console.WriteLine("Empréstimo solicitado com sucesso!");
        Console.WriteLine($"Saldo atual: {contaEmpresarial.Saldo:C}");
    }

    public void PagarEmprestimo(ContaBancaria contaLogada)
    {
        if (contaLogada is not ContaEmpresarial contaEmpresarial)
        {
            Console.WriteLine("Apenas contas empresariais podem pagar empréstimo.");
            Thread.Sleep(1000);
            return;
        }
        Console.WriteLine("Bem - Vindo a área de pagamento de emprestimo");
        Console.Write("Valor do pagamento: ");
        double valor = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Processando pagamento...");
        contaEmpresarial.PagarEmprestimo(valor);
        Salvar();
        Console.WriteLine("Pagamento realizado com sucesso!");
        Console.WriteLine($"Saldo atual: {contaEmpresarial.Saldo:C}");
    }

    public void AplicarRendimento(ContaBancaria contaLogada)
    {
        if (contaLogada is not ContaPoupanca contaPoupanca)
        {
            Console.WriteLine("Apenas contas poupança recebem rendimento.");
            Thread.Sleep(1000);
            return;
        }

        try
        {
            Console.WriteLine("Bem - Vindo a área de Rendimento");

            contaPoupanca.CalcularRendimento();
            Salvar();

            Console.WriteLine(
                $"Rendimento aplicado! Novo saldo: {contaPoupanca.Saldo:C}"
            );


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    internal void DeletarConta(int numeroConta)
    {
        var conta = contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
        if (conta != null)
        {
            contas.Remove(conta);
            Salvar();
        }
        else
        {
            throw new Exception("Conta não encontrada.");
        }
    }

    public void VerDivida(ContaBancaria contaLogada)
    {
        if (contaLogada is not ContaEmpresarial contaEmpresarial)
        {
            Console.WriteLine("Essa conta não possui empréstimo.");
            Thread.Sleep(1000);
            return;
        }

        Console.WriteLine("===== SITUAÇÃO DO EMPRÉSTIMO =====");

        if (contaEmpresarial.DividaEmprestimo <= 0)
        {
            Console.WriteLine("Você não possui dívida ");
            return;
        }

        Console.WriteLine($"Dívida atual: {contaEmpresarial.DividaEmprestimo:C}");
        Console.WriteLine($"Último pagamento: {contaEmpresarial.DataUltimoPagamento:dd/MM/yyyy}");
    }

    public void Pagamento(ContaBancaria conta)
    {
        Console.WriteLine("Escolha a forma de pagamanento 1 - tranferencia  2 - pix");
        if (!int.TryParse(Console.ReadLine(), out int entrar))
            switch (entrar)
            {
                case 1:
                    Console.WriteLine("sistema em implementação");
                    Thread.Sleep(1000);
                    break;

                case 2:
                    Console.WriteLine("sistema em implementação");
                    Thread.Sleep(1000);
                    break;

            }
    }

}