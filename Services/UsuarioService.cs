using GuieMe.Helpers;
using GuieMe.Interfaces;
using GuieMe.Models;
using System.Text.Json;

namespace GuieMe.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IDataStorageService _storageService;
        private readonly IHelperService _helperService;
        public UsuarioService(IDataStorageService storageService, IHelperService helperService)
        {
            _storageService = storageService;
            _helperService = helperService;
        }

        public async void AtualizarDataCertificacao()
        {
            Usuario usuario = await GetUsuario();

            await _storageService.SetValueAsync(Constants.UsuarioKey, usuario);
        }

        public async void AtualizarUsuario(Usuario usuario)
            => await _storageService.SetValueAsync(Constants.UsuarioKey, usuario);

        public async Task<Usuario> GetUsuario()
        {
            var result = await SecureStorage.GetAsync(Constants.UsuarioKey);
            if (result == null) 
                return new Usuario();

            var usuario = JsonSerializer.Deserialize<Usuario>(result);
            if (usuario == null) 
                return new Usuario();

            usuario.Curso = _helperService.GetCursoUsuario(usuario.Curso.Id);
            
            return usuario;
        }
    }
}
