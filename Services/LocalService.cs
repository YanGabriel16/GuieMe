using GuieMe.Models;
using System.Linq;

namespace GuieMe.Services
{
    public class LocalService : ILocalService
    {
        public List<Local> Locais()
        {
            List<Local> locais = new List<Local>
            {
                new Local { Id = 1, Nome = "Secretaria Veteranos", LatitudeMin = -0.000003M, LongitudeMin = -0.000001M, LatitudeMax = -0.000008M, LongitudeMax = -0.000005M, LatitudeEntrada = -0.000005M, LongitudeEntrada = -0.000005M, LocalAcessivel = true},
                new Local { Id = 2, Nome = "Papelaria", LatitudeMin = -00.000009M, LongitudeMin = -00.000001M, LatitudeMax = -00.000017M, LongitudeMax = -00.000005M, LatitudeEntrada = -00.000012M, LongitudeEntrada = -00.000005M, LocalAcessivel = true},
                new Local { Id = 3, Nome = "Cafeteria Expresso", LatitudeMin = -00.000018M, LongitudeMin = -00.000001M, LatitudeMax = -00.000028M, LongitudeMax = -00.000004M, LatitudeEntrada = -00.000026M, LongitudeEntrada = -00.000004M, LocalAcessivel = true},
                new Local { Id = 4, Nome = "Secretaria Calouros", LatitudeMin = -00.000001M, LongitudeMin = -00.000009M, LatitudeMax = -00.000007M, LongitudeMax = -00.000013M, LatitudeEntrada = -00.000007M, LongitudeEntrada = -00.000010M, LocalAcessivel = true},
                new Local { Id = 5, Nome = "Coordenação", LatitudeMin = -00.000014M, LongitudeMin = -00.000008M, LatitudeMax = -00.000019M, LongitudeMax = -00.000013M, LatitudeEntrada = -00.000014M, LongitudeEntrada = -00.000010M, LocalAcessivel = true},
                new Local { Id = 6, Nome = "Cafeteria Mozi", LatitudeMin = -00.000020M, LongitudeMin = -00.000009M, LatitudeMax = -00.000027M, LongitudeMax = -00.000013M, LatitudeEntrada = -00.000027M, LongitudeEntrada = -00.000011M, LocalAcessivel = true},
                //new Local { Id = 7, Nome = "Predio Principal", LatitudeMin = -0.000001M, LongitudeMin = -00.000001M, LatitudeMax = -00.000050M, LongitudeMax = -00.000050M, LatitudeEntrada = -00.000050M, LongitudeEntrada = -00.000045M, LocalAcessivel = false},
            };
            return locais.OrderBy(o => o.Nome).ToList();
        }

        public List<Tuple<decimal, decimal>> Paredes()
        {
            List<Tuple<decimal, decimal>> paredes = new List<Tuple<decimal, decimal>>();
            return paredes;
        }
    }
}
