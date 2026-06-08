using BLL_22MS;
using Servicios_22MS;
using System;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmMenuPrincipal_22MS : Form
    {
        private bool cerrarSinConfirmar_22MS = false;

        public FrmMenuPrincipal_22MS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmPrincipal_22MS_Load(object sender, EventArgs e)
        {
            if (SessionManager_22MS.GetInstance_22MS() == null)
            {
                MessageBox.Show("Debe iniciar sesión");

                new FrmInicioSesion_22MS(true).Show();

                this.Close();

                return;
            }

            UsuarioServicios_22MS usuario = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;

            if (usuario.Rol_22MS.IdRol_22MS != 1)
            {
                gestionarUsuarioToolStripMenuItem.Visible = false;
                bitacoraToolStripMenuItem.Visible = false;
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",
                "Confirmar",
                MessageBoxButtons.YesNo
            );

            if (resultado == DialogResult.No)
                return;

            try
            {
                UsuarioServicios_22MS usuario = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;

                BLLUsuario_22MS bllUsuario = new BLLUsuario_22MS();

                bllUsuario.Logout_22MS();

                MessageBox.Show("Sesión cerrada");

                BLLBitacoraEvento_22MS bitacoraEvento = new BLLBitacoraEvento_22MS();

                bitacoraEvento.RegistrarEvento_22MS(
                    usuario.Username_22MS,
                    "Seguridad",
                    "Logout",
                    1
                );

                new FrmInicioSesion_22MS().Show();

                cerrarSinConfirmar_22MS = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gestionarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionManager_22MS.GetInstance_22MS() == null)
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            SessionManager_22MS sessionManager = SessionManager_22MS.GetInstance_22MS();
            UsuarioServicios_22MS usuario = sessionManager.Usuario_22MS;

            if (usuario.Rol_22MS.IdRol_22MS != 1)
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }

            new FrmGestionarUsuarios_22MS().Show();
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInicioSesion_22MS frmInicioSesion = new FrmInicioSesion_22MS();

            frmInicioSesion.ShowDialog();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCambiarPassword_22MS frmCambiarPassword = new FrmCambiarPassword_22MS();

            if (frmCambiarPassword.ShowDialog() == DialogResult.OK)
            {
                cerrarSinConfirmar_22MS = true;

                FrmInicioSesion_22MS frmInicioSesion = new FrmInicioSesion_22MS();

                frmInicioSesion.Show();

                this.Close();
            }
        }

        private void FrmMenuPrincipal_22MS_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (cerrarSinConfirmar_22MS)
                return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de que desea salir de la aplicación?",
                    "Confirmar salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    BLLUsuario_22MS bllUsuario = new BLLUsuario_22MS();

                    bllUsuario.Logout_22MS();
                }
            }
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionManager_22MS.GetInstance_22MS() == null)
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            SessionManager_22MS sessionManager = SessionManager_22MS.GetInstance_22MS();
            UsuarioServicios_22MS usuario = sessionManager.Usuario_22MS;

            if (usuario.Rol_22MS.IdRol_22MS != 1)
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }

            new FrmBitacoraEventos_22MS().Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionManager_22MS.GetInstance_22MS() == null)
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            SessionManager_22MS sessionManager = SessionManager_22MS.GetInstance_22MS();
            UsuarioServicios_22MS usuario = sessionManager.Usuario_22MS;

            if (usuario.Rol_22MS.IdRol_22MS != 1)
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }

            new FrmGestionarRoles_22MS().Show();
        }

        private void digitoVerificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDigitoVerificador_22MS frm = new FrmDigitoVerificador_22MS();
            frm.ShowDialog();
        }
    }
}