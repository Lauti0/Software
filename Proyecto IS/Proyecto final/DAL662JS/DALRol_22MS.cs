using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_22MS
{
    public class DALRol_22MS
    {
        public int CrearRol_22MS(string nombreRol)
        {
            string query = @"
                           INSERT INTO Rol_22MS (NombreRol_22MS)
                           VALUES (@NombreRol_22MS);

                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@NombreRol_22MS", nombreRol);

            DataTable tablaRoles = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            return Convert.ToInt32(tablaRoles.Rows[0][0]);
        }

        public void ModificarRol_22MS(int idRol, string nombreRol)
        {
            string query = @"
                           UPDATE Rol_22MS
                           SET NombreRol_22MS = @NombreRol_22MS
                           WHERE IdRol_22MS = @IdRol_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);
            sqlCommand.Parameters.AddWithValue("@NombreRol_22MS", nombreRol);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void EliminarRol_22MS(int idRol)
        {
            string query = @"
                           DELETE FROM RolFamilia_22MS
                           WHERE IdRol_22MS = @IdRol_22MS;

                           DELETE FROM RolPermiso_22MS
                           WHERE IdRol_22MS = @IdRol_22MS;

                           DELETE FROM Rol_22MS
                           WHERE IdRol_22MS = @IdRol_22MS;";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public List<Rol_22MS> ObtenerRoles_22MS()
        {
            string query = "SELECT * FROM Rol_22MS ORDER BY IdRol_22MS ASC";

            SqlCommand sqlCommand = new SqlCommand(query);

            DataTable tablaRoles = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            List<Rol_22MS> roles = new List<Rol_22MS>();

            foreach (DataRow fila in tablaRoles.Rows)
            {
                roles.Add(new Rol_22MS
                {
                    IdRol_22MS = Convert.ToInt32(fila["IdRol_22MS"]),
                    NombreRol_22MS = fila["NombreRol_22MS"].ToString()
                });
            }

            return roles;
        }

        public List<Familia_22MS> ObtenerFamiliasPorRol_22MS(int idRol)
        {
            string query = @"
                           SELECT f.IdFamilia_22MS, f.NombreFamilia_22MS 
                           FROM RolFamilia_22MS rf
                           INNER JOIN Familia_22MS f 
                               ON rf.IdFamilia_22MS = f.IdFamilia_22MS
                           WHERE rf.IdRol_22MS = @IdRol_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);

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

        public List<Permiso_22MS> ObtenerPermisosPorRol_22MS(int idRol)
        {
            string query = @"
                           SELECT DISTINCT p.IdPermiso_22MS, p.NombrePermiso_22MS
                           FROM RolFamilia_22MS rf
                           INNER JOIN FamiliaPermiso_22MS fp 
                               ON rf.IdFamilia_22MS = fp.IdFamilia_22MS
                           INNER JOIN Permiso_22MS p 
                               ON fp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE rf.IdRol_22MS = @IdRol_22MS

                           UNION

                           SELECT DISTINCT p.IdPermiso_22MS, p.NombrePermiso_22MS
                           FROM RolPermiso_22MS rp
                           INNER JOIN Permiso_22MS p 
                               ON rp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE rp.IdRol_22MS = @IdRol_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);

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

        public List<Permiso_22MS> ObtenerPermisosDirectosPorRol_22MS(int idRol)
        {
            string query = @"
                           SELECT p.IdPermiso_22MS, p.NombrePermiso_22MS
                           FROM RolPermiso_22MS rp
                           INNER JOIN Permiso_22MS p
                               ON rp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE rp.IdRol_22MS = @IdRol_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);

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

        public DataTable ObtenerRolFamiliaPermiso_22MS(int idRol)
        {
            string query = @"
                           SELECT 
                               r.NombreRol_22MS AS Rol,
                               f.NombreFamilia_22MS AS Familia,
                               p.NombrePermiso_22MS AS Permiso
                           FROM Rol_22MS r
                           INNER JOIN RolFamilia_22MS rf
                               ON r.IdRol_22MS = rf.IdRol_22MS
                           INNER JOIN Familia_22MS f
                               ON rf.IdFamilia_22MS = f.IdFamilia_22MS
                           INNER JOIN FamiliaPermiso_22MS fp
                               ON f.IdFamilia_22MS = fp.IdFamilia_22MS
                           INNER JOIN Permiso_22MS p
                               ON fp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE r.IdRol_22MS = @IdRol_22MS

                           UNION

                           SELECT
                               r.NombreRol_22MS AS Rol,
                               'Permiso directo' AS Familia,
                               p.NombrePermiso_22MS AS Permiso
                           FROM Rol_22MS r
                           INNER JOIN RolPermiso_22MS rp
                               ON r.IdRol_22MS = rp.IdRol_22MS
                           INNER JOIN Permiso_22MS p
                               ON rp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE r.IdRol_22MS = @IdRol_22MS

                           ORDER BY Familia, Permiso;";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);
        }

        public void AgregarFamiliaARol_22MS(int idRol, int idFamilia)
        {
            string query = @"
                           INSERT INTO RolFamilia_22MS (IdRol_22MS, IdFamilia_22MS)
                           VALUES (@IdRol_22MS, @IdFamilia_22MS)";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);
            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void EliminarFamiliaDeRol_22MS(int idRol, int idFamilia)
        {
            string query = @"
                           DELETE FROM RolFamilia_22MS
                           WHERE IdRol_22MS = @IdRol_22MS
                           AND IdFamilia_22MS = @IdFamilia_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);
            sqlCommand.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void AgregarPermisoARol_22MS(int idRol, int idPermiso)
        {
            string query = @"
                           INSERT INTO RolPermiso_22MS (IdRol_22MS, IdPermiso_22MS)
                           VALUES (@IdRol_22MS, @IdPermiso_22MS)";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);
            sqlCommand.Parameters.AddWithValue("@IdPermiso_22MS", idPermiso);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void QuitarPermisoDeRol_22MS(int idRol, int idPermiso)
        {
            string query = @"
                           DELETE FROM RolPermiso_22MS
                           WHERE IdRol_22MS = @IdRol_22MS
                           AND IdPermiso_22MS = @IdPermiso_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);
            sqlCommand.Parameters.AddWithValue("@IdPermiso_22MS", idPermiso);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public bool RolEstaAsignadoAUsuario_22MS(int idRol)
        {
            string query = @"
                           SELECT COUNT(*) 
                           FROM Usuario_22MS
                           WHERE IdRol_22MS = @IdRol_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);

            DataTable tablaUsuarios = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            return Convert.ToInt32(tablaUsuarios.Rows[0][0]) > 0;
        }

        public bool RolTieneFamilias_22MS(int idRol)
        {
            string query = @"
                           SELECT COUNT(*) 
                           FROM RolFamilia_22MS
                           WHERE IdRol_22MS = @IdRol_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);

            DataTable tablaFamilias = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            return Convert.ToInt32(tablaFamilias.Rows[0][0]) > 0;
        }

        public bool RolTienePermisos_22MS(int idRol)
        {
            string query = @"
                           SELECT COUNT(*) 
                           FROM RolPermiso_22MS
                           WHERE IdRol_22MS = @IdRol_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);

            DataTable tablaPermisos = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            return Convert.ToInt32(tablaPermisos.Rows[0][0]) > 0;
        }
    }
}