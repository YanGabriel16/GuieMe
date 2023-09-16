using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
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

            if (objetivo != null)
            {
                usuario.ObjetivosConcluidos.Add(objetivo);
                usuario.ObjetivosConcluidos = usuario.ObjetivosConcluidos.OrderBy(x => x.Id).ToList();
                await _storageService.SetValueAsync(Constants.UsuarioKey, usuario);
            }
        }

        public async Task<bool> GerarCertificado()
        {
            Usuario usuario = await _usuarioService.GetUsuario();

            if (usuario.TodosObjetivosForamConcluidos.HasValue 
                && usuario.TodosObjetivosForamConcluidos.Value == false) return false;

            int horas = usuario.ObjetivosConcluidos.Count();
            string cursoNome = nameof(usuario.Curso);
            DateTime data = DateTime.Now;

            //TODO: Criar modelo de certificacao
            string htmlCertificado = $@"
Certificamos que o aluno {usuario.Nome} {usuario.Sobrenome}, do curso {cursoNome}, do RA {usuario.RA}
concluiu todos os objetivos de conhecimento do campus, no dia {data.Date}. 
com uma carga horaria de {horas}.
";
            HTMLDocument certificado = new HTMLDocument(htmlCertificado);
            
            string savePath = Path.Combine(@"\storage\emulated\0\Download\certificado-guieMe.pdf");

            Converter.ConvertHTML(certificado, new PdfSaveOptions(), savePath);

            _usuarioService.AtualizarDataCertificacao();

            return true;
        }

        public List<Objetivo> GetObjetivos(int? cursoId)
        {
            var objetivos = new List<Objetivo>()
            {
                new Objetivo(0, 0, null, "Inicie reconhecendo o predio principal"),
                new Objetivo(1, 1, null, "Uma boa vida academica vem da facilidade de resolver problemas, e a secretaria dos veteranos pode resolver alguns (se você for um veterano(a))"),
                new Objetivo(2, 4, null, "Uma boa vida academica vem da facilidade de resolver problemas, e a secretaria dos calouros pode resolver alguns (se você for um calouro(a))"),
                new Objetivo(3, 2, null, "As vezes é necessário uma lembrancinha academica ou até materiais academicos..."),
                new Objetivo(4, 5, null, "Nem todos os problemas podemos resolver nas secretarias, as vezes você pode achar a solução aqui"),
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
