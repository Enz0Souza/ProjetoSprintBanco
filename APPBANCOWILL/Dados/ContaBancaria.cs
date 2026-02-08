public abstract class ContaBancaria
{
    public int NumeroConta { get; protected set; }
    public string Titular { get; protected set; }
    public string CPF { get; protected set; }
    public double Saldo { get; protected set; }

    protected ContaBancaria(string titular, string cpf)
    {
        NumeroConta = new Random().Next(10000, 99999);
        Titular = titular;
        CPF = cpf;
        Saldo = 0;
    }

    public virtual void Depositar(double valor)
    {
        if (valor <= 0)
            throw new Exception("Valor inválido");

        Saldo += valor;
    }

    public abstract void Sacar(double valor);
}
