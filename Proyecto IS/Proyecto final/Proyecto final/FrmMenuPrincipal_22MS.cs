using BLL_22MS;
using Servicios_22MS;
using System;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmMenuPrincipal_22MS : FrmBaseIdioma_22MS
    {
        private bool cerrarSinConfirmar_22MS = false;
        private readonly BLLIdioma_22MS bllIdioma_22MS = new BLLIdioma_22MS();

        public FrmMenuPrincipal_22MS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
           
        }

        private void FrmPrincipal_22MS_Load(object sender, EventArgs e)
        {
            UsuarioServicios_22MS usuario_22MS = ObtenerUsuarioSesion_22MS();

            if (usuario_22MS == null)
            {
                MostrarAdvertencia_22MS(
                    "mensaje_debe_iniciar_sesion"
                );

                new FrmInicioSesion_22MS(true).Show();

                Close();
                return;
            }

            if (usuario_22MS.Rol_22MS.IdRol_22MS != 1)
            {
                gestionarUsuarioToolStripMenuItem.Visible = false;
                bitacoraToolStripMenuItem.Visible = false;
            }

            if (usuario_22MS.Rol_22MS.IdRol_22MS == 2)
            {
                adminToolStripMenuItem.Visible = false;
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
        TraducirMensaje_22MS(
            "pregunta_cerrar_sesion"
        ),
        TraducirMensaje_22MS(
            "titulo_confirmar_cierre_sesion"
        ),
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                UsuarioServicios_22MS usuario_22MS =
                    ObtenerUsuarioSesion_22MS();

                if (usuario_22MS == null)
                {
                    MostrarAdvertencia_22MS(
                        "mensaje_debe_iniciar_sesion"
                    );

                    return;
                }

                BLLUsuario_22MS bllUsuario_22MS =
                    new BLLUsuario_22MS();

                bllUsuario_22MS.Logout_22MS();

                MostrarInformacion_22MS(
                    "mensaje_sesion_cerrada"
                );

                BLLBitacoraEvento_22MS bitacoraEvento_22MS =
                    new BLLBitacoraEvento_22MS();

                bitacoraEvento_22MS.RegistrarEvento_22MS(
                    usuario_22MS.Username_22MS,
                    "Seguridad",
                    "Logout",
                    1
                );

                new FrmInicioSesion_22MS().Show();

                cerrarSinConfirmar_22MS = true;

                Close();
            }
            catch (Exception ex)
            {
                MostrarError_22MS(ex);
            }
        }

        private void gestionarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ValidarAdministrador_22MS(out UsuarioServicios_22MS usuario_22MS))
            {
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
                    TraducirMensaje_22MS(
                        "pregunta_salir_aplicacion"
                    ),
                    TraducirMensaje_22MS(
                        "titulo_confirmar_salida"
                    ),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                BLLUsuario_22MS bllUsuario_22MS =
                    new BLLUsuario_22MS();

                bllUsuario_22MS.Logout_22MS();
            }
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ValidarAdministrador_22MS(out UsuarioServicios_22MS usuario_22MS))
            {
                return;
            }

            new FrmBitacoraEventos_22MS().Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ValidarAdministrador_22MS(out UsuarioServicios_22MS usuario_22MS))
            {
                return;
            }

            new FrmGestionarRoles_22MS().Show();
        }

        private void digitoVerificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDigitoVerificador_22MS frm = new FrmDigitoVerificador_22MS();
            frm.ShowDialog();
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBackup_22MS frmBackup = new FrmBackup_22MS();
            frmBackup.ShowDialog();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRestore_22MS frmRestore = new FrmRestore_22MS();
            frmRestore.ShowDialog();
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCambiarIdioma_22MS frmCambiarIdioma_22MS = new FrmCambiarIdioma_22MS();
            frmCambiarIdioma_22MS.ShowDialog();
        }

        private void FrmMenuPrincipal_22MS_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private string TraducirMensaje_22MS(string clave_22MS)
        {
            return bllIdioma_22MS.Traducir_22MS(clave_22MS);
        }

        private void MostrarAdvertencia_22MS(string claveMensaje_22MS)
        {
            MessageBox.Show(
                TraducirMensaje_22MS(claveMensaje_22MS),
                TraducirMensaje_22MS("titulo_menu_principal"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private void MostrarInformacion_22MS(string claveMensaje_22MS)
        {
            MessageBox.Show(
                TraducirMensaje_22MS(claveMensaje_22MS),
                TraducirMensaje_22MS("titulo_menu_principal"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void MostrarError_22MS(Exception ex)
        {
            MessageBox.Show(
                TraducirMensaje_22MS(ex.Message),
                TraducirMensaje_22MS("titulo_error"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private UsuarioServicios_22MS ObtenerUsuarioSesion_22MS()
        {
            SessionManager_22MS sesion_22MS =
                SessionManager_22MS.GetInstance_22MS();

            return sesion_22MS?.Usuario_22MS;
        }

        private bool ValidarAdministrador_22MS(
            out UsuarioServicios_22MS usuario_22MS)
        {
            usuario_22MS = ObtenerUsuarioSesion_22MS();

            if (usuario_22MS == null)
            {
                MostrarAdvertencia_22MS(
                    "mensaje_debe_iniciar_sesion"
                );

                return false;
            }

            if (usuario_22MS.Rol_22MS == null ||
                usuario_22MS.Rol_22MS.IdRol_22MS != 1)
            {
                MostrarAdvertencia_22MS(
                    "mensaje_sin_permisos"
                );

                return false;
            }

            return true;
        }
    }
}