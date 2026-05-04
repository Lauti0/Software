using DAL662JS;
using Servicios662JS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BLL662JS
{
    public class BLLUsuario662JS
    {
        DALUsuario662JS dal = new DALUsuario662JS();
        //5bebc86242f338e945178b35361b13128ae41dbc1e3f3e2d1f3b076e4e031a17
        private static Dictionary<string, int> intentos_22MS = new Dictionary<string, int>(); 
        private static Dictionary<string, DateTime> ultimoIntento_22MS = new Dictionary<string, DateTime>();
        public UsuarioServicios662JS Login662JS(string user, string pass)
        {

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                throw new Exception("Debe completar usuario y contraseña");

            
            var usuario = dal.ObtenerUsuario662JS(user);

            if (usuario == null)
                throw new Exception("Usuario inexistente");
            if (dal.EstaBloqueado662JS(usuario.Username662JS))
                throw new Exception("Usuario bloqueado. Intente más tarde");    
            if(!dal.EstaActivo662JS(usuario.Username662JS))
                throw new Exception("Usuario inactivo. Contacte al administrador");

            string hash = Crypto662JS.Hash662JS(pass);

            if (usuario.Password662JS != hash)
            {
                int intentos = IncrementarIntentos_22MS(user);

                if (intentos >= 3)
                {
                    dal.BloquearUsuario662JS(user);
                    throw new Exception("Demasiados intentos. Intente nuevamente en 2 horas");
                }

                throw new Exception($"Contraseña incorrecta. Intentos: {intentos}");
            }

            ResetearIntentos_22MS(user);

            return usuario;
        }
        public void CambiarPassword662JS(string user, string passActual, string nuevaPass)
        {
            var usuario = dal.ObtenerUsuario662JS(user);

            string hashActual = Crypto662JS.Hash662JS(passActual);

            if (usuario.Password662JS != hashActual)
                throw new Exception("Contraseña actual incorrecta");

            string hashNueva = Crypto662JS.Hash662JS(nuevaPass);

            dal.CambiarPassword662JS(user, hashNueva);
        }
        public void Desbloquear662JS(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new Exception("Usuario inválido");

            bool bloqueado = dal.EstaBloqueado662JS(user);

            if (!bloqueado)
                throw new Exception("El usuario no está bloqueado");

            dal.DesbloquearUsuario662JS(user);
        }
        public void InsertarUsuario662JS(string apellido, string nombre, string dni, string rol, string email)
        {                        
            string username = nombre + dni;
            string passwordPlano = dni + apellido;
            string passwordHash = Crypto662JS.Hash662JS(passwordPlano);            
            if (dal.ExisteUsuario662JS(username, int.Parse(dni)))
                throw new Exception("El usuario ya existe");
                                 
            dal.InsertarUsuario662JS(username, passwordHash, int.Parse(dni), apellido, nombre, rol, email);
        }
        public void ModificarUsuario662JS(string dni, string email, string rol)
        {            
            dal.ModificarUsuario662JS(int.Parse(dni), email, rol);
        }
        public DataTable ObtenerUsuariosFiltrados662JS(string dni, string apellido, string nombre, 
            string email, string rol, string login, bool activos)
        {
            DALUsuario662JS dal = new DALUsuario662JS();

            return dal.ObtenerUsuariosFiltrados662JS(
                dni, apellido, nombre, email, rol, login, activos
            );
        }

        public void CambiarEstado662JS(int dni, bool activo)
        {
            dal.CambiarEstado662JS(dni, activo);
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
        public void Logout_662JS()
        {
            SessionManager662JS.Logout662JS();
        }
    }
}
