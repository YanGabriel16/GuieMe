using GuieMe.Domain.Models;

namespace GuieMe.Domain.Interfaces
{
    public interface IObjetivoService
    {
        void ConcluirObjetivo(int idObjetivo);
        Task<CertificadoDados> GetDadosCertificado();
        List<Objetivo> GetObjetivos(int? cursoId);
    }
}
