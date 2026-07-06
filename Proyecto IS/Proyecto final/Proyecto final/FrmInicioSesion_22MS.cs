using BLL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmInicioSesion_22MS : FrmBaseIdioma_22MS
    {
        private bool isPasswordHidden = true;
        private bool cerrarSinConfirmar_22MS = false;
        private bool abiertoDesdeMenu_22MS;
        private bool modoReparacionDV_22MS = false;
        private BLLIdioma_22MS bllIdioma_22MS = new BLLIdioma_22MS();


        public FrmInicioSesion_22MS(bool abiertoDesdeMenu_22MS = false, bool modoReparacionDV = false)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            txtContraseña_22MS.UseSystemPasswordChar = true;
            btnOcultarContraseña.Text = "👁";

            this.abiertoDesdeMenu_22MS = abiertoDesdeMenu_22MS;
            this.modoReparacionDV_22MS = modoReparacionDV;
        }

        private void btnIniciarSesion_22MS_Click(object sender, EventArgs e)
        {
            BLLBitacoraEvento_22MS bitacoraEvento =
        new BLLBitacoraEvento_22MS();

            try
            {
                BLLUsuario_22MS bllUsuario =
                    new BLLUsuario_22MS();

                UsuarioServicios_22MS usuario =
                    bllUsuario.Login_22MS(
                        txtUsuario_22MS.Text,
                        txtContraseña_22MS.Text
                    );

                /*
                 * Primero se verifica si existe una sesión.
                 * Así un intento de ingreso rechazado no modifica
                 * el idioma de la sesión que ya está abierta.
                 */
                SessionManager_22MS sesionActual =
                    SessionManager_22MS.GetInstance_22MS();

                if (sesionActual != null &&
                    sesionActual.Usuario_22MS != null)
                {
                    UsuarioServicios_22MS usuarioLogueado =
                        sesionActual.Usuario_22MS;

                    if (usuarioLogueado.Username_22MS ==
                            usuario.Username_22MS &&
                        usuarioLogueado.Password_22MS ==
                            usuario.Password_22MS)
                    {
                        MostrarMensaje_22MS(
                            "mensaje_mismo_usuario_logueado",
                            "titulo_inicio_sesion",
                            MessageBoxIcon.Warning
                        );

                        bitacoraEvento.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Seguridad",
                            "Intento loguearse con mismo usuario sin cerrar sesión",
                            2
                        );

                        FrmMenuPrincipal_22MS menuPrincipal =
                            new FrmMenuPrincipal_22MS();

                        menuPrincipal.Show();

                        cerrarSinConfirmar_22MS = true;
                        Close();

                        return;
                    }

                    MostrarMensaje_22MS(
                        "mensaje_otro_usuario_logueado",
                        "titulo_inicio_sesion",
                        MessageBoxIcon.Warning
                    );

                    bitacoraEvento.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Seguridad",
                        "Intento loguearse con otro usuario sin cerrar sesión",
                        2
                    );

                    return;
                }

                // Aplica el idioma guardado del usuario que ingresará.
                AplicarIdiomaGuardado_22MS(usuario);

                BLLDigitoVerificador_22MS bllDigito =
                    new BLLDigitoVerificador_22MS();

                List<ErrorIntegridad_22MS> erroresIntegridad =
                    bllDigito.VerificarIntegridad_22MS();

                if (erroresIntegridad.Count > 0)
                {
                    bool esAdmin =
                        usuario.Rol_22MS != null &&
                        usuario.Rol_22MS.NombreRol_22MS == "Admin";

                    if (!esAdmin)
                    {
                        MostrarMensaje_22MS(
                            "mensaje_sistema_no_disponible_integridad",
                            "titulo_sistema_no_disponible",
                            MessageBoxIcon.Error
                        );

                        bitacoraEvento.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Dígito Verificador",
                            "Intento de acceso bloqueado por inconsistencia de integridad",
                            3
                        );

                        return;
                    }

                    MostrarMensaje_22MS(
                        "mensaje_admin_redirigido_dv",
                        "titulo_error_integridad",
                        MessageBoxIcon.Warning
                    );

                    SessionManager_22MS.Login_22MS(usuario);

                    bitacoraEvento.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Dígito Verificador",
                        "Ingreso de administrador al módulo de reparación por inconsistencia de integridad",
                        3
                    );

                    FrmDigitoVerificador_22MS frmDigito =
                        new FrmDigitoVerificador_22MS();

                    Hide();
                    frmDigito.ShowDialog();

                    cerrarSinConfirmar_22MS = true;
                    Close();

                    return;
                }

                SessionManager_22MS.Login_22MS(usuario);

                string passwordFabrica =
                    usuario.DNI_22MS +
                    usuario.Apellido_22MS;

                if (usuario.Password_22MS ==
                    Crypto_22MS.Hash_22MS(passwordFabrica))
                {
                    MostrarMensaje_22MS(
                        "mensaje_login_cambiar_contrasena",
                        "titulo_inicio_sesion",
                        MessageBoxIcon.Information
                    );

                    FrmCambiarPassword_22MS frmCambiarPassword =
                        new FrmCambiarPassword_22MS();

                    Hide();

                    if (frmCambiarPassword.ShowDialog() ==
                        DialogResult.OK)
                    {
                        txtContraseña_22MS.Clear();
                    }

                    Show();
                    return;
                }

                MostrarMensaje_22MS(
                    "mensaje_login_correcto",
                    "titulo_inicio_sesion",
                    MessageBoxIcon.Information
                );

                bitacoraEvento.RegistrarEvento_22MS(
                    usuario.Username_22MS,
                    "Usuarios",
                    "Login",
                    1
                );

                cerrarSinConfirmar_22MS = true;

                FrmMenuPrincipal_22MS frmMenuPrincipal =
                    new FrmMenuPrincipal_22MS();

                Hide();
                frmMenuPrincipal.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    TraducirMensaje_22MS(ex.Message),
                    TraducirMensaje_22MS("titulo_error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FrmInicioSesion_22MS_Load(object sender, EventArgs e)
        {
            
        }


        private void btnOcultarContraseña_Click(object sender, EventArgs e)
        {
            isPasswordHidden = !isPasswordHidden;

            txtContraseña_22MS.UseSystemPasswordChar = isPasswordHidden;

            btnOcultarContraseña.Text = isPasswordHidden ? "👁" : "🔒";
        }

        private void FrmInicioSesion_22MS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrarSinConfirmar_22MS)
                return;

            bool menuAbierto = Application.OpenForms
                .OfType<FrmMenuPrincipal_22MS>()
                .Any();

            if (menuAbierto)
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
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        

        private void AplicarIdiomaGuardado_22MS(UsuarioServicios_22MS usuario)
        {
            if (usuario == null)
                return;

            string codigoIdioma_22MS =
                usuario.CodigoIdioma_22MS;

            if (string.IsNullOrWhiteSpace(codigoIdioma_22MS))
                codigoIdioma_22MS = "es";

            Idioma_22MS idiomaUsuario_22MS;

            try
            {
                idiomaUsuario_22MS =
                    bllIdioma_22MS.ObtenerIdioma_22MS(
                        codigoIdioma_22MS.Trim().ToLower()
                    );
            }
            catch
            {
                idiomaUsuario_22MS =
                    bllIdioma_22MS.ObtenerIdioma_22MS("es");
            }

            IdiomaManager_22MS
                .GetInstance_22MS()
                .CambiarIdioma_22MS(
                    idiomaUsuario_22MS
                );
        }


        private string ObtenerUsuarioActual_22MS()
        {
            if (SessionManager_22MS.GetInstance_22MS() != null &&
                SessionManager_22MS.GetInstance_22MS().Usuario_22MS != null)
            {
                return SessionManager_22MS
                    .GetInstance_22MS()
                    .Usuario_22MS
                    .Username_22MS;
            }

            return "Sistema";
        }

        private void btnCambiarIdioma_Click_1(object sender, EventArgs e)
        {
            FrmCambiarIdioma_22MS frmCambiarIdioma_22MS = new FrmCambiarIdioma_22MS();
            frmCambiarIdioma_22MS.ShowDialog();
        }

        private string TraducirMensaje_22MS(string clave_22MS)
        {
            return bllIdioma_22MS.Traducir_22MS(clave_22MS);
        }

        private void MostrarMensaje_22MS(
            string claveMensaje_22MS,
            string claveTitulo_22MS,
            MessageBoxIcon icono_22MS)
        {
            MessageBox.Show(
                TraducirMensaje_22MS(claveMensaje_22MS),
                TraducirMensaje_22MS(claveTitulo_22MS),
                MessageBoxButtons.OK,
                icono_22MS
            );
        }
    }
}