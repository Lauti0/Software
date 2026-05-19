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

                BLLUsuario_22MS bll = new BLLUsuario_22MS();
                BLLBitacoraEvento_22MS bitacora = new BLLBitacoraEvento_22MS();
                if (string.IsNullOrWhiteSpace(txtActual.Text) ||
                string.IsNullOrWhiteSpace(txtNueva.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmar.Text))
                    throw new Exception("Debe completar todos los campos");

                if (txtNueva.Text != txtConfirmar.Text)
                {
                    bitacora.RegistrarEvento_22MS(usuario.Username_22MS, "Seguridad", "Intenta cambiar contraseña", 2);
                    throw new Exception("Las contraseñas no coinciden");
                }
                    
                if (txtNueva.Text.Length < 6)
                {
                    bitacora.RegistrarEvento_22MS(usuario.Username_22MS, "Seguridad", "Intenta cambiar contraseña", 2);
                    throw new Exception("La contraseña debe tener al menos 6 caracteres");
                }
                if (txtActual.Text == txtNueva.Text)
                {
                    bitacora.RegistrarEvento_22MS(usuario.Username_22MS, "Seguridad", "Intenta cambiar contraseña", 2);
                    throw new Exception("La nueva contraseña no puede ser igual a la actual");
                }                    
                if (!txtNueva.Text.Any(char.IsUpper) || !txtNueva.Text.Any(char.IsDigit))
                {
                    bitacora.RegistrarEvento_22MS(usuario.Username_22MS, "Seguridad", "Intenta cambiar contraseña", 2);
                    throw new Exception("Debe tener al menos una mayúscula y un número");
                }                

                bll.CambiarPassword_22MS(
                    usuario.Username_22MS,
                    txtActual.Text,
                    txtNueva.Text
                );

                MessageBox.Show("Contraseña actualizada correctamente");
                bitacora.RegistrarEvento_22MS(usuario.Username_22MS, "Seguridad", "Cambio de contraseña", 2);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCambiarPassword_22MS_Load(object sender, EventArgs e)
        {
        }
    }
}
