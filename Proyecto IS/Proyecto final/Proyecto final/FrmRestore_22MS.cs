using BLL_22MS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmRestore_22MS : Form
    {
        private BLLBackupRestore_22MS bllBackupRestore_22MS = new BLLBackupRestore_22MS();


        public FrmRestore_22MS()
        {
            InitializeComponent();
        }

        private void CargarBackups_22MS()
        {
            dgvRestore.DataSource = null;
            dgvRestore.DataSource = bllBackupRestore_22MS.ObtenerBackups_22MS();

            if (dgvRestore.Columns["RutaBackup_22MS"] != null)
                dgvRestore.Columns["RutaBackup_22MS"].Visible = false;

            if (dgvRestore.Columns["IdBackup_22MS"] != null)
                dgvRestore.Columns["IdBackup_22MS"].Visible = false;
        }

        private void ConfigurarGrilla_22MS()
        {
            dgvRestore.ReadOnly = true;
            dgvRestore.AllowUserToAddRows = false;
            dgvRestore.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRestore.MultiSelect = false;
            dgvRestore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRestore.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un backup.");
                    return;
                }

                string rutaBackup = dgvRestore.CurrentRow.Cells["RutaBackup_22MS"].Value.ToString();

                DialogResult respuesta = MessageBox.Show(
                    "Se restaurará la base de datos desde el backup seleccionado.\n\n" +
                    "Esta acción reemplazará el estado actual de la base. ¿Desea continuar?",
                    "Confirmar restore",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta != DialogResult.Yes)
                    return;

                bllBackupRestore_22MS.RestaurarBackup_22MS(rutaBackup);

                MessageBox.Show("Backup restaurado correctamente. El sistema se cerrará.");

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmRestore_22MS_Load(object sender, EventArgs e)
        {
            CargarBackups_22MS();
            ConfigurarGrilla_22MS();
        }
    }
}
