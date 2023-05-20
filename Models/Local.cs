namespace GuieMe.Models;

public class Local
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal LatitudeMin { get; set; }
    public decimal LatitudeMax { get; set; }
    public decimal LongitudeMin { get; set; }
    public decimal LongitudeMax { get; set; }
    public decimal LatitudeEntrada { get; set; }
    public decimal LongitudeEntrada { get; set; }
    public bool LocalAcessivel { get; set; }
}