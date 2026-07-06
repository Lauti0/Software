using Servicios_22MS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL_22MS
{
    public class DALBitacoraEvento_22MS
    {
        private Acceso_22MS acceso_22MS = Acceso_22MS.GetInstance_22MS();

        public void RegistrarEvento_22MS(BitacoraEvento_22MS bitacoraEvento)
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = @"
            INSERT INTO BitacoraEvento_22MS
            (
                Username_22MS,
                Fecha_22MS,
                Hora_22MS,
                Modulo_22MS,
                Evento_22MS,
                Criticidad_22MS
            )
            VALUES
            (
                @user,
                @fecha,
                @hora,
                @modulo,
                @evento,
                @criticidad
            )";

            sqlCommand.Parameters.AddWithValue("@user", bitacoraEvento.Username_22MS);
            sqlCommand.Parameters.AddWithValue("@fecha", bitacoraEvento.Fecha_22MS.Date);
            sqlCommand.Parameters.AddWithValue("@hora", bitacoraEvento.Hora_22MS);
            sqlCommand.Parameters.AddWithValue("@modulo", bitacoraEvento.Modulo_22MS);
            sqlCommand.Parameters.AddWithValue("@evento", bitacoraEvento.Evento_22MS);
            sqlCommand.Parameters.AddWithValue("@criticidad", bitacoraEvento.Criticidad_22MS);

            acceso_22MS.Escribir_22MS(sqlCommand);
        }

        public DataTable ObtenerEventos_22MS(
            string login,
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string modulo,
            string evento,
            string criticidad
        )
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = @"
            SELECT *
            FROM BitacoraEvento_22MS
            WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(login))
            {
                sqlCommand.CommandText += " AND Username_22MS = @login";
                sqlCommand.Parameters.AddWithValue("@login", login);
            }

            if (fechaInicio.HasValue)
            {
                sqlCommand.CommandText += " AND Fecha_22MS >= @fechaIni";
                sqlCommand.Parameters.AddWithValue("@fechaIni", fechaInicio.Value.Date);
            }

            if (fechaFin.HasValue)
            {
                sqlCommand.CommandText += " AND Fecha_22MS <= @fechaFin";
                sqlCommand.Parameters.AddWithValue("@fechaFin", fechaFin.Value.Date);
            }

            if (!string.IsNullOrWhiteSpace(modulo))
            {
                sqlCommand.CommandText += " AND Modulo_22MS = @modulo";
                sqlCommand.Parameters.AddWithValue("@modulo", modulo);
            }

            if (!string.IsNullOrWhiteSpace(evento))
            {
                sqlCommand.CommandText += " AND Evento_22MS = @evento";
                sqlCommand.Parameters.AddWithValue("@evento", evento);
            }

            if (!string.IsNullOrWhiteSpace(criticidad))
            {
                sqlCommand.CommandText += " AND Criticidad_22MS = @criticidad";
                sqlCommand.Parameters.AddWithValue("@criticidad", criticidad);
            }

            sqlCommand.CommandText += " ORDER BY Fecha_22MS DESC, Hora_22MS DESC";

            return acceso_22MS.Leer_22MS(sqlCommand);
        }

        public DataTable ObtenerEventosFiltrados_22MS(
            string login,
            string modulo,
            string evento,
            string criticidad,
            DateTime fechaInicio,
            DateTime fechaFin
        )
        {
            StringBuilder query = new StringBuilder();

            query.Append(@"
                        SELECT 
                            Username_22MS,
                            Fecha_22MS,
                            Hora_22MS,
                            Modulo_22MS,
                            Evento_22MS,
                            Criticidad_22MS
                        FROM BitacoraEvento_22MS
                        WHERE Fecha_22MS BETWEEN @fechaInicio AND @fechaFin
                        ");

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            sqlCommand.Parameters.AddWithValue("@fechaFin", fechaFin);

            if (!string.IsNullOrWhiteSpace(login))
            {
                query.Append(" AND Username_22MS = @login");
                sqlCommand.Parameters.AddWithValue("@login", login);
            }

            if (!string.IsNullOrWhiteSpace(modulo))
            {
                query.Append(" AND Modulo_22MS = @modulo");
                sqlCommand.Parameters.AddWithValue("@modulo", modulo);
            }

            if (!string.IsNullOrWhiteSpace(evento)
            && evento != "Todos")
            {
                query.Append(" AND Evento_22MS LIKE @Evento");
                sqlCommand.Parameters.AddWithValue(
                    "@Evento",
                    "%" + evento + "%"
                );
            }

            if (!string.IsNullOrWhiteSpace(criticidad))
            {
                query.Append(" AND Criticidad_22MS = @criticidad");
                sqlCommand.Parameters.AddWithValue("@criticidad", criticidad);
            }

            query.Append(" ORDER BY Fecha_22MS DESC");

            sqlCommand.CommandText = query.ToString();

            return acceso_22MS.Leer_22MS(sqlCommand);
        }
    }
}