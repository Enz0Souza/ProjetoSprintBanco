public class ContaEmpresarial : ContaBancaria
{
    public double LimiteEmprestimo { get; } = 5000;

    private double dividaEmprestimo;
    private DateTime dataUltimoPagamento;
    private const double JurosMensal = 0.05;

    public double DividaEmprestimo => dividaEmprestimo;
    public DateTime DataUltimoPagamento => dataUltimoPagamento;

    public ContaEmpresarial(string titular, string cpf, string senha)
        : base(titular, cpf, senha)
    {
        dividaEmprestimo = 0;
        dataUltimoPagamento = DateTime.Now;
    }

    internal void SolicitarEmprestimo(double valor)
    {
        if (valor <= 0)
            throw new Exception("Valor inválido.");

        if (dividaEmprestimo + valor > LimiteEmprestimo)
            throw new Exception("Limite excedido.");

        dividaEmprestimo += valor;
        Saldo += valor;
        dataUltimoPagamento = DateTime.Now;
    }

    internal void PagarEmprestimo(double valor)
    {
        AplicarJurosSeAtrasado();

        if (valor <= 0)
            throw new Exception("Valor inválido.");

        if (valor > Saldo)
            throw new Exception("Saldo insuficiente.");

        if (valor > dividaEmprestimo)
            valor = dividaEmprestimo;

        Saldo -= valor;
        dividaEmprestimo -= valor;
        dataUltimoPagamento = DateTime.Now;
    }

    private void AplicarJurosSeAtrasado()
    {
        int meses = ((DateTime.Now.Year - dataUltimoPagamento.Year) * 12)
                  + DateTime.Now.Month - dataUltimoPagamento.Month;

        for (int i = 0; i < meses; i++)
            dividaEmprestimo += dividaEmprestimo * JurosMensal;

        if (meses > 0)
            dataUltimoPagamento = DateTime.Now;
    }

    public string ExportarDados()
    {
        return $"{dividaEmprestimo};{dataUltimoPagamento:o}";
    }

    public void ImportarDados(double divida, DateTime data)
    {
        dividaEmprestimo = divida;
        dataUltimoPagamento = data;
    }
}