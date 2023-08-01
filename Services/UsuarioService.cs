using GuieMe.Enums;
using GuieMe.Models;
using System.Linq;

namespace GuieMe.Services
{
    public class UsuarioService : IUsuarioService
    {
        public void AtualizarDataCertificacao(DateTime date)
        {
            Usuario usuario = GetUsuario();
            usuario.CertificadoData = date;
        }

        public void AtualizarUsuario(string nome, string sobrenome, Pronome pronome, Curso curso)
        {
            Usuario usuarioCache = GetUsuario();
            Usuario usuario = usuarioCache != null ? usuarioCache : new Usuario();

            usuario.Nome = nome;
            usuario.Sobrenome = sobrenome;
            usuario.Pronome = pronome;
            usuario.Curso = curso;
        }

        public Usuario GetUsuario() => new Usuario(); //TODO: Pegar do cache do usuario registrado
    }
}
