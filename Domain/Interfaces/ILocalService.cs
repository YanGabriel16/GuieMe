using GuieMe.Domain.Models;

namespace GuieMe.Domain.Interfaces
{
    public interface ILocalService
    {
        List<Local> Locais();
        List<Tuple<int, int>> Paredes();
        List<Tuple<int, int>> Escadas();
    }
}
