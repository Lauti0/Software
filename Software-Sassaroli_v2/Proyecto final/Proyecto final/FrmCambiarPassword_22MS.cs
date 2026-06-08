using BLL_22MS;
using Servicios_22MS;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmCambiarPassword_22MS : Form
    {
        public FrmCambiarPassword_22MS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionManager_22MS.GetInstance_22MS() == null)
                {
                    MessageBox.Show("Debe iniciar sesión");
                    return;
                }

                UsuarioServicios_22MS usuario = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;

                BLLUsuario_22MS bllUsuario = new BLLUsuario_22MS();
                BLLBitacoraEvento_22MS bitacoraEvento = new BLLBitacoraEvento_22MS();

                if (string.IsNullOrWhiteSpace(txtActual.Text) ||
                    string.IsNullOrWhiteSpace(txtNueva.Text) ||
                    string.IsNullOrWhiteSpace(txtConfirmar.Text))
                {
                    throw new Exception("Debe completar todos los campos");
                }

                string hashActual = Crypto_22MS.Hash_22MS(txtActual.Text);
                string hashNueva = Crypto_22MS.Hash_22MS(txtNueva.Text);
                string hashConfirmar = Crypto_22MS.Hash_22MS(txtConfirmar.Text);

                if (hashNueva != hashConfirmar)
                {
                    bitacoraEvento.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Intenta cambiar contraseña",
                        2
                    );

                    throw new Exception("Las contraseñas no coinciden");
                }

                if (txtNueva.Text.Length < 6)
                {
                    bitacoraEvento.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Intenta cambiar contraseña",
                        2
                    );

                    throw new Exception("La contraseña debe tener al menos 6 caracteres");
                }

                if (hashActual == hashNueva)
                {
                    bitacoraEvento.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Intenta cambiar contraseña",
                        2
                    );

                    throw new Exception("La nueva contraseña no puede ser igual a la actual");
                }

                if (!txtNueva.Text.Any(char.IsUpper) || !txtNueva.Text.Any(char.IsDigit))
                {
                    bitacoraEvento.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Intenta cambiar contraseña",
                        2
                    );

                    throw new Exception("Debe tener al menos una mayúscula y un número");
                }

                if (hashActual != usuario.Password_22MS)
                {
                    bitacoraEvento.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Intenta cambiar contraseña",
                        2
                    );

                    throw new Exception("Su contraseña actual es incorrecta");
                }

                bllUsuario.CambiarPassword_22MS(
                    usuario.Username_22MS,
                    hashNueva
                );

                MessageBox.Show("Contraseña actualizada correctamente");

                bitacoraEvento.RegistrarEvento_22MS(
                    usuario.Username_22MS,
                    "Seguridad",
                    "Cambio de contraseña",
                    2
                );

                LimpiarCampos_22MS();

                bllUsuario.Logout_22MS();

                MessageBox.Show("Debe iniciar sesión nuevamente");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarCampos_22MS()
        {
            txtActual.Text = "";
            txtNueva.Text = "";
            txtConfirmar.Text = "";
        }

        private void FrmCambiarPassword_22MS_Load(object sender, EventArgs e)
        {
        }
    }
}