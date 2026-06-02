using DAL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_22MS
{
    public class BLLRol_22MS
    {
        private DALRol_22MS dalRol_22MS = new DALRol_22MS();

        public List<Rol_22MS> ObtenerRoles_22MS()
        {
            return dalRol_22MS.ObtenerRoles_22MS();
        }

        public List<Familia_22MS> ObtenerFamilias_22MS()
        {
            return dalRol_22MS.ObtenerFamilias_22MS();
        }

        public List<Permiso_22MS> ObtenerPermisos_22MS()
        {
            return dalRol_22MS.ObtenerPermisos_22MS();
        }

        public List<Familia_22MS> ObtenerFamiliasPorRol_22MS(int IdRol)
        {
            return dalRol_22MS.ObtenerFamiliasPorRol_22MS(IdRol);
        }

        public List<Permiso_22MS> ObtenerPermisosPorFamilia_22MS(int IdFamilia)
        {
            return dalRol_22MS.ObtenerPermisosPorFamilia_22MS(IdFamilia);
        }

        public List<Permiso_22MS> ObtenerPermisosPorRol_22MS(int IdRol)
        {
            return dalRol_22MS.ObtenerPermisosPorRol_22MS(IdRol);
        }

        public List<Familia_22MS> ObtenerFamiliasHijas_22MS(int IdFamiliaPadre)
        {
            return dalRol_22MS.ObtenerFamiliasHijas_22MS(IdFamiliaPadre);
        }

        public List<Permiso_22MS> ObtenerPermisosDirectosPorRol_22MS(int idRol)
        {
            if (idRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            return dalRol_22MS.ObtenerPermisosDirectosPorRol_22MS(idRol);
        }

        public DataTable ObtenerRolFamiliaPermiso_22MS(int idRol)
        {
            if (idRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            return dalRol_22MS.ObtenerRolFamiliaPermiso_22MS(idRol);
        }

        public DataTable ObtenerResumenFamilia_22MS(int idFamilia)
        {
            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            return dalRol_22MS.ObtenerResumenFamilia_22MS(idFamilia);
        }

        public List<Permiso_22MS> ObtenerPermisosHeredadosPorFamilia_22MS(int idFamiliaPadre)
        {
            if (idFamiliaPadre <= 0)
                throw new Exception("Debe seleccionar una familia.");

            return dalRol_22MS.ObtenerPermisosHeredadosPorFamilia_22MS(idFamiliaPadre);
        }



        public List<Permiso_22MS> ObtenerPermisosCompletosPorFamilia_22MS(int idFamilia)
        {
            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            return dalRol_22MS.ObtenerPermisosCompletosPorFamilia_22MS(idFamilia);
        }


        public void CrearRol_22MS(string NombreRol)
        {
            if (string.IsNullOrWhiteSpace(NombreRol))
                throw new Exception("Debe ingresar un nombre para el rol.");

            List<Rol_22MS> roles = dalRol_22MS.ObtenerRoles_22MS();

            bool existe = roles.Any(r => r.NombreRol_22MS.Equals(NombreRol, StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception("Ya existe un rol con ese nombre.");

            dalRol_22MS.CrearRol_22MS(NombreRol);
        }

        public void ModificarRol_22MS(int IdRol, string NombreRol)
        {
            if (IdRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (string.IsNullOrWhiteSpace(NombreRol))
                throw new Exception("Debe ingresar un nombre para el rol.");

            List<Rol_22MS> roles = dalRol_22MS.ObtenerRoles_22MS();

            bool existe = roles.Any(r =>
                r.IdRol_22MS != IdRol &&
                r.NombreRol_22MS.Equals(NombreRol, StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception("Ya existe otro rol con ese nombre.");

            dalRol_22MS.ModificarRol_22MS(IdRol, NombreRol);
        }

        public void EliminarRol_22MS(int IdRol)
        {
            if (IdRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (IdRol == 1)
                throw new Exception("No se puede eliminar el rol Administrador.");

            dalRol_22MS.EliminarRol_22MS(IdRol);
        }

        public void CrearFamilia_22MS(string NombreFamilia)
        {
            if (string.IsNullOrWhiteSpace(NombreFamilia))
                throw new Exception("Debe ingresar un nombre para la familia.");

            List<Familia_22MS> familias = dalRol_22MS.ObtenerFamilias_22MS();

            bool existe = familias.Any(f => f.NombreFamilia_22MS.Equals(NombreFamilia, StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception("Ya existe una familia con ese nombre.");

            dalRol_22MS.CrearFamilia_22MS(NombreFamilia);
        }

        public void ModificarFamilia_22MS(int IdFamilia, string NombreFamilia)
        {
            if (IdFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            if (string.IsNullOrWhiteSpace(NombreFamilia))
                throw new Exception("Debe ingresar un nombre para la familia.");

            List<Familia_22MS> familias = dalRol_22MS.ObtenerFamilias_22MS();

            bool existe = familias.Any(f =>
                f.IdFamilia_22MS != IdFamilia &&
                f.NombreFamilia_22MS.Equals(NombreFamilia, StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception("Ya existe otra familia con ese nombre.");

            dalRol_22MS.ModificarFamilia_22MS(IdFamilia, NombreFamilia);
        }

        public void EliminarFamilia_22MS(int IdFamilia)
        {
            if (IdFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            dalRol_22MS.EliminarFamilia_22MS(IdFamilia);
        }

        public void AgregarFamiliaARol_22MS(int IdRol, int IdFamilia)
        {
            if (IdRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (IdFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            List<Familia_22MS> familiasDelRol = dalRol_22MS.ObtenerFamiliasPorRol_22MS(IdRol);

            bool yaExiste = familiasDelRol.Any(f => f.IdFamilia_22MS == IdFamilia);

            if (yaExiste)
                throw new Exception("La familia ya está asignada a este rol.");

            dalRol_22MS.AgregarFamiliaARol_22MS(IdRol, IdFamilia);
        }

        public void EliminarFamiliaDeRol_22MS(int IdRol, int IdFamilia)
        {
            if (IdRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (IdFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            dalRol_22MS.EliminarFamiliaDeRol_22MS(IdRol, IdFamilia);
        }

        public void AgregarPermisoAFamilia_22MS(int IdFamilia, int IdPermiso)
        {
            if (IdFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            if (IdPermiso <= 0)
                throw new Exception("Debe seleccionar un permiso.");

            List<Permiso_22MS> permisosCompletos = dalRol_22MS.ObtenerPermisosCompletosPorFamilia_22MS(IdFamilia);

            bool yaExiste = permisosCompletos.Any(p => p.IdPermiso_22MS == IdPermiso);

            if (yaExiste)
                throw new Exception("La familia ya posee ese permiso, ya sea directo o heredado por una subfamilia.");

            dalRol_22MS.AgregarPermisoAFamilia_22MS(IdFamilia, IdPermiso);
        }

        public void EliminarPermisoDeFamilia_22MS(int IdFamilia, int IdPermiso)
        {
            if (IdFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            if (IdPermiso <= 0)
                throw new Exception("Debe seleccionar un permiso.");

            dalRol_22MS.EliminarPermisoDeFamilia_22MS(IdFamilia, IdPermiso);
        }

        public void AgregarPermisoARol_22MS(int IdRol, int IdPermiso)
        {
            if (IdRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (IdPermiso <= 0)
                throw new Exception("Debe seleccionar un permiso.");

            List<Permiso_22MS> permisosRol = dalRol_22MS.ObtenerPermisosPorRol_22MS(IdRol);

            bool yaExiste = permisosRol.Any(p => p.IdPermiso_22MS == IdPermiso);

            if (yaExiste)
                throw new Exception("El rol ya posee ese permiso.");

            dalRol_22MS.AgregarPermisoARol_22MS(IdRol, IdPermiso);
        }

        public void QuitarPermisoDeRol_22MS(int IdRol, int IdPermiso)
        {
            if (IdRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (IdPermiso <= 0)
                throw new Exception("Debe seleccionar un permiso.");

            dalRol_22MS.QuitarPermisoDeRol_22MS(IdRol, IdPermiso);
        }

        public void AgregarFamiliaAFamilia_22MS(int IdFamiliaPadre, int IdFamiliaHija)
        {
            if (IdFamiliaPadre <= 0)
                throw new Exception("Debe seleccionar la familia padre.");

            if (IdFamiliaHija <= 0)
                throw new Exception("Debe seleccionar la familia hija.");

            if (IdFamiliaPadre == IdFamiliaHija)
                throw new Exception("Una familia no puede agregarse a sí misma.");

            List<Familia_22MS> familiasHijas = dalRol_22MS.ObtenerFamiliasHijas_22MS(IdFamiliaPadre);

            bool yaExiste = familiasHijas.Any(f => f.IdFamilia_22MS == IdFamiliaHija);

            if (yaExiste)
                throw new Exception("La familia hija ya está asignada a esta familia.");

            List<Permiso_22MS> permisosPadre = dalRol_22MS.ObtenerPermisosCompletosPorFamilia_22MS(IdFamiliaPadre);
            List<Permiso_22MS> permisosHija = dalRol_22MS.ObtenerPermisosCompletosPorFamilia_22MS(IdFamiliaHija);

            bool hayPermisosRepetidos = permisosHija.Any(ph =>
                permisosPadre.Any(pp => pp.IdPermiso_22MS == ph.IdPermiso_22MS));

            if (hayPermisosRepetidos)
                throw new Exception("No se puede agregar la subfamilia porque algunos de sus permisos ya están asignados a la familia padre.");

            dalRol_22MS.AgregarFamiliaAFamilia_22MS(IdFamiliaPadre, IdFamiliaHija);
        }

        public void QuitarFamiliaDeFamilia_22MS(int IdFamiliaPadre, int IdFamiliaHija)
        {
            if (IdFamiliaPadre <= 0)
                throw new Exception("Debe seleccionar la familia padre.");

            if (IdFamiliaHija <= 0)
                throw new Exception("Debe seleccionar la familia hija.");

            dalRol_22MS.QuitarFamiliaDeFamilia_22MS(IdFamiliaPadre, IdFamiliaHija);
        }

    }
}
