namespace GuieMe.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Curso { get; set; }
    public decimal LatitudeAtual { get; set; } = -0.000030M; //1; 
    public decimal LongitudeAtual { get; set; } = -0.000015M; //1; 
}