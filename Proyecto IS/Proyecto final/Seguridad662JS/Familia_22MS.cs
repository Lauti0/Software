using System;
using System.Collections.Generic;

namespace Servicios_22MS
{
    public class Familia_22MS : Rol_22MS
    {
        public int IdFamilia_22MS { get; set; }
        public string NombreFamilia_22MS { get; set; }

        public Familia_22MS()
        {
        }

        public Familia_22MS(int idFamilia_22MS, string nombreFamilia_22MS)
            : base(idFamilia_22MS, nombreFamilia_22MS)
        {
            this.IdFamilia_22MS = idFamilia_22MS;
            this.NombreFamilia_22MS = nombreFamilia_22MS;
        }

        public override void Agregar(Rol_22MS componente)
        {
            if (componente == null)
                throw new Exception("El componente no puede ser nulo.");

            if (!(componente is Familia_22MS) && !(componente is Permiso_22MS))
                throw new Exception("Una familia solo puede contener familias o permisos.");

            base.Agregar(componente);
        }

        public override void Eliminar(Rol_22MS componente)
        {
            base.Eliminar(componente);
        }

        public override List<Rol_22MS> ObtenerHijos_22MS()
        {
            return Componentes_22MS;
        }

        public override List<Permiso_22MS> ObtenerPermisos_22MS()
        {
            List<Permiso_22MS> permisos = new List<Permiso_22MS>();

            foreach (Rol_22MS componente in Componentes_22MS)
            {
                permisos.AddRange(componente.ObtenerPermisos_22MS());
            }

            return permisos;
        }

        public override string ToString()
        {
            return NombreFamilia_22MS;
        }
    }
}