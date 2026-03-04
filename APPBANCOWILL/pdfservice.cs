using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Layout.Properties;
using iText.IO.Image;
using iText.Layout.Borders;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
// Serviço para geração de extrato bancário em PDF usando iText7

public static class PdfService
{
    private static string ObterCaminho(string nomeArquivo)
    {
        string downloads = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),// Obtém a pasta do usuário que não esteja protegida para evitar erros de permissão
            "Downloads"
        );

        return Path.Combine(downloads, nomeArquivo);
    }

    private static void AdicionarLogo(Document document)// Adiciona o logo do banco ao PDF
    {
        string logoPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "_filedump",
            "bancowillarquivosimportantes",
            "Logobancowill.png"
        );

        if (File.Exists(logoPath))
        {
            var imageData = ImageDataFactory.Create(logoPath);
            var logo = new Image(imageData)
                .ScaleToFit(120, 120)
                .SetHorizontalAlignment(HorizontalAlignment.CENTER);

            document.Add(logo);
            document.Add(new Paragraph("\n"));
        }
    }

    public static void GerarExtratoCompleto(ContaBancaria conta, string? tipoOperacao, double valor)
    {
        string path = ObterCaminho($"Extrato_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

        using var writer = new PdfWriter(path);
        using var pdf = new PdfDocument(writer);
        using var document = new Document(pdf);

        var fonteNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        var fonteNegrito = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

        // LOGO
        AdicionarLogo(document);

        // TÍTULO
        var titulo = new Paragraph("EXTRATO BANCÁRIO")
            .SetFont(fonteNegrito)
            .SetFontSize(18)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontColor(ColorConstants.DARK_GRAY);

        document.Add(titulo);
        document.Add(new Paragraph("\n"));

        // DADOS CLIENTE
        document.Add(new Paragraph($"Titular: {conta.Titular}").SetFont(fonteNegrito));
        document.Add(new Paragraph($"Conta: {conta.NumeroConta}").SetFont(fonteNormal));
        document.Add(new Paragraph($"CPF: {conta.CPF}").SetFont(fonteNormal));
        document.Add(new Paragraph($"Data de emissão: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
            .SetFont(fonteNormal));

        document.Add(new Paragraph("\n"));

        // LINHA SEPARADORA
        var linha = new LineSeparator(new iText.Kernel.Pdf.Canvas.Draw.SolidLine());
        document.Add(linha);
        document.Add(new Paragraph("\n"));

        string tipo = string.IsNullOrWhiteSpace(tipoOperacao)
            ? ""
            : tipoOperacao;

        // SE NÃO HOUVER MOVIMENTAÇÃO
        if (string.IsNullOrWhiteSpace(tipo) || valor == 0)
        {
            document.Add(new Paragraph("Nenhuma movimentação registrada no período.")
                .SetFont(fonteNegrito)
                .SetFontSize(12)
                .SetFontColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.CENTER));

            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph($"Saldo atual: R$ {conta.Saldo:N2}")
                .SetFont(fonteNegrito)
                .SetFontSize(14)
                .SetTextAlignment(TextAlignment.CENTER));

        }
        else
        {

            Table tabela = new Table(4).UseAllAvailableWidth();

            var headerStyle = new Style()
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetFont(fonteNegrito);

            tabela.AddHeaderCell(new Cell().Add(new Paragraph("Data")).AddStyle(headerStyle));
            tabela.AddHeaderCell(new Cell().Add(new Paragraph("Tipo")).AddStyle(headerStyle));
            tabela.AddHeaderCell(new Cell().Add(new Paragraph("Valor")).AddStyle(headerStyle));
            tabela.AddHeaderCell(new Cell().Add(new Paragraph("Saldo Atual")).AddStyle(headerStyle));

            tabela.AddCell(DateTime.Now.ToString("dd/MM/yyyy"));
            tabela.AddCell(tipo);

            var valorCell = new Cell()
                .Add(new Paragraph($"R$ {valor:N2}").SetFont(fonteNegrito))
                .SetPadding(5);

            if (tipo == "Depósito")
                valorCell.SetFontColor(ColorConstants.GREEN);
            else if (tipo == "Saque")
                valorCell.SetFontColor(ColorConstants.RED);

            tabela.AddCell(valorCell);
            tabela.AddCell(new Paragraph($"R$ {conta.Saldo:N2}").SetFont(fonteNormal));

            document.Add(tabela);
        }

        document.Add(new Paragraph("\n"));

        // RODAPÉz
        document.Add(new Paragraph("Banco Will - Confiança e Segurança")//KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKkkkkkkkkkkk
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(10)
            .SetFontColor(ColorConstants.GRAY));

        Console.WriteLine($"Extrato criado com sucesso em: {path}");
    }
}