public abstract class ContaBancaria
{
    public int NumeroConta { get; private set; }
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
        if(valor >= 8000 )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Depósito acima ou igual a oito mil detectado. Tentativa de deposito negada.");
            Console.ResetColor();
            Console.WriteLine("Voltando ao menu principal...");
            Thread.Sleep(5000); 
            return;
        }
        if (valor <= 0)
            throw new Exception("Valor inválido.");

        Saldo += valor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Depósito de {valor:C} realizado com sucesso! Novo saldo: {Saldo:C}");
        Console.ResetColor();
    }

    public virtual void Sacar(double valor)
    {
        if (valor > Saldo)
            throw new Exception("Saldo insuficiente");

        Saldo -= valor;
    }

    internal void DefinirNumeroConta(int v)
    {
        NumeroConta = v;
    }
}