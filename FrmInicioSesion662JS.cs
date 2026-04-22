using BE662JS;
using BLL662JS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seguridad662JS;
namespace Proyecto_final
{
    public partial class FrmInicioSesion662JS : Form
    {
        public FrmInicioSesion662JS()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion662JS_Click(object sender, EventArgs e)
        {
            try
            {
                BLLUsuario662JS bll = new BLLUsuario662JS();

                var usuario = bll.Login662JS(txtUsuario662JS.Text, txtContraseña662JS.Text);

                if (SessionManager662JS.IsLogged662JS())
                    SessionManager662JS.Logout662JS();

                SessionManager662JS.Login662JS(usuario);

                MessageBox.Show("Login correcto");
               
                if (usuario.Rol662JS == "Admin")
                {
                    new FrmAdministrador662JS().Show();
                }
                else
                {
                    new FrmPrincipal662JS().Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmInicioSesion662JS_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string username = "eramirez";
            string dni = "45679200";
            string nombre="Esteban";
            string apellido = "Ramirez";
            string rol = "Cajero";
            string email = "estebanramirez@gmail.com";


            BLLUsuario662JS bll = new BLLUsuario662JS();
            bll.InsertarUsuario662JS(username, apellido, nombre, dni,rol,email);
        }
    }
}
