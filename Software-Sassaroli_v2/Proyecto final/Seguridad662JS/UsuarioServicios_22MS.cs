using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_22MS
{
    public class UsuarioServicios_22MS
    {
        public int IdUsuario_22MS {  get; set; }
        public int DNI_22MS {  get; set; }
        public string Username_22MS { get; set; }
        public string Password_22MS { get; set; }        
        public string Nombre_22MS { get; set; }
        public string Apellido_22MS { get; set; }        
        public string Email_22MS { get; set; }
        public Rol_22MS Rol_22MS { get; set; }        
        public bool Activo_22MS { get; set; }
        public bool Bloqueado_22MS { get; set; }

    }
}
