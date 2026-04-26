using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios662JS
{
    public enum Modulo_22MS
    {
        Usuario,
        Admin,
        Maestro,
        Reserva,
        Compras,            
        Reporte,
        Ayuda
    }
    public enum Evento_22MS
    {
        Login,
        Logout,
        CrearUsuario,
        Desbloquear,
        Activar,
        Desactivar
    }
    public class Bitacora_22MS
    {
        private UsuarioServicios662JS usuario;

        private DateTime _fecha;

        private int _criticidad;


        public Evento_22MS Evento
        {
            get; set;
        }


        public Modulo_22MS Modulo
        {
            get; set;
        }


        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public UsuarioServicios662JS Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public int Criticidad
        {
            get { return _criticidad; }
            set { _criticidad = value; }
        }
    }
}
