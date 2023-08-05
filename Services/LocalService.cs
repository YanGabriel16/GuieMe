using GuieMe.Interfaces;
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
                new Local { Id = 0, Nome = "Predio Principal Entrada", LatitudeMin = 0, LongitudeMin = 0, LatitudeMax = 0, LongitudeMax = 0, LatitudeEntrada = 0, LongitudeEntrada = 0, LocalAcessivel = true},
                new Local { Id = 1, Nome = "Secretaria Veteranos", LatitudeMin = 3, LongitudeMin = 1, LatitudeMax = 8, LongitudeMax = 5, LatitudeEntrada = 5, LongitudeEntrada = 5, LocalAcessivel = true},
                new Local { Id = 2, Nome = "Papelaria", LatitudeMin = 9, LongitudeMin = 1, LatitudeMax = 17, LongitudeMax = 5, LatitudeEntrada = 12, LongitudeEntrada = 5, LocalAcessivel = true},
                new Local { Id = 3, Nome = "Cafeteria Expresso", LatitudeMin = 18, LongitudeMin = 1, LatitudeMax = 28, LongitudeMax = 4, LatitudeEntrada = 26, LongitudeEntrada = 4, LocalAcessivel = true},
                new Local { Id = 4, Nome = "Secretaria Calouros", LatitudeMin = 1, LongitudeMin = 9, LatitudeMax = 7, LongitudeMax = 13, LatitudeEntrada = 7, LongitudeEntrada = 10, LocalAcessivel = true},
                new Local { Id = 5, Nome = "Coordenação", LatitudeMin = 14, LongitudeMin = 8, LatitudeMax = 19, LongitudeMax = 13, LatitudeEntrada = 14, LongitudeEntrada = 10, LocalAcessivel = true},
                new Local { Id = 6, Nome = "Cafeteria Mozi", LatitudeMin = 20, LongitudeMin = 9, LatitudeMax = 27, LongitudeMax = 13, LatitudeEntrada = 27, LongitudeEntrada = 11, LocalAcessivel = true},
                //new Local { Id = 7, Nome = "Predio Principal", LatitudeMin = 1, LongitudeMin = 1, LatitudeMax = 50, LongitudeMax = 50, LatitudeEntrada = 50, LongitudeEntrada = 45, LocalAcessivel = false},
            };
            return locais.OrderBy(o => o.Nome).ToList();
        }

        public List<Tuple<int, int>> Paredes()
        {
            List<Tuple<int, int>> paredes = new List<Tuple<int, int>>();
            return paredes;
        }
    }
}
