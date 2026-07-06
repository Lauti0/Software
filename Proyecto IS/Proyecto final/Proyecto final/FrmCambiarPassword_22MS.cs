using BLL_22MS;
using Servicios_22MS;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmCambiarPassword_22MS : FrmBaseIdioma_22MS
    {
        private readonly BLLIdioma_22MS bllIdioma_22MS =
            new BLLIdioma_22MS();

        public FrmCambiarPassword_22MS()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SessionManager_22MS sesion_22MS =
                    SessionManager_22MS.GetInstance_22MS();

                if (sesion_22MS == null ||
                    sesion_22MS.Usuario_22MS == null)
                {
                    throw new Exception(
                        "mensaje_debe_iniciar_sesion"
                    );
                }

                UsuarioServicios_22MS usuario_22MS =
                    sesion_22MS.Usuario_22MS;

                BLLUsuario_22MS bllUsuario_22MS =
                    new BLLUsuario_22MS();

                BLLBitacoraEvento_22MS bitacoraEvento_22MS =
                    new BLLBitacoraEvento_22MS();

                if (string.IsNullOrWhiteSpace(txtActual.Text) ||
                    string.IsNullOrWhiteSpace(txtNueva.Text) ||
                    string.IsNullOrWhiteSpace(txtConfirmar.Text))
                {
                    throw new Exception(
                        "mensaje_completar_campos"
                    );
                }

                string hashActual_22MS =
                    Crypto_22MS.Hash_22MS(txtActual.Text);

                string hashNueva_22MS =
                    Crypto_22MS.Hash_22MS(txtNueva.Text);

                string hashConfirmar_22MS =
                    Crypto_22MS.Hash_22MS(txtConfirmar.Text);

                if (hashNueva_22MS != hashConfirmar_22MS)
                {
                    RegistrarIntentoFallido_22MS(
                        bitacoraEvento_22MS,
                        usuario_22MS
                    );

                    throw new Exception(
                        "mensaje_contrasenas_no_coinciden"
                    );
                }

                if (txtNueva.Text.Length < 6)
                {
                    RegistrarIntentoFallido_22MS(
                        bitacoraEvento_22MS,
                        usuario_22MS
                    );

                    throw new Exception(
                        "mensaje_contrasena_minimo_caracteres"
                    );
                }

                if (hashActual_22MS == hashNueva_22MS)
                {
                    RegistrarIntentoFallido_22MS(
                        bitacoraEvento_22MS,
                        usuario_22MS
                    );

                    throw new Exception(
                        "mensaje_contrasena_igual_actual"
                    );
                }

                if (!txtNueva.Text.Any(char.IsUpper) ||
                    !txtNueva.Text.Any(char.IsDigit))
                {
                    RegistrarIntentoFallido_22MS(
                        bitacoraEvento_22MS,
                        usuario_22MS
                    );

                    throw new Exception(
                        "mensaje_contrasena_mayuscula_numero"
                    );
                }

                if (hashActual_22MS !=
                    usuario_22MS.Password_22MS)
                {
                    RegistrarIntentoFallido_22MS(
                        bitacoraEvento_22MS,
                        usuario_22MS
                    );

                    throw new Exception(
                        "mensaje_contrasena_actual_incorrecta"
                    );
                }

                bllUsuario_22MS.CambiarPassword_22MS(
                    usuario_22MS.Username_22MS,
                    hashNueva_22MS
                );

                MessageBox.Show(
                    bllIdioma_22MS.Traducir_22MS(
                        "mensaje_contrasena_actualizada"
                    ),
                    bllIdioma_22MS.Traducir_22MS(
                        "titulo_cambiar_contrasena"
                    ),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                bitacoraEvento_22MS.RegistrarEvento_22MS(
                    usuario_22MS.Username_22MS,
                    "Seguridad",
                    "Cambio de contraseña",
                    2
                );

                LimpiarCampos_22MS();

                bllUsuario_22MS.Logout_22MS();

                MessageBox.Show(
                    bllIdioma_22MS.Traducir_22MS(
                        "mensaje_iniciar_sesion_nuevamente"
                    ),
                    bllIdioma_22MS.Traducir_22MS(
                        "titulo_cambiar_contrasena"
                    ),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    bllIdioma_22MS.Traducir_22MS(
                        ex.Message
                    ),
                    bllIdioma_22MS.Traducir_22MS(
                        "titulo_error"
                    ),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void RegistrarIntentoFallido_22MS(
            BLLBitacoraEvento_22MS bitacoraEvento_22MS,
            UsuarioServicios_22MS usuario_22MS)
        {
            bitacoraEvento_22MS.RegistrarEvento_22MS(
                usuario_22MS.Username_22MS,
                "Seguridad",
                "Intenta cambiar contraseña",
                2
            );
        }

        private void LimpiarCampos_22MS()
        {
            txtActual.Clear();
            txtNueva.Clear();
            txtConfirmar.Clear();
        }

        private void FrmCambiarPassword_22MS_Load(
            object sender,
            EventArgs e)
        {
        }
    }
}