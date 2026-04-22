using BE662JS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL662JS
{
    public class DALUsuario662JS
    {
        public BEUsuario662JS ObtenerUsuario662JS(string username)
        {
            string query = @"SELECT * FROM Usuario662JS 
                     WHERE Username662JS = @Username662JS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username662JS", username);

            DataTable dt = Acceso662JS.GetInstance662JS().Leer662JS(cmd);

            if (dt.Rows.Count == 1)
            {
                var row = dt.Rows[0];

                return new BEUsuario662JS
                {
                    IdUsuario662JS = Convert.ToInt32(row["IdUsuario662JS"]),
                    DNI662JS = Convert.ToInt32(row["DNI662JS"]),
                    Username662JS = row["Username662JS"].ToString(),
                    Password662JS = row["Password662JS"].ToString(),
                    Nombre662JS=row["Nombre662JS"].ToString(),
                    Apellido662JS = row["Apellido662JS"].ToString(),
                    Email662JS = row["Email662JS"].ToString(),
                    Rol662JS=row["Rol662JS"].ToString(),
                    Bloqueado662JS = Convert.ToBoolean(row["Bloqueado662JS"]),
                    IntentosFallidos662JS = Convert.ToInt32(row["IntentosFallidos662JS"])
                };
            }

            return null;
        }
        public void IncrementarIntentos662JS(string username)
        {
            string query = @"UPDATE Usuario662JS 
                     SET IntentosFallidos662JS = IntentosFallidos662JS + 1 
                     WHERE Username662JS = @Username662JS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username662JS", username);

            Acceso662JS.GetInstance662JS().Escribir662JS(cmd);
        }
        public void ResetearIntentos662JS(string username)
        {
            string query = @"UPDATE Usuario662JS 
                     SET IntentosFallidos662JS = 0 
                     WHERE Username662JS = @Username662JS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username662JS", username);

            Acceso662JS.GetInstance662JS().Escribir662JS(cmd);
        }
        public void BloquearUsuario662JS(string username)
        {
            string query = @"UPDATE Usuario662JS 
                     SET Bloqueado662JS = 1 
                     WHERE Username662JS = @Username662JS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username662JS", username);

            Acceso662JS.GetInstance662JS().Escribir662JS(cmd);
        }
        public int ObtenerIntentos662JS(string username)
        {
            string query = @"SELECT IntentosFallidos662JS 
                     FROM Usuario662JS 
                     WHERE Username662JS = @Username662JS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username662JS", username);

            DataTable dt = Acceso662JS.GetInstance662JS().Leer662JS(cmd);

            if (dt.Rows.Count == 1)
                return Convert.ToInt32(dt.Rows[0]["IntentosFallidos662JS"]);

            return 0;
        }
        public void CambiarPassword662JS(string username, string passwordHash)
        {
            string query = @"UPDATE Usuario662JS 
                     SET Password662JS = @Password662JS 
                     WHERE Username662JS = @Username662JS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username662JS", username);
            cmd.Parameters.AddWithValue("@Password662JS", passwordHash);

            Acceso662JS.GetInstance662JS().Escribir662JS(cmd);
        }
        public void DesbloquearUsuario662JS(string username)
        {
            string query = @"UPDATE Usuario662JS 
                     SET Bloqueado662JS = 0, IntentosFallidos662JS = 0
                     WHERE Username662JS = @Username662JS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username662JS", username);

            Acceso662JS.GetInstance662JS().Escribir662JS(cmd);
        }
        public void InsertarUsuario662JS(string username, string passwordHash, int dni, string apellido, string nombre, string rol, string email)
        {
            string query = @"INSERT INTO Usuario662JS 
                     (Username662JS, Password662JS, DNI662JS, Apellido662JS, Nombre662JS, Rol662JS, Email662JS, Bloqueado662JS, IntentosFallidos662JS, Activo662JS)
                     VALUES (@Username662JS, @Password662JS, @DNI662JS, @Apellido662JS, @Nombre662JS, @Rol662JS, @Email662JS, 0, 0, 1)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username662JS", username);
            cmd.Parameters.AddWithValue("@Password662JS", passwordHash);
            cmd.Parameters.AddWithValue("@DNI662JS", dni);
            cmd.Parameters.AddWithValue("@Apellido662JS", apellido);
            cmd.Parameters.AddWithValue("@Rol662JS", rol);
            cmd.Parameters.AddWithValue("@Email662JS", email);
            cmd.Parameters.AddWithValue("@Nombre662JS", nombre);
            Acceso662JS.GetInstance662JS().Escribir662JS(cmd);
        }

        public DataTable ObtenerUsuariosFiltrados662JS(string dni, string apellido, string nombre, 
            string email, string rol, string login, bool activos, bool todos)
        {
            string query = @"SELECT * FROM Usuario662JS WHERE 1=1";

            SqlCommand cmd = new SqlCommand();

            if (!string.IsNullOrWhiteSpace(dni))
            {
                query += " AND DNI662JS = @DNI662JS";
                cmd.Parameters.AddWithValue("@DNI662JS", int.Parse(dni));
            }

            if (!string.IsNullOrWhiteSpace(apellido))
            {
                query += " AND Apellido662JS LIKE @Apellido662JS";
                cmd.Parameters.AddWithValue("@Apellido662JS", "%" + apellido + "%");
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query += " AND Nombre662JS LIKE @Nombre662JS";
                cmd.Parameters.AddWithValue("@Nombre662JS", "%" + nombre + "%");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query += " AND Email662JS LIKE @Email662JS";
                cmd.Parameters.AddWithValue("@Email662JS", "%" + email + "%");
            }

            if (!string.IsNullOrWhiteSpace(rol))
            {
                query += " AND Rol662JS LIKE @Rol662JS";
                cmd.Parameters.AddWithValue("@Rol662JS", "%" + rol + "%");
            }

            if (!string.IsNullOrWhiteSpace(login))
            {
                query += " AND Username662JS LIKE @Username662JS";
                cmd.Parameters.AddWithValue("@Username662JS", "%" + login + "%");
            }
           
            if (activos && !todos)
                query += " AND Activo662JS = 1";

            if (todos)
                query += ""; // trae todo

            cmd.CommandText = query;

            return Acceso662JS.GetInstance662JS().Leer662JS(cmd);
        }
        public bool ExisteUsuario662JS(string username)
        {
            string query = @"SELECT COUNT(*) FROM Usuario662JS
                     WHERE Username662JS = @Username662JS";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@Username662JS", username);

            DataTable dt = Acceso662JS.GetInstance662JS().Leer662JS(cmd);

            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public void ModificarUsuario662JS(string username, string dni, string apellido)
        {
            string query = @"UPDATE Usuario662JS
                     SET DNI662JS = @DNI662JS,
                         Apellido662JS = @Apellido662JS
                     WHERE Username662JS = @Username662JS";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@Username662JS", username);
            cmd.Parameters.AddWithValue("@DNI662JS", int.Parse(dni));
            cmd.Parameters.AddWithValue("@Apellido662JS", apellido);

            Acceso662JS.GetInstance662JS().Escribir662JS(cmd);
        }
    }
}
