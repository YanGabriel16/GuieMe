using GuieMe.Models;

namespace GuieMe.Interfaces
{
    public interface IHelperService
    {
        List<Curso> GetCursos();
        Curso GetCursoUsuario(int id);
    }
}
