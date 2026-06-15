using BLL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmBackup_22MS : Form
    {
        private BLLBackupRestore_22MS bllBackupRestore_22MS = new BLLBackupRestore_22MS();
        private BLLBitacoraEvento_22MS bllBitacoraEvento_22MS = new BLLBitacoraEvento_22MS();
        

        public FrmBackup_22MS()
        {
            InitializeComponent();
        }

        private string ObtenerUsuarioActual_22MS()
        {
            if (SessionManager_22MS.GetInstance_22MS() != null &&
                SessionManager_22MS.GetInstance_22MS().Usuario_22MS != null)
            {
                return SessionManager_22MS.GetInstance_22MS().Usuario_22MS.Username_22MS;
            }

            return "Sistema";
        }

        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                bllBackupRestore_22MS.GenerarBackup_22MS(txtRutaBackup.Text);

                bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                    ObtenerUsuarioActual_22MS(),
                    "Backup",
                    "Generación de backup de base de datos",
                    2
                );

                MessageBox.Show("Backup generado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Backup SQL Server (*.bak)|*.bak";
            saveFileDialog.Title = "Guardar backup";
            saveFileDialog.FileName = "Backup_22MS_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaBackup.Text = saveFileDialog.FileName;
            }
        }

        private void FrmBackup_22MS_Load(object sender, EventArgs e)
        {

        }
    }
}
