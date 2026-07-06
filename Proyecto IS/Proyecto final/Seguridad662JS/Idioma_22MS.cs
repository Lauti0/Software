using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_22MS
{
    public class Idioma_22MS
    {
        public string Codigo_22MS { get; set; }
        public string Nombre_22MS { get; set; }
        public Dictionary<string, string> Traducciones_22MS { get; set; }

        public Idioma_22MS()
        {
            Traducciones_22MS = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            return Nombre_22MS;
        }
    }
}
