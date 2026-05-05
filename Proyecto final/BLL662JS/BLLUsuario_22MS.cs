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
        private static Dictionary<string, int> intentos_22MS = new Dictionary<string, int>(); 
        private static Dictionary<string, DateTime> ultimoIntento_22MS = new Dictionary<string, DateTime>();
        public UsuarioServicios_22MS Login_22MS(string user, string pass)
        {

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                throw new Exception("Debe completar usuario y contraseña");

            
            var usuario = dal.ObtenerUsuario_22MS(user);

            if (usuario == null)
                throw new Exception("Usuario inexistente");
            if (dal.EstaBloqueado_22MS(usuario.Username_22MS))
                throw new Exception("Usuario bloqueado. Intente más tarde");    
            if(!dal.EstaActivo_22MS(usuario.Username_22MS))
                throw new Exception("Usuario inactivo. Contacte al administrador");

            string hash = Crypto_22MS.Hash_22MS(pass);

            if (usuario.Password_22MS != hash)
            {
                int intentos = IncrementarIntentos_22MS(user);

                if (intentos >= 3)
                {
                    dal.BloquearUsuario_22MS(user);
                    throw new Exception("Demasiados intentos. Intente nuevamente en 2 horas");
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
            if (!intentos_22MS.ContainsKey(user))
            {
                intentos_22MS[user] = 0;
            }            
            if (ultimoIntento_22MS.ContainsKey(user))
            {
                DateTime ultimo = ultimoIntento_22MS[user];

                if ((DateTime.Now - ultimo).TotalHours >= 2)
                {                    
                    intentos_22MS[user] = 0;
                }
            }

            intentos_22MS[user]++;

            ultimoIntento_22MS[user] = DateTime.Now;

            return intentos_22MS[user];
        }
        public static void ResetearIntentos_22MS(string user)
        {
            if (intentos_22MS.ContainsKey(user))
                intentos_22MS[user] = 0;

            if (ultimoIntento_22MS.ContainsKey(user))
                ultimoIntento_22MS.Remove(user); 
        }
        public void Logout_22MS()
        {
            SessionManager_22MS.Logout_22MS();
        }
    }
}
