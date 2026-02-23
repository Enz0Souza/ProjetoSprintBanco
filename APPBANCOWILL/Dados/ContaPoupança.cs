public class ContaPoupanca : ContaBancaria
{
    private DateTime ultimoRendimento;

    public ContaPoupanca(string titular, string cpf, string senha)
        : base(titular, cpf, senha)
    {
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
            throw new Exception("Rendimento já aplicado neste período.");

        double rendimento = Saldo * 0.05;
        Saldo += rendimento;
        ultimoRendimento = DateTime.Now;
    }
}
