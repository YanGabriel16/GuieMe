using GuieMe.Domain.Helpers;
using GuieMe.Domain.Interfaces;
using GuieMe.Domain.Models;

namespace GuieMe.Infra.Services
{
    public class ObjetivoService : IObjetivoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IDataStorageService _storageService;
        private readonly ILocalService _localService;

        public ObjetivoService(IUsuarioService usuarioService, IDataStorageService storageService, ILocalService localService)
        {
            _usuarioService = usuarioService;
            _storageService = storageService;
            _localService = localService;
        }
        public async void ConcluirObjetivo(int localId)
        {
            Usuario usuario = await _usuarioService.GetUsuario();

            List<Objetivo> objetivos = GetObjetivos(usuario.Curso?.Id);

            Objetivo objetivo = objetivos.FirstOrDefault(x => x.LocalId == localId);

            if (objetivo == null) return;

            if (!usuario.ObjetivosConcluidos.Any(x => x.Id == objetivo.Id))
            {
                usuario.ObjetivosConcluidos.Add(objetivo);
                usuario.ObjetivosConcluidos = usuario.ObjetivosConcluidos.OrderBy(x => x.Id).ToList();
                await _storageService.SetValueAsync(Constants.UsuarioKey, usuario);
            }

            if (usuario.ObjetivosConcluidos.Count >= objetivos.Count)
            {
                usuario.TodosObjetivosForamConcluidos = true;
                _usuarioService.AtualizarUsuario(usuario);
            }
        }

        public async Task<CertificadoDados> GetDadosCertificado()
        {
            Usuario usuario = await _usuarioService.GetUsuario();
            int horas = usuario.ObjetivosConcluidos.Count;
            DateTime data = DateTime.Now;

            CertificadoDados certificadoDados = new()
            {
                Data = data,
                QuantidadeHoras = horas,
                AlunoNome = $"{usuario.Nome} {usuario.Sobrenome}",
                AlunoCurso = usuario.Curso.Nome,
                AlunoRA = usuario.RA,
            };

            if (usuario.CertificadoData == null)
                _usuarioService.AtualizarDataCertificacao();

            return certificadoDados;
        }

        public List<Objetivo> GetObjetivos(int? cursoId)
        {
            var objetivos = new List<Objetivo>()
            {
              //  new Objetivo(0, 0, null, "Inicie reconhecendo o predio principal"),
                new Objetivo(1, 1, null, "Uma boa vida academica vem da facilidade de resolver problemas, e a secretaria dos calouros pode resolver alguns (se você for um calouro(a))"),
                //new Objetivo(2, 1, null, "Uma boa vida academica vem da facilidade de resolver problemas, e a secretaria dos veteranos pode resolver alguns (se você for um veterano(a))"),
                //new Objetivo(3, 5, null, "Nem todos os problemas podemos resolver nas secretarias, as vezes você pode achar a solução aqui"),
                //new Objetivo(4, 2, null, "As vezes é necessário uma lembrancinha academica ou até materiais academicos..."),
            };

            var locais = _localService.Locais();

            objetivos = objetivos.Where(o => !o.CursoId.HasValue || o.CursoId.Value == cursoId).ToList();

            foreach(var objetivo in objetivos)
            {
                objetivo.Nome = locais.FirstOrDefault(x => x.Id == objetivo.LocalId).Nome;
            }

            return objetivos.Any() ? objetivos : new List<Objetivo>();
        }
    }
}
