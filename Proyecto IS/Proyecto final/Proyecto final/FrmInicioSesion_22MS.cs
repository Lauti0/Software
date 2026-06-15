using BLL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmInicioSesion_22MS : Form
    {
        private bool isPasswordHidden = true;
        private bool cerrarSinConfirmar_22MS = false;
        private bool abiertoDesdeMenu_22MS;
        private bool modoReparacionDV_22MS = false;


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
            BLLBitacoraEvento_22MS bitacoraEvento = new BLLBitacoraEvento_22MS();

            try
            {
                BLLUsuario_22MS bllUsuario = new BLLUsuario_22MS();

                UsuarioServicios_22MS usuario = bllUsuario.Login_22MS(
                    txtUsuario_22MS.Text,
                    txtContraseña_22MS.Text
                );

                BLLDigitoVerificador_22MS bllDigito = new BLLDigitoVerificador_22MS();
                List<ErrorIntegridad_22MS> erroresIntegridad = bllDigito.VerificarIntegridad_22MS();

                if (erroresIntegridad.Count > 0)
                {
                    bool esAdmin = usuario.Rol_22MS != null &&
                                   usuario.Rol_22MS.NombreRol_22MS == "Admin";

                    if (!esAdmin)
                    {
                        MessageBox.Show(
                            "El sistema no se encuentra disponible por una inconsistencia en la base de datos.\n\n" +
                            "Contacte a un administrador.",
                            "Sistema no disponible",
                            MessageBoxButtons.OK,
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

                    MessageBox.Show(
                        "Se detectó una inconsistencia en la base de datos.\n\n" +
                        "Como administrador, será redirigido al módulo de Dígito Verificador.",
                        "Error de integridad",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    SessionManager_22MS.Login_22MS(usuario);

                    bitacoraEvento.RegistrarEvento_22MS(
                        usuario.Username_22MS,
                        "Dígito Verificador",
                        "Ingreso de administrador al módulo de reparación por inconsistencia de integridad",
                        3
                    );

                    FrmDigitoVerificador_22MS frmDigito = new FrmDigitoVerificador_22MS();

                    this.Hide();

                    frmDigito.ShowDialog();

                    cerrarSinConfirmar_22MS = true;

                    this.Close();

                    return;
                }

                if (SessionManager_22MS.GetInstance_22MS() != null)
                {
                    UsuarioServicios_22MS usuarioLogueado = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;

                    if (usuarioLogueado.Username_22MS == usuario.Username_22MS &&
                        usuarioLogueado.Password_22MS == usuario.Password_22MS)
                    {
                        MessageBox.Show("Ya hay una instancia de ese usuario logueada. Cierre la sesión de ese usuario para continuar");

                        bitacoraEvento.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Seguridad",
                            "Intento loguearse con mismo usuario sin cerrar sesión",
                            2
                        );

                        FrmMenuPrincipal_22MS menuPrincipal = new FrmMenuPrincipal_22MS();

                        menuPrincipal.Show();

                        cerrarSinConfirmar_22MS = true;

                        this.Close();

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ya hay una instancia de usuario logueada. Cierre la sesión de ese usuario para continuar");

                        bitacoraEvento.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Seguridad",
                            "Intento loguearse con otro usuario sin cerrar sesión",
                            2
                        );

                        return;
                    }
                }

                SessionManager_22MS.Login_22MS(usuario);

                string passwordFabrica = usuario.DNI_22MS + usuario.Apellido_22MS;

                if (usuario.Password_22MS == Crypto_22MS.Hash_22MS(passwordFabrica))
                {
                    MessageBox.Show("Login correcto. Debe cambiar su contraseña");

                    FrmCambiarPassword_22MS frmCambiarPassword = new FrmCambiarPassword_22MS();

                    this.Hide();

                    if (frmCambiarPassword.ShowDialog() == DialogResult.OK)
                    {
                        txtContraseña_22MS.Text = "";
                        this.Show();
                    }
                    else
                    {
                        this.Show();
                    }

                    return;
                }

                MessageBox.Show("Login correcto");

                bitacoraEvento.RegistrarEvento_22MS(
                    usuario.Username_22MS,
                    "Usuarios",
                    "Login",
                    1
                );

                cerrarSinConfirmar_22MS = true;

                FrmMenuPrincipal_22MS frmMenuPrincipal = new FrmMenuPrincipal_22MS();

                this.Hide();

                frmMenuPrincipal.ShowDialog();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    "¿Está seguro que desea salir de la aplicación?",
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
                    Application.Exit();
                }
            }
        }
    }
}