using BLL_22MS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios_22MS;
namespace Proyecto_final
    
{
    public partial class FrmInicioSesion_22MS : Form
    {
        private bool isPasswordHidden = true;
        private bool cerrarSinConfirmar_22MS = false;
        public FrmInicioSesion_22MS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtContraseña_22MS.UseSystemPasswordChar = true; 
            btnOcultarContraseña.Text = "👁"; 
        }

        private void btnIniciarSesion_22MS_Click(object sender, EventArgs e)
        {
            BLLBitacoraEvento_22MS bitacora = new BLLBitacoraEvento_22MS();
            try
            {
                BLLUsuario_22MS bll = new BLLUsuario_22MS();

                var usuario = bll.Login_22MS(
                    txtUsuario_22MS.Text,
                    txtContraseña_22MS.Text
                );

                if (SessionManager_22MS.GetInstance_22MS()!=null)
                {
                    UsuarioServicios_22MS user= SessionManager_22MS.GetInstance_22MS().Usuario_22MS;
                    if (user.Username_22MS == usuario.Username_22MS && user.Password_22MS==usuario.Password_22MS)
                    {
                        MessageBox.Show("Ya hay una instancia de ese usuario logueada. Cierre la sesion de ese usuario para continuar");
                        bitacora.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Seguridad",
                            "Intento loguearse con mismo usuario sin cerrar sesion",
                            2
                        );
                        FrmMenuPrincipal_22MS menu = new FrmMenuPrincipal_22MS();
                        menu.Show();

                        cerrarSinConfirmar_22MS = true;
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ya hay una instancia de usuario logueada. Cierre la sesion de ese usuario para continuar");
                        bitacora.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Seguridad",
                            "Intento loguearse con otro usuario sin cerrar sesion",
                            2
                        );
                        return;
                    }

                }
                
                SessionManager_22MS.Login_22MS(usuario);

                MessageBox.Show("Login correcto");
                bitacora.RegistrarEvento_22MS(
                    usuario.Username_22MS,
                    "Usuarios",
                    "Login",
                    1
                );
                FrmMenuPrincipal_22MS menuPrincipal = new FrmMenuPrincipal_22MS();
                menuPrincipal.Show();

                this.Hide();
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
                    Environment.Exit(0);
                }
            }
        }

        //private void btnCrearUsuario_Click(object sender, EventArgs e)
        //{
        //    string username = "eramirez";
        //    string dni = "45679200";
        //    string nombre="Esteban";
        //    string apellido = "Ramirez";
        //    string rol = "Cajero";
        //    string email = "estebanramirez@gmail.com";


        //    BLLUsuario662JS bll = new BLLUsuario662JS();
        //    bll.InsertarUsuario662JS(username, apellido, nombre, dni,rol,email);
        //}
    }
}
