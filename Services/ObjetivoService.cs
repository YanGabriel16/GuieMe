using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using GuieMe.Helpers;
using GuieMe.Interfaces;
using GuieMe.Models;

namespace GuieMe.Services
{
    public class ObjetivoService : IObjetivoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IDataStorageService _storageService;

        public ObjetivoService(IUsuarioService usuarioService, IDataStorageService storageService) 
        {
            _usuarioService = usuarioService;
            _storageService = storageService;
        }
        public async void ConcluirObjetivo(int idObjetivo, Curso curso)
        {
            CursoObjetivos CursoObjetivos = new CursoObjetivos(); //TODO: Pegar da listagem de objetivos
            Usuario usuario = await _usuarioService.GetUsuario();
            Objetivo objetivo = CursoObjetivos.Objetivos.Find(o => o.Id == idObjetivo && o.Curso.Id == curso.Id);
            if (objetivo != null)
            {
                usuario.ObjetivosConcluidos.Add(objetivo);
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
    }
}
