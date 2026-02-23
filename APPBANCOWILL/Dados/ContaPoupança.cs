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
            throw new Exception("Saldo insuficiente");

        Saldo -= valor;
    }

    public void CalcularRendimento()
    {
        if ((DateTime.Now - ultimoRendimento).TotalDays < 2)
            throw new Exception("Rendimento já aplicado para esta conta neste período.");

        double rendimento = Saldo * 0.05;
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
    }
}