using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE662JS
{
    public class SessionManager662JS
    {
        private static readonly object _lock662JS = new object();
        private static SessionManager662JS _session662JS;

        public BEUsuario662JS Usuario662JS { get; private set; }
        public DateTime FechaInicio662JS { get; private set; }

        public static SessionManager662JS GetInstance662JS()
        {
            return _session662JS;
        }

        public static bool IsLogged662JS()
        {
            return _session662JS != null;
        }

        public static void Login662JS(BEUsuario662JS usuario)
        {
            if (usuario == null)
                throw new Exception("Usuario inválido");

            lock (_lock662JS)
            {
                if (_session662JS == null)
                {
                    _session662JS = new SessionManager662JS
                    {
                        Usuario662JS = usuario,
                        FechaInicio662JS = DateTime.Now
                    };
                }
                else
                {
                    throw new Exception("Sesión ya iniciada");
                }
            }
        }

        public static void Logout662JS()
        {
            lock (_lock662JS)
            {
                if (_session662JS != null)
                {
                    _session662JS = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }
        }
    }
}
