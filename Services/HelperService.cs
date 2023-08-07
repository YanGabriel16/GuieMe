using GuieMe.Interfaces;
using GuieMe.Models;

namespace GuieMe.Services
{
    internal class HelperService : IHelperService
    {
        public List<Curso> GetCursos()
        {
            var cursos = new List<Curso>();

            cursos.Add(new Curso(0, "Não informado"));
            cursos.Add(new Curso(1, "Administracao"));
            cursos.Add(new Curso(2, "Analise Desenvolvimento de Sistemas"));
            cursos.Add(new Curso(3, "Arquitetura e Urbanismo"));
            cursos.Add(new Curso(4, "Automacao Insutrial"));
            cursos.Add(new Curso(5, "Biomedicina"));
            cursos.Add(new Curso(6, "Ciencias Da Computacao"));
            cursos.Add(new Curso(7, "Ciencias Biologicas"));
            cursos.Add(new Curso(8, "Comunicacao Social"));
            cursos.Add(new Curso(9, "Design Grafico"));
            cursos.Add(new Curso(10, "Direito"));
            cursos.Add(new Curso(11, "Educacao Fisica"));
            cursos.Add(new Curso(12, "Enfermagem"));
            cursos.Add(new Curso(13, "Engenharia Civil"));
            cursos.Add(new Curso(14, "Engenharia Mecanica"));
            cursos.Add(new Curso(15, "Farmacia"));
            cursos.Add(new Curso(16, "Fisioterapia"));
            cursos.Add(new Curso(17, "Gestao Financeira"));
            cursos.Add(new Curso(18, "Gestao De Recursos Humanos"));
            cursos.Add(new Curso(19, "Logistica"));
            cursos.Add(new Curso(20, "Marketing"));
            cursos.Add(new Curso(21, "Nutricao"));
            cursos.Add(new Curso(22, "Odontologia"));
            cursos.Add(new Curso(23, "Pedagocia"));
            cursos.Add(new Curso(24, "Psicologia"));

            return cursos;
        }
    }
}
