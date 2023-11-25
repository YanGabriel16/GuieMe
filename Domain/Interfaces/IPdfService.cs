using GuieMe.Domain.Models;

namespace GuieMe.Domain.Interfaces
{
    public interface IPdfService
    {
        byte[] CriarPDF(CertificadoDados dados);
        void GerarAbrirCertificadoPDF(CertificadoDados certificadoDados);
    }
}
