using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL_22MS
{
    public class DALDigitoVerificador_22MS
    {
        public DataTable ObtenerRegistros_22MS(ConfigTablaDigito_22MS config)
        {
            List<string> columnas = new List<string>();

            columnas.AddRange(config.ColumnasClave_22MS);

            foreach (string columna in config.ColumnasControladas_22MS)
            {
                if (!columnas.Contains(columna))
                    columnas.Add(columna);
            }

            if (!columnas.Contains("DVH_22MS"))
                columnas.Add("DVH_22MS");

            string columnasSql = string.Join(", ", columnas);

            string query = $"SELECT {columnasSql} FROM {config.NombreTabla_22MS}";

            SqlCommand sqlCommand = new SqlCommand(query);

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);
        }

        public void ActualizarDVH_22MS(ConfigTablaDigito_22MS config, DataRow row, long dvh)
        {
            string where = ArmarWherePorClave_22MS(config, row);

            string query = $@"
                UPDATE {config.NombreTabla_22MS}
                SET DVH_22MS = @DVH_22MS
                WHERE {where}";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@DVH_22MS", dvh);

            AgregarParametrosClave_22MS(sqlCommand, config, row);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void EliminarDigitosVerticalesTabla_22MS(string nombreTabla)
        {
            string query = @"
                DELETE FROM DigitoVerificador_22MS
                WHERE NombreTabla_22MS = @NombreTabla_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@NombreTabla_22MS", nombreTabla);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void GuardarDigitoVertical_22MS(string nombreTabla, string nombreColumna, long dv)
        {
            string query = @"
                INSERT INTO DigitoVerificador_22MS
                (NombreTabla_22MS, NombreColumna_22MS, DV_22MS)
                VALUES
                (@NombreTabla_22MS, @NombreColumna_22MS, @DV_22MS)";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@NombreTabla_22MS", nombreTabla);
            sqlCommand.Parameters.AddWithValue("@NombreColumna_22MS", nombreColumna);
            sqlCommand.Parameters.AddWithValue("@DV_22MS", dv);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public DataTable ObtenerDigitosVerticalesGuardados_22MS(string nombreTabla)
        {
            string query = @"
                SELECT NombreTabla_22MS, NombreColumna_22MS, DV_22MS
                FROM DigitoVerificador_22MS
                WHERE NombreTabla_22MS = @NombreTabla_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@NombreTabla_22MS", nombreTabla);

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);
        }

        private string ArmarWherePorClave_22MS(ConfigTablaDigito_22MS config, DataRow row)
        {
            List<string> condiciones = new List<string>();

            foreach (string columnaClave in config.ColumnasClave_22MS)
            {
                condiciones.Add($"{columnaClave} = @{columnaClave}");
            }

            return string.Join(" AND ", condiciones);
        }

        private void AgregarParametrosClave_22MS(SqlCommand sqlCommand, ConfigTablaDigito_22MS config, DataRow row)
        {
            foreach (string columnaClave in config.ColumnasClave_22MS)
            {
                sqlCommand.Parameters.AddWithValue("@" + columnaClave, row[columnaClave]);
            }
        }
    }
}
