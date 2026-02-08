public class ContaPoupanca : ContaBancaria
{
    public ContaPoupanca(string titular, string cpf)
        : base(titular, cpf) { }

    public override void Sacar(double valor)
    {
        if (valor > Saldo)
            throw new Exception("Saldo insuficiente");

        Saldo -= valor;
    }
}
