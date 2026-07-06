using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_22MS
{
    public class DALFamilia_22MS
    {
        public int CrearFamilia_22MS(string nombreFamilia)
        {
            string query = @"
                           insert into Familia_22MS (NombreFamilia_22MS)
                           values (@NombreFamilia_22MS);

                           select cast(scope_identity() as int);";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@NombreFamilia_22MS", nombreFamilia);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void ModificarFamilia_22MS(int idFamilia, string nombreFamilia)
        {
            string query = @"
                           UPDATE Familia_22MS
                           SET NombreFamilia_22MS = @NombreFamilia_22MS
                           WHERE IdFamilia_22MS = @IdFamilia_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);
            sqlCommand.Parameters.AddWithValue("@NombreFamilia_22MS", nombreFamilia);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void EliminarFamilia_22MS(int idFamilia)
        {
            string query = @"
                           DELETE FROM RolFamilia_22MS
                           WHERE IdFamilia_22MS = @IdFamilia_22MS;

                           DELETE FROM FamiliaPermiso_22MS
                           WHERE IdFamilia_22MS = @IdFamilia_22MS;

                           DELETE FROM FamiliaFamilia_22MS
                           WHERE IdFamiliaPadre_22MS = @IdFamilia_22MS
                              OR IdFamiliaHijo_22MS = @IdFamilia_22MS;

                           DELETE FROM Familia_22MS
                           WHERE IdFamilia_22MS = @IdFamilia_22MS;";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public List<Familia_22MS> ObtenerFamilias_22MS()
        {
            string query = "SELECT * FROM Familia_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            DataTable tablaFamilias = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            List<Familia_22MS> familias = new List<Familia_22MS>();

            foreach (DataRow fila in tablaFamilias.Rows)
            {
                familias.Add(new Familia_22MS
                {
                    IdFamilia_22MS = Convert.ToInt32(fila["IdFamilia_22MS"]),
                    NombreFamilia_22MS = fila["NombreFamilia_22MS"].ToString()
                });
            }

            return familias;
        }

        public List<Permiso_22MS> ObtenerPermisosPorFamilia_22MS(int idFamilia)
        {
            string query = @"
                           SELECT p.IdPermiso_22MS, p.NombrePermiso_22MS
                           FROM FamiliaPermiso_22MS fp
                           INNER JOIN Permiso_22MS p 
                               ON fp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE fp.IdFamilia_22MS = @IdFamilia_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            DataTable tablaPermisos = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            List<Permiso_22MS> permisos = new List<Permiso_22MS>();

            foreach (DataRow fila in tablaPermisos.Rows)
            {
                permisos.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(fila["IdPermiso_22MS"]),
                    NombrePermiso_22MS = fila["NombrePermiso_22MS"].ToString()
                });
            }

            return permisos;
        }

        public List<Familia_22MS> ObtenerFamiliasHijas_22MS(int idFamiliaPadre)
        {
            string query = @"
                           SELECT f.IdFamilia_22MS, f.NombreFamilia_22MS
                           FROM FamiliaFamilia_22MS ff
                           INNER JOIN Familia_22MS f
                               ON ff.IdFamiliaHijo_22MS = f.IdFamilia_22MS
                           WHERE ff.IdFamiliaPadre_22MS = @IdFamiliaPadre_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamiliaPadre_22MS", idFamiliaPadre);

            DataTable tablaFamilias = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            List<Familia_22MS> familias = new List<Familia_22MS>();

            foreach (DataRow fila in tablaFamilias.Rows)
            {
                familias.Add(new Familia_22MS
                {
                    IdFamilia_22MS = Convert.ToInt32(fila["IdFamilia_22MS"]),
                    NombreFamilia_22MS = fila["NombreFamilia_22MS"].ToString()
                });
            }

            return familias;
        }

        public DataTable ObtenerResumenFamilia_22MS(int idFamilia)
        {
            string query = @"
                           SELECT 
                               fp.NombreFamilia_22MS AS Familia,
                               'Permiso directo' AS SubFamilia,
                               p.NombrePermiso_22MS AS Permiso
                           FROM Familia_22MS fp
                           INNER JOIN FamiliaPermiso_22MS fperm
                               ON fp.IdFamilia_22MS = fperm.IdFamilia_22MS
                           INNER JOIN Permiso_22MS p
                               ON fperm.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE fp.IdFamilia_22MS = @IdFamilia_22MS

                           UNION

                           SELECT
                               fpadre.NombreFamilia_22MS AS Familia,
                               fhija.NombreFamilia_22MS AS SubFamilia,
                               p.NombrePermiso_22MS AS Permiso
                           FROM FamiliaFamilia_22MS ff
                           INNER JOIN Familia_22MS fpadre
                               ON ff.IdFamiliaPadre_22MS = fpadre.IdFamilia_22MS
                           INNER JOIN Familia_22MS fhija
                               ON ff.IdFamiliaHijo_22MS = fhija.IdFamilia_22MS
                           INNER JOIN FamiliaPermiso_22MS fp
                               ON fhija.IdFamilia_22MS = fp.IdFamilia_22MS
                           INNER JOIN Permiso_22MS p
                               ON fp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE fpadre.IdFamilia_22MS = @IdFamilia_22MS

                           ORDER BY SubFamilia, Permiso;";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);
        }

        public List<Permiso_22MS> ObtenerPermisosHeredadosPorFamilia_22MS(int idFamiliaPadre)
        {
            string query = @"
                           SELECT DISTINCT p.IdPermiso_22MS, p.NombrePermiso_22MS
                           FROM FamiliaFamilia_22MS ff
                           INNER JOIN FamiliaPermiso_22MS fp
                               ON ff.IdFamiliaHijo_22MS = fp.IdFamilia_22MS
                           INNER JOIN Permiso_22MS p
                               ON fp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE ff.IdFamiliaPadre_22MS = @IdFamiliaPadre_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamiliaPadre_22MS", idFamiliaPadre);

            DataTable tablaPermisos = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            List<Permiso_22MS> permisos = new List<Permiso_22MS>();

            foreach (DataRow fila in tablaPermisos.Rows)
            {
                permisos.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(fila["IdPermiso_22MS"]),
                    NombrePermiso_22MS = fila["NombrePermiso_22MS"].ToString()
                });
            }

            return permisos;
        }

        public List<Permiso_22MS> ObtenerPermisosCompletosPorFamilia_22MS(int idFamilia)
        {
            string query = @"
                           SELECT DISTINCT p.IdPermiso_22MS, p.NombrePermiso_22MS
                           FROM FamiliaPermiso_22MS fp
                           INNER JOIN Permiso_22MS p
                               ON fp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE fp.IdFamilia_22MS = @IdFamilia_22MS

                           UNION

                           SELECT DISTINCT p.IdPermiso_22MS, p.NombrePermiso_22MS
                           FROM FamiliaFamilia_22MS ff
                           INNER JOIN FamiliaPermiso_22MS fp
                               ON ff.IdFamiliaHijo_22MS = fp.IdFamilia_22MS
                           INNER JOIN Permiso_22MS p
                               ON fp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE ff.IdFamiliaPadre_22MS = @IdFamilia_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            DataTable tablaPermisos = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            List<Permiso_22MS> permisos = new List<Permiso_22MS>();

            foreach (DataRow fila in tablaPermisos.Rows)
            {
                permisos.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(fila["IdPermiso_22MS"]),
                    NombrePermiso_22MS = fila["NombrePermiso_22MS"].ToString()
                });
            }

            return permisos;
        }

        public void AgregarPermisoAFamilia_22MS(int idFamilia, int idPermiso)
        {
            string query = @"
                           INSERT INTO FamiliaPermiso_22MS (IdFamilia_22MS, IdPermiso_22MS)
                           VALUES (@IdFamilia_22MS, @IdPermiso_22MS)";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);
            sqlCommand.Parameters.AddWithValue("@IdPermiso_22MS", idPermiso);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void EliminarPermisoDeFamilia_22MS(int idFamilia, int idPermiso)
        {
            string query = @"
                           DELETE FROM FamiliaPermiso_22MS
                           WHERE IdFamilia_22MS = @IdFamilia_22MS
                           AND IdPermiso_22MS = @IdPermiso_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);
            sqlCommand.Parameters.AddWithValue("@IdPermiso_22MS", idPermiso);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void AgregarFamiliaAFamilia_22MS(int idFamiliaPadre, int idFamiliaHijo)
        {
            string query = @"
                           INSERT INTO FamiliaFamilia_22MS
                           (IdFamiliaPadre_22MS, IdFamiliaHijo_22MS)
                           VALUES
                           (@IdFamiliaPadre_22MS, @IdFamiliaHijo_22MS)";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamiliaPadre_22MS", idFamiliaPadre);
            sqlCommand.Parameters.AddWithValue("@IdFamiliaHijo_22MS", idFamiliaHijo);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void QuitarFamiliaDeFamilia_22MS(int idFamiliaPadre, int idFamiliaHijo)
        {
            string query = @"
                           DELETE FROM FamiliaFamilia_22MS
                           WHERE IdFamiliaPadre_22MS = @IdFamiliaPadre_22MS
                           AND IdFamiliaHijo_22MS = @IdFamiliaHijo_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamiliaPadre_22MS", idFamiliaPadre);
            sqlCommand.Parameters.AddWithValue("@IdFamiliaHijo_22MS", idFamiliaHijo);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public bool FamiliaEstaAsignadaARol_22MS(int idFamilia)
        {
            string query = @"
                           SELECT COUNT(*) 
                           FROM RolFamilia_22MS
                           WHERE IdFamilia_22MS = @IdFamilia_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            DataTable tablaFamilias = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            return Convert.ToInt32(tablaFamilias.Rows[0][0]) > 0;
        }

        public bool FamiliaTienePermisos_22MS(int idFamilia)
        {
            string query = @"
                           SELECT COUNT(*) 
                           FROM FamiliaPermiso_22MS
                           WHERE IdFamilia_22MS = @IdFamilia_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            DataTable tablaPermisos = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            return Convert.ToInt32(tablaPermisos.Rows[0][0]) > 0;
        }

        public bool FamiliaTieneSubFamilias_22MS(int idFamilia)
        {
            string query = @"
                           SELECT COUNT(*) 
                           FROM FamiliaFamilia_22MS
                           WHERE IdFamiliaPadre_22MS = @IdFamilia_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            DataTable tablaFamilias = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            return Convert.ToInt32(tablaFamilias.Rows[0][0]) > 0;
        }

        public bool FamiliaEsSubFamilia_22MS(int idFamilia)
        {
            string query = @"
                           SELECT COUNT(*) 
                           FROM FamiliaFamilia_22MS
                           WHERE IdFamiliaHijo_22MS = @IdFamilia_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            DataTable tablaFamilias = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            return Convert.ToInt32(tablaFamilias.Rows[0][0]) > 0;
        }
    }
}