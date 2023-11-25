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
                await _storageService.SetValueAsync(VariaveisGlobais.UsuarioKey, usuario);
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
                //new Objetivo(1, 28, null, "Uma boa vida acadêmica decorre da habilidade em resolver problemas, e a secretaria dos calouros pode auxiliar em alguns (se você for um calouro(a))."),
                //new Objetivo(2, 27, null, "Uma boa vida acadêmica resulta da habilidade em resolver problemas, e a secretaria dos veteranos pode ajudar com alguns (se você for um veterano(a))."),
                new Objetivo(3, 1, null, "Nem todos os problemas podemos resolver nas secretarias; às vezes, você pode encontrar a solução aqui."),
                new Objetivo(4, 6, null, "Às vezes é necessário uma lembrancinha acadêmica ou até materiais acadêmicos...."),
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
