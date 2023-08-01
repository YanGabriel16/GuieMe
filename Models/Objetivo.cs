using GuieMe.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuieMe.Models
{
    public class Objetivo
    {
        public int Id { get; set; }
        public int localId { get; set; }
        public Curso Curso { get; set; }
        public string Descricao { get; set; }
    }
}

