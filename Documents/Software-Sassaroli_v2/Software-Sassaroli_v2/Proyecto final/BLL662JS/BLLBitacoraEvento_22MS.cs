using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_22MS;
using Servicios_22MS;

namespace BLL_22MS
{
    public class BLLBitacoraEvento_22MS
    {
        DALBitacoraEvento_22MS dal = new DALBitacoraEvento_22MS();

        public void RegistrarEvento_22MS(
            string user,
            string modulo,
            string evento,
            int criticidad
        )
        {
            BitacoraEvento_22MS ev = new BitacoraEvento_22MS();

            ev.Username_22MS = user;
            ev.Fecha_22MS = DateTime.Now;
            ev.Hora_22MS = DateTime.Now.TimeOfDay;
            ev.Modulo_22MS = modulo;
            ev.Evento_22MS = evento;
            ev.Criticidad_22MS = criticidad;

            dal.RegistrarEvento_22MS(ev);
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
            return dal.ObtenerEventos_22MS(
                login,
                fechaInicio,
                fechaFin,
                modulo,
                evento,
                criticidad
            );
        }

        public DataTable ObtenerEventosFiltrados_22MS(string login, string modulo, string evento, string criticidad, DateTime fechaIni, DateTime fechaFin)
        {
            return dal.ObtenerEventosFiltrados_22MS(login,modulo,evento,criticidad,fechaIni,fechaFin);
        }
    }
}
