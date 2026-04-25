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

namespace Proyecto_final
{
    public partial class FrmAdministrador662JS : Form
    {
        public FrmAdministrador662JS()
        {
            InitializeComponent();
        }
        private List<Control> campos662JS;
        enum Modo662JS
        {
            Consulta,
            Alta,
            Modificar,
            Desbloquear
        }
        private Modo662JS modoActual662JS = Modo662JS.Consulta;
        private void CambiarModo662JS(Modo662JS modo)
        {
            modoActual662JS = modo;

            ConfigurarBotones662JS(modo);
            ConfigurarCampos662JS(modo);
            ConfigurarMensaje662JS(modo);
        }
        private void ConfigurarMensaje662JS(Modo662JS modo)
        {
            switch (modo)
            {
                case Modo662JS.Consulta:
                    lblMensaje.Text = "Modo Consulta";
                    break;

                case Modo662JS.Alta:
                    lblMensaje.Text = "Modo Alta";
                    break;

                case Modo662JS.Modificar:                    
                    lblMensaje.Text = "Modo Modificar";
                    break;
                    
                case Modo662JS.Desbloquear:
                    if (dgvUsuarios662JS.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione un usuario");
                        return;
                    }
                    lblMensaje.Text = "Modo Desbloquear";
                    break;
            }
        }
        private void ConfigurarBotones662JS(Modo662JS modo)
        {
            bool esConsulta = modo == Modo662JS.Consulta;

            btnCrear.Enabled = esConsulta;
            btnModificar.Enabled = esConsulta;
            btnDesbloquear.Enabled = esConsulta;

            btnAplicar.Enabled = true;
            btnCancelar.Enabled = !esConsulta;
        }
        private void ConfigurarCampos662JS(Modo662JS modo)
        {
            bool habilitar = (modo == Modo662JS.Alta || modo == Modo662JS.Modificar);

            HabilitarCampos662JS(habilitar);
            txtDNI.Enabled = (modo == Modo662JS.Alta);
            if (modo == Modo662JS.Alta)
                LimpiarCampos662JS();
        }

        private void LimpiarCampos662JS()
        {
            txtApellido.Text=txtNombre.Text=txtDNI.Text=txtEmail.Text=txtLogin.Text=txtRol.Text="";
            chkActivos662JS.Checked = true;
            chkTodos662JS.Checked = false;
        }

        private void InicializarCampos662JS()
        {
            campos662JS = new List<Control>
            {
                txtDNI, txtNombre, txtApellido, txtEmail, txtRol, txtLogin
            };
        }

        private void HabilitarCampos662JS(bool habilitar)
        {
            foreach (var c in campos662JS)
                c.Enabled = habilitar;
        }
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLUsuario662JS bll = new BLLUsuario662JS();

                switch (modoActual662JS)
                {
                    case Modo662JS.Consulta:

                        DataTable tabla = bll.ObtenerUsuariosFiltrados662JS(
                            txtDNI.Text,
                            txtApellido.Text,
                            txtNombre.Text,
                            txtEmail.Text,
                            txtRol.Text,
                            txtLogin.Text,
                            chkActivos662JS.Checked,
                            chkTodos662JS.Checked
                        );

                        CargarUsuarios662JS(tabla);
                        break;

                    case Modo662JS.Alta:
                        if (string.IsNullOrWhiteSpace(txtLogin.Text))
                        {
                            MessageBox.Show("El usuario es obligatorio");
                            return;
                        }
                        bll.InsertarUsuario662JS(
                            txtLogin.Text,
                            txtApellido.Text, 
                            txtNombre.Text,
                            txtDNI.Text,
                            txtRol.Text,
                            txtEmail.Text   
                        );

                        MessageBox.Show("Usuario creado");
                        break;

                    case Modo662JS.Modificar:
                        if (string.IsNullOrWhiteSpace(txtLogin.Text))
                        {
                            MessageBox.Show("El usuario es obligatorio");
                            return;
                        }
                        bll.ModificarUsuario662JS(
                            txtLogin.Text,
                            txtDNI.Text,
                            txtApellido.Text
                        );

                        MessageBox.Show("Usuario modificado");
                        break;

                    case Modo662JS.Desbloquear:

                        string username = dgvUsuarios662JS.SelectedRows[0]
                            .Cells["Username662JS"].Value.ToString();

                        bll.Desbloquear662JS(username);

                        MessageBox.Show("Usuario desbloqueado");
                        break;
                }
                CambiarModo662JS(Modo662JS.Consulta);
                LimpiarCampos662JS();
                RecargarGrilla662JS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecargarGrilla662JS()
        {
            BLLUsuario662JS bll = new BLLUsuario662JS();

            DataTable tabla = bll.ObtenerUsuariosFiltrados662JS(
                txtDNI.Text,
                txtApellido.Text,
                txtNombre.Text,
                txtEmail.Text,
                txtRol.Text,
                txtLogin.Text,
                chkActivos662JS.Checked,
                chkTodos662JS.Checked
            );

            CargarUsuarios662JS(tabla);
        }

        private void CargarUsuarios662JS(DataTable tabla)
        {
            dgvUsuarios662JS.DataSource = tabla;

            dgvUsuarios662JS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios662JS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios662JS.ReadOnly = true;
        }

        private void FrmAdministrador662JS_Load(object sender, EventArgs e)
        {
            chkActivos662JS.Checked = true;
            chkTodos662JS.Checked = false;
            InicializarCampos662JS();
            btnAplicar.PerformClick();
            CambiarModo662JS(Modo662JS.Consulta);
        }

        private void dgvUsuarios662JS_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvUsuarios662JS.Rows[e.RowIndex];

            if (row.Cells["Activo662JS"].Value != DBNull.Value &&
                Convert.ToBoolean(row.Cells["Activo662JS"].Value) == false)
            {
                row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CambiarModo662JS(Modo662JS.Alta);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios662JS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            var row = dgvUsuarios662JS.SelectedRows[0];

            txtLogin.Text = row.Cells["Username662JS"].Value.ToString();
            txtDNI.Text = row.Cells["DNI662JS"].Value.ToString();
            txtApellido.Text = row.Cells["Apellido662JS"].Value.ToString();
            txtNombre.Text = row.Cells["Nombre662JS"].Value.ToString();
            txtEmail.Text = row.Cells["Email662JS"].Value.ToString();
            txtRol.Text = row.Cells["Rol662JS"].Value.ToString();

            CambiarModo662JS(Modo662JS.Modificar);
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            CambiarModo662JS(Modo662JS.Desbloquear);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CambiarModo662JS(Modo662JS.Consulta);
        }
    }
}
