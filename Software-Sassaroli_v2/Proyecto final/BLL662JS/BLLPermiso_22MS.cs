using DAL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_22MS
{
    public class BLLPermiso_22MS
    {
        private DALPermiso_22MS dalPermiso_22MS = new DALPermiso_22MS();

        public List<Permiso_22MS> ObtenerPermisos_22MS()
        {
            return dalPermiso_22MS.ObtenerPermisos_22MS();
        }
    }
}
