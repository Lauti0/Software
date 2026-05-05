using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_22MS
{
    public class Acceso_22MS
    {
        private static Acceso_22MS _instance;
        private static readonly object _lock = new object();

        private readonly string _cadenaConexion =
            ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

        private Acceso_22MS() { }

        public static Acceso_22MS GetInstance_22MS()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Acceso_22MS();
                }
            }
            return _instance;
        }

    
        public DataTable Leer_22MS(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                {
                    cmd.Connection = conexion;
                    conexion.Open();

                    DataTable tabla = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }

                    return tabla;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar comando SQL: " + ex.Message);
            }
            
        }

      
        public int Escribir_22MS(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                {
                    cmd.Connection = conexion;
                    conexion.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex) 
            {
                throw new Exception("Error al ejecutar comando SQL: " + ex.Message);
            }
            
        }

        public bool VerificarConexion_22MS()
        {
            try
            {
                using (var conexion = new SqlConnection(_cadenaConexion))
                {
                    conexion.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
