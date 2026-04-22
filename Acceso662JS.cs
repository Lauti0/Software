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

        // 🔹 SELECT
        public DataTable Leer662JS(SqlCommand cmd)
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

        // 🔹 INSERT / UPDATE / DELETE
        public int Escribir662JS(SqlCommand cmd)
        {
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                cmd.Connection = conexion;
                conexion.Open();

                return cmd.ExecuteNonQuery();
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
