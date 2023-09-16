using GuieMe.Domain.Interfaces;
using GuieMe.Domain.Models;

namespace GuieMe.Infra.Services
{
    internal class HelperService : IHelperService
    {
        public List<Curso> GetCursos()
        {
            var cursos = new List<Curso>
            {
                new Curso(0, "Não informado"),
                new Curso(1, "Administracao"),
                new Curso(2, "Analise Desenvolvimento de Sistemas"),
                new Curso(3, "Arquitetura e Urbanismo"),
                new Curso(4, "Automacao Insutrial"),
                new Curso(5, "Biomedicina"),
                new Curso(6, "Ciencias da Computação"),
                new Curso(7, "Ciencias Biologicas"),
                new Curso(8, "Comunicacao Social"),
                new Curso(9, "Design Grafico"),
                new Curso(10, "Direito"),
                new Curso(11, "Educacao Fisica"),
                new Curso(12, "Enfermagem"),
                new Curso(13, "Engenharia Civil"),
                new Curso(14, "Engenharia Mecanica"),
                new Curso(15, "Farmacia"),
                new Curso(16, "Fisioterapia"),
                new Curso(17, "Gestao Financeira"),
                new Curso(18, "Gestao De Recursos Humanos"),
                new Curso(19, "Logistica"),
                new Curso(20, "Marketing"),
                new Curso(21, "Nutricao"),
                new Curso(22, "Odontologia"),
                new Curso(23, "Pedagocia"),
                new Curso(24, "Psicologia")
            };

            return cursos;
        }

        public Curso GetCursoUsuario(int id)
            => GetCursos().FirstOrDefault(c => c.Id == id);
    }
}
