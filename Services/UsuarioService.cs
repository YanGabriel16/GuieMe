using GuieMe.Enums;
using GuieMe.Helpers;
using GuieMe.Interfaces;
using GuieMe.Models;
using System.Linq;
using System.Reflection.Metadata;

namespace GuieMe.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IDataStorageService _storageService;
        public UsuarioService(IDataStorageService storageService)
        {
            _storageService = storageService;
        }

        public async void AtualizarDataCertificacao(DateTime date)
        {
            Usuario usuario = await GetUsuario();
            usuario.CertificadoData = date;

            await _storageService.SetValueAsync(Constants.UsuarioKey, usuario);
        }

        public async void AtualizarUsuario(string nome, string sobrenome, Pronome pronome, Curso curso)
        {
            Usuario usuarioCache = await GetUsuario();
            Usuario usuario = usuarioCache != null ? usuarioCache : new Usuario();

            usuario.Nome = nome;
            usuario.Sobrenome = sobrenome;
            usuario.Pronome = pronome;
            usuario.Curso = curso;

            await _storageService.SetValueAsync(Constants.UsuarioKey, usuario);
        }

        public async Task<Usuario> GetUsuario()
            => (await _storageService.GetValueAsync(Constants.UsuarioKey)) as Usuario;

    }
}
