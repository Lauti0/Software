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

            BLLDigitoVerificador_22MS bllDigito = new BLLDigitoVerificador_22MS();
            List<ErrorIntegridad_22MS> errores = bllDigito.VerificarIntegridad_22MS();

            if (errores.Count > 0)
            {
                MessageBox.Show(
                    "Se detectó una inconsistencia en la base de datos.\n\n" +
                    "Mientras persista la inconsistencia, únicamente los administradores podrán iniciar sesión para realizar tareas de reparación.",
                    "Error de integridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Application.Run(new FrmInicioSesion_22MS(false, true));
            }
            else
            {
                Application.Run(new FrmInicioSesion_22MS());
            }
        }
    }
}
