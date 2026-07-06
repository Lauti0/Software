using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios_22MS
{
    public class Rol_22MS
    {
        public int IdRol_22MS { get; set; }

        public string NombreRol_22MS { get; set; }

        protected List<Rol_22MS> Componentes_22MS;

        public Rol_22MS()
        {
            Componentes_22MS = new List<Rol_22MS>();
        }

        public Rol_22MS(int idRol_22MS, string nombreRol_22MS)
        {
            this.IdRol_22MS = idRol_22MS;
            this.NombreRol_22MS = nombreRol_22MS;
            Componentes_22MS = new List<Rol_22MS>();
        }

        public virtual void Agregar(Rol_22MS componente)
        {
            if (componente == null)
                throw new Exception("El componente no puede ser nulo.");

            if (!(componente is Familia_22MS) && !(componente is Permiso_22MS))
                throw new Exception("Un rol solo puede contener familias o permisos.");

            Componentes_22MS.Add(componente);
        }

        public virtual void Eliminar(Rol_22MS componente)
        {
            Componentes_22MS.Remove(componente);
        }

        public virtual List<Rol_22MS> ObtenerHijos_22MS()
        {
            return Componentes_22MS;
        }

        public virtual List<Permiso_22MS> ObtenerPermisos_22MS()
        {
            List<Permiso_22MS> permisos = new List<Permiso_22MS>();

            foreach (Rol_22MS componente in Componentes_22MS)
            {
                permisos.AddRange(componente.ObtenerPermisos_22MS());
            }

            return permisos;
        }

        public bool TienePermiso_22MS(string nombrePermiso)
        {
            return ObtenerPermisos_22MS().Any(permiso => permiso.NombrePermiso_22MS == nombrePermiso);
        }

        public override string ToString()
        {
            return NombreRol_22MS;
        }
    }
}