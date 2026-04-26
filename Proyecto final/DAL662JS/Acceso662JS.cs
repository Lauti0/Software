using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL662JS
{
    public class Acceso662JS
    {
        private static Acceso662JS _instance;
        private static readonly object _lock = new object();

        private readonly string _cadenaConexion =
            ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

        private Acceso662JS() { }

        public static Acceso662JS GetInstance662JS()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Acceso662JS();
                }
            }
            return _instance;
        }

    
        public DataTable Leer662JS(SqlCommand cmd)
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

      
        public int Escribir662JS(SqlCommand cmd)
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

        public bool VerificarConexion662JS()
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
