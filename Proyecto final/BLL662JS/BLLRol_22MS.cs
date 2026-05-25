using DAL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_22MS
{
    public class BLLRol_22MS
    {
        DALRol_22MS dal = new DALRol_22MS();

        public List<RolServicios_22MS> ObtenerRoles_22MS()
        {
            return dal.ObtenerRoles_22MS();
        }
    }
}
