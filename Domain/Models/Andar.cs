using GuieMe.Domain.Enums;

namespace GuieMe.Domain.Models;

public class Andar
{
    public Andar(){}

    public Andar(int id, string nome)
    {
        AndarId = id;
        Nome = nome;
    }

    public int AndarId { get; set; }
    public string Nome { get; set; }
    public int Pisoo { get; set; }
    public int IndexAndar { get; set; }

  //  public EnPredio Predio { get; set; } = EnPredio.NaoInformado;
}