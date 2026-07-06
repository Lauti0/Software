using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_22MS
{
    public class ConfigTablaDigito_22MS
    {
        public string NombreTabla_22MS { get; set; }
        public List<string> ColumnasClave_22MS { get; set; }
        public List<string> ColumnasControladas_22MS { get; set; }

        public ConfigTablaDigito_22MS()
        {
            ColumnasClave_22MS = new List<string>();
            ColumnasControladas_22MS = new List<string>();
        }
    }
}
