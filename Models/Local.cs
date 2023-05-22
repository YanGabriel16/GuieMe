namespace GuieMe.Models;

public class Local
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int LatitudeMin { get; set; }
    public int LatitudeMax { get; set; }
    public int LongitudeMin { get; set; }
    public int LongitudeMax { get; set; }
    public int LatitudeEntrada { get; set; }
    public int LongitudeEntrada { get; set; }
    public bool LocalAcessivel { get; set; }
}