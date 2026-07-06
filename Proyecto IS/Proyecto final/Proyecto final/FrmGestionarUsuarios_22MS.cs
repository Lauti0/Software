using BLL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class FrmGestionarUsuarios_22MS : FrmBaseIdioma_22MS
    {
        public FrmGestionarUsuarios_22MS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private List<Control> campos_22MS;
        private BLLIdioma_22MS bllIdioma_22MS = new BLLIdioma_22MS();

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
                    lblMensaje.Text =
                        TraducirMensaje_22MS("modo_consulta");
                    break;

                case Modo_22MS.Alta:
                    lblMensaje.Text =
                        TraducirMensaje_22MS("modo_alta");
                    break;

                case Modo_22MS.Modificar:
                    lblMensaje.Text =
                        TraducirMensaje_22MS("modo_modificar");
                    break;

                case Modo_22MS.Desbloquear:
                    lblMensaje.Text =
                        TraducirMensaje_22MS("modo_desbloquear");
                    break;

                case Modo_22MS.ActivarDesactivar:
                    lblMensaje.Text =
                        TraducirMensaje_22MS(
                            "modo_activar_desactivar"
                        );
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
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            txtLogin.Clear();

            cmbRol.SelectedIndex = -1;

            if (cmbIdioma.DataSource != null)
                cmbIdioma.SelectedValue = "es";
        }

        private void InicializarCampos_22MS()
        {
            campos_22MS = new List<Control>
            {
                txtDNI,
                txtNombre,
                txtApellido,
                txtEmail,
                cmbRol,
                cmbIdioma,
                txtLogin
            };
        }

        private void HabilitarCampos_22MS(bool habilitar)
        {
            foreach (Control campo in campos_22MS)
            {
                campo.Enabled = habilitar;
            }

            txtLogin.Enabled = false;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLUsuario_22MS bllUsuario =
                    new BLLUsuario_22MS();

                BLLBitacoraEvento_22MS bitacoraEvento =
                    new BLLBitacoraEvento_22MS();

                SessionManager_22MS sesion =
                    SessionManager_22MS.GetInstance_22MS();

                if (sesion == null ||
                    sesion.Usuario_22MS == null)
                {
                    throw new Exception(
                        "mensaje_debe_iniciar_sesion"
                    );
                }

                UsuarioServicios_22MS usuario =
                    sesion.Usuario_22MS;

                switch (modoActual_22MS)
                {
                    case Modo_22MS.Consulta:
                        {
                            int? idRol = null;

                            if (cmbRol.SelectedIndex != -1)
                            {
                                idRol = Convert.ToInt32(
                                    cmbRol.SelectedValue
                                );
                            }

                            DataTable tablaUsuarios =
                                bllUsuario.ObtenerUsuariosFiltrados_22MS(
                                    txtDNI.Text,
                                    txtApellido.Text,
                                    txtNombre.Text,
                                    txtEmail.Text,
                                    idRol,
                                    txtLogin.Text,
                                    rbActivos_22MS.Checked
                                );

                            CargarUsuarios_22MS(tablaUsuarios);

                            // Evita limpiar los filtros y volver
                            // a cargar toda la grilla.
                            return;
                        }

                    case Modo_22MS.Alta:
                        {
                            if (string.IsNullOrWhiteSpace(txtDNI.Text))
                            {
                                throw new Exception(
                                    "mensaje_dni_obligatorio"
                                );
                            }

                            if (string.IsNullOrWhiteSpace(
                                txtApellido.Text))
                            {
                                throw new Exception(
                                    "mensaje_apellido_obligatorio"
                                );
                            }

                            if (string.IsNullOrWhiteSpace(
                                txtNombre.Text))
                            {
                                throw new Exception(
                                    "mensaje_nombre_obligatorio"
                                );
                            }

                            if (string.IsNullOrWhiteSpace(
                                txtEmail.Text))
                            {
                                throw new Exception(
                                    "mensaje_email_obligatorio"
                                );
                            }

                            if (cmbRol.SelectedItem == null)
                            {
                                throw new Exception(
                                    "mensaje_rol_obligatorio"
                                );
                            }

                            if (cmbIdioma.SelectedItem == null)
                            {
                                throw new Exception(
                                    "mensaje_idioma_obligatorio"
                                );
                            }

                            if (!txtEmail.Text.Contains("@"))
                            {
                                throw new Exception(
                                    "mensaje_email_invalido"
                                );
                            }

                            if (txtDNI.Text.Length < 8)
                            {
                                throw new Exception(
                                    "mensaje_dni_invalido"
                                );
                            }

                            string codigoIdioma =
                                cmbIdioma.SelectedValue?.ToString();

                            bllUsuario.InsertarUsuario_22MS(
                                txtApellido.Text,
                                txtNombre.Text,
                                txtDNI.Text,
                                Convert.ToInt32(
                                    cmbRol.SelectedValue
                                ),
                                txtEmail.Text,
                                codigoIdioma
                            );

                            MostrarInformacion_22MS(
                                "mensaje_usuario_creado"
                            );

                            bitacoraEvento.RegistrarEvento_22MS(
                                usuario.Username_22MS,
                                "Usuarios",
                                "Alta usuario",
                                2
                            );

                            break;
                        }

                    case Modo_22MS.Modificar:
                        {
                            if (string.IsNullOrWhiteSpace(txtDNI.Text))
                            {
                                throw new Exception(
                                    "mensaje_dni_invalido"
                                );
                            }

                            if (string.IsNullOrWhiteSpace(
                                txtEmail.Text))
                            {
                                throw new Exception(
                                    "mensaje_email_obligatorio"
                                );
                            }

                            if (cmbRol.SelectedItem == null)
                            {
                                throw new Exception(
                                    "mensaje_rol_obligatorio"
                                );
                            }

                            if (!txtEmail.Text.Contains("@"))
                            {
                                throw new Exception(
                                    "mensaje_email_invalido"
                                );
                            }

                            string pregunta = string.Format(
                                TraducirMensaje_22MS(
                                    "pregunta_modificar_usuario"
                                ),
                                txtLogin.Text
                            );

                            DialogResult resultado =
                                MessageBox.Show(
                                    pregunta,
                                    TraducirMensaje_22MS(
                                        "titulo_confirmar_cambios"
                                    ),
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );

                            if (resultado != DialogResult.Yes)
                                return;

                            bllUsuario.ModificarUsuario_22MS(
                                txtDNI.Text,
                                txtEmail.Text,
                                Convert.ToInt32(
                                    cmbRol.SelectedValue
                                )
                            );

                            MostrarInformacion_22MS(
                                "mensaje_usuario_modificado"
                            );

                            bitacoraEvento.RegistrarEvento_22MS(
                                usuario.Username_22MS,
                                "Usuarios",
                                "Modificar usuario",
                                3
                            );

                            break;
                        }

                    case Modo_22MS.Desbloquear:
                        {
                            if (dgvUsuarios_22MS.SelectedRows.Count == 0)
                            {
                                throw new Exception(
                                    "mensaje_seleccionar_usuario"
                                );
                            }

                            DataGridViewRow fila =
                                dgvUsuarios_22MS.SelectedRows[0];

                            int dniDesbloquear =
                                Convert.ToInt32(
                                    fila.Cells["DNI_22MS"].Value
                                );

                            string username =
                                fila.Cells["Username_22MS"]
                                    .Value
                                    .ToString();

                            string apellido =
                                fila.Cells["Apellido_22MS"]
                                    .Value
                                    .ToString();

                            string pregunta = string.Format(
                                TraducirMensaje_22MS(
                                    "pregunta_desbloquear_usuario"
                                ),
                                username
                            );

                            DialogResult resultado =
                                MessageBox.Show(
                                    pregunta,
                                    TraducirMensaje_22MS(
                                        "titulo_confirmar_desbloqueo"
                                    ),
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );

                            if (resultado != DialogResult.Yes)
                                return;

                            bllUsuario.Desbloquear_22MS(
                                username,
                                apellido,
                                dniDesbloquear
                            );

                            MostrarInformacion_22MS(
                                "mensaje_usuario_desbloqueado"
                            );

                            bitacoraEvento.RegistrarEvento_22MS(
                                usuario.Username_22MS,
                                "Usuarios",
                                "Desbloquear usuario",
                                3
                            );

                            break;
                        }

                    case Modo_22MS.ActivarDesactivar:
                        {
                            if (dgvUsuarios_22MS.SelectedRows.Count == 0)
                            {
                                throw new Exception(
                                    "mensaje_seleccionar_usuario"
                                );
                            }

                            DataGridViewRow fila =
                                dgvUsuarios_22MS.SelectedRows[0];

                            int dni = Convert.ToInt32(
                                fila.Cells["DNI_22MS"].Value
                            );

                            bool activo = Convert.ToBoolean(
                                fila.Cells["Activo_22MS"].Value
                            );

                            string nombreUsuario =
                                fila.Cells["Nombre_22MS"]
                                    .Value
                                    .ToString();

                            string clavePregunta = activo
                                ? "pregunta_desactivar_usuario"
                                : "pregunta_activar_usuario";

                            string pregunta = string.Format(
                                TraducirMensaje_22MS(
                                    clavePregunta
                                ),
                                nombreUsuario
                            );

                            DialogResult resultado =
                                MessageBox.Show(
                                    pregunta,
                                    TraducirMensaje_22MS(
                                        "titulo_confirmar_cambio_estado"
                                    ),
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );

                            if (resultado != DialogResult.Yes)
                                return;

                            bllUsuario.CambiarEstado_22MS(
                                dni,
                                !activo
                            );

                            MostrarInformacion_22MS(
                                activo
                                    ? "mensaje_usuario_desactivado"
                                    : "mensaje_usuario_activado"
                            );

                            bitacoraEvento.RegistrarEvento_22MS(
                                usuario.Username_22MS,
                                "Usuarios",
                                activo
                                    ? "Usuario desactivado"
                                    : "Usuario activado",
                                3
                            );

                            break;
                        }
                }

                CambiarModo_22MS(Modo_22MS.Consulta);
                LimpiarCampos_22MS();
                RecargarGrilla_22MS();
            }
            catch (Exception ex)
            {
                MostrarError_22MS(ex);
            }
        }

        private void RecargarGrilla_22MS()
        {
            BLLUsuario_22MS bllUsuario = new BLLUsuario_22MS();

            int? idRol = null;

            if (cmbRol.SelectedIndex != -1)
                idRol = Convert.ToInt32(cmbRol.SelectedValue);

            DataTable tablaUsuarios = bllUsuario.ObtenerUsuariosFiltrados_22MS(
                txtDNI.Text,
                txtApellido.Text,
                txtNombre.Text,
                txtEmail.Text,
                idRol,
                txtLogin.Text,
                rbActivos_22MS.Checked
            );

            CargarUsuarios_22MS(tablaUsuarios);
        }

        private void CargarUsuarios_22MS(DataTable tablaUsuarios)
        {
            dgvUsuarios_22MS.DataSource = tablaUsuarios;

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
            dgvUsuarios_22MS.ClearSelection();
        }

        private void FrmAdministrador_22MS_Load(object sender, EventArgs e)
        {
            rbActivos_22MS.Checked = true;

            InicializarCampos_22MS();
            CargarRoles_22MS();
            CambiarModo_22MS(Modo_22MS.Consulta);
            CargarIdiomas_22MS();

            btnAplicar.PerformClick();

            btnModificar.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnActDesact.Enabled = false;
        }

        private void CargarRoles_22MS()
        {
            BLLRol_22MS bllRol = new BLLRol_22MS();

            cmbRol.DataSource = bllRol.ObtenerRoles_22MS();
            cmbRol.DisplayMember = "NombreRol_22MS";
            cmbRol.ValueMember = "IdRol_22MS";
            cmbRol.SelectedIndex = -1;
        }

        private void dgvUsuarios_22MS_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow fila = dgvUsuarios_22MS.Rows[e.RowIndex];

            if (fila.Cells["Activo_22MS"].Value != DBNull.Value &&
                Convert.ToBoolean(fila.Cells["Activo_22MS"].Value) == false)
            {
                fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 106, 106);
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
                MostrarAdvertencia_22MS(
                    "mensaje_seleccionar_usuario"
                );

                return;
            }

            DataGridViewRow fila =
                dgvUsuarios_22MS.SelectedRows[0];

            txtLogin.Text =
                fila.Cells["Username_22MS"].Value.ToString();

            txtDNI.Text =
                fila.Cells["DNI_22MS"].Value.ToString();

            txtApellido.Text =
                fila.Cells["Apellido_22MS"].Value.ToString();

            txtNombre.Text =
                fila.Cells["Nombre_22MS"].Value.ToString();

            txtEmail.Text =
                fila.Cells["Email_22MS"].Value.ToString();

            cmbRol.SelectedValue =
                fila.Cells["IdRol_22MS"].Value;

            CambiarModo_22MS(Modo_22MS.Modificar);
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios_22MS.SelectedRows.Count == 0)
            {
                MostrarAdvertencia_22MS(
                    "mensaje_seleccionar_usuario"
                );

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
                MostrarAdvertencia_22MS(
                    "mensaje_seleccionar_usuario"
                );

                return;
            }

            DataGridViewRow fila =
                dgvUsuarios_22MS.SelectedRows[0];

            txtLogin.Text =
                fila.Cells["Username_22MS"].Value.ToString();

            txtDNI.Text =
                fila.Cells["DNI_22MS"].Value.ToString();

            txtApellido.Text =
                fila.Cells["Apellido_22MS"].Value.ToString();

            txtNombre.Text =
                fila.Cells["Nombre_22MS"].Value.ToString();

            txtEmail.Text =
                fila.Cells["Email_22MS"].Value.ToString();

            cmbRol.SelectedValue =
                fila.Cells["IdRol_22MS"].Value;

            CambiarModo_22MS(
                Modo_22MS.ActivarDesactivar
            );
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

            DataGridViewRow fila = dgvUsuarios_22MS.SelectedRows[0];

            if (fila.IsNewRow)
            {
                btnModificar.Enabled = false;
                btnDesbloquear.Enabled = false;
                btnActDesact.Enabled = false;
                return;
            }

            UsuarioServicios_22MS usuarioLogueado = SessionManager_22MS.GetInstance_22MS().Usuario_22MS;

            int dni = Convert.ToInt32(fila.Cells["DNI_22MS"].Value);

            bool esMismoUsuario = usuarioLogueado.DNI_22MS == dni;

            btnModificar.Enabled = !esMismoUsuario;
            btnActDesact.Enabled = !esMismoUsuario;

            bool bloqueado = Convert.ToBoolean(fila.Cells["Bloqueado_22MS"].Value);

            btnDesbloquear.Enabled = !esMismoUsuario && bloqueado;
        }

        private void CargarIdiomas_22MS()
        {
            cmbIdioma.DataSource = null;

            cmbIdioma.DataSource =
                bllIdioma_22MS.ObtenerIdiomas_22MS();

            cmbIdioma.DisplayMember =
                "Nombre_22MS";

            cmbIdioma.ValueMember =
                "Codigo_22MS";

            cmbIdioma.SelectedValue = "es";
        }

        private string TraducirMensaje_22MS(string clave_22MS)
        {
            return bllIdioma_22MS.Traducir_22MS(clave_22MS);
        }

        private void MostrarInformacion_22MS(string claveMensaje_22MS)
        {
            MessageBox.Show(
                TraducirMensaje_22MS(claveMensaje_22MS),
                TraducirMensaje_22MS("titulo_gestion_usuarios"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void MostrarAdvertencia_22MS(string claveMensaje_22MS)
        {
            MessageBox.Show(
                TraducirMensaje_22MS(claveMensaje_22MS),
                TraducirMensaje_22MS("titulo_gestion_usuarios"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
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
    }
}