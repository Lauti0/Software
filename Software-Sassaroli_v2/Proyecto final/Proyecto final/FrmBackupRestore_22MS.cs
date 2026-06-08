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
    public partial class FrmBackupRestore_22MS : Form
    {
        private BLLBackupRestore_22MS bllBackupRestore_22MS = new BLLBackupRestore_22MS();

        public FrmBackupRestore_22MS()
        {
            InitializeComponent();
        }

        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                bllBackupRestore_22MS.GenerarBackup_22MS();

                MessageBox.Show(
                    "Backup generado correctamente.",
                    "Backup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarBackups_22MS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerBackups_Click(object sender, EventArgs e)
        {
            try
            {
                CargarBackups_22MS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarBackups_22MS()
        {
            dgvBackups.DataSource = null;
            dgvBackups.DataSource = bllBackupRestore_22MS.ObtenerBackups_22MS();

            if (dgvBackups.Columns["RutaBackup_22MS"] != null)
                dgvBackups.Columns["RutaBackup_22MS"].Visible = false;
        }

        private void ConfigurarGrilla_22MS()
        {
            dgvBackups.ReadOnly = true;
            dgvBackups.AllowUserToAddRows = false;
            dgvBackups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBackups.MultiSelect = false;
            dgvBackups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBackups.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un backup.");
                    return;
                }

                string rutaBackup = dgvBackups.CurrentRow.Cells["RutaBackup_22MS"].Value.ToString();

                DialogResult respuesta = MessageBox.Show(
                    "Se restaurará la base de datos desde el backup seleccionado.\n\n" +
                    "Esta acción reemplazará el estado actual de la base. ¿Desea continuar?",
                    "Confirmar restauración",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta != DialogResult.Yes)
                    return;

                bllBackupRestore_22MS.RestaurarBackup_22MS(rutaBackup);

                MessageBox.Show(
                    "Backup restaurado correctamente. El sistema se cerrará para iniciar nuevamente.",
                    "Restore finalizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmBackupRestore_22MS_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla_22MS();
            CargarBackups_22MS();
        }
    }
}
