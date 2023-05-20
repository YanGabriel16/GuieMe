using GuieMe.Models;

namespace GuieMe.Services
{
    public interface ILocalService
    {
        List<Local> Locais();
        List<Tuple<decimal, decimal>> Paredes();
    }
}
