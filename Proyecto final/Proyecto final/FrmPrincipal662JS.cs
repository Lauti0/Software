using BE662JS;
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
    public partial class FrmPrincipal662JS : Form
    {
        public FrmPrincipal662JS()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                SessionManager662JS.Logout662JS();

                MessageBox.Show("Sesión cerrada");

                new FrmInicioSesion662JS().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmPrincipal662JS_Load(object sender, EventArgs e)
        {
            if (!SessionManager662JS.IsLogged662JS())
            {
                MessageBox.Show("Debe iniciar sesión");
                new FrmInicioSesion662JS().Show();
                this.Close();
            }
        }
    }
}
