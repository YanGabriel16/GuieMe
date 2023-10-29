using GuieMe.Domain.Helpers;
using GuieMe.Domain.Interfaces;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace GuieMe.Infra.Services
{
    public class PdfService
    {
        public void CriarPdfESalvar2()
        {
            //string diretorioApp = AppDomain.CurrentDomain.BaseDirectory;
            //string pastaPdf = Path.Combine(diretorioApp, "PDFs");
            //string nomeArquivo = "arquivo.pdf";
            //string caminhoPdf = Path.Combine(pastaPdf, nomeArquivo);

            //if (!Directory.Exists(pastaPdf))
            //{
            //    Directory.CreateDirectory(pastaPdf);
            //}

            //Constants.rotaPdf = caminhoPdf;

            //using (var documento = new PdfSharpCore.Pdf.PdfDocument())
            //{
            //    documento.Info.Title = "Meu Arquivo PDF";
            //    PdfSharpCore.Pdf.PdfPage pagina = documento.AddPage();
            //    XGraphics graficos = XGraphics.FromPdfPage(pagina);
            //    XFont fonte = new XFont("Verdana", 20, XFontStyle.Bold);

            //    graficos.DrawString("Olá, este é o meu PDF!", fonte, XBrushes.Black, new XRect(0, 0, pagina.Width, pagina.Height), XStringFormats.Center);
            //    documento.Save(caminhoPdf);

            string pastaPdf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "arquivo.pdf");

            using (var documento = new PdfSharpCore.Pdf.PdfDocument())
            {
                documento.Info.Title = "Meu Arquivo PDF";
                PdfSharpCore.Pdf.PdfPage pagina = documento.AddPage();
                XGraphics graficos = XGraphics.FromPdfPage(pagina);
                XFont fonte = new XFont("OpenSansRegular", 20, XFontStyle.Regular);

                graficos.DrawString("Olá, este é o meu PDF!", fonte, XBrushes.Black, new XRect(0, 0, pagina.Width, pagina.Height), XStringFormats.Center);
                documento.Save(pastaPdf);
            }
        }


        public byte[] CriarPdf()
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var documento = new PdfDocument())
                {
                    documento.Info.Title = "Meu Arquivo PDF";
                    PdfPage pagina = documento.AddPage();
                    XGraphics graficos = XGraphics.FromPdfPage(pagina);
                    XFont fonte = new XFont("OpenSansRegular", 20, XFontStyle.Regular);

                    graficos.DrawString("Olá, este é o meu PDF em byte!", fonte, XBrushes.Black, new XRect(0, 0, pagina.Width, pagina.Height), XStringFormats.Center);
                    documento.Save(memoryStream);
                }
                return memoryStream.ToArray();
            }
        }

        //public void OpenPdf()
        //{
        //    string fileName = "temp.pdf";
        //    var pdfByte = CriarPdf();
        //    try
        //    {
        //        DependencyService.Get<IPdfViewer>().OpenPdf(pdfByte, fileName);
        //    }
        //    catch(Exception ex)
        //    {
        //        Constants.rotaPdf = ex.Message;
        //    }
        //}

        public void AbrirPDF()
        {
            try
            {
                string fileName = "temp.pdf";
                var pdfByte = CriarPdf();
                string caminhoArquivo = Path.Combine(FileSystem.CacheDirectory, fileName);

                File.WriteAllBytes(caminhoArquivo, pdfByte);
                Launcher.OpenAsync(new OpenFileRequest
                {
                    File = new ReadOnlyFile(caminhoArquivo)
                });
            }
            catch (Exception ex) { Constants.erro = ex.Message; }
        }
    }
}