using GuieMe.Models;

namespace GuieMe.Interfaces
{
    public interface ILocalService
    {
        List<Local> Locais();
        List<Tuple<int, int>> Paredes();
    }
}
