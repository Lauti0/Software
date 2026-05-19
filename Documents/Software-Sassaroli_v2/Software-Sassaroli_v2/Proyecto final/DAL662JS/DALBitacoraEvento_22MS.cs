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
    public class DALBitacoraEvento_22MS
    {
        Acceso_22MS acceso = Acceso_22MS.GetInstance_22MS();

        public void RegistrarEvento_22MS(BitacoraEvento_22MS evento)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"
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

            cmd.Parameters.AddWithValue("@user", evento.Username_22MS);
            cmd.Parameters.AddWithValue("@fecha", evento.Fecha_22MS.Date);
            cmd.Parameters.AddWithValue("@hora", evento.Hora_22MS);
            cmd.Parameters.AddWithValue("@modulo", evento.Modulo_22MS);
            cmd.Parameters.AddWithValue("@evento", evento.Evento_22MS);
            cmd.Parameters.AddWithValue("@criticidad", evento.Criticidad_22MS);

            acceso.Escribir_22MS(cmd);
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
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"
            SELECT *
            FROM BitacoraEvento_22MS
            WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(login))
            {
                cmd.CommandText += " AND Username_22MS = @login";
                cmd.Parameters.AddWithValue("@login", login);
            }

            if (fechaInicio.HasValue)
            {
                cmd.CommandText += " AND Fecha_22MS >= @fechaIni";
                cmd.Parameters.AddWithValue("@fechaIni", fechaInicio.Value.Date);
            }

            if (fechaFin.HasValue)
            {
                cmd.CommandText += " AND Fecha_22MS <= @fechaFin";
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin.Value.Date);
            }

            if (!string.IsNullOrWhiteSpace(modulo))
            {
                cmd.CommandText += " AND Modulo_22MS = @modulo";
                cmd.Parameters.AddWithValue("@modulo", modulo);
            }

            if (!string.IsNullOrWhiteSpace(evento))
            {
                cmd.CommandText += " AND Evento_22MS = @evento";
                cmd.Parameters.AddWithValue("@evento", evento);
            }

            if (!string.IsNullOrWhiteSpace(criticidad))
            {
                cmd.CommandText += " AND Criticidad_22MS = @criticidad";
                cmd.Parameters.AddWithValue("@criticidad", criticidad);
            }

            cmd.CommandText += " ORDER BY Fecha_22MS DESC, Hora_22MS DESC";

            return acceso.Leer_22MS(cmd);
        }

        public DataTable ObtenerEventosFiltrados_22MS(string login, string modulo, string evento, string criticidad, DateTime fechaIni, DateTime fechaFin)
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
                        WHERE Fecha_22MS BETWEEN @FechaIni AND @FechaFin
                        ");

            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@FechaIni", fechaIni);
            cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

            if (!string.IsNullOrWhiteSpace(login))
            {
                query.Append(" AND Username_22MS = @Login");
                cmd.Parameters.AddWithValue("@Login", login);
            }

            if (!string.IsNullOrWhiteSpace(modulo))
            {
                query.Append(" AND Modulo_22MS = @Modulo");
                cmd.Parameters.AddWithValue("@Modulo", modulo);
            }

            if (!string.IsNullOrWhiteSpace(evento)
                && evento != "Todos")
            {
                query.Append(" AND Evento_22MS = @Evento");
                cmd.Parameters.AddWithValue("@Evento", evento);
            }

            if (!string.IsNullOrWhiteSpace(criticidad))
            {
                query.Append(" AND Criticidad_22MS = @Criticidad");
                cmd.Parameters.AddWithValue("@Criticidad", criticidad);
            }

            query.Append(" ORDER BY Fecha_22MS DESC");

            cmd.CommandText = query.ToString();

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
        }
    }
}
