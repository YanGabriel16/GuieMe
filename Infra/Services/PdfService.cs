using GuieMe.Domain.Helpers;
using GuieMe.Domain.Interfaces;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.IO;
using SkiaSharp;

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

            string pastaPdf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "arquivo.pdf");

            using (var documento = new PdfSharpCore.Pdf.PdfDocument())
            {
                documento.Info.Title = "Meu Arquivo PDF";
                PdfSharpCore.Pdf.PdfPage pagina = documento.AddPage();
                XGraphics graficos = XGraphics.FromPdfPage(pagina);
                XFont fonte = new XFont("Verdana", 20, XFontStyle.Regular);

                graficos.DrawString("Olá, este é o meu PDF!", fonte, XBrushes.Black, new XRect(0, 0, pagina.Width, pagina.Height), XStringFormats.Center);
                documento.Save(pastaPdf);
            }
        }


        //public byte[] CriarPdf()
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var documento = new PdfDocument())
        //        {
        //            documento.Info.Title = "Meu Arquivo PDF";
        //            PdfPage pagina = documento.AddPage();
        //            XGraphics graficos = XGraphics.FromPdfPage(pagina);
        //            XFont fonte = new XFont("Verdana", 20, XFontStyle.Regular);

        //            graficos.DrawString("Olá, este é o meu PDF em byte!", fonte, XBrushes.Black, new XRect(0, 0, pagina.Width, pagina.Height), XStringFormats.Center);
        //            documento.Save(memoryStream);
        //        }
        //        return memoryStream.ToArray();
        //    }
        //}

        public byte[] CriarPDF()
        {
            // Cria um objeto MemoryStream para armazenar os dados do PDF em memória
            using (MemoryStream stream = new MemoryStream())
            {
                // Cria um objeto SKDocument para o PDF
                using (SKDocument documento = SKDocument.CreatePdf(stream))
                {
                    // Cria uma página no documento PDF
                    using (SKCanvas canvas = documento.BeginPage(500, 500))
                    {
                        // Cria um objeto SKPaint para o texto
                        SKPaint paint = new SKPaint
                        {
                            TextSize = 20,
                            IsAntialias = true,
                            Color = SKColors.Black,
                        };

                        // Desenha o texto na página PDF
                        canvas.DrawText("Texto no PDF usando SkiaSharp", 50, 100, paint);
                    }

                    // Finaliza a página
                    documento.EndPage();
                }

                // Obtém o array de bytes do MemoryStream
                byte[] pdfBytes = stream.ToArray();
                return pdfBytes;
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
                var pdfByte = CriarPDF();
                string caminhoArquivo = System.IO.Path.Combine(FileSystem.CacheDirectory, fileName);

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