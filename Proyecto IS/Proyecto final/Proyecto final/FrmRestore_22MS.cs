using BLL_22MS;
using System;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmRestore_22MS : FrmBaseIdioma_22MS
    {
        private readonly BLLBackupRestore_22MS bllBackupRestore_22MS =
            new BLLBackupRestore_22MS();

        private readonly BLLIdioma_22MS bllIdioma_22MS =
            new BLLIdioma_22MS();

        public FrmRestore_22MS()
        {
            InitializeComponent();
        }

        private string Traducir_22MS(string clave_22MS)
        {
            return bllIdioma_22MS.Traducir_22MS(clave_22MS);
        }

        private void CargarBackups_22MS()
        {
            dgvRestore.DataSource = null;
            dgvRestore.DataSource =
                bllBackupRestore_22MS.ObtenerBackups_22MS();

            if (dgvRestore.Columns["RutaBackup_22MS"] != null)
                dgvRestore.Columns["RutaBackup_22MS"].Visible = false;

            if (dgvRestore.Columns["IdBackup_22MS"] != null)
                dgvRestore.Columns["IdBackup_22MS"].Visible = false;
        }

        private void ConfigurarGrilla_22MS()
        {
            dgvRestore.ReadOnly = true;
            dgvRestore.AllowUserToAddRows = false;

            dgvRestore.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvRestore.MultiSelect = false;

            dgvRestore.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRestore.CurrentRow == null)
                {
                    MessageBox.Show(
                        Traducir_22MS(
                            "mensaje_seleccionar_backup"
                        ),
                        Traducir_22MS(
                            "titulo_restaurar_backup"
                        ),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string rutaBackup =
                    dgvRestore.CurrentRow
                        .Cells["RutaBackup_22MS"]
                        .Value
                        .ToString();

                DialogResult respuesta = MessageBox.Show(
                    Traducir_22MS(
                        "mensaje_confirmar_restore"
                    ),
                    Traducir_22MS(
                        "titulo_confirmar_restore"
                    ),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta != DialogResult.Yes)
                    return;

                bllBackupRestore_22MS
                    .RestaurarBackup_22MS(rutaBackup);

                MessageBox.Show(
                    Traducir_22MS(
                        "mensaje_restore_correcto"
                    ),
                    Traducir_22MS(
                        "titulo_restaurar_backup"
                    ),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    Traducir_22MS(ex.Message),
                    Traducir_22MS("titulo_error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FrmRestore_22MS_Load(
            object sender,
            EventArgs e)
        {
            ConfigurarGrilla_22MS();
            CargarBackups_22MS();
        }
    }
}