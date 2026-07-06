using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_22MS
{
    public class DALPermiso_22MS
    {
        public List<Permiso_22MS> ObtenerPermisos_22MS()
        {
            string query = "SELECT * FROM Permiso_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            DataTable tablaPermisos = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            List<Permiso_22MS> permisos = new List<Permiso_22MS>();

            foreach (DataRow fila in tablaPermisos.Rows)
            {
                permisos.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(fila["IdPermiso_22MS"]),
                    NombrePermiso_22MS = fila["NombrePermiso_22MS"].ToString()
                });
            }

            return permisos;
        }
    }
}