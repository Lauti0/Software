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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Proyecto_final
{
    public partial class FrmGestionarUsuarios_22MS : Form
    {
        public FrmGestionarUsuarios_22MS()
        {
            InitializeComponent();
        }
        private List<Control> campos662JS;
        enum Modo662JS
        {
            Consulta,
            Alta,
            Modificar,
            Desbloquear,
            ActivarDesactivar
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

                case Modo662JS.ActivarDesactivar:
                    lblMensaje.Text = "Modo Activar / Desactivar";
                    break;
            }
        }
        private void ConfigurarBotones662JS(Modo662JS modo)
        {
            bool esConsulta = modo == Modo662JS.Consulta;

            btnCrear.Enabled = esConsulta;
            btnModificar.Enabled = esConsulta;
            btnDesbloquear.Enabled = esConsulta;
            btnActDesact.Enabled = esConsulta;

            btnAplicar.Enabled = true;
            btnCancelar.Enabled = !esConsulta;
        }
        private void ConfigurarCampos662JS(Modo662JS modo)
        {
            
            HabilitarCampos662JS(false);

            if (modo == Modo662JS.Alta)
            {                
                HabilitarCampos662JS(true);
                LimpiarCampos662JS();
            }
            else if (modo == Modo662JS.Modificar)
            {                
                txtEmail.Enabled = true;
                txtRol.Enabled = true;                
                txtDNI.Enabled = false;
            }
        }

        private void LimpiarCampos662JS()
        {
            txtApellido.Text=txtNombre.Text=txtDNI.Text=txtEmail.Text=txtLogin.Text=txtRol.Text="";            
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
            txtLogin.Enabled = false;
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
                        if (string.IsNullOrWhiteSpace(txtDNI.Text))
                            throw new Exception("El DNI es obligatorio");

                        if (string.IsNullOrWhiteSpace(txtApellido.Text))
                            throw new Exception("El apellido es obligatorio");
                        if (string.IsNullOrWhiteSpace(txtNombre.Text))
                            throw new Exception("El nombre es obligatorio");
                        if (string.IsNullOrWhiteSpace(txtEmail.Text))
                            throw new Exception("El email es obligatorio");
                        if (string.IsNullOrWhiteSpace(txtRol.Text))
                            throw new Exception("El rol es obligatorio");
                        if (!txtEmail.Text.Contains("@"))
                            throw new Exception("Email inválido");
                        bll.InsertarUsuario662JS(                            
                            txtApellido.Text, 
                            txtNombre.Text,
                            txtDNI.Text,
                            txtRol.Text,
                            txtEmail.Text   
                        );

                        MessageBox.Show("Usuario creado");
                        break;

                    case Modo662JS.Modificar:
                        if (string.IsNullOrWhiteSpace(txtDNI.Text))
                            throw new Exception("DNI inválido");

                        if (string.IsNullOrWhiteSpace(txtEmail.Text))
                            throw new Exception("Email obligatorio");

                        if (string.IsNullOrWhiteSpace(txtRol.Text))
                            throw new Exception("Rol obligatorio");

                        if (!txtEmail.Text.Contains("@"))
                            throw new Exception("Email inválido");
                        bll.ModificarUsuario662JS(
                            txtDNI.Text,
                            txtEmail.Text,
                            txtRol.Text
                        );

                        MessageBox.Show("Usuario modificado");
                        break;

                    case Modo662JS.Desbloquear:

                        var rowDesb = dgvUsuarios662JS.SelectedRows[0];
                        int dniDesb = Convert.ToInt32(rowDesb.Cells["DNI662JS"].Value);
                        string username = rowDesb.Cells["Username662JS"].Value.ToString();                        

                        bll.Desbloquear662JS(username);

                        MessageBox.Show("Usuario desbloqueado");
                        break;

                    case Modo662JS.ActivarDesactivar:

                        var rowAct = dgvUsuarios662JS.SelectedRows[0];

                        int dni = Convert.ToInt32(rowAct.Cells["DNI662JS"].Value);
                        bool activo = Convert.ToBoolean(rowAct.Cells["Activo662JS"].Value);                        
                        bll.CambiarEstado662JS(dni, !activo);

                        MessageBox.Show(activo ? "Usuario desactivado" : "Usuario activado");

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
            if (dgvUsuarios662JS.Columns.Contains("Password662JS"))
            {
                dgvUsuarios662JS.Columns["Password662JS"].Visible = false;
            }
            dgvUsuarios662JS.AllowUserToResizeColumns = false;
            dgvUsuarios662JS.AllowUserToResizeRows = false;
            dgvUsuarios662JS.AllowUserToAddRows = false;

            dgvUsuarios662JS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios662JS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios662JS.ReadOnly = true;
            dgvUsuarios662JS.ClearSelection();//para que no empiece con una fila seleccionada
        }

        private void FrmAdministrador662JS_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            chkActivos662JS.Checked = true;
            chkTodos662JS.Checked = false;
            InicializarCampos662JS();
            btnAplicar.PerformClick();
            CambiarModo662JS(Modo662JS.Consulta);
            btnModificar.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnActDesact.Enabled = false;
        }

        private void dgvUsuarios662JS_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvUsuarios662JS.Rows[e.RowIndex];

            if (row.Cells["Activo662JS"].Value != DBNull.Value &&
                Convert.ToBoolean(row.Cells["Activo662JS"].Value) == false)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 106, 106);
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
            if (dgvUsuarios662JS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }
            CambiarModo662JS(Modo662JS.Desbloquear);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CambiarModo662JS(Modo662JS.Consulta);
        }

        private void btnActDesact_Click(object sender, EventArgs e)
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
            CambiarModo662JS(Modo662JS.ActivarDesactivar);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios662JS_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios662JS.SelectedRows.Count == 0)
            {
                btnModificar.Enabled = false;
                btnDesbloquear.Enabled = false;
                btnActDesact.Enabled = false;
                return;
            }

            var row = dgvUsuarios662JS.SelectedRows[0];
           
            if (row.IsNewRow)//para evitar error al seleccionar la fila de "nueva fila" que aparece al final
            {
                btnModificar.Enabled = false;
                btnDesbloquear.Enabled = false;
                btnActDesact.Enabled = false;
                return;
            }

            var usuarioLogueado = SessionManager662JS.GetInstance662JS().Usuario662JS;
            int dni = Convert.ToInt32(row.Cells["DNI662JS"].Value);

            bool esMismoUsuario = usuarioLogueado.DNI662JS == dni;

            btnModificar.Enabled = !esMismoUsuario;
            btnDesbloquear.Enabled = !esMismoUsuario;
            btnActDesact.Enabled = !esMismoUsuario;
            
            bool bloqueado = Convert.ToBoolean(row.Cells["Bloqueado662JS"].Value);//si el usuario está bloqueado, habilito
                                                                           //el botón de desbloquear, sino lo deshabilito

            btnDesbloquear.Enabled = bloqueado;
        }
    }
}
