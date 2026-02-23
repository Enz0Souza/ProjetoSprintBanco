public class ContaEmpresarial : ContaBancaria
{
    public double LimiteEmprestimo { get; } = 5000;

    public ContaEmpresarial(string titular, string cpf, string senha)
        : base(titular, cpf, senha) { }

    public override void Sacar(double valor)
    {
        if (valor > Saldo + LimiteEmprestimo)
            throw new Exception("Limite excedido");

        Saldo -= valor;
    }

    internal void SolicitarEmprestimo(double valor)
    {
        if (valor <= 0)
            throw new Exception("Valor inválido.");

        if (valor > LimiteEmprestimo)
            throw new Exception("Valor do empréstimo excede o limite.");

        Saldo += valor;
    }

}
