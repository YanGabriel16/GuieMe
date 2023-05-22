namespace GuieMe.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Curso { get; set; }
    public int LatitudeAtual { get; set; } = 0; //1; 
    public int LongitudeAtual { get; set; } = 0; //1; 
}