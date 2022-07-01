using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1Rest.Models
{
    public class Respuesta
    {
        public int CodError { get; set; }
        public string Error { get; set; }
        public string Mensaje { get; set; }
    }
}
