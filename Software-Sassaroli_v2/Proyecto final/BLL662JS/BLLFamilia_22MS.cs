using DAL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL_22MS
{
    public class BLLFamilia_22MS
    {
        private DALFamilia_22MS dalFamilia_22MS = new DALFamilia_22MS();
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

        public List<Familia_22MS> ObtenerFamilias_22MS()
        {
            return dalFamilia_22MS.ObtenerFamilias_22MS();
        }

        public List<Permiso_22MS> ObtenerPermisosPorFamilia_22MS(int idFamilia)
        {
            return dalFamilia_22MS.ObtenerPermisosPorFamilia_22MS(idFamilia);
        }

        public List<Familia_22MS> ObtenerFamiliasHijas_22MS(int idFamiliaPadre)
        {
            return dalFamilia_22MS.ObtenerFamiliasHijas_22MS(idFamiliaPadre);
        }

        public DataTable ObtenerResumenFamilia_22MS(int idFamilia)
        {
            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            return dalFamilia_22MS.ObtenerResumenFamilia_22MS(idFamilia);
        }

        public List<Permiso_22MS> ObtenerPermisosHeredadosPorFamilia_22MS(int idFamiliaPadre)
        {
            if (idFamiliaPadre <= 0)
                throw new Exception("Debe seleccionar una familia.");

            return dalFamilia_22MS.ObtenerPermisosHeredadosPorFamilia_22MS(idFamiliaPadre);
        }

        public List<Permiso_22MS> ObtenerPermisosCompletosPorFamilia_22MS(int idFamilia)
        {
            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            return dalFamilia_22MS.ObtenerPermisosCompletosPorFamilia_22MS(idFamilia);
        }

        public void CrearFamilia_22MS(string nombreFamilia)
        {
            if (string.IsNullOrWhiteSpace(nombreFamilia))
                throw new Exception("Debe ingresar un nombre para la familia.");

            List<Familia_22MS> familias = dalFamilia_22MS.ObtenerFamilias_22MS();

            bool existe = familias.Any(f =>
                f.NombreFamilia_22MS.Equals(nombreFamilia, StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception("Ya existe una familia con ese nombre.");

            dalFamilia_22MS.CrearFamilia_22MS(nombreFamilia);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Familias",
                "Creación de familia: " + nombreFamilia,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void ModificarFamilia_22MS(int idFamilia, string nombreFamilia)
        {
            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            if (string.IsNullOrWhiteSpace(nombreFamilia))
                throw new Exception("Debe ingresar un nombre para la familia.");

            List<Familia_22MS> familias = dalFamilia_22MS.ObtenerFamilias_22MS();

            bool existe = familias.Any(f =>
                f.IdFamilia_22MS != idFamilia &&
                f.NombreFamilia_22MS.Equals(nombreFamilia, StringComparison.OrdinalIgnoreCase));

            if (existe)
                throw new Exception("Ya existe otra familia con ese nombre.");

            dalFamilia_22MS.ModificarFamilia_22MS(idFamilia, nombreFamilia);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Familias",
                "Modificación de familia ID: " + idFamilia + " - Nuevo nombre: " + nombreFamilia,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void EliminarFamilia_22MS(int idFamilia)
        {
            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            if (dalFamilia_22MS.FamiliaEstaAsignadaARol_22MS(idFamilia))
                throw new Exception("No se puede eliminar la familia porque está asignada a uno o más roles.");

            if (dalFamilia_22MS.FamiliaTienePermisos_22MS(idFamilia))
                throw new Exception("No se puede eliminar la familia porque tiene permisos asignados.");

            if (dalFamilia_22MS.FamiliaTieneSubFamilias_22MS(idFamilia))
                throw new Exception("No se puede eliminar la familia porque tiene subfamilias asignadas.");

            if (dalFamilia_22MS.FamiliaEsSubFamilia_22MS(idFamilia))
                throw new Exception("No se puede eliminar la familia porque está asignada como subfamilia de otra familia.");

            dalFamilia_22MS.EliminarFamilia_22MS(idFamilia);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Familias",
                "Eliminación de familia ID: " + idFamilia,
                3
            );

            RecalcularDigitos_22MS();
        }

        public void AgregarPermisoAFamilia_22MS(int idFamilia, int idPermiso)
        {
            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            if (idPermiso <= 0)
                throw new Exception("Debe seleccionar un permiso.");

            List<Permiso_22MS> permisosCompletos = dalFamilia_22MS.ObtenerPermisosCompletosPorFamilia_22MS(idFamilia);

            bool yaExiste = permisosCompletos.Any(p => p.IdPermiso_22MS == idPermiso);

            if (yaExiste)
                throw new Exception("La familia ya posee ese permiso, ya sea directo o heredado por una subfamilia.");

            dalFamilia_22MS.AgregarPermisoAFamilia_22MS(idFamilia, idPermiso);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Familias",
                "Asignación de permiso ID " + idPermiso + " a la familia ID " + idFamilia,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void EliminarPermisoDeFamilia_22MS(int idFamilia, int idPermiso)
        {
            if (idFamilia <= 0)
                throw new Exception("Debe seleccionar una familia.");

            if (idPermiso <= 0)
                throw new Exception("Debe seleccionar un permiso.");

            dalFamilia_22MS.EliminarPermisoDeFamilia_22MS(idFamilia, idPermiso);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Familias",
                "Se quitó el permiso ID " + idPermiso + " de la familia ID " + idFamilia,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void AgregarFamiliaAFamilia_22MS(int idFamiliaPadre, int idFamiliaHija)
        {
            if (idFamiliaPadre <= 0)
                throw new Exception("Debe seleccionar la familia padre.");

            if (idFamiliaHija <= 0)
                throw new Exception("Debe seleccionar la familia hija.");

            if (idFamiliaPadre == idFamiliaHija)
                throw new Exception("Una familia no puede agregarse a sí misma.");

            List<Familia_22MS> familiasHijas = dalFamilia_22MS.ObtenerFamiliasHijas_22MS(idFamiliaPadre);

            bool yaExiste = familiasHijas.Any(f => f.IdFamilia_22MS == idFamiliaHija);

            if (yaExiste)
                throw new Exception("La familia hija ya está asignada a esta familia.");

            List<Permiso_22MS> permisosPadre = dalFamilia_22MS.ObtenerPermisosCompletosPorFamilia_22MS(idFamiliaPadre);
            List<Permiso_22MS> permisosHija = dalFamilia_22MS.ObtenerPermisosCompletosPorFamilia_22MS(idFamiliaHija);

            bool hayPermisosRepetidos = permisosHija.Any(permisoHija =>
                permisosPadre.Any(permisoPadre => permisoPadre.IdPermiso_22MS == permisoHija.IdPermiso_22MS));

            if (hayPermisosRepetidos)
                throw new Exception("No se puede agregar la subfamilia porque algunos de sus permisos ya están asignados a la familia padre.");

            dalFamilia_22MS.AgregarFamiliaAFamilia_22MS(idFamiliaPadre, idFamiliaHija);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Familias",
                "Asignación de subfamilia ID " + idFamiliaHija + " a la familia ID " + idFamiliaPadre,
                2
            );

            RecalcularDigitos_22MS();
        }

        public void QuitarFamiliaDeFamilia_22MS(int idFamiliaPadre, int idFamiliaHija)
        {
            if (idFamiliaPadre <= 0)
                throw new Exception("Debe seleccionar la familia padre.");

            if (idFamiliaHija <= 0)
                throw new Exception("Debe seleccionar la familia hija.");

            dalFamilia_22MS.QuitarFamiliaDeFamilia_22MS(idFamiliaPadre, idFamiliaHija);

            bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                ObtenerUsuarioActual_22MS(),
                "Familias",
                "Se quitó la subfamilia ID " + idFamiliaHija + " de la familia ID " + idFamiliaPadre,
                2
            );

            RecalcularDigitos_22MS();

        }
    }
}