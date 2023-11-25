using GuieMe.Domain.Models;

namespace GuieMe.Domain.Interfaces
{
    public interface IUsuarioService
    {
        void AtualizarUsuario(Usuario usuario, bool zerarObjetivos = false);
        void AtualizarDataCertificacao();
        Task<Usuario> GetUsuario();
    }
}
