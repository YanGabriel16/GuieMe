using GuieMe.Enums;
using GuieMe.Models;

namespace GuieMe.Services
{
    public interface IObjetivoService
    {
        void ConcluirObjetivo(int idObjetivo, Curso curso);
        bool GerarCertificado();
    }
}
