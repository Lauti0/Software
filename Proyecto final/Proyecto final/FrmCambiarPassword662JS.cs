using BLL662JS;
using Servicios662JS;
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
    public partial class FrmCambiarPassword662JS : Form
    {
        public FrmCambiarPassword662JS()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SessionManager662JS.IsLogged662JS())
                {
                    MessageBox.Show("Debe iniciar sesión");
                    return;
                }

                BEUsuario662JS usuario = SessionManager662JS.GetInstance662JS().Usuario662JS;

                BLLUsuario662JS bll = new BLLUsuario662JS();
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

                bll.CambiarPassword662JS(
                    usuario.Username662JS,
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

        private void FrmCambiarPassword662JS_Load(object sender, EventArgs e)
        {

        }
    }
}
