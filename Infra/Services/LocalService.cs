using GuieMe.Domain.Interfaces;
using GuieMe.Domain.Models;
using System.Linq;

namespace GuieMe.Infra.Services
{
    public class LocalService : ILocalService
    {

        public List<Andar> Andares()
        {
            List<Andar> andares = new()
            {
                new Andar(0, "mapaTerreo") { Pisoo = 1, IndexAndar = 0 },
                new Andar(1, "mapaPrimeiroAndar") { Pisoo = 2, IndexAndar = 1 },
                new Andar(2, "mapaSegundoAndar") { Pisoo = 3, IndexAndar = 2 }
            };

            return andares.OrderBy(o => o.Nome).ToList();
        }

        public List<Local> Locais()
        {
            List<Local> locais = new()
            {
                new Local(0, "Predio Principal Entrada") { LatitudeMin = 00, LongitudeMin = 00, LatitudeMax = 00, LongitudeMax = 00, LatitudeEntrada = 00, LongitudeEntrada = 00, Pisoo = 1, AndarId = 0},
                new Local(1, "Secretaria Veteranos")     { LatitudeMin = 03, LongitudeMin = 01, LatitudeMax = 08, LongitudeMax = 05, LatitudeEntrada = 05, LongitudeEntrada = 05, Pisoo = 1, AndarId = 0},
                new Local(2, "Papelaria")                { LatitudeMin = 09, LongitudeMin = 01, LatitudeMax = 17, LongitudeMax = 05, LatitudeEntrada = 12, LongitudeEntrada = 05, Pisoo = 1, AndarId = 0},
                new Local(3, "Cafeteria Expresso")       { LatitudeMin = 18, LongitudeMin = 01, LatitudeMax = 28, LongitudeMax = 04, LatitudeEntrada = 26, LongitudeEntrada = 04, Pisoo = 1, AndarId = 0},
                new Local(4, "Secretaria Calouros")      { LatitudeMin = 01, LongitudeMin = 09, LatitudeMax = 07, LongitudeMax = 13, LatitudeEntrada = 07, LongitudeEntrada = 10, Pisoo = 1, AndarId = 0},
                new Local(5, "Coordenação")              { LatitudeMin = 14, LongitudeMin = 08, LatitudeMax = 19, LongitudeMax = 13, LatitudeEntrada = 14, LongitudeEntrada = 10, Pisoo = 1, AndarId = 0},
                new Local(6, "Laboratório")              { LatitudeMin = 20, LongitudeMin = 09, LatitudeMax = 27, LongitudeMax = 13, LatitudeEntrada = 27, LongitudeEntrada = 11, Pisoo = 1, AndarId = 0},
                //new Local { Id = 7, Nome = "Predio Principal", LatitudeMin = 1, LongitudeMin = 1, LatitudeMax = 50, LongitudeMax = 50, LatitudeEntrada = 50, LongitudeEntrada = 45, LocalAcessivel = false},

                new Local(9, "Secretaria 2")             { LatitudeMin = 01, LongitudeMin = 01, LatitudeMax = 06, LongitudeMax = 09, LatitudeEntrada = 06, LongitudeEntrada = 08, Pisoo = 2, AndarId = 1},
                new Local(10, "Papelaria 2")             { LatitudeMin = 09, LongitudeMin = 01, LatitudeMax = 17, LongitudeMax = 06, LatitudeEntrada = 16, LongitudeEntrada = 06, Pisoo = 2, AndarId = 1},
                new Local(11, "Cafeteria 2")             { LatitudeMin = 22, LongitudeMin = 01, LatitudeMax = 28, LongitudeMax = 09, LatitudeEntrada = 22, LongitudeEntrada = 03, Pisoo = 2, AndarId = 1},
                new Local(13, "Laboratório 2")           { LatitudeMin = 04, LongitudeMin = 10, LatitudeMax = 12, LongitudeMax = 14, LatitudeEntrada = 10, LongitudeEntrada = 10, Pisoo = 2, AndarId = 1},
                new Local(14, "Coordenação 2")           { LatitudeMin = 16, LongitudeMin = 10, LatitudeMax = 24, LongitudeMax = 14, LatitudeEntrada = 16, LongitudeEntrada = 12, Pisoo = 2, AndarId = 1},

                new Local(9, "Secretaria 3")             { LatitudeMin = 01, LongitudeMin = 01, LatitudeMax = 06, LongitudeMax = 09, LatitudeEntrada = 06, LongitudeEntrada = 08, Pisoo = 3, AndarId = 2},
                new Local(10, "Papelaria 3")             { LatitudeMin = 09, LongitudeMin = 01, LatitudeMax = 17, LongitudeMax = 06, LatitudeEntrada = 16, LongitudeEntrada = 06, Pisoo = 3, AndarId = 2},
                new Local(11, "Cafeteria 3")             { LatitudeMin = 22, LongitudeMin = 01, LatitudeMax = 28, LongitudeMax = 09, LatitudeEntrada = 22, LongitudeEntrada = 03, Pisoo = 3, AndarId = 2},
                new Local(13, "Laboratório 3")           { LatitudeMin = 04, LongitudeMin = 10, LatitudeMax = 12, LongitudeMax = 14, LatitudeEntrada = 10, LongitudeEntrada = 10, Pisoo = 3, AndarId = 2},
                new Local(14, "Laboratório 3")           { LatitudeMin = 16, LongitudeMin = 10, LatitudeMax = 24, LongitudeMax = 14, LatitudeEntrada = 16, LongitudeEntrada = 12, Pisoo = 3, AndarId = 2},


                new Local(7, "Escada 1")                 { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 08, LongitudeEntrada = 06, Pisoo = 1, Escada = true}, 
                new Local(8, "Escada 2")                 { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 21, LongitudeEntrada = 08, Pisoo = 1, Escada = true},
                new Local(15, "Escada 3")                 { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 08, LongitudeEntrada = 06, Pisoo = 2, Escada = true},
                new Local(16, "Escada 4")                { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 21, LongitudeEntrada = 08, Pisoo = 2, Escada = true},
            };

            return locais.OrderBy(o => o.Nome).ToList();
        }

        public List<Tuple<int, int>> Paredes() //TODO: Validar
        {
            List<Tuple<int, int>> paredes = new List<Tuple<int, int>>();
            return paredes;
        }
        public List<Tuple<int, int>> Escadas()
        {
            List<Tuple<int, int>> escadas = new List<Tuple<int, int>>();
            return escadas;
        }
    }
}
