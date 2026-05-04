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
    public partial class FrmMenuPrincipal_22MS : Form
    {
        public FrmMenuPrincipal_22MS()
        {
            InitializeComponent();
        }        

        private void FrmPrincipal662JS_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            if (SessionManager662JS.GetInstance662JS() == null)
            {
                MessageBox.Show("Debe iniciar sesión");
                new FrmInicioSesion662JS().Show();
                this.Close();
                return; 
            }

            UsuarioServicios662JS usuario = SessionManager662JS.GetInstance662JS().Usuario662JS;

            if (usuario.Rol662JS != "Admin")
            {
                gestionarUsuarioToolStripMenuItem.Visible = false;
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.No)
                return;

            try
            {
                BLLUsuario662JS bll = new BLLUsuario662JS();                
                bll.Logout_662JS();

                MessageBox.Show("Sesión cerrada");

                new FrmInicioSesion662JS().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gestionarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionManager662JS.GetInstance662JS() == null)
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            SessionManager662JS session = SessionManager662JS.GetInstance662JS();
            UsuarioServicios662JS usuario = session.Usuario662JS;

            if (usuario.Rol662JS != "Admin")
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }

            new FrmGestionarUsuarios_22MS().Show();
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmInicioSesion662JS().Show();
            this.Hide();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionManager662JS.GetInstance662JS() == null)
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            new FrmCambiarPassword662JS().ShowDialog();
        }
    }
}
