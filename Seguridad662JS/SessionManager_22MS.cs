using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_22MS
{
    public class SessionManager_22MS
    {
        private static readonly object _lock_22MS = new object();
        private static SessionManager_22MS _session_22MS;

        public UsuarioServicios_22MS Usuario_22MS { get; private set; }
        private static Dictionary<string, int> intentos_22MS = new Dictionary<string, int>();
        
        public static int IncrementarIntentos_22MS(string user)
        {
            if (!intentos_22MS.ContainsKey(user))
                intentos_22MS[user] = 0;

            intentos_22MS[user]++;

            return intentos_22MS[user];
        }

        public static void ResetearIntentos_22MS(string user)
        {
            if (intentos_22MS.ContainsKey(user))
                intentos_22MS[user] = 0;
        }
        public static SessionManager_22MS GetInstance_22MS()
        {
            return _session_22MS;
        }

        public static bool IsLogged_22MS()
        {
            return _session_22MS != null;
        }

        public static void Login_22MS(UsuarioServicios_22MS usuario)
        {
            if (usuario == null)
                throw new Exception("Usuario inválido");

            lock (_lock_22MS)
            {
                if (_session_22MS == null)
                {
                    _session_22MS = new SessionManager_22MS
                    {
                        Usuario_22MS = usuario,                        
                    };
                }
                else
                {
                    throw new Exception("Sesión ya iniciada");
                }
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
