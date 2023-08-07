using GuieMe.Helpers;
using GuieMe.Interfaces;
using GuieMe.Models;
using System.Text.Json;

namespace GuieMe.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IDataStorageService _storageService;
        public UsuarioService(IDataStorageService storageService)
        {
            _storageService = storageService;
        }

        public async void AtualizarDataCertificacao()
        {
            Usuario usuario = await GetUsuario();
            //usuario.CertificadoData = DateTime.Now;

            await _storageService.SetValueAsync(Constants.UsuarioKey, usuario);
        }

        public async void AtualizarUsuario(Usuario usuario)
            => await _storageService.SetValueAsync(Constants.UsuarioKey, usuario);

        public async Task<Usuario> GetUsuario()
        {
            var result = await SecureStorage.GetAsync(Constants.UsuarioKey);
            var usuario = JsonSerializer.Deserialize<Usuario>(result);
            if (usuario != null) return usuario; 
            else return new Usuario();
        }
    }
}
