public class ContaEmpresarial : ContaBancaria
{
    public double LimiteEmprestimo { get; } = 5000;

    public ContaEmpresarial(string titular, string cpf)
        : base(titular, cpf) { }

    public override void Sacar(double valor)
    {
        if (valor > Saldo + LimiteEmprestimo)
            throw new Exception("Limite excedido");

        Saldo -= valor;
    }
}
