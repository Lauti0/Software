using System;

namespace Servicios_22MS
{
    public class SessionManager_22MS
    {
        private static readonly object _lock_22MS = new object();
        private static SessionManager_22MS _session_22MS;

        public UsuarioServicios_22MS Usuario_22MS { get; private set; }

        public static SessionManager_22MS GetInstance_22MS()
        {
            return _session_22MS;
        }

        public static void Login_22MS(UsuarioServicios_22MS usuario)
        {
            if (usuario == null)
                throw new Exception("Usuario inválido");

            lock (_lock_22MS)
            {
                if (_session_22MS != null)
                {
                    if (_session_22MS.Usuario_22MS.Username_22MS == usuario.Username_22MS)
                        throw new Exception("Ya hay una instancia de ese usuario logueada");
                    else
                        throw new Exception("Ya hay una sesión iniciada. Debe cerrar sesión primero");
                }

                _session_22MS = new SessionManager_22MS
                {
                    Usuario_22MS = usuario
                };
            }
        }

        public static void Logout_22MS()
        {
            lock (_lock_22MS)
            {
                if (_session_22MS != null)
                {
                    _session_22MS = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }
        }
    }
}