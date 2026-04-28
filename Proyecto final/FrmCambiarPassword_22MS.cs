using BLL_22MS;
using Servicios_22MS;
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
    public partial class FrmCambiarPassword_22MS : Form
    {
        public FrmCambiarPassword_22MS()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SessionManager_22MS.IsLogged_22MS())
                {
                    MessageBox.Show("Debe iniciar sesión");
                    return;
                }

                UsuarioServicios_22MS usuario = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;

                BLLUsuario_22MS bll = new BLLUsuario_22MS();
                if (string.IsNullOrWhiteSpace(txtActual.Text) ||
                string.IsNullOrWhiteSpace(txtNueva.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmar.Text))
                    throw new Exception("Debe completar todos los campos");

                if (txtNueva.Text != txtConfirmar.Text)
                    throw new Exception("Las contraseñas no coinciden");

                if (txtNueva.Text.Length < 6)
                    throw new Exception("La contraseña debe tener al menos 6 caracteres");
                if (txtActual.Text == txtNueva.Text)
                    throw new Exception("La nueva contraseña no puede ser igual a la actual");
                if (!txtNueva.Text.Any(char.IsUpper) || !txtNueva.Text.Any(char.IsDigit))
                    throw new Exception("Debe tener al menos una mayúscula y un número");

                bll.CambiarPassword_22MS(
                    usuario.Username_22MS,
                    txtActual.Text,
                    txtNueva.Text,
                    txtConfirmar.Text
                );

                MessageBox.Show("Contraseña actualizada correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCambiarPassword_22MS_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
