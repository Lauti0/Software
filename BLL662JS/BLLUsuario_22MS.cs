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
        
        public UsuarioServicios_22MS Login_22MS(string user, string pass)
        {

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                throw new Exception("Debe completar usuario y contraseña");

            
            var usuario = dal.ObtenerUsuario6_22MS(user);

            if (usuario == null)
                throw new Exception("Usuario inexistente");

            if (usuario.Bloqueado_22MS)
                throw new Exception("Usuario bloqueado");

            string hash = Crypto_22MS.Hash_22MS(pass);

            if (usuario.Password_22MS != hash)
            {
                int intentos = SessionManager_22MS.IncrementarIntentos_22MS(user);

                if (intentos >= 3)
                {
                    dal.BloquearUsuario_22MS(user);
                    throw new Exception("Usuario bloqueado por intentos fallidos");
                }

                throw new Exception($"Contraseña incorrecta. Intentos: {intentos}");
            }

            SessionManager_22MS.ResetearIntentos_22MS(user);

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
            string email, string rol, string login, bool activos, bool todos)
        {
            DALUsuario_22MS dal = new DALUsuario_22MS();

            return dal.ObtenerUsuariosFiltrados_22MS(
                dni, apellido, nombre, email, rol, login, activos, todos
            );
        }

        public void CambiarEstado_22MS(int dni, bool activo)
        {
            dal.CambiarEstado_22MS(dni, activo);
        }
        public void CambiarPassword_22MS(string user, string actual, string nueva, string confirmar)
        {
            UsuarioServicios_22MS usuario = dal.ObtenerUsuario_22MS(user);

            string hashActual = Crypto_22MS.Hash_22MS(actual);

            if (usuario.Password_22MS != hashActual)
                throw new Exception("La contraseña actual es incorrecta");

            string hashNueva = Crypto_22MS.Hash_22MS(nueva);

            dal.CambiarPassword_22MS(user, hashNueva);
        }
    }
}
