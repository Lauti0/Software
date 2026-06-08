using System;
using System.Collections.Generic;

namespace Servicios_22MS
{
    public class Permiso_22MS : Rol_22MS
    {
        public int IdPermiso_22MS { get; set; }
        public string NombrePermiso_22MS { get; set; }

        public Permiso_22MS()
        {
        }

        public Permiso_22MS(int idPermiso_22MS, string nombrePermiso_22MS)
            : base(idPermiso_22MS, nombrePermiso_22MS)
        {
            this.IdPermiso_22MS = idPermiso_22MS;
            this.NombrePermiso_22MS = nombrePermiso_22MS;
        }

        public override void Agregar(Rol_22MS componente)
        {
            throw new Exception("No se pueden agregar elementos a un permiso.");
        }

        public override void Eliminar(Rol_22MS componente)
        {
            throw new Exception("No se pueden eliminar elementos de un permiso.");
        }

        public override List<Rol_22MS> ObtenerHijos_22MS()
        {
            return new List<Rol_22MS>();
        }

        public override List<Permiso_22MS> ObtenerPermisos_22MS()
        {
            return new List<Permiso_22MS> { this };
        }

        public override string ToString()
        {
            return NombrePermiso_22MS;
        }
    }
}