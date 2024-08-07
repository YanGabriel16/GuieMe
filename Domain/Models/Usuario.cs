﻿namespace GuieMe.Domain.Models;

public class Usuario
{
    public Usuario()
    {
        RA = string.Empty;
        Nome = string.Empty;
        Sobrenome = string.Empty;
        Curso = new Curso(0, "Não informado");
        LatitudeAtual = 0; //1
        LongitudeAtual = 0; //1
        ObjetivosConcluidos = new List<Objetivo>();
        TodosObjetivosForamConcluidos = false;
    }

    public string RA { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public Curso Curso { get; set; } 
    public int LatitudeAtual { get; set; }
    public int LongitudeAtual { get; set; }
  //  public EnPiso PisoAtual { get; set; } = EnPiso.NaoInformado;
    public int PisoAtual { get; set; }
    public List<Objetivo> ObjetivosConcluidos { get; set; }
    public bool? TodosObjetivosForamConcluidos { get; set; }
    public DateTime? CertificadoData { get; set; }
}