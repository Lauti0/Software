using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_22MS
{
    public class DALUsuario_22MS
    {
        public UsuarioServicios_22MS ObtenerUsuario_22MS(string username)
        {
            string query = @"
                            SELECT 
                                u.*,
                                r.IdRol_22MS,
                                r.NombreRol_22MS
                            FROM Usuario_22MS u
                            INNER JOIN Rol_22MS r
                                ON u.IdRol_22MS = r.IdRol_22MS
                            WHERE u.Username_22MS = @Username_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@Username_22MS", username);

            DataTable tablaUsuarios = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            if (tablaUsuarios.Rows.Count == 1)
            {
                DataRow fila = tablaUsuarios.Rows[0];

                return new UsuarioServicios_22MS
                {
                    IdUsuario_22MS = Convert.ToInt32(fila["IdUsuario_22MS"]),
                    DNI_22MS = Convert.ToInt32(fila["DNI_22MS"]),
                    Username_22MS = fila["Username_22MS"].ToString(),
                    Password_22MS = fila["Password_22MS"].ToString(),
                    Nombre_22MS = fila["Nombre_22MS"].ToString(),
                    Apellido_22MS = fila["Apellido_22MS"].ToString(),
                    Email_22MS = fila["Email_22MS"].ToString(),
                    CodigoIdioma_22MS = fila["CodigoIdioma_22MS"].ToString(),
                    Activo_22MS = Convert.ToBoolean(fila["Activo_22MS"]),
                    Bloqueado_22MS = Convert.ToBoolean(fila["Bloqueado_22MS"]),
                    Rol_22MS = new Rol_22MS
                    {
                        IdRol_22MS = Convert.ToInt32(fila["IdRol_22MS"]),
                        NombreRol_22MS = fila["NombreRol_22MS"].ToString()
                    }
                };
            }

            return null;
        }

        public void BloquearUsuario_22MS(string username)
        {
            string query = @"
                            UPDATE Usuario_22MS 
                            SET Bloqueado_22MS = 1 
                            WHERE Username_22MS = @Username_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@Username_22MS", username);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void CambiarPassword_22MS(string username, string passwordHash)
        {
            string query = @"
                            UPDATE Usuario_22MS 
                            SET Password_22MS = @Password_22MS 
                            WHERE Username_22MS = @Username_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@Username_22MS", username);
            sqlCommand.Parameters.AddWithValue("@Password_22MS", passwordHash);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void DesbloquearUsuario_22MS(string username, string password)
        {
            string query = @"
                            UPDATE Usuario_22MS 
                            SET Bloqueado_22MS = 0,
                                Password_22MS = @Password_22MS
                            WHERE Username_22MS = @Username_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@Username_22MS", username);
            sqlCommand.Parameters.AddWithValue("@Password_22MS", password);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void InsertarUsuario_22MS(
            string username,
            string passwordHash,
            int dni,
            string apellido,
            string nombre,
            int? idRol,
            string email,
            string codigoIdioma
        )
        {
            string query = @"
                    INSERT INTO Usuario_22MS
                    (
                        Username_22MS,
                        Password_22MS,
                        DNI_22MS,
                        Apellido_22MS,
                        Nombre_22MS,
                        IdRol_22MS,
                        Email_22MS,
                        CodigoIdioma_22MS,
                        Bloqueado_22MS,
                        Activo_22MS
                    )
                    VALUES
                    (
                        @Username_22MS,
                        @Password_22MS,
                        @DNI_22MS,
                        @Apellido_22MS,
                        @Nombre_22MS,
                        @IdRol_22MS,
                        @Email_22MS,
                        @CodigoIdioma_22MS,
                        0,
                        1
                    )";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue(
                "@Username_22MS",
                username
            );

            sqlCommand.Parameters.AddWithValue(
                "@Password_22MS",
                passwordHash
            );

            sqlCommand.Parameters.AddWithValue(
                "@DNI_22MS",
                dni
            );

            sqlCommand.Parameters.AddWithValue(
                "@Apellido_22MS",
                apellido
            );

            sqlCommand.Parameters.AddWithValue(
                "@Nombre_22MS",
                nombre
            );

            sqlCommand.Parameters.AddWithValue(
                "@IdRol_22MS",
                idRol
            );

            sqlCommand.Parameters.AddWithValue(
                "@Email_22MS",
                email
            );

            sqlCommand.Parameters.AddWithValue(
                "@CodigoIdioma_22MS",
                codigoIdioma
            );

            Acceso_22MS
                .GetInstance_22MS()
                .Escribir_22MS(sqlCommand);
        }

        public DataTable ObtenerUsuariosFiltrados_22MS(
            string dni,
            string apellido,
            string nombre,
            string email,
            int? idRol,
            string login,
            bool activos
        )
        {
            string query = @"
                            SELECT
                                u.*,
                                r.NombreRol_22MS
                            FROM Usuario_22MS u
                            INNER JOIN Rol_22MS r
                                ON u.IdRol_22MS = r.IdRol_22MS
                            WHERE 1=1";

            SqlCommand sqlCommand = new SqlCommand();

            if (!string.IsNullOrWhiteSpace(dni))
            {
                query += " AND u.DNI_22MS = @DNI_22MS";
                sqlCommand.Parameters.AddWithValue("@DNI_22MS", int.Parse(dni));
            }

            if (!string.IsNullOrWhiteSpace(apellido))
            {
                query += " AND u.Apellido_22MS LIKE @Apellido_22MS";
                sqlCommand.Parameters.AddWithValue("@Apellido_22MS", "%" + apellido + "%");
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query += " AND u.Nombre_22MS LIKE @Nombre_22MS";
                sqlCommand.Parameters.AddWithValue("@Nombre_22MS", "%" + nombre + "%");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query += " AND u.Email_22MS LIKE @Email_22MS";
                sqlCommand.Parameters.AddWithValue("@Email_22MS", "%" + email + "%");
            }

            if (idRol.HasValue)
            {
                query += " AND u.IdRol_22MS = @IdRol_22MS";
                sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol.Value);
            }

            if (!string.IsNullOrWhiteSpace(login))
            {
                query += " AND u.Username_22MS LIKE @Username_22MS";
                sqlCommand.Parameters.AddWithValue("@Username_22MS", "%" + login + "%");
            }

            if (activos)
                query += " AND u.Activo_22MS = 1";

            sqlCommand.CommandText = query;

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);
        }

        public bool ExisteUsuario_22MS(string username, int dni)
        {
            string query = @"
                            SELECT COUNT(*) 
                            FROM Usuario_22MS
                            WHERE Username_22MS = @Username_22MS 
                               OR DNI_22MS = @DNI_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@Username_22MS", username);
            sqlCommand.Parameters.AddWithValue("@DNI_22MS", dni);

            DataTable tablaUsuarios = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            return Convert.ToInt32(tablaUsuarios.Rows[0][0]) > 0;
        }

        public void ModificarUsuario_22MS(int dni, string email, int idRol)
        {
            string query = @"
                            UPDATE Usuario_22MS
                            SET Email_22MS = @Email_22MS,
                                IdRol_22MS = @IdRol_22MS
                            WHERE DNI_22MS = @DNI_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@DNI_22MS", dni);
            sqlCommand.Parameters.AddWithValue("@Email_22MS", email);
            sqlCommand.Parameters.AddWithValue("@IdRol_22MS", idRol);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public void ActualizarIdiomaUsuario_22MS(int idUsuario, string codigoIdioma)
        {
            string query = @"
                    UPDATE Usuario_22MS
                    SET CodigoIdioma_22MS = @CodigoIdioma_22MS
                    WHERE IdUsuario_22MS = @IdUsuario_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue(
                "@CodigoIdioma_22MS",
                codigoIdioma
            );

            sqlCommand.Parameters.AddWithValue(
                "@IdUsuario_22MS",
                idUsuario
            );

            Acceso_22MS
                .GetInstance_22MS()
                .Escribir_22MS(sqlCommand);
        }


        public void CambiarEstado_22MS(int dni, bool activo)
        {
            string query = @"
                            UPDATE Usuario_22MS
                            SET Activo_22MS = @Activo_22MS
                            WHERE DNI_22MS = @DNI_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@Activo_22MS", activo);
            sqlCommand.Parameters.AddWithValue("@DNI_22MS", dni);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(sqlCommand);
        }

        public bool EstaBloqueado_22MS(string username)
        {
            string query = @"
                            SELECT Bloqueado_22MS
                            FROM Usuario_22MS 
                            WHERE Username_22MS = @Username_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@Username_22MS", username);

            DataTable tablaUsuarios = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            if (tablaUsuarios.Rows.Count == 0)
                throw new Exception("Usuario inexistente");

            return Convert.ToBoolean(tablaUsuarios.Rows[0]["Bloqueado_22MS"]);
        }

        public bool EstaActivo_22MS(string username)
        {
            string query = @"
                            SELECT Activo_22MS
                            FROM Usuario_22MS 
                            WHERE Username_22MS = @Username_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@Username_22MS", username);

            DataTable tablaUsuarios = Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);

            if (tablaUsuarios.Rows.Count == 0)
                throw new Exception("Usuario inexistente");

            return Convert.ToBoolean(tablaUsuarios.Rows[0]["Activo_22MS"]);
        }

        public DataTable ObtenerUsuarios_22MS()
        {
            string query = @"
                            SELECT Username_22MS
                            FROM Usuario_22MS
                            ORDER BY Username_22MS";

            SqlCommand sqlCommand = new SqlCommand(query);

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);
        }

        public DataTable ObtenerUsuarioPorLogin_22MS(string login)
        {
            string query = @"
                            SELECT 
                                Nombre_22MS,
                                Apellido_22MS
                            FROM Usuario_22MS
                            WHERE Username_22MS = @Login";

            SqlCommand sqlCommand = new SqlCommand(query);

            sqlCommand.Parameters.AddWithValue("@Login", login);

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(sqlCommand);
        }
    }
}