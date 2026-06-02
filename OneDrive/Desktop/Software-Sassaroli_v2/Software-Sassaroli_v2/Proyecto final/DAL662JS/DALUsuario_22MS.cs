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
    public class DALUsuario_22MS
    {
        public UsuarioServicios_22MS ObtenerUsuario_22MS(string username)
        {
            string query = @"SELECT u.*,
                                    r.IdRol_22MS,
                                    r.NombreRol_22MS
                                    FROM Usuario_22MS u
                                    INNER JOIN Rol_22MS r
                                    ON u.IdRol_22MS = r.IdRol_22MS
                                    WHERE u.Username_22MS=@Username_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username_22MS", username);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            if (dt.Rows.Count == 1)
            {
                var row = dt.Rows[0];

                return new UsuarioServicios_22MS
                {
                    IdUsuario_22MS = Convert.ToInt32(row["IdUsuario_22MS"]),
                    DNI_22MS = Convert.ToInt32(row["DNI_22MS"]),
                    Username_22MS = row["Username_22MS"].ToString(),
                    Password_22MS = row["Password_22MS"].ToString(),
                    Nombre_22MS = row["Nombre_22MS"].ToString(),
                    Apellido_22MS = row["Apellido_22MS"].ToString(),                    
                    Email_22MS = row["Email_22MS"].ToString(),
                    Activo_22MS = Convert.ToBoolean(row["Activo_22MS"]),
                    Bloqueado_22MS = Convert.ToBoolean(row["Bloqueado_22MS"]),    
                    Rol_22MS= new Rol_22MS
                    {
                        IdRol_22MS = Convert.ToInt32(row["IdRol_22MS"]),
                        NombreRol_22MS = row["NombreRol_22MS"].ToString()
                    }
                };
                
            }

            return null;
        }        
        public void BloquearUsuario_22MS(string username)
        {
            string query = @"UPDATE Usuario_22MS 
                     SET Bloqueado_22MS = 1 
                     WHERE Username_22MS = @Username_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username_22MS", username);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }
        
        public void CambiarPassword_22MS(string username, string passwordHash)
        {
            string query = @"UPDATE Usuario_22MS 
                     SET Password_22MS = @Password_22MS 
                     WHERE Username_22MS = @Username_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username_22MS", username);
            cmd.Parameters.AddWithValue("@Password_22MS", passwordHash);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }
        public void DesbloquearUsuario_22MS(string username, string password)
        {
            string query = @"UPDATE Usuario_22MS 
                     SET Bloqueado_22MS = 0,
                         Password_22MS=@Password_22MS
                     WHERE Username_22MS = @Username_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username_22MS", username);
            cmd.Parameters.AddWithValue("@Password_22MS", password);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }
        public void InsertarUsuario_22MS(string username, string passwordHash, int dni, string apellido, string nombre, int? idrol, string email)
        {
            string query = @"INSERT INTO Usuario_22MS 
                     (Username_22MS, Password_22MS, DNI_22MS, Apellido_22MS, Nombre_22MS, IdRol_22MS, Email_22MS, Bloqueado_22MS, Activo_22MS)
                     VALUES (@Username_22MS, @Password_22MS, @DNI_22MS, @Apellido_22MS, @Nombre_22MS, @IdRol_22MS, @Email_22MS, 0, 1)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username_22MS", username);
            cmd.Parameters.AddWithValue("@Password_22MS", passwordHash);
            cmd.Parameters.AddWithValue("@DNI_22MS", dni);
            cmd.Parameters.AddWithValue("@Apellido_22MS", apellido);
            cmd.Parameters.AddWithValue("@IdRol_22MS", idrol);
            cmd.Parameters.AddWithValue("@Email_22MS", email);
            cmd.Parameters.AddWithValue("@Nombre_22MS", nombre);
            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public DataTable ObtenerUsuariosFiltrados_22MS(string dni, string apellido, string nombre, 
            string email, int? idrol, string login, bool activos)
        {
            string query = @"
                            SELECT
                                u.*,
                                r.NombreRol_22MS
                            FROM Usuario_22MS u
                            INNER JOIN Rol_22MS r
                                ON u.IdRol_22MS = r.IdRol_22MS
                            WHERE 1=1";

            SqlCommand cmd = new SqlCommand();

            if (!string.IsNullOrWhiteSpace(dni))
            {
                query += " AND u.DNI_22MS = @DNI_22MS";
                cmd.Parameters.AddWithValue("@DNI_22MS", int.Parse(dni));
            }

            if (!string.IsNullOrWhiteSpace(apellido))
            {
                query += " AND u.Apellido_22MS LIKE @Apellido_22MS";
                cmd.Parameters.AddWithValue(
                    "@Apellido_22MS",
                    "%" + apellido + "%");
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query += " AND u.Nombre_22MS LIKE @Nombre_22MS";
                cmd.Parameters.AddWithValue(
                    "@Nombre_22MS",
                    "%" + nombre + "%");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query += " AND u.Email_22MS LIKE @Email_22MS";
                cmd.Parameters.AddWithValue(
                    "@Email_22MS",
                    "%" + email + "%");
            }

            if (idrol.HasValue)
            {
                query += " AND u.IdRol_22MS = @IdRol_22MS";
                cmd.Parameters.AddWithValue(
                    "@IdRol_22MS",
                    idrol.Value);
            }

            if (!string.IsNullOrWhiteSpace(login))
            {
                query += " AND u.Username_22MS LIKE @Username_22MS";
                cmd.Parameters.AddWithValue(
                    "@Username_22MS",
                    "%" + login + "%");
            }

            if (activos)
                query += " AND u.Activo_22MS = 1";

            cmd.CommandText = query;

            return Acceso_22MS
                .GetInstance_22MS()
                .Leer_22MS(cmd);
        }
        public bool ExisteUsuario_22MS(string username, int dni)
        {
            string query = @"SELECT COUNT(*) FROM Usuario_22MS
                     WHERE Username_22MS = @Username_22MS or DNI_22MS = @DNI_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username_22MS", username);
            cmd.Parameters.AddWithValue("@DNI_22MS", dni);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public void ModificarUsuario_22MS(int dni, string email, int idrol)
        {
            string query = @"UPDATE Usuario_22MS
                     SET Email_22MS = @Email_22MS,
                         IdRol_22MS = @IdRol_22MS
                     WHERE DNI_22MS = @DNI_22MS";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@DNI_22MS", dni);
            cmd.Parameters.AddWithValue("@Email_22MS", email);
            cmd.Parameters.AddWithValue("@IdRol_22MS", idrol);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }
        public void CambiarEstado_22MS(int dni, bool activo)
        {
            string query = @"UPDATE Usuario_22MS
                     SET Activo_22MS = @Activo_22MS
                     WHERE DNI_22MS = @DNI_22MS";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@Activo_22MS", activo);
            cmd.Parameters.AddWithValue("@DNI_22MS", dni);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }
        public bool EstaBloqueado_22MS(string username)
        {
            string query = @"SELECT Bloqueado_22MS
                     FROM Usuario_22MS 
                     WHERE Username_22MS = @Username_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username_22MS", username);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            if (dt.Rows.Count == 0)
                throw new Exception("Usuario inexistente");

            return Convert.ToBoolean(dt.Rows[0]["Bloqueado_22MS"]);
        }
        public bool EstaActivo_22MS(string username)
        {
            string query = @"SELECT Activo_22MS
                     FROM Usuario_22MS 
                     WHERE Username_22MS = @Username_22MS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username_22MS", username);

            DataTable dt = Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);

            if (dt.Rows.Count == 0)
                throw new Exception("Usuario inexistente");

            return Convert.ToBoolean(dt.Rows[0]["Activo_22MS"]);
        }

        public DataTable ObtenerUsuarios_22MS()
        {
            string query = @"SELECT Username_22MS
                            FROM Usuario_22MS
                            ORDER BY Username_22MS";
            SqlCommand cmd = new SqlCommand(query);
            return Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
        }

        public DataTable ObtenerUsuarioPorLogin_22MS(string login)
        {
            string query = @"
                        SELECT 
                            Nombre_22MS,
                            Apellido_22MS
                        FROM Usuario_22MS
                        WHERE Username_22MS = @Login";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@Login", login);

            return Acceso_22MS
                .GetInstance_22MS()
                .Leer_22MS(cmd);
        }
    }
}
