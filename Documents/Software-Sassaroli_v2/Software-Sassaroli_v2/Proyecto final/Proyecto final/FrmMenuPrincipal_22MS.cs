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
    public partial class FrmMenuPrincipal_22MS : Form
    {
        public FrmMenuPrincipal_22MS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private bool cerrarSinConfirmar_22MS = false;
        private void FrmPrincipal_22MS_Load(object sender, EventArgs e)
        {
            if (SessionManager_22MS.GetInstance_22MS() == null)
            {
                MessageBox.Show("Debe iniciar sesión");
                new FrmInicioSesion_22MS().Show();
                this.Close();
                return; 
            }

            UsuarioServicios_22MS usuario = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;

            if (usuario.Rol_22MS.ToString() != "Admin")
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
                UsuarioServicios_22MS usuario = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;
                BLLUsuario_22MS bll = new BLLUsuario_22MS();                
                bll.Logout_22MS();

                MessageBox.Show("Sesión cerrada");
                BLLBitacoraEvento_22MS bitacora = new BLLBitacoraEvento_22MS();
                bitacora.RegistrarEvento_22MS(
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

            SessionManager_22MS session = SessionManager_22MS.GetInstance_22MS();
            UsuarioServicios_22MS usuario = session.Usuario_22MS;

            if (usuario.Rol_22MS.ToString() != "Admin")
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }

            new FrmGestionarUsuarios_22MS().Show();
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInicioSesion_22MS login = new FrmInicioSesion_22MS();
            login.ShowDialog();
            cerrarSinConfirmar_22MS = true;
            this.Close();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SessionManager_22MS.GetInstance_22MS() == null)
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            new FrmCambiarPassword_22MS().ShowDialog();
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
                    BLLUsuario_22MS bLLUsuario_22MS = new BLLUsuario_22MS();
                    bLLUsuario_22MS.Logout_22MS();
                    Environment.Exit(0);
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

            SessionManager_22MS session = SessionManager_22MS.GetInstance_22MS();
            UsuarioServicios_22MS usuario = session.Usuario_22MS;

            if (usuario.Rol_22MS.ToString() != "Admin")
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }

            new FrmBitacoraEventos_22MS().Show();
        }
    }
}
