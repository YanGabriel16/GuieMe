﻿namespace GuieMe.Models;

public class Curso
{
    public Curso(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
}