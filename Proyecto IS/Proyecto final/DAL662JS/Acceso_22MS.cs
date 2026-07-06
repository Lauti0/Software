using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_22MS
{
    public class Acceso_22MS
    {
        private static Acceso_22MS _instance;
        private static readonly object _lock = new object();

        private static readonly string _cadenaConexion =
            @"Data Source=.;Initial Catalog=ProyectoFinal1;Integrated Security=True";

        private Acceso_22MS()
        {
        }

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

        public DataTable Leer_22MS(SqlCommand sqlCommand)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                {
                    sqlCommand.Connection = conexion;
                    conexion.Open();

                    DataTable tabla = new DataTable();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
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

        public int Escribir_22MS(SqlCommand sqlCommand)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                {
                    sqlCommand.Connection = conexion;
                    conexion.Open();

                    return sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar comando SQL: " + ex.Message);
            }
        }

        public void EscribirMaster_22MS(SqlCommand sqlCommand)
        {
            try
            {
                string connectionStringMaster = _cadenaConexion.Replace(
                    "Initial Catalog=ProyectoFinal1;",
                    "Initial Catalog=master;"
                );

                using (SqlConnection conn = new SqlConnection(connectionStringMaster))
                {
                    sqlCommand.Connection = conn;
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar comando SQL en master: " + ex.Message);
            }
        }

        public bool VerificarConexion_22MS()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
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