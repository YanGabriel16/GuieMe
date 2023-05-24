using GuieMe.Models;

namespace GuieMe.Services
{
    public interface ILocalService
    {
        List<Local> Locais();
        List<Tuple<int, int>> Paredes();
        Task<Coordenadas> GetLocalizacaoAtual(CancellationToken cancellationToken);
    }
}
