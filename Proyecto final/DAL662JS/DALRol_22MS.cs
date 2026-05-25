using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_22MS
{
    public class DALRol_22MS
    {
        public List<RolServicios_22MS> ObtenerRoles_22MS()
        {
            string query = "SELECT * FROM Rol_22MS";

            SqlCommand cmd = new SqlCommand(query);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            List<RolServicios_22MS> lista = new List<RolServicios_22MS>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new RolServicios_22MS
                {
                    IdRol_22MS =Convert.ToInt32(row["IdRol_22MS"]),

                    NombreRol_22MS =row["NombreRol_22MS"].ToString()
                });
            }

            return lista;
        }
    }
}
