using GuieMe.Domain.Enums;

namespace GuieMe.Domain.Models;

public class Local
{
    public Local(){}

    public Local(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    //public string Descricao { get; set; }
    public int LatitudeMin { get; set; }
    public int LatitudeMax { get; set; }
    public int LongitudeMin { get; set; }
    public int LongitudeMax { get; set; }
    public int LatitudeEntrada { get; set; }
    public int LongitudeEntrada { get; set; }
    public bool LocalAcessivel { get; set; } = true;
    public bool Escada { get; set; } = false;
    public EnPiso Piso { get; set; } = EnPiso.NaoInformado;
    public EnPredio Predio { get; set; } = EnPredio.NaoInformado;
}