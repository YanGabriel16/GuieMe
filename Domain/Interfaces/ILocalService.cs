using GuieMe.Domain.Models;

namespace GuieMe.Domain.Interfaces
{
    public interface ILocalService
    {
        List<Andar> Andares();
        List<Local> Locais();
    }
}
