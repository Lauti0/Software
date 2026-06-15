using DAL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL_22MS
{
    public class BLLRol_22MS
    {
        private DALRol_22MS dalRol_22MS = new DALRol_22MS();
        private BLLBitacoraEvento_22MS bllBitacoraEvento_22MS = new BLLBitacoraEvento_22MS();

        private void RecalcularDigitos_22MS()
        {
            BLLDigitoVerificador_22MS bllDigito = new BLLDigitoVerificador_22MS();
            bllDigito.RecalcularTodos_22MS();
        }

        private string ObtenerUsuarioActual_22MS()
        {
            if (SessionManager_22MS.GetInstance_22MS().Usuario_22MS != null)
                return SessionManager_22MS.GetInstance_22MS().Usuario_22MS.Username_22MS;

            return "Sistema";
        }

        public List<Rol_22MS> ObtenerRoles_22MS()
        {
            return dalRol_22MS.ObtenerRoles_22MS();
        }

        public List<Familia_22MS> ObtenerFamiliasPorRol_22MS(int idRol)
        {
            return dalRol_22MS.ObtenerFamiliasPorRol_22MS(idRol);
        }

        public List<Permiso_22MS> ObtenerPermisosPorRol_22MS(int idRol)
        {
            return dalRol_22MS.ObtenerPermisosPorRol_22MS(idRol);
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

        public void CrearRol_22MS(string nombreRol)
        {
            if (string.IsNullOrWhiteSpace(nombreRol))
                throw new Exception("Debe ingresar un nombre para el rol.");

            List<Rol_22MS> roles = dalRol_22MS.ObtenerRoles_22MS();

            bool existe = roles.Any(r =>
                r.NombreRol_22MS.Equals(nombreRol, StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception("Ya existe un rol con ese nombre.");

            int idRolNuevo = dalRol_22MS.CrearRol_22MS(nombreRol);

            // Permisos básicos por defecto
            // 43 Login
            // 44 Logout
            // 45 Cambiar clave
            // 46 Cambiar idioma

            dalRol_22MS.AgregarPermisoARol_22MS(idRolNuevo, 43);
            dalRol_22MS.AgregarPermisoARol_22MS(idRolNuevo, 44);
            dalRol_22MS.AgregarPermisoARol_22MS(idRolNuevo, 45);
            dalRol_22MS.AgregarPermisoARol_22MS(idRolNuevo, 46);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Roles",
                "Creación de rol: " + nombreRol,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void ModificarRol_22MS(int idRol, string nombreRol)
        {
            if (idRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (string.IsNullOrWhiteSpace(nombreRol))
                throw new Exception("Debe ingresar un nombre para el rol.");

            List<Rol_22MS> roles = dalRol_22MS.ObtenerRoles_22MS();

            bool existe = roles.Any(r =>
                r.IdRol_22MS != idRol &&
                r.NombreRol_22MS.Equals(nombreRol, StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception("Ya existe otro rol con ese nombre.");

            dalRol_22MS.ModificarRol_22MS(idRol, nombreRol);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Roles",
                "Modificación de rol ID: " + idRol + " - Nuevo nombre: " + nombreRol,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void EliminarRol_22MS(int idRol)
        {
            if (idRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (idRol == 1)
                throw new Exception("No se puede eliminar el rol Administrador.");

            if (dalRol_22MS.RolEstaAsignadoAUsuario_22MS(idRol))
                throw new Exception("No se puede eliminar el rol porque está asignado a uno o más usuarios.");

            //if (dalRol_22MS.RolTieneFamilias_22MS(idRol))
                //throw new Exception("No se puede eliminar el rol porque tiene familias asignadas.");

            //if (dalRol_22MS.RolTienePermisos_22MS(idRol))
                //throw new Exception("No se puede eliminar el rol porque tiene permisos asignados.");

            dalRol_22MS.EliminarRol_22MS(idRol);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Roles",
                "Eliminación de rol ID: " + idRol,
                3
            );

            RecalcularDigitos_22MS();
        }

        public void AgregarFamiliaARol_22MS(int idRol, int idFamilia)
        {
            if (idRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            List<Familia_22MS> familiasDelRol = dalRol_22MS.ObtenerFamiliasPorRol_22MS(idRol);

            bool familiaYaAsignada = familiasDelRol.Any(f => f.IdFamilia_22MS == idFamilia);

            if (familiaYaAsignada)
                throw new Exception("La familia ya está asignada a este rol.");

            List<Permiso_22MS> permisosDirectosRol = dalRol_22MS.ObtenerPermisosDirectosPorRol_22MS(idRol);

            DALFamilia_22MS dalFamilia_22MS = new DALFamilia_22MS();

            List<Permiso_22MS> permisosFamilia = dalFamilia_22MS.ObtenerPermisosCompletosPorFamilia_22MS(idFamilia);

            bool tienePermisosRepetidos = permisosDirectosRol.Any(permisoRol =>
                permisosFamilia.Any(permisoFamilia => permisoFamilia.IdPermiso_22MS == permisoRol.IdPermiso_22MS));

            if (tienePermisosRepetidos)
                throw new Exception("No se puede asignar la familia porque el rol ya posee permisos directos incluidos en esa familia.");

            dalRol_22MS.AgregarFamiliaARol_22MS(idRol, idFamilia);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Roles",
                "Asignación de familia ID " + idFamilia + " al rol ID " + idRol,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void EliminarFamiliaDeRol_22MS(int idRol, int idFamilia)
        {
            if (idRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            dalRol_22MS.EliminarFamiliaDeRol_22MS(idRol, idFamilia);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Roles",
                "Se quitó la familia ID " + idFamilia + " del rol ID " + idRol,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void AgregarPermisoARol_22MS(int idRol, int idPermiso)
        {
            if (idRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (idPermiso <= 0)
                throw new Exception("Debe seleccionar un permiso.");

            List<Permiso_22MS> permisosRol = dalRol_22MS.ObtenerPermisosPorRol_22MS(idRol);

            bool yaExiste = permisosRol.Any(p => p.IdPermiso_22MS == idPermiso);

            if (yaExiste)
                throw new Exception("El rol ya posee ese permiso, ya sea directo o heredado por una familia.");

            dalRol_22MS.AgregarPermisoARol_22MS(idRol, idPermiso);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Roles",
                "Asignación de permiso directo ID " + idPermiso + " al rol ID " + idRol,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void QuitarPermisoDeRol_22MS(int idRol, int idPermiso)
        {
            if (idRol <= 0)
                throw new Exception("Debe seleccionar un rol.");

            if (idPermiso <= 0)
                throw new Exception("Debe seleccionar un permiso.");

            dalRol_22MS.QuitarPermisoDeRol_22MS(idRol, idPermiso);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Roles",
                "Se quitó el permiso directo ID " + idPermiso + " del rol ID " + idRol,
                2
            );

            RecalcularDigitos_22MS();
        }
    }
}