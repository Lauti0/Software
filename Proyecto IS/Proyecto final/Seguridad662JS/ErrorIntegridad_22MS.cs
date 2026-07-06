using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_22MS
{
    public class ErrorIntegridad_22MS
    {
        public string NombreTabla_22MS { get; set; }
        public string NombreColumna_22MS { get; set; }
        public string ClaveRegistro_22MS { get; set; }
        public string TipoError_22MS { get; set; }
        public long DVGuardado_22MS { get; set; }
        public long DVCalculado_22MS { get; set; }
        public string Detalle_22MS { get; set; }
    }
}
