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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Proyecto_final
{
    public partial class FrmGestionarUsuarios_22MS : Form
    {
        public FrmGestionarUsuarios_22MS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private List<Control> campos_22MS;
        enum Modo_22MS
        {
            Consulta,
            Alta,
            Modificar,
            Desbloquear,
            ActivarDesactivar
        }
        private Modo_22MS modoActual_22MS = Modo_22MS.Consulta;
        private void CambiarModo_22MS(Modo_22MS modo)
        {
            modoActual_22MS = modo;

            ConfigurarBotones_22MS(modo);
            ConfigurarCampos_22MS(modo);
            ConfigurarMensaje_22MS(modo);
        }
        private void ConfigurarMensaje_22MS(Modo_22MS modo)
        {
            switch (modo)
            {
                case Modo_22MS.Consulta:
                    lblMensaje.Text = "Modo Consulta";
                    break;

                case Modo_22MS.Alta:
                    lblMensaje.Text = "Modo Alta";
                    break;

                case Modo_22MS.Modificar:                    
                    lblMensaje.Text = "Modo Modificar";
                    break;
                    
                case Modo_22MS.Desbloquear:
                    if (dgvUsuarios_22MS.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione un usuario");
                        return;
                    }
                    lblMensaje.Text = "Modo Desbloquear";
                    break;

                case Modo_22MS.ActivarDesactivar:
                    lblMensaje.Text = "Modo Activar / Desactivar";
                    break;
            }
        }
        private void ConfigurarBotones_22MS(Modo_22MS modo)
        {
            bool esConsulta = modo == Modo_22MS.Consulta;

            btnCrear.Enabled = esConsulta;
            btnModificar.Enabled = esConsulta;
            btnDesbloquear.Enabled = esConsulta;
            btnActDesact.Enabled = esConsulta;

            btnAplicar.Enabled = true;
            btnCancelar.Enabled = !esConsulta;
        }
        private void ConfigurarCampos_22MS(Modo_22MS modo)
        {

            HabilitarCampos_22MS(false);

            if (modo == Modo_22MS.Alta)
            {
                HabilitarCampos_22MS(true);
                LimpiarCampos_22MS();
            }
            else if (modo == Modo_22MS.Modificar)
            {                
                txtEmail.Enabled = true;
                cmbRol.Enabled = true;                
                txtDNI.Enabled = false;
            }
        }

        private void LimpiarCampos_22MS()
        {
            txtApellido.Text=txtNombre.Text=txtDNI.Text=txtEmail.Text=txtLogin.Text="";
            cmbRol.SelectedIndex = -1;
        }

        private void InicializarCampos_22MS()
        {
            campos_22MS = new List<Control>
            {
                txtDNI, txtNombre, txtApellido, txtEmail, cmbRol, txtLogin
            };

        }

        private void HabilitarCampos_22MS(bool habilitar)
        {
            foreach (var c in campos_22MS)
                c.Enabled = habilitar;  
            txtLogin.Enabled = false;
        }
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLUsuario_22MS bll = new BLLUsuario_22MS();
                BLLBitacoraEvento_22MS bitacora = new BLLBitacoraEvento_22MS();
                UsuarioServicios_22MS usuario = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;
                string pregunta;
                DialogResult resultado;
                switch (modoActual_22MS)
                {
                    case Modo_22MS.Consulta:
                        int? idRol = null;

                        if (cmbRol.SelectedIndex != -1)
                            idRol = Convert.ToInt32(cmbRol.SelectedValue);
                        DataTable tabla = bll.ObtenerUsuariosFiltrados_22MS(
                            txtDNI.Text,
                            txtApellido.Text,
                            txtNombre.Text,
                            txtEmail.Text,
                            idRol,
                            txtLogin.Text,
                            rbActivos_22MS.Checked
                           // rbTodos662JS.Checked
                        );

                        CargarUsuarios_22MS(tabla);
                        break;

                    case Modo_22MS.Alta:
                        if (string.IsNullOrWhiteSpace(txtDNI.Text))
                            throw new Exception("El DNI es obligatorio");
                        if (string.IsNullOrWhiteSpace(txtApellido.Text))
                            throw new Exception("El apellido es obligatorio");
                        if (string.IsNullOrWhiteSpace(txtNombre.Text))
                            throw new Exception("El nombre es obligatorio");
                        if (string.IsNullOrWhiteSpace(txtEmail.Text))
                            throw new Exception("El email es obligatorio");
                        if (cmbRol.SelectedItem==null)
                            throw new Exception("El rol es obligatorio");
                        if (!txtEmail.Text.Contains("@"))
                            throw new Exception("Email inválido");
                        if(txtDNI.Text.Length <8)
                            throw new Exception("DNI inválido");
                        bll.InsertarUsuario_22MS(                            
                            txtApellido.Text, 
                            txtNombre.Text,
                            txtDNI.Text,
                            Convert.ToInt32(cmbRol.SelectedValue),
                            txtEmail.Text   
                        );

                        MessageBox.Show("Usuario creado");
                        bitacora.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Usuarios",
                            "Alta usuario",
                            2
                        );
                        break;

                    case Modo_22MS.Modificar:
                        if (string.IsNullOrWhiteSpace(txtDNI.Text))
                            throw new Exception("DNI inválido");

                        if (string.IsNullOrWhiteSpace(txtEmail.Text))
                            throw new Exception("Email obligatorio");

                        if (cmbRol.SelectedItem==null)
                            throw new Exception("Rol obligatorio");

                        if (!txtEmail.Text.Contains("@"))
                            throw new Exception("Email inválido");
                        pregunta = $"¿Está seguro que desea modificar al usuario {txtLogin.Text}?";
                        resultado = MessageBox.Show(pregunta, "Confirmar cambios",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(resultado == DialogResult.Yes)
                        {
                            bll.ModificarUsuario_22MS(txtDNI.Text, txtEmail.Text, Convert.ToInt32(cmbRol.SelectedValue));
                            MessageBox.Show("Usuario modificado");
                            bitacora.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Usuarios",
                            "Modificar usuario",
                            3
                        );
                        }
                        else
                        {
                            return;
                        }
                        break;

                    case Modo_22MS.Desbloquear:

                        var rowDesb = dgvUsuarios_22MS.SelectedRows[0];
                        int dniDesb = Convert.ToInt32(rowDesb.Cells["DNI_22MS"].Value);
                        string username = rowDesb.Cells["Username_22MS"].Value.ToString();
                        string apellido = rowDesb.Cells["Apellido_22MS"].Value.ToString();
                        pregunta = $"¿Está seguro que desea desbloquear al usuario {username}?";

                        resultado = MessageBox.Show(pregunta, "Confirmar desbloqueo",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            bll.Desbloquear_22MS(username, apellido, dniDesb);
                            MessageBox.Show("Usuario desbloqueado");
                            bitacora.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Usuarios",
                            "Desbloquear usuario",
                            3
                        );
                        }
                        else
                        {
                            return;
                        }                        
                        break;

                    case Modo_22MS.ActivarDesactivar:

                        var rowAct = dgvUsuarios_22MS.SelectedRows[0];

                        int dni = Convert.ToInt32(rowAct.Cells["DNI_22MS"].Value);
                        bool activo = Convert.ToBoolean(rowAct.Cells["Activo_22MS"].Value);
                        string nombreUsuario = rowAct.Cells["Nombre_22MS"].Value.ToString();
                      
                        string accion = activo ? "desactivar" : "activar";
                        pregunta = $"¿Está seguro que desea {accion} al usuario {nombreUsuario}?";
         
                        resultado = MessageBox.Show(pregunta, "Confirmar Cambio de Estado",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                        if (resultado == DialogResult.Yes)
                        {
                            bll.CambiarEstado_22MS(dni, !activo);
                            MessageBox.Show(activo ? "Usuario desactivado" : "Usuario activado");
                            bitacora.RegistrarEvento_22MS(
                            usuario.Username_22MS,
                            "Usuarios",
                            activo ? "Usuario desactivado" : "Usuario activado",
                            3
                        );
                        }
                        else
                        {                          
                            return;
                        }

                        break;
                }
                CambiarModo_22MS(Modo_22MS.Consulta);
                LimpiarCampos_22MS();
                RecargarGrilla_22MS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecargarGrilla_22MS()
        {
            BLLUsuario_22MS bll = new BLLUsuario_22MS();

            int? idRol = null;

            if (cmbRol.SelectedIndex != -1)
                idRol = Convert.ToInt32(cmbRol.SelectedValue);

            DataTable tabla = bll.ObtenerUsuariosFiltrados_22MS(
                txtDNI.Text,
                txtApellido.Text,
                txtNombre.Text,
                txtEmail.Text,
                idRol,
                txtLogin.Text,
                rbActivos_22MS.Checked
            );

            CargarUsuarios_22MS(tabla);
        }

        private void CargarUsuarios_22MS(DataTable tabla)
        {
            dgvUsuarios_22MS.DataSource = tabla;
            if (dgvUsuarios_22MS.Columns.Contains("Password_22MS"))
            {
                dgvUsuarios_22MS.Columns["Password_22MS"].Visible = false;
            }
            dgvUsuarios_22MS.AllowUserToResizeColumns = false;
            dgvUsuarios_22MS.AllowUserToResizeRows = false;
            dgvUsuarios_22MS.AllowUserToAddRows = false;

            dgvUsuarios_22MS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios_22MS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios_22MS.ReadOnly = true;
            dgvUsuarios_22MS.ClearSelection();//para que no empiece con una fila seleccionada
        }

        private void FrmAdministrador_22MS_Load(object sender, EventArgs e)
        {
            rbActivos_22MS.Checked = true;
            InicializarCampos_22MS();
            CargarRoles_22MS();
            CambiarModo_22MS(Modo_22MS.Consulta);
            btnAplicar.PerformClick();
            btnModificar.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnActDesact.Enabled = false;
        }

        private void CargarRoles_22MS()
        {
            BLLRol_22MS bllRol = new BLLRol_22MS();

            cmbRol.DataSource =
                bllRol.ObtenerRoles_22MS();

            cmbRol.DisplayMember =
                "NombreRol_22MS";

            cmbRol.ValueMember =
                "IdRol_22MS";

            cmbRol.SelectedIndex = -1;
        }

        private void dgvUsuarios_22MS_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvUsuarios_22MS.Rows[e.RowIndex];

            if (row.Cells["Activo_22MS"].Value != DBNull.Value &&
                Convert.ToBoolean(row.Cells["Activo_22MS"].Value) == false)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 106, 106);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CambiarModo_22MS(Modo_22MS.Alta);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios_22MS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            var row = dgvUsuarios_22MS.SelectedRows[0];            

            txtLogin.Text = row.Cells["Username_22MS"].Value.ToString();
            txtDNI.Text = row.Cells["DNI_22MS"].Value.ToString();
            txtApellido.Text = row.Cells["Apellido_22MS"].Value.ToString();
            txtNombre.Text = row.Cells["Nombre_22MS"].Value.ToString();
            txtEmail.Text = row.Cells["Email_22MS"].Value.ToString();
            cmbRol.SelectedValue =row.Cells["IdRol_22MS"].Value;

            CambiarModo_22MS(Modo_22MS.Modificar);
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios_22MS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }
            CambiarModo_22MS(Modo_22MS.Desbloquear);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CambiarModo_22MS(Modo_22MS.Consulta);
        }

        private void btnActDesact_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios_22MS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }
            var row = dgvUsuarios_22MS.SelectedRows[0];

            txtLogin.Text = row.Cells["Username_22MS"].Value.ToString();
            txtDNI.Text = row.Cells["DNI_22MS"].Value.ToString();
            txtApellido.Text = row.Cells["Apellido_22MS"].Value.ToString();
            txtNombre.Text = row.Cells["Nombre_22MS"].Value.ToString();
            txtEmail.Text = row.Cells["Email_22MS"].Value.ToString();
            cmbRol.SelectedValue =row.Cells["IdRol_22MS"].Value;
            CambiarModo_22MS(Modo_22MS.ActivarDesactivar);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_22MS_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios_22MS.SelectedRows.Count == 0)
            {
                btnModificar.Enabled = false;
                btnDesbloquear.Enabled = false;
                btnActDesact.Enabled = false;
                return;
            }

            var row = dgvUsuarios_22MS.SelectedRows[0];
           
            if (row.IsNewRow)//para evitar error al seleccionar la fila de "nueva fila" que aparece al final
            {
                btnModificar.Enabled = false;
                btnDesbloquear.Enabled = false;
                btnActDesact.Enabled = false;
                return;
            }

            var usuarioLogueado = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;
            int dni = Convert.ToInt32(row.Cells["DNI_22MS"].Value);

            bool esMismoUsuario = usuarioLogueado.DNI_22MS == dni;

            btnModificar.Enabled = !esMismoUsuario;
            btnDesbloquear.Enabled = !esMismoUsuario;
            btnActDesact.Enabled = !esMismoUsuario;
            
            bool bloqueado = Convert.ToBoolean(row.Cells["Bloqueado_22MS"].Value);//si el usuario está bloqueado, habilito
                                                                           //el botón de desbloquear, sino lo deshabilito

            btnDesbloquear.Enabled = bloqueado;
        }
    }
}
