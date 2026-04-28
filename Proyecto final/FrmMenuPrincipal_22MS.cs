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
    public partial class FrmMenuPrincipal_22MS : Form
    {
        public FrmMenuPrincipal_22MS()
        {
            InitializeComponent();
        }        

        private void FrmPrincipal_22MS_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            if (!SessionManager_22MS.IsLogged_22MS())
            {
                MessageBox.Show("Debe iniciar sesión");
                new FrmInicioSesion_22MS().Show();
                this.Close();
                return; 
            }

            UsuarioServicios_22MS usuario = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;

            if (usuario.Rol_22MS != "Admin")
            {
                gestionarUsuarioToolStripMenuItem.Visible = false;
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SessionManager_22MS.Logout_22MS();

                MessageBox.Show("Sesión cerrada");

                new FrmInicioSesion_22MS().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gestionarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SessionManager_22MS.IsLogged_22MS())
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            SessionManager_22MS session = SessionManager_22MS.GetInstance_22MS();
            UsuarioServicios_22MS usuario = session.Usuario_22MS;

            if (usuario.Rol_22MS != "Admin")
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }

            new FrmGestionarUsuarios_22MS().Show();
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionManager_22MS.IsLogged_22MS())
            {
                MessageBox.Show("El usuario ya esta logeado");                
            }
            else
            {
                new FrmInicioSesion_22MS().Show();
            }
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SessionManager_22MS.IsLogged_22MS())
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            new FrmCambiarPassword_22MS().ShowDialog();
        }
    }
}
