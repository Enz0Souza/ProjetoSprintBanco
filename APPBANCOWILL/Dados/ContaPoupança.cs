public class ContaPoupanca : ContaBancaria
{
    private DateTime ultimoRendimento;

    public ContaPoupanca(string titular, string cpf, string senha)
        : base(titular, cpf, senha)
    {
        string caminho = $"dados/conta_{NumeroConta}_rendimento.txt";

        if (File.Exists(caminho))
            ultimoRendimento = DateTime.Parse(File.ReadAllText(caminho));
        else
            ultimoRendimento = DateTime.MinValue;
    }

    public override void Sacar(double valor)
    {
        if (valor > Saldo)
            throw new Exception("\x1b[38;5;9mSaldo insuficiente\x1b[0m");

        Saldo -= valor;
    }

    public void CalcularRendimento()
    {
        if (Saldo < 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Saldo insuficiente para começar rendimento (saldo mínimo de 5 reais)");
            Console.ResetColor();
            return;

        }



        if ((DateTime.Now - ultimoRendimento).TotalMinutes < 1)
            throw new Exception("\x1b[38;5;9mRendimento já aplicado para esta conta neste período\u001b[0m.");

        double rendimento = Saldo * 0.05;//5%
        Saldo += rendimento;
        ultimoRendimento = DateTime.Now;

        Directory.CreateDirectory("dados");

        File.AppendAllText(
            "Rendimentos.txt",
            $"{DateTime.Now}: Conta {NumeroConta} recebeu R$ {rendimento:F2}\n"
        );

        File.WriteAllText(
            $"dados/conta_{NumeroConta}_rendimento.txt",
            ultimoRendimento.ToString("O")
        );
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(
               $"Rendimento aplicado! Novo saldo: {Saldo:C}"
           );
        Console.ResetColor();

    }
}