using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_22MS
{
    public class Rol_22MS
    {
        public string Descripcion_22MS { get; set; }

        public Rol_22MS() { }

        public Rol_22MS(string descripcion_22MS)
        {
            Descripcion_22MS = descripcion_22MS;
        }

        public override string ToString()
        {
            return Descripcion_22MS;
        }
    }   
}
