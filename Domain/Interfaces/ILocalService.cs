using GuieMe.Domain.Models;

namespace GuieMe.Domain.Interfaces
{
    public interface ILocalService
    {
        List<Andar> Andares();
        List<Local> Locais();
        List<Tuple<int, int>> Paredes();
        List<Tuple<int, int>> Escadas();
    }
}
