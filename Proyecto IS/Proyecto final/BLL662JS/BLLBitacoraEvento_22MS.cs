using System;
using System.Data;
using DAL_22MS;
using Servicios_22MS;

namespace BLL_22MS
{
    public class BLLBitacoraEvento_22MS
    {
        private DALBitacoraEvento_22MS dalBitacoraEvento = new DALBitacoraEvento_22MS();

        public void RegistrarEvento_22MS(
            string username,
            string modulo,
            string evento,
            int criticidad
        )
        {
            BitacoraEvento_22MS bitacoraEvento = new BitacoraEvento_22MS();

            bitacoraEvento.Username_22MS = username;
            bitacoraEvento.Fecha_22MS = DateTime.Now;
            bitacoraEvento.Hora_22MS = DateTime.Now.TimeOfDay;
            bitacoraEvento.Modulo_22MS = modulo;
            bitacoraEvento.Evento_22MS = evento;
            bitacoraEvento.Criticidad_22MS = criticidad;

            dalBitacoraEvento.RegistrarEvento_22MS(bitacoraEvento);
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
            return dalBitacoraEvento.ObtenerEventos_22MS(
                login,
                fechaInicio,
                fechaFin,
                modulo,
                evento,
                criticidad
            );
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
            return dalBitacoraEvento.ObtenerEventosFiltrados_22MS(
                login,
                modulo,
                evento,
                criticidad,
                fechaInicio,
                fechaFin
            );
        }
    }
}
