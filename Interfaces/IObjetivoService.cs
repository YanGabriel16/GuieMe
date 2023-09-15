using GuieMe.Models;

namespace GuieMe.Interfaces
{
    public interface IObjetivoService
    {
        void ConcluirObjetivo(int idObjetivo);
        Task<bool> GerarCertificado();
        List<Objetivo> GetObjetivos(int? cursoId);
    }
}
