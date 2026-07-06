using DAL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL_22MS
{
    public class BLLUsuario_22MS
    {
        private DALUsuario_22MS dalUsuario_22MS = new DALUsuario_22MS();
        private BLLIdioma_22MS bllIdioma_22MS = new BLLIdioma_22MS();

        // 5bebc86242f338e945178b35361b13128ae41dbc1e3f3e2d1f3b076e4e031a17
        private static Dictionary<string, (int intentos, DateTime ultimoIntento)> cacheIntentos
            = new Dictionary<string, (int, DateTime)>();

        private void RecalcularDigitos_22MS()
        {
            BLLDigitoVerificador_22MS bllDigito = new BLLDigitoVerificador_22MS();
            bllDigito.RecalcularTodos_22MS();
        }

        public UsuarioServicios_22MS Login_22MS(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Debe completar usuario y contraseña");

            BLLBitacoraEvento_22MS bitacora = new BLLBitacoraEvento_22MS();

            var usuario = dalUsuario_22MS.ObtenerUsuario_22MS(username);

            if (usuario == null)
            {
                bitacora.RegistrarEvento_22MS(
                    username,
                    "Seguridad",
                    "Login fallido",
                    2
                );

                throw new Exception("Usuario inexistente");
            }

            if (dalUsuario_22MS.EstaBloqueado_22MS(usuario.Username_22MS))
            {
                bitacora.RegistrarEvento_22MS(
                    usuario.Username_22MS,
                    "Seguridad",
                    "Login fallido. Usuario bloqueado.",
                    2
                );

                throw new Exception("Usuario bloqueado. Intente más tarde");
            }

            if (!dalUsuario_22MS.EstaActivo_22MS(usuario.Username_22MS))
            {
                bitacora.RegistrarEvento_22MS(
                    usuario.Username_22MS,
                    "Seguridad",
                    "Login fallido. Usuario desactivado.",
                    2
                );

                throw new Exception("Usuario desactivado. Contacte al administrador");
            }

            string hashPassword = Crypto_22MS.Hash_22MS(password);

            if (usuario.Password_22MS != hashPassword)
            {
                int intentos = IncrementarIntentos_22MS(username);

                bitacora.RegistrarEvento_22MS(
                    usuario.Username_22MS,
                    "Seguridad",
                    "Login fallido. Contraseña incorrecta.",
                    2
                );

                if (intentos >= 3)
                {
                    dalUsuario_22MS.BloquearUsuario_22MS(username);

                    bitacora.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Bloqueo de usuario",
                        1
                    );

                    RecalcularDigitos_22MS();

                    throw new Exception("Demasiados intentos. Intente nuevamente en 5 minutos");
                }

                throw new Exception($"Contraseña incorrecta. Intentos: {intentos}");
            }

            ResetearIntentos_22MS(username);

            return usuario;
        }

        public void CambiarPassword_22MS(string username, string nuevaPassword)
        {
            dalUsuario_22MS.CambiarPassword_22MS(username, nuevaPassword);

            RecalcularDigitos_22MS();
        }

        public void Desbloquear_22MS(string username, string apellido, int dniDesbloqueo)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Usuario inválido");

            bool bloqueado = dalUsuario_22MS.EstaBloqueado_22MS(username);

            if (!bloqueado)
                throw new Exception("El usuario no está bloqueado");

            string password = Crypto_22MS.Hash_22MS(dniDesbloqueo + apellido);

            dalUsuario_22MS.DesbloquearUsuario_22MS(username, password);

            RecalcularDigitos_22MS();
        }

        public void InsertarUsuario_22MS(string apellido, string nombre, string dni, int? idRol, string email, string codigoIdioma)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new Exception(
                    "Debe ingresar el apellido."
                );

            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception(
                    "Debe ingresar el nombre."
                );

            if (!int.TryParse(dni, out int dniNumero))
                throw new Exception(
                    "El DNI ingresado no es válido."
                );

            if (!idRol.HasValue)
                throw new Exception(
                    "Debe seleccionar un rol."
                );

            if (string.IsNullOrWhiteSpace(codigoIdioma))
                throw new Exception(
                    "Debe seleccionar un idioma."
                );

            Idioma_22MS idioma =
                bllIdioma_22MS.ObtenerIdioma_22MS(
                    codigoIdioma
                );

            if (idioma == null)
                throw new Exception(
                    "El idioma seleccionado no es válido."
                );

            string username = nombre + dni;
            string passwordPlano = dni + apellido;

            string passwordHash =
                Crypto_22MS.Hash_22MS(
                    passwordPlano
                );

            if (dalUsuario_22MS.ExisteUsuario_22MS(
                username,
                dniNumero))
            {
                throw new Exception(
                    "El usuario ya existe."
                );
            }

            dalUsuario_22MS.InsertarUsuario_22MS(
                username,
                passwordHash,
                dniNumero,
                apellido,
                nombre,
                idRol,
                email,
                codigoIdioma
            );

            RecalcularDigitos_22MS();
        }

        public void ModificarUsuario_22MS(string dni, string email, int idRol)
        {
            dalUsuario_22MS.ModificarUsuario_22MS(int.Parse(dni), email, idRol);

            RecalcularDigitos_22MS();
        }

        public void ActualizarIdiomaUsuario_22MS(int idUsuario, string codigoIdioma)
        {
            if (idUsuario <= 0)
                throw new Exception(
                    "El usuario no es válido."
                );

            if (string.IsNullOrWhiteSpace(codigoIdioma))
                throw new Exception(
                    "Debe seleccionar un idioma."
                );

            Idioma_22MS idioma =
                bllIdioma_22MS.ObtenerIdioma_22MS(
                    codigoIdioma
                );

            if (idioma == null)
                throw new Exception(
                    "El idioma seleccionado no es válido."
                );

            dalUsuario_22MS.ActualizarIdiomaUsuario_22MS(
                idUsuario,
                codigoIdioma
            );

            RecalcularDigitos_22MS();
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
            return dalUsuario_22MS.ObtenerUsuariosFiltrados_22MS(
                dni,
                apellido,
                nombre,
                email,
                idRol,
                login,
                activos
            );
        }

        public void CambiarEstado_22MS(int dni, bool activo)
        {
            dalUsuario_22MS.CambiarEstado_22MS(dni, activo);

            RecalcularDigitos_22MS();
        }

        public static int IncrementarIntentos_22MS(string username)
        {
            if (!cacheIntentos.ContainsKey(username))
            {
                cacheIntentos[username] = (1, DateTime.Now);
                return 1;
            }

            var dataIntentos = cacheIntentos[username];

            if ((DateTime.Now - dataIntentos.ultimoIntento).TotalMinutes >= 5)
            {
                cacheIntentos[username] = (1, DateTime.Now);
                return 1;
            }

            int nuevosIntentos = dataIntentos.intentos + 1;

            cacheIntentos[username] = (nuevosIntentos, DateTime.Now);

            return nuevosIntentos;
        }

        public static void ResetearIntentos_22MS(string username)
        {
            if (cacheIntentos.ContainsKey(username))
                cacheIntentos.Remove(username);
        }

        public void Logout_22MS()
        {
            SessionManager_22MS.Logout_22MS();
        }

        public DataTable ObtenerUsuarios_22MS()
        {
            return dalUsuario_22MS.ObtenerUsuarios_22MS();
        }

        public DataRow ObtenerUsuarioPorLogin_22MS(string login)
        {
            DataTable tablaUsuarios = dalUsuario_22MS.ObtenerUsuarioPorLogin_22MS(login);

            if (tablaUsuarios.Rows.Count == 0)
                return null;

            return tablaUsuarios.Rows[0];
        }

        public bool ValidarAdministradorReparacion_22MS(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Debe completar usuario y contraseña.");

            UsuarioServicios_22MS usuario = dalUsuario_22MS.ObtenerUsuario_22MS(username);

            if (usuario == null)
                throw new Exception("Usuario inexistente.");

            if (!usuario.Activo_22MS)
                throw new Exception("El usuario se encuentra inactivo.");

            if (usuario.Bloqueado_22MS)
                throw new Exception("El usuario se encuentra bloqueado.");

            string hashPassword = Crypto_22MS.Hash_22MS(password);

            if (usuario.Password_22MS != hashPassword)
                throw new Exception("Contraseña incorrecta.");

            if (usuario.Rol_22MS == null || usuario.Rol_22MS.NombreRol_22MS != "Admin")
                throw new Exception("Solo un administrador puede reparar la integridad del sistema.");

            return true;
        }

    }
}