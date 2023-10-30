using GuieMe.Domain.Helpers;
using GuieMe.Domain.Interfaces;
using GuieMe.Domain.Models;
using SkiaSharp;

namespace GuieMe.Infra.Services
{
    public class PdfService : IPdfService
    {
        public byte[] CriarPDF(CertificadoDados dados)
        {
            int largura = 800;
            int altura = 600;
            SKColor corFundo = SKColors.LightBlue;
            SKColor corTexto = SKColors.Black;
            SKColor corBorda = SKColors.DarkBlue;
            SKColor corBorda2 = SKColors.Yellow;

            using (MemoryStream stream = new MemoryStream())
            {
                using (SKDocument documento = SKDocument.CreatePdf(stream))
                {
                    using (SKCanvas canvas = documento.BeginPage(largura, altura))
                    {
                        canvas.Clear(corFundo);

                        SKPaint paintTexto = new SKPaint
                        {
                            Color = corTexto,
                            TextSize = 40.0f,
                            TextAlign = SKTextAlign.Center,
                            IsAntialias = true
                        };

                        string dataFormatada = dados.Data.ToString("dd/MM/yyyy HH:mm");
                        float x = largura / 2;
                        float y = altura / 2 - paintTexto.TextSize;
                        canvas.DrawText(dados.AlunoNome, x, y, paintTexto);
                        y += paintTexto.TextSize * 1.5f;
                        canvas.DrawText("RA: " + dados.AlunoRA, x, y, paintTexto);
                        y += paintTexto.TextSize * 1.5f;
                        canvas.DrawText("Horas: " + dados.QuantidadeHoras, x, y, paintTexto);
                        y += paintTexto.TextSize * 1.5f;
                        canvas.DrawText("Data: " + dataFormatada, x, y, paintTexto);
                        y += paintTexto.TextSize * 1.5f;
                        canvas.DrawText("Curso: " + dados.AlunoCurso, x, y, paintTexto);

                        // Configurações de borda
                        SKPaint paintBorda = new SKPaint
                        {
                            Color = corBorda,
                            StrokeWidth = 10,
                            IsAntialias = true,
                            Style = SKPaintStyle.Stroke
                        };

                        // Desenha a borda do certificado
                        SKRect rect = new SKRect(0, 0, largura, altura);
                        canvas.DrawRoundRect(rect, 20, 20, paintBorda);

                        // Configurações de segunda borda
                        SKPaint paintBorda2 = new SKPaint
                        {
                            Color = corBorda2,
                            StrokeWidth = 5,
                            IsAntialias = true,
                            Style = SKPaintStyle.Stroke
                        };

                        // Desenha uma segunda borda dentro da primeira
                        rect.Inflate(-10, -10);
                        canvas.DrawRoundRect(rect, 20, 20, paintBorda2);
                    }

                    documento.EndPage();
                }

                byte[] pdfBytes = stream.ToArray();
                return pdfBytes;
            }
        }

        public void GerarAbrirCertificadoPDF(CertificadoDados certificadoDados)
        {
            try
            {
                string fileName = "GuieMeCertificado.pdf";
                var pdfByte = CriarPDF(certificadoDados);
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