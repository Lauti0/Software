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
namespace Proyecto_final
{
    public partial class FrmInicioSesion_22MS : Form
    {
        private bool isPasswordHidden = true;
        public FrmInicioSesion_22MS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtContraseña_22MS.UseSystemPasswordChar = true; 
            btnOcultarContraseña.Text = "👁"; 
        }

        private void btnIniciarSesion_22MS_Click(object sender, EventArgs e)
        {
            
            try
            {
                BLLUsuario_22MS bll = new BLLUsuario_22MS();

                var usuario = bll.Login_22MS(txtUsuario_22MS.Text, txtContraseña_22MS.Text);

                if (Servicios_22MS.SessionManager_22MS.IsLogged_22MS())
                    Servicios_22MS.SessionManager_22MS.Logout_22MS();

                Servicios_22MS.SessionManager_22MS.Login_22MS(usuario);

                MessageBox.Show("Login correcto");
                new FrmMenuPrincipal_22MS().Show();                
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
