using GuieMe.Models;

namespace GuieMe.Interfaces
{
    public interface IUsuarioService
    {
        void AtualizarUsuario(Usuario usuario);
        void AtualizarDataCertificacao();
        Task<Usuario> GetUsuario();
    }
}
