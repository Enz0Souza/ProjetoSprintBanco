public class ContaCorrente : ContaBancaria
{
    private const double TAXA = 2.50;

    public ContaCorrente(string titular, string cpf, string senha)
        : base(titular, cpf, senha) { }

    public override void Sacar(double valor)
    {
        double total = valor + TAXA;
        Console.WriteLine($"Valor do saque: {valor:C}, Taxa: {TAXA:C}, Total debitado: {total:C}");

        if (total > Saldo)
            throw new Exception("Saldo insuficiente");

        Saldo -= total;
    }
}
