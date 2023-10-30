using GuieMe.Domain.Helpers;
using GuieMe.Domain.Interfaces;
using GuieMe.Domain.Models;
using SkiaSharp;
using System.IO;
using System.Net;

namespace GuieMe.Infra.Services
{
    public class PdfService : IPdfService
    {
        public byte[] CriarPDF(CertificadoDados dados)
        {
            int largura = 800;
            int altura = 600;

            SKColor corBorda = SKColors.DarkBlue;
            SKColor corBorda2 = SKColors.Yellow;

            using (MemoryStream stream = new())
            {
                using (SKDocument documento = SKDocument.CreatePdf(stream))
                {
                    using (SKCanvas canvas = documento.BeginPage(largura, altura))
                    {
                        string urlImagem = "https://logospng.org/download/unip/logo-unip-vermelha-1024.png";

                        SKBitmap imagem;
                        DateTime dataCertificado = dados.Data;

                        using (var webClient = new WebClient())
                        {
                            byte[] data = webClient.DownloadData(urlImagem);
                            using (var streamBitmap = new MemoryStream(data))
                            {
                                imagem = SKBitmap.Decode(streamBitmap);
                            }
                        }

                        SKPaint paintTitulo = new()
                        {
                            TextSize = 40f,
                            TextAlign = SKTextAlign.Center,
                            IsAntialias = true
                        };

                        SKPaint paintTexto = new()
                        {
                            TextSize = 15f,
                            TextAlign = SKTextAlign.Center,
                            IsAntialias = true
                        };

                        SKPaint paintNegrito = new()
                        {
                            TextSize = 14f,
                            TextAlign = SKTextAlign.Center,
                            IsAntialias = true,
                            FakeBoldText = true 
                        };

                        string dataFormatada = $"{dataCertificado.Day} de {dataCertificado.ToString("MMMM")} de {dataCertificado.Year}";
                        float x = largura / 2;
                        float y = altura / 4 - paintTexto.TextSize;

                        float larguraImagem = 200;
                        float alturaImagem = 140; 

                        if (imagem != null)
                        {
                            SKRect destino = new SKRect(20, 10, 10 + larguraImagem, 10 + alturaImagem);
                            canvas.DrawBitmap(imagem, destino);
                        }

                        string titulo = $"Certificado";
                        canvas.DrawText(titulo, x, y, paintTitulo);
                        y += paintTexto.TextSize * 6f; 

                        string[] linhas = {
                            $"Certifico que {dados.AlunoNome.ToUpper()}, RA: {dados.AlunoRA.ToUpper()}, concluiu com êxito os objetivos propostos no",
                            $"aplicativo GuieMe, com carga horária de 10 horas, realizada no dia {dataFormatada}, na Universidade",
                            $"Paulista Campus Sorocaba."
                        };

                        foreach (string linha in linhas)
                        {
                            canvas.DrawText(linha, x, y, paintTexto);
                            y += paintTexto.TextSize * 1.5f; 
                        }
                        y += paintTexto.TextSize * 7f;

                        string texto2 = $"Sorocaba, {dataFormatada}";
                        canvas.DrawText(texto2, x, y, paintTexto);
                        y += paintTexto.TextSize * 7f;

                        string[] linhas2 = {
                            $"Prof. Respons",
                            $"Coordenador do Curso de Ciencia da Computação",
                            $"UNIP - Sorocaba"
                        };

                        foreach (string linha in linhas2)
                        {
                            canvas.DrawText(linha, x, y, paintNegrito);
                            y += paintTexto.TextSize * 1f; 
                        }

                        SKPaint paintBorda = new()
                        {
                            Color = corBorda,
                            StrokeWidth = 10,
                            IsAntialias = true,
                            Style = SKPaintStyle.Stroke
                        };

                        SKRect rect = new(0, 0, largura, altura);
                        canvas.DrawRoundRect(rect, 20, 20, paintBorda);

                        SKPaint paintBorda2 = new()
                        {
                            Color = corBorda2,
                            StrokeWidth = 5,
                            IsAntialias = true,
                            Style = SKPaintStyle.Stroke
                        };

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