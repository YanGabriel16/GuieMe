using GuieMe.Domain.Models;

namespace GuieMe.Domain.Interfaces
{
    public interface IObjetivoService
    {
        void ConcluirObjetivo(int idObjetivo);
        Task<bool> GerarCertificado();
        List<Objetivo> GetObjetivos(int? cursoId);
    }
}
