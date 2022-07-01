using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1Rest.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int Edad { get; set; }
    }
}
