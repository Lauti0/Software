using BE662JS;
using DAL662JS;
using Seguridad662JS;
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

        public BEUsuario662JS Login662JS(string user, string pass)
        {

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                throw new Exception("Debe completar usuario y contraseña");

            
            var usuario = dal.ObtenerUsuario662JS(user);

            if (usuario == null)
                throw new Exception("Usuario inexistente");

            if (usuario.Bloqueado662JS)
                throw new Exception("Usuario bloqueado");

            string hash = Seguridad662JS.Seguridad662JS.Hash662JS(pass);

            if (usuario.Password662JS != hash)
            {
                dal.IncrementarIntentos662JS(user);

                int intentos = dal.ObtenerIntentos662JS(user);

                if (intentos >= 3)
                {
                    dal.BloquearUsuario662JS(user);
                    throw new Exception("Usuario bloqueado por intentos fallidos");
                }

                throw new Exception($"Contraseña incorrecta. Intentos: {intentos}");
            }

            dal.ResetearIntentos662JS(user);

            return usuario;
        }
        public void CambiarPassword662JS(string user, string passActual, string nuevaPass)
        {
            var usuario = dal.ObtenerUsuario662JS(user);

            string hashActual = Seguridad662JS.Seguridad662JS.Hash662JS(passActual);

            if (usuario.Password662JS != hashActual)
                throw new Exception("Contraseña actual incorrecta");

            string hashNueva = Seguridad662JS.Seguridad662JS.Hash662JS(nuevaPass);

            dal.CambiarPassword662JS(user, hashNueva);
        }
        public void Desbloquear662JS(string user)
        {
            dal.DesbloquearUsuario662JS(user);
        }
        public void InsertarUsuario662JS(string username, string apellido, string nombre, string dni, string rol, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("El username es obligatorio");

            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("El DNI es obligatorio");

            if (string.IsNullOrWhiteSpace(apellido))
                throw new Exception("El apellido es obligatorio");
            if (string.IsNullOrWhiteSpace(rol))
                throw new Exception("El rol es obligatorio");

            string passwordPlano = dni + apellido;
            string passwordHash = Seguridad662JS.Seguridad662JS.Hash662JS(passwordPlano);            
            if (dal.ExisteUsuario662JS(username))
                throw new Exception("El usuario ya existe");
                                 
            dal.InsertarUsuario662JS(username, passwordHash, int.Parse(dni), apellido, nombre, rol, email);
        }
        public void ModificarUsuario662JS(string username, string dni, string apellido)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Usuario inválido");

            DALUsuario662JS dal = new DALUsuario662JS();

            dal.ModificarUsuario662JS(username, dni, apellido);
        }
        public DataTable ObtenerUsuariosFiltrados662JS(string dni, string apellido, string nombre, 
            string email, string rol, string login, bool activos, bool todos)
        {
            DALUsuario662JS dal = new DALUsuario662JS();

            return dal.ObtenerUsuariosFiltrados662JS(
                dni, apellido, nombre, email, rol, login, activos, todos
            );
        }
    }
}
