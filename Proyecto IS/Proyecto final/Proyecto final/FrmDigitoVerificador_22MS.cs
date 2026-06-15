using BLL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmDigitoVerificador_22MS : Form
    {
        private BLLDigitoVerificador_22MS bllDigito_22MS = new BLLDigitoVerificador_22MS();
        private BLLBitacoraEvento_22MS bllBitacoraEvento_22MS = new BLLBitacoraEvento_22MS();


        public FrmDigitoVerificador_22MS()
        {
            InitializeComponent();
        }

        private void FrmDigitoVerificador_22MS_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla_22MS();
            CargarErroresIntegridad_22MS();
        }

        private void CargarErroresIntegridad_22MS()
        {
            try
            {
                List<ErrorIntegridad_22MS> errores = bllDigito_22MS.VerificarIntegridad_22MS();

                dgvErrores.DataSource = null;
                dgvErrores.DataSource = errores;

                if (errores.Count == 0)
                {
                    MessageBox.Show("La integridad de la base de datos es correcta.");
                }
                else
                {
                    MessageBox.Show("Se detectaron errores de integridad. Revise la grilla.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void ConfigurarGrilla_22MS()
        {
            dgvErrores.AutoGenerateColumns = true;
            dgvErrores.ReadOnly = true;
            dgvErrores.AllowUserToAddRows = false;
            dgvErrores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvErrores.MultiSelect = false;
            dgvErrores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRecalcularDV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show(
                    "Recalcular los dígitos verificadores no corrige una inconsistencia, solo acepta el estado actual de la base como válido. ¿Desea continuar?",
                    "Confirmar recálculo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta != DialogResult.Yes)
                    return;

                bllDigito_22MS.RecalcularTodos_22MS();

                bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                    ObtenerUsuarioActual_22MS(),
                    "Dígito Verificador",
                    "Recálculo de dígitos verificadores. Se acepta el estado actual de la base de datos.",
                    2
                );

                dgvErrores.DataSource = null;

                MessageBox.Show("Dígitos verificadores recalculados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmDigitoVerificador_22MS_Load_1(object sender, EventArgs e)
        {
            ConfigurarGrilla_22MS();
            CargarErroresIntegridad_22MS();
        }
    }
}
