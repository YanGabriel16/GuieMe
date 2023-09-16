namespace GuieMe.Domain.Models
{
    public class Objetivo
    {
        public Objetivo(int id, int localId, int? cursoId, string descricao)
        {
            Id = id;
            LocalId = localId;
            CursoId = cursoId;
            Descricao = descricao;
        }

        public int Id { get; set; }
        public int LocalId { get; set; }
        public int? CursoId { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
    }
}

