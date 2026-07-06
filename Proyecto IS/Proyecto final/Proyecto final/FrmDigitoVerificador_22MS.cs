using BLL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmDigitoVerificador_22MS : FrmBaseIdioma_22MS
    {
        private readonly BLLDigitoVerificador_22MS bllDigito_22MS =
            new BLLDigitoVerificador_22MS();

        private readonly BLLBitacoraEvento_22MS bllBitacoraEvento_22MS =
            new BLLBitacoraEvento_22MS();

        private readonly BLLIdioma_22MS bllIdioma_22MS =
            new BLLIdioma_22MS();

        public FrmDigitoVerificador_22MS()
        {
            InitializeComponent();
        }

        private void FrmDigitoVerificador_22MS_Load(
            object sender,
            EventArgs e)
        {
            ConfigurarGrilla_22MS();
            CargarErroresIntegridad_22MS();
        }

        private void CargarErroresIntegridad_22MS()
        {
            try
            {
                List<ErrorIntegridad_22MS> errores =
                    bllDigito_22MS.VerificarIntegridad_22MS();

                dgvErrores.DataSource = null;
                dgvErrores.DataSource = errores;

                if (errores.Count == 0)
                {
                    MessageBox.Show(
                        bllIdioma_22MS.Traducir_22MS(
                            "mensaje_integridad_correcta"
                        ),
                        bllIdioma_22MS.Traducir_22MS(
                            "titulo_digito_verificador"
                        ),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        bllIdioma_22MS.Traducir_22MS(
                            "mensaje_errores_integridad"
                        ),
                        bllIdioma_22MS.Traducir_22MS(
                            "titulo_digito_verificador"
                        ),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    bllIdioma_22MS.Traducir_22MS(ex.Message),
                    bllIdioma_22MS.Traducir_22MS(
                        "titulo_error"
                    ),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string ObtenerUsuarioActual_22MS()
        {
            SessionManager_22MS sesion_22MS =
                SessionManager_22MS.GetInstance_22MS();

            if (sesion_22MS != null &&
                sesion_22MS.Usuario_22MS != null)
            {
                return sesion_22MS
                    .Usuario_22MS
                    .Username_22MS;
            }

            return "Sistema";
        }

        private void ConfigurarGrilla_22MS()
        {
            dgvErrores.AutoGenerateColumns = true;
            dgvErrores.ReadOnly = true;
            dgvErrores.AllowUserToAddRows = false;

            dgvErrores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvErrores.MultiSelect = false;

            dgvErrores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRecalcularDV_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show(
                    bllIdioma_22MS.Traducir_22MS(
                        "mensaje_confirmar_recalculo_dv"
                    ),
                    bllIdioma_22MS.Traducir_22MS(
                        "titulo_confirmar_recalculo"
                    ),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta != DialogResult.Yes)
                    return;

                bllDigito_22MS.RecalcularTodos_22MS();

                bllBitacoraEvento_22MS.RegistrarEvento_22MS(
                    ObtenerUsuarioActual_22MS(),
                    "Dígito Verificador",
                    "Recálculo de dígitos verificadores. " +
                    "Se acepta el estado actual de la base de datos.",
                    2
                );

                dgvErrores.DataSource = null;

                MessageBox.Show(
                    bllIdioma_22MS.Traducir_22MS(
                        "mensaje_dv_recalculados"
                    ),
                    bllIdioma_22MS.Traducir_22MS(
                        "titulo_digito_verificador"
                    ),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    bllIdioma_22MS.Traducir_22MS(ex.Message),
                    bllIdioma_22MS.Traducir_22MS(
                        "titulo_error"
                    ),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}