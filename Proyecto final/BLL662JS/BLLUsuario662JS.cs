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
        
        public UsuarioServicios662JS Login662JS(string user, string pass)
        {

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                throw new Exception("Debe completar usuario y contraseña");

            
            var usuario = dal.ObtenerUsuario662JS(user);

            if (usuario == null)
                throw new Exception("Usuario inexistente");

            if (usuario.Bloqueado662JS)
                throw new Exception("Usuario bloqueado");

            string hash = Crypto662JS.Hash662JS(pass);

            if (usuario.Password662JS != hash)
            {
                int intentos = SessionManager662JS.IncrementarIntentos_22MS(user);

                if (intentos >= 3)
                {
                    dal.BloquearUsuario662JS(user);
                    throw new Exception("Usuario bloqueado por intentos fallidos");
                }

                throw new Exception($"Contraseña incorrecta. Intentos: {intentos}");
            }

            SessionManager662JS.ResetearIntentos_22MS(user);

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
            dal.DesbloquearUsuario662JS(user);
        }
        public void InsertarUsuario662JS(string apellido, string nombre, string dni, string rol, string email)
        {                        
            string username = nombre + dni;
            string passwordPlano = dni + apellido;
            string passwordHash = Crypto662JS.Hash662JS(passwordPlano);            
            if (dal.ExisteUsuario662JS(username))
                throw new Exception("El usuario ya existe");
                                 
            dal.InsertarUsuario662JS(username, passwordHash, int.Parse(dni), apellido, nombre, rol, email);
        }
        public void ModificarUsuario662JS(string dni, string email, string rol)
        {            
            dal.ModificarUsuario662JS(int.Parse(dni), email, rol);
        }
        public DataTable ObtenerUsuariosFiltrados662JS(string dni, string apellido, string nombre, 
            string email, string rol, string login, bool activos, bool todos)
        {
            DALUsuario662JS dal = new DALUsuario662JS();

            return dal.ObtenerUsuariosFiltrados662JS(
                dni, apellido, nombre, email, rol, login, activos, todos
            );
        }

        public void CambiarEstado662JS(int dni, bool activo)
        {
            dal.CambiarEstado662JS(dni, activo);
        }
        public void CambiarPassword662JS(string user, string actual, string nueva, string confirmar)
        {
            UsuarioServicios662JS usuario = dal.ObtenerUsuario662JS(user);

            string hashActual = Crypto662JS.Hash662JS(actual);

            if (usuario.Password662JS != hashActual)
                throw new Exception("La contraseña actual es incorrecta");

            string hashNueva = Crypto662JS.Hash662JS(nueva);

            dal.CambiarPassword662JS(user, hashNueva);
        }
    }
}
