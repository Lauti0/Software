using BLL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InicializarIdioma_22MS();
            Application.Run(new FrmInicioSesion_22MS());
            
        }

        private static void InicializarIdioma_22MS()
        {
            try
            {
                BLLIdioma_22MS bllIdioma_22MS =
                    new BLLIdioma_22MS();

                Idioma_22MS idiomaEspañol_22MS =
                    bllIdioma_22MS.ObtenerIdioma_22MS("es");

                IdiomaManager_22MS
                    .GetInstance_22MS()
                    .CambiarIdioma_22MS(idiomaEspañol_22MS);
            }
            catch
            {

            }
        }


    }
}
