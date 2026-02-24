public abstract class ContaBancaria
{
    public int NumeroConta { get; }
    public string Titular { get; }
    public string CPF { get; }
    public string Senha { get; }
    public double Saldo { get; protected set; }

    protected static int contador = 1000;
    protected ContaBancaria(string titular, string cpf, string senha)
    {
        NumeroConta = contador++;
        Titular = titular;
        CPF = cpf;
        Senha = senha;
    }

    public void DefinirSaldoInicial(double saldo)
    {
        Saldo = saldo;
    }

    public void Depositar(double valor)
    {
        if (valor <= 0)
            throw new Exception("Valor inválido.");

        Saldo += valor;
    }

    public virtual void Sacar(double valor)
    {
        if (valor > Saldo)
            throw new Exception("Saldo insuficiente");

        Saldo -= valor;
    }
}