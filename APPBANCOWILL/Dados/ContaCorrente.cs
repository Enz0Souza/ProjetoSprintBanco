public class ContaCorrente : ContaBancaria
{
    private const double Taxa = 2.50;

    public ContaCorrente(string titular, string cpf, string senha)
        : base(titular, cpf, senha) { }

    public override void Sacar(double valor)
    {
        double total = valor + Taxa;
        if (total > Saldo)
        {
            throw new Exception("Saldo insuficiente");
        }

        Saldo -= total;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Valor do saque: {valor:C}, Taxa: {Taxa:C}, Total debitado: {total:C}");
        Console.ResetColor();


    }
}
