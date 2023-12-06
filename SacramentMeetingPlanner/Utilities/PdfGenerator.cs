using DinkToPdf;
using DinkToPdf.Contracts;

public class PdfGenerator
{
    private readonly IConverter _converter;

    public PdfGenerator(IConverter converter)
    {
        _converter = converter;
    }

    public byte[] GeneratePdf(string htmlContent)
    {
        var doc = new HtmlToPdfDocument()
        {
            Objects =
            {
                new ObjectSettings { HtmlContent = htmlContent }
            }
        };

        return _converter.Convert(doc);
    }
}