using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_22MS
{
    public class DALRol_22MS
    {
        public void CrearRol_22MS(string NombreRol)
        {
            string query = @"
                           INSERT INTO Rol_22MS (NombreRol_22MS)
                           VALUES (@NombreRol_22MS)";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@NombreRol_22MS", NombreRol);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void ModificarRol_22MS(int IdRol, string NombreRol)
        {
            string query = @"
        UPDATE Rol_22MS
        SET NombreRol_22MS = @NombreRol_22MS
        WHERE IdRol_22MS = @IdRol_22MS";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdRol_22MS", IdRol);
            cmd.Parameters.AddWithValue("@NombreRol_22MS", NombreRol);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void EliminarRol_22MS(int IdRol)
        {
            string query = @"
                           DELETE FROM RolFamilia_22MS
                           WHERE IdRol_22MS = @IdRol_22MS;

                           DELETE FROM RolPermiso_22MS
                           WHERE IdRol_22MS = @IdRol_22MS;

                           DELETE FROM Rol_22MS
                           WHERE IdRol_22MS = @IdRol_22MS;";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdRol_22MS", IdRol);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void CrearFamilia_22MS(string NombreFamilia)
        {
            string query = @"
                           INSERT INTO Familia_22MS (NombreFamilia_22MS)
                           VALUES (@NombreFamilia_22MS)";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@NombreFamilia_22MS", NombreFamilia);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void ModificarFamilia_22MS(int IdFamilia, string NombreFamilia)
        {
            string query = @"
                           UPDATE Familia_22MS
                           SET NombreFamilia_22MS = @NombreFamilia_22MS
                           WHERE IdFamilia_22MS = @IdFamilia_22MS";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdFamilia_22MS", IdFamilia);
            cmd.Parameters.AddWithValue("@NombreFamilia_22MS", NombreFamilia);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void EliminarFamilia_22MS(int IdFamilia)
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

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdFamilia_22MS", IdFamilia);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }


        public List<Rol_22MS> ObtenerRoles_22MS()
        {
            string query = "SELECT * FROM Rol_22MS";

            SqlCommand cmd = new SqlCommand(query);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            List<Rol_22MS> lista = new List<Rol_22MS>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Rol_22MS
                {
                    IdRol_22MS =Convert.ToInt32(row["IdRol_22MS"]),

                    NombreRol_22MS =row["NombreRol_22MS"].ToString()
                });
            }

            return lista;
        }

        public List<Familia_22MS> ObtenerFamilias_22MS()
        {
            string query = "SELECT * FROM Familia_22MS";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
            List<Familia_22MS> lista = new List<Familia_22MS>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Familia_22MS
                {
                    IdFamilia_22MS = Convert.ToInt32(row["IdFamilia_22MS"]),
                    NombreFamilia_22MS = row["NombreFamilia_22MS"].ToString()
                });
            }
            return lista;
        }

        public List<Permiso_22MS> ObtenerPermisos_22MS()
        {
            string query = "SELECT * FROM Permiso_22MS";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
            List<Permiso_22MS> lista = new List<Permiso_22MS>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(row["IdPermiso_22MS"]),
                    NombrePermiso_22MS = row["NombrePermiso_22MS"].ToString()
                });
            }
            return lista;
        }

        public List<Familia_22MS> ObtenerFamiliasPorRol_22MS(int IdRol) 
        {
            string query = @"SELECT f.IdFamilia_22MS, f.NombreFamilia_22MS 
                            FROM RolFamilia_22MS rf
                            INNER JOIN Familia_22MS f ON rf.IdFamilia_22MS = f.IdFamilia_22MS
                            WHERE rf.IdRol_22MS = @IdRol_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdRol_22MS", IdRol);
            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
            List<Familia_22MS> lista = new List<Familia_22MS>();
            foreach(DataRow row in dt.Rows)
            {
                lista.Add(new Familia_22MS
                {
                    IdFamilia_22MS = Convert.ToInt32(row["IdFamilia_22MS"]),
                    NombreFamilia_22MS = row["NombreFamilia_22MS"].ToString()
                });
            }

            return lista;
        }

        public List<Permiso_22MS> ObtenerPermisosPorFamilia_22MS(int IdFamilia)
        {
            string query = @"SELECT p.IdPermiso_22MS, p.NombrePermiso_22MS
                             FROM FamiliaPermiso_22MS fp
                             INNER JOIN Permiso_22MS p ON fp.IdPermiso_22MS = p.IdPermiso_22MS
                             WHERE fp.IdFamilia_22MS = @IdFamilia_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdFamilia_22MS", IdFamilia);
            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
            List<Permiso_22MS> lista = new List<Permiso_22MS>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(row["IdPermiso_22MS"]),
                    NombrePermiso_22MS = row["NombrePermiso_22MS"].ToString()
                });
            }

            return lista;
        }

        public List<Permiso_22MS> ObtenerPermisosPorRol_22MS(int IdRol)
        {
            string query = @"SELECT DISTINCT p.IdPermiso_22MS, p.NombrePermiso_22MS
                            FROM RolFamilia_22MS rf
                            INNER JOIN FamiliaPermiso_22MS fp ON rf.IdFamilia_22MS = fp.IdFamilia_22MS
                            INNER JOIN Permiso_22MS p ON fp.IdPermiso_22MS = p.IdPermiso_22MS
                            WHERE rf.IdRol_22MS = @IdRol_22MS

                            UNION

                            SELECT DISTINCT p.IdPermiso_22MS, p.NombrePermiso_22MS
                            FROM RolPermiso_22MS rp
                            INNER JOIN Permiso_22MS p ON rp.IdPermiso_22MS = p.IdPermiso_22MS
                            WHERE rp.IdRol_22MS = @IdRol_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdRol_22MS", IdRol);
            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
            List<Permiso_22MS> lista = new List<Permiso_22MS>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(row["IdPermiso_22MS"]),
                    NombrePermiso_22MS = row["NombrePermiso_22MS"].ToString()
                });
            }

            return lista;
        }

        public List<Familia_22MS> ObtenerFamiliasHijas_22MS(int IdFamiliaPadre)
        {
            string query = @"
                           SELECT f.IdFamilia_22MS, f.NombreFamilia_22MS
                           FROM FamiliaFamilia_22MS ff
                           INNER JOIN Familia_22MS f
                               ON ff.IdFamiliaHijo_22MS = f.IdFamilia_22MS
                           WHERE ff.IdFamiliaPadre_22MS = @IdFamiliaPadre_22MS";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdFamiliaPadre_22MS", IdFamiliaPadre);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            List<Familia_22MS> lista = new List<Familia_22MS>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Familia_22MS
                {
                    IdFamilia_22MS = Convert.ToInt32(row["IdFamilia_22MS"]),
                    NombreFamilia_22MS = row["NombreFamilia_22MS"].ToString()
                });
            }

            return lista;
        }

        public List<Permiso_22MS> ObtenerPermisosDirectosPorRol_22MS(int idRol)
        {
            string query = @"
                           SELECT p.IdPermiso_22MS, p.NombrePermiso_22MS
                           FROM RolPermiso_22MS rp
                           INNER JOIN Permiso_22MS p
                               ON rp.IdPermiso_22MS = p.IdPermiso_22MS
                           WHERE rp.IdRol_22MS = @IdRol_22MS";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdRol_22MS", idRol);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            List<Permiso_22MS> lista = new List<Permiso_22MS>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(row["IdPermiso_22MS"]),
                    NombrePermiso_22MS = row["NombrePermiso_22MS"].ToString()
                });
            }

            return lista;
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

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdRol_22MS", idRol);

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
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

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
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

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdFamiliaPadre_22MS", idFamiliaPadre);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            List<Permiso_22MS> lista = new List<Permiso_22MS>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(row["IdPermiso_22MS"]),
                    NombrePermiso_22MS = row["NombrePermiso_22MS"].ToString()
                });
            }

            return lista;
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

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdFamilia_22MS", idFamilia);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            List<Permiso_22MS> lista = new List<Permiso_22MS>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Permiso_22MS
                {
                    IdPermiso_22MS = Convert.ToInt32(row["IdPermiso_22MS"]),
                    NombrePermiso_22MS = row["NombrePermiso_22MS"].ToString()
                });
            }

            return lista;
        }


        public void AgregarFamiliaARol_22MS(int IdRol, int IdFamilia)
        {
            string query = @"
                           INSERT INTO RolFamilia_22MS (IdRol_22MS, IdFamilia_22MS)
                           VALUES (@IdRol_22MS, @IdFamilia_22MS)";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdRol_22MS", IdRol);
            cmd.Parameters.AddWithValue("@IdFamilia_22MS", IdFamilia);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void EliminarFamiliaDeRol_22MS(int IdRol, int IdFamilia)
        {
            string query = @"
                           DELETE FROM RolFamilia_22MS
                           WHERE IdRol_22MS = @IdRol_22MS
                           AND IdFamilia_22MS = @IdFamilia_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdRol_22MS", IdRol);
            cmd.Parameters.AddWithValue("@IdFamilia_22MS", IdFamilia);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void AgregarPermisoAFamilia_22MS(int IdFamilia, int IdPermiso)
        {
            string query = @"
                           INSERT INTO FamiliaPermiso_22MS (IdFamilia_22MS, IdPermiso_22MS)
                           VALUES (@IdFamilia_22MS, @IdPermiso_22MS)";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdFamilia_22MS", IdFamilia);
            cmd.Parameters.AddWithValue("@IdPermiso_22MS", IdPermiso);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void EliminarPermisoDeFamilia_22MS(int IdFamilia, int IdPermiso)
        {
            string query = @"
                           DELETE FROM FamiliaPermiso_22MS
                           WHERE IdFamilia_22MS = @IdFamilia_22MS
                           AND IdPermiso_22MS = @IdPermiso_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@IdFamilia_22MS", IdFamilia);
            cmd.Parameters.AddWithValue("@IdPermiso_22MS", IdPermiso);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void AgregarPermisoARol_22MS(int IdRol, int IdPermiso)
        {
            string query = @"
                           INSERT INTO RolPermiso_22MS (IdRol_22MS, IdPermiso_22MS)
                           VALUES (@IdRol_22MS, @IdPermiso_22MS)";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdRol_22MS", IdRol);
            cmd.Parameters.AddWithValue("@IdPermiso_22MS", IdPermiso);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void QuitarPermisoDeRol_22MS(int IdRol, int IdPermiso)
        {
            string query = @"
                           DELETE FROM RolPermiso_22MS
                           WHERE IdRol_22MS = @IdRol_22MS
                           AND IdPermiso_22MS = @IdPermiso_22MS";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdRol_22MS", IdRol);
            cmd.Parameters.AddWithValue("@IdPermiso_22MS", IdPermiso);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void AgregarFamiliaAFamilia_22MS(int IdFamiliaPadre, int IdFamiliaHijo)
        {
            string query = @"
                           INSERT INTO FamiliaFamilia_22MS
                           (IdFamiliaPadre_22MS, IdFamiliaHijo_22MS)
                           VALUES
                           (@IdFamiliaPadre_22MS, @IdFamiliaHijo_22MS)";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdFamiliaPadre_22MS", IdFamiliaPadre);
            cmd.Parameters.AddWithValue("@IdFamiliaHijo_22MS", IdFamiliaHijo);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public void QuitarFamiliaDeFamilia_22MS(int IdFamiliaPadre, int IdFamiliaHijo)
        {
            string query = @"
                           DELETE FROM FamiliaFamilia_22MS
                           WHERE IdFamiliaPadre_22MS = @IdFamiliaPadre_22MS
                           AND IdFamiliaHijo_22MS = @IdFamiliaHijo_22MS";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@IdFamiliaPadre_22MS", IdFamiliaPadre);
            cmd.Parameters.AddWithValue("@IdFamiliaHijo_22MS", IdFamiliaHijo);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

    }
}
