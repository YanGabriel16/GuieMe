using GuieMe.Domain.Models;

namespace GuieMe.Domain.Interfaces
{
    public interface IHelperService
    {
        List<Curso> GetCursos();
        Curso GetCursoUsuario(int id);
    }
}
