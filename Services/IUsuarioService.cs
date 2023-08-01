using GuieMe.Enums;
using GuieMe.Models;

namespace GuieMe.Services
{
    public interface IUsuarioService
    {
        void AtualizarUsuario(string nome, string sobrenome, Pronome pronome, Curso curso);
        void AtualizarDataCertificacao(DateTime date);
        Usuario GetUsuario();
    }
}
