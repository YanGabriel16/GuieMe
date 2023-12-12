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
                new Andar(0, "mapaSubSolo") { Pisoo = 1, IndexAndar = 0 },
                new Andar(1, "mapaTerreo")  { Pisoo = 2, IndexAndar = 1 },
            };

            return andares.OrderBy(o => o.Nome).ToList();
        }

        public List<Local> Locais()
        {
            List<Local> locais = new()
            {
                //Térreo
                new Local(1, "Coordenação")                 { LatitudeMin = 00, LongitudeMin = 24, LatitudeMax = 05, LongitudeMax = 29, LatitudeEntrada = 04, LongitudeEntrada = 24, Pisoo = 2, AndarId = 1},
                new Local(2, "Cafeteria 1")                 { LatitudeMin = 17, LongitudeMin = 00, LatitudeMax = 20, LongitudeMax = 04, LatitudeEntrada = 20, LongitudeEntrada = 03, Pisoo = 2, AndarId = 1},
                new Local(3, "Pravaler")                    { LatitudeMin = 17, LongitudeMin = 07, LatitudeMax = 20, LongitudeMax = 11, LatitudeEntrada = 20, LongitudeEntrada = 09, Pisoo = 2, AndarId = 1},
                new Local(4, "Pós Graduação")               { LatitudeMin = 17, LongitudeMin = 15, LatitudeMax = 20, LongitudeMax = 20, LatitudeEntrada = 20, LongitudeEntrada = 18, Pisoo = 2, AndarId = 1},
                new Local(5, "Cafeteria 2")                 { LatitudeMin = 17, LongitudeMin = 24, LatitudeMax = 20, LongitudeMax = 29, LatitudeEntrada = 20, LongitudeEntrada = 26, Pisoo = 2, AndarId = 1},
                new Local(6, "Papelaria")                   { LatitudeMin = 17, LongitudeMin = 34, LatitudeMax = 20, LongitudeMax = 39, LatitudeEntrada = 20, LongitudeEntrada = 37, Pisoo = 2, AndarId = 1},
                new Local(7, "Banheiro Feminino")           { LatitudeMin = 13, LongitudeMin = 24, LatitudeMax = 15, LongitudeMax = 26, LatitudeEntrada = 14, LongitudeEntrada = 24, Pisoo = 2, AndarId = 1},
                new Local(8, "Cafeteria 3")                 { LatitudeMin = 39, LongitudeMin = 00, LatitudeMax = 42, LongitudeMax = 04, LatitudeEntrada = 39, LongitudeEntrada = 03, Pisoo = 2, AndarId = 1},
                new Local(9, "Cópia Cabana")                { LatitudeMin = 39, LongitudeMin = 07, LatitudeMax = 42, LongitudeMax = 11, LatitudeEntrada = 39, LongitudeEntrada = 09, Pisoo = 2, AndarId = 1},
                new Local(10, "Vestibular")                 { LatitudeMin = 39, LongitudeMin = 15, LatitudeMax = 42, LongitudeMax = 20, LatitudeEntrada = 39, LongitudeEntrada = 18, Pisoo = 2, AndarId = 1},
                new Local(11, "Cafeteria 4")                { LatitudeMin = 39, LongitudeMin = 24, LatitudeMax = 42, LongitudeMax = 29, LatitudeEntrada = 39, LongitudeEntrada = 27, Pisoo = 2, AndarId = 1},
                new Local(12, "Banheiro Feminino")          { LatitudeMin = 44, LongitudeMin = 18, LatitudeMax = 46, LongitudeMax = 20, LatitudeEntrada = 45, LongitudeEntrada = 20, Pisoo = 2, AndarId = 1},
                new Local(13, "Banheiro Masculino")         { LatitudeMin = 44, LongitudeMin = 24, LatitudeMax = 46, LongitudeMax = 26, LatitudeEntrada = 45, LongitudeEntrada = 24, Pisoo = 2, AndarId = 1},
                new Local(14, "Computadores")               { LatitudeMin = 39, LongitudeMin = 34, LatitudeMax = 42, LongitudeMax = 39, LatitudeEntrada = 39, LongitudeEntrada = 37, Pisoo = 2, AndarId = 1},
                new Local(25, "Banheiro Masculino")         { LatitudeMin = 13, LongitudeMin = 37, LatitudeMax = 15, LongitudeMax = 39, LatitudeEntrada = 14, LongitudeEntrada = 39, Pisoo = 2, AndarId = 1},
                new Local(27, "Secretaria Veteranos")       { LatitudeMin = 48, LongitudeMin = 34, LatitudeMax = 54, LongitudeMax = 39, LatitudeEntrada = 50, LongitudeEntrada = 39, Pisoo = 2, AndarId = 1},
                new Local(28, "Secretaria Calouros")        { LatitudeMin = 54, LongitudeMin = 34, LatitudeMax = 59, LongitudeMax = 39, LatitudeEntrada = 57, LongitudeEntrada = 39, Pisoo = 2, AndarId = 1},

                //Escadas
                new Local(15, "Escada")                    { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 17, LongitudeEntrada = 23, Pisoo = 1, Escada = true},
                new Local(16, "Escada")                    { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 43, LongitudeEntrada = 21, Pisoo = 1, Escada = true},
                new Local(19, "Escada")                    { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 16, LongitudeEntrada = 40, Pisoo = 1, Escada = true},

                //quarteirões
                new Local(356565, "") { LatitudeMin = 00, LongitudeMin = 00, LatitudeMax = 17, LongitudeMax = 11, LatitudeEntrada = -1, LongitudeEntrada = -1, Pisoo = 2, AndarId = 1, LocalAcessivel = false },
                new Local(356566, "") { LatitudeMin = 00, LongitudeMin = 24, LatitudeMax = 17, LongitudeMax = 39, LatitudeEntrada = -1, LongitudeEntrada = -1, Pisoo = 2, AndarId = 1, LocalAcessivel = false },
                new Local(356567, "") { LatitudeMin = 42, LongitudeMin = 24, LatitudeMax = 59, LongitudeMax = 39, LatitudeEntrada = -1, LongitudeEntrada = -1, Pisoo = 2, AndarId = 1, LocalAcessivel = false },
                new Local(356568, "") { LatitudeMin = 42, LongitudeMin = 00, LatitudeMax = 59, LongitudeMax = 11, LatitudeEntrada = -1, LongitudeEntrada = -1, Pisoo = 2, AndarId = 1, LocalAcessivel = false },
                new Local(356569, "") { LatitudeMin = 00, LongitudeMin = 15, LatitudeMax = 17, LongitudeMax = 20, LatitudeEntrada = -1, LongitudeEntrada = -1, Pisoo = 2, AndarId = 1, LocalAcessivel = false},
                new Local(356570, "") { LatitudeMin = 39, LongitudeMin = 15, LatitudeMax = 59, LongitudeMax = 20, LatitudeEntrada = -1, LongitudeEntrada = -1, Pisoo = 2, AndarId = 1, LocalAcessivel = false },


                //SubSolo ------------------------------------------------------------------
                new Local(29, "Banheiro Masculino")       { LatitudeMin = 14, LongitudeMin = 21, LatitudeMax = 16, LongitudeMax = 23, LatitudeEntrada = 16, LongitudeEntrada = 22, Pisoo = 1, AndarId = 0},
                new Local(30, "Pós Odontologia")          { LatitudeMin = 20, LongitudeMin = 21, LatitudeMax = 26, LongitudeMax = 26, LatitudeEntrada = 20, LongitudeEntrada = 23, Pisoo = 1, AndarId = 0},
                new Local(31, "Laboratório Enfermagem")   { LatitudeMin = 20, LongitudeMin = 26, LatitudeMax = 26, LongitudeMax = 31, LatitudeEntrada = 20, LongitudeEntrada = 27, Pisoo = 1, AndarId = 0},
                new Local(32, "Triagem Odontologia")      { LatitudeMin = 20, LongitudeMin = 31, LatitudeMax = 26, LongitudeMax = 36, LatitudeEntrada = 26, LongitudeEntrada = 35, Pisoo = 1, AndarId = 0},
                new Local(44, "Copa")                     { LatitudeMin = 19, LongitudeMin = 41, LatitudeMax = 23, LongitudeMax = 45, LatitudeEntrada = 21, LongitudeEntrada = 41, Pisoo = 1, AndarId = 0},
                new Local(33, "Refeitório")               { LatitudeMin = 23, LongitudeMin = 41, LatitudeMax = 27, LongitudeMax = 45, LatitudeEntrada = 25, LongitudeEntrada = 41, Pisoo = 1, AndarId = 0},
                new Local(34, "Banheiro Feminino")        { LatitudeMin = 14, LongitudeMin = 34, LatitudeMax = 16, LongitudeMax = 36, LatitudeEntrada = 16, LongitudeEntrada = 35, Pisoo = 1, AndarId = 0},

                //Escadas
                new Local(20, "Escada")                    { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 17, LongitudeEntrada = 23, Pisoo = 2, Escada = true},
                new Local(21, "Escada")                    { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 43, LongitudeEntrada = 21, Pisoo = 2, Escada = true},
                new Local(24, "Escada")                    { LatitudeMin = -1, LongitudeMin = -1, LatitudeMax = -1, LongitudeMax = -1, LatitudeEntrada = 16, LongitudeEntrada = 40, Pisoo = 2, Escada = true},

                ////quarteirões
                new Local(356571, "") { LatitudeMin = 00, LongitudeMin = 21, LatitudeMax = 16, LongitudeMax = 36, LatitudeEntrada = -1, LongitudeEntrada = -1, Pisoo = 1, AndarId = 0, LocalAcessivel = false },
                new Local(356572, "") { LatitudeMin = 00, LongitudeMin = 41, LatitudeMax = 59, LongitudeMax = 45, LatitudeEntrada = -1, LongitudeEntrada = -1, Pisoo = 1, AndarId = 0, LocalAcessivel = false },
            };
            return locais.OrderBy(o => o.Nome).ToList();
        }
    }
}
