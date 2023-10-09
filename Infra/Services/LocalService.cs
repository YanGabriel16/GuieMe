using GuieMe.Domain.Interfaces;
using GuieMe.Domain.Models;
using System.Linq;

namespace GuieMe.Infra.Services
{
    public class LocalService : ILocalService
    {
        public List<Local> Locais()
        {
            List<Local> locais = new()
            {
                new Local(0, "Predio Principal Entrada") { LatitudeMin = 00, LongitudeMin = 00, LatitudeMax = 00, LongitudeMax = 00, LatitudeEntrada = 00, LongitudeEntrada = 00},
                new Local(1, "Secretaria Veteranos")     { LatitudeMin = 03, LongitudeMin = 01, LatitudeMax = 08, LongitudeMax = 05, LatitudeEntrada = 05, LongitudeEntrada = 05},
                new Local(2, "Papelaria")                { LatitudeMin = 09, LongitudeMin = 01, LatitudeMax = 17, LongitudeMax = 05, LatitudeEntrada = 12, LongitudeEntrada = 05},
                new Local(3, "Cafeteria Expresso")       { LatitudeMin = 18, LongitudeMin = 01, LatitudeMax = 28, LongitudeMax = 04, LatitudeEntrada = 26, LongitudeEntrada = 04},
                new Local(4, "Secretaria Calouros")      { LatitudeMin = 01, LongitudeMin = 09, LatitudeMax = 07, LongitudeMax = 13, LatitudeEntrada = 07, LongitudeEntrada = 10},
                new Local(5, "Coordenação")              { LatitudeMin = 14, LongitudeMin = 08, LatitudeMax = 19, LongitudeMax = 13, LatitudeEntrada = 14, LongitudeEntrada = 10},
                new Local(6, "Cafeteria Mozi")           { LatitudeMin = 20, LongitudeMin = 09, LatitudeMax = 27, LongitudeMax = 13, LatitudeEntrada = 27, LongitudeEntrada = 11},
                //new Local { Id = 7, Nome = "Predio Principal", LatitudeMin = 1, LongitudeMin = 1, LatitudeMax = 50, LongitudeMax = 50, LatitudeEntrada = 50, LongitudeEntrada = 45, LocalAcessivel = false},
                new Local(7, string.Empty)               { LatitudeMin = 08, LongitudeMin = 06, LatitudeMax = 08, LongitudeMax = 06, LatitudeEntrada = 08, LongitudeEntrada = 06, Escada = true},

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
