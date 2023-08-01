using GuieMe.Enums;

namespace GuieMe.Models;

public class Usuario
{
    public string RA { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public Pronome Pronome { get; set; } = Pronome.NaoInformado;
    public Curso Curso { get; set; } = Curso.NaoInformado;
    public int LatitudeAtual { get; set; } = 0; //1; 
    public int LongitudeAtual { get; set; } = 0; //1; 
    public List<Objetivo> ObjetivosConcluidos { get; set; }
    public bool TodosObjetivosForamConcluidos { get; set; } = false;
    public DateTime CertificadoData { get; set; }
}