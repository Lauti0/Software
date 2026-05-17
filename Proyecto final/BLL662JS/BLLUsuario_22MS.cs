using DAL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BLL_22MS
{
    public class BLLUsuario_22MS
    {
        DALUsuario_22MS dal = new DALUsuario_22MS();
        //5bebc86242f338e945178b35361b13128ae41dbc1e3f3e2d1f3b076e4e031a17
        private static Dictionary<string, (int intentos, DateTime ultimoIntento)> cacheIntentos
    = new Dictionary<string, (int, DateTime)>();
        public UsuarioServicios_22MS Login_22MS(string user, string pass)
        {

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                throw new Exception("Debe completar usuario y contraseña");

            BLLBitacoraEvento_22MS bitacora = new BLLBitacoraEvento_22MS();
            var usuario = dal.ObtenerUsuario_22MS(user);

            if (usuario == null)
            {
                bitacora.RegistrarEvento_22MS(
                        user,
                        "Seguridad",
                        "Login fallido",
                        2
                    );
                throw new Exception("Usuario inexistente");
            }
            if (dal.EstaBloqueado_22MS(usuario.Username_22MS))
            {
                bitacora.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Login fallido. Usuario bloqueado.",
                        2
                    );
                throw new Exception("Usuario bloqueado. Intente más tarde");
            }
            if (!dal.EstaActivo_22MS(usuario.Username_22MS))
            {
                bitacora.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Login fallido. Usuario desactivado.",
                        2
                    );
                throw new Exception("Usuario desactivado. Contacte al administrador");
            }

            string hash = Crypto_22MS.Hash_22MS(pass);

            if (usuario.Password_22MS != hash)
            {
                int intentos = IncrementarIntentos_22MS(user);
                bitacora.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Login fallido. Contraseña incorrecta.",
                        2
                    );
                if (intentos >= 3)
                {
                    dal.BloquearUsuario_22MS(user);
                    bitacora.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Seguridad",
                            "Bloqueo de usuario",
                            1
                        );
                    throw new Exception("Demasiados intentos. Intente nuevamente en 5 minutos");
                }

                throw new Exception($"Contraseña incorrecta. Intentos: {intentos}");
            }

            ResetearIntentos_22MS(user);

            return usuario;
        }
        public void CambiarPassword_22MS(string user, string passActual, string nuevaPass)
        {
            var usuario = dal.ObtenerUsuario_22MS(user);

            string hashActual = Crypto_22MS.Hash_22MS(passActual);

            if (usuario.Password_22MS != hashActual)
                throw new Exception("Contraseña actual incorrecta");

            string hashNueva = Crypto_22MS.Hash_22MS(nuevaPass);

            dal.CambiarPassword_22MS(user, hashNueva);
        }
        public void Desbloquear_22MS(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new Exception("Usuario inválido");

            bool bloqueado = dal.EstaBloqueado_22MS(user);

            if (!bloqueado)
                throw new Exception("El usuario no está bloqueado");

            dal.DesbloquearUsuario_22MS(user);
        }
        public void InsertarUsuario_22MS(string apellido, string nombre, string dni, string rol, string email)
        {                        
            string username = nombre + dni;
            string passwordPlano = dni + apellido;
            string passwordHash = Crypto_22MS.Hash_22MS(passwordPlano);            
            if (dal.ExisteUsuario_22MS(username, int.Parse(dni)))
                throw new Exception("El usuario ya existe");
                                 
            dal.InsertarUsuario_22MS(username, passwordHash, int.Parse(dni), apellido, nombre, rol, email);
        }
        public void ModificarUsuario_22MS(string dni, string email, string rol)
        {            
            dal.ModificarUsuario_22MS(int.Parse(dni), email, rol);
        }
        public DataTable ObtenerUsuariosFiltrados_22MS(string dni, string apellido, string nombre, 
            string email, string rol, string login, bool activos)
        {
            DALUsuario_22MS dal = new DALUsuario_22MS();

            return dal.ObtenerUsuariosFiltrados_22MS(
                dni, apellido, nombre, email, rol, login, activos
            );
        }

        public void CambiarEstado_22MS(int dni, bool activo)
        {
            dal.CambiarEstado_22MS(dni, activo);
        }        
        public static int IncrementarIntentos_22MS(string user)
        {
            if (!cacheIntentos.ContainsKey(user))
            {
                cacheIntentos[user] = (1, DateTime.Now);
                return 1;
            }

            var data = cacheIntentos[user];
            
            if ((DateTime.Now - data.ultimoIntento).TotalMinutes >= 5)
            {
                cacheIntentos[user] = (1, DateTime.Now);
                return 1;
            }

            int nuevosIntentos = data.intentos + 1;
            cacheIntentos[user] = (nuevosIntentos, DateTime.Now);

            return nuevosIntentos;
        }
        public static void ResetearIntentos_22MS(string user)
        {
            if (cacheIntentos.ContainsKey(user))
                cacheIntentos.Remove(user);
        }
        public void Logout_22MS()
        {
            SessionManager_22MS.Logout_22MS();
        }
        public DataTable ObtenerUsuarios_22MS()
        {
            return dal.ObtenerUsuarios_22MS();
        }
        public DataRow ObtenerUsuarioPorLogin_22MS(string login)
        {
            DataTable tabla = dal.ObtenerUsuarioPorLogin_22MS(login);

            if (tabla.Rows.Count == 0)
                return null;

            return tabla.Rows[0];
        }
    }
}
