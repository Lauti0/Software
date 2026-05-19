using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_22MS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Proyecto_final
{
    public partial class FrmBitacoraEventos_22MS : Form
    {
        public FrmBitacoraEventos_22MS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmBitacoraEventos_22MS_Load(object sender, EventArgs e)
        {
            CargarModulos();
            CargarCriticidad();
            CargarEventos();
            CargarUsuarios();
            cmbModulo_22MS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriticidad_22MS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEvento_22MS.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimePickerFechaIni_22MS.Value = DateTime.Now.AddDays(-3);
            dateTimePickerFechaFin_22MS.Value = DateTime.Now;
            CargarGrilla_22MS();
        }

        private void CargarUsuarios()
        {
            BLLUsuario_22MS bllusuario = new BLLUsuario_22MS();

            cmbLogin_22MS.DataSource = bllusuario.ObtenerUsuarios_22MS();
            cmbLogin_22MS.DisplayMember = "Username_22MS";
            cmbLogin_22MS.ValueMember = "Username_22MS";
            cmbLogin_22MS.SelectedIndex = -1;

        }

        private void CargarEventos()
        {
            cmbEvento_22MS.Items.Add("Todos");
            cmbEvento_22MS.Items.Add("Login");
            cmbEvento_22MS.Items.Add("Logout");
            cmbEvento_22MS.Items.Add("Alta usuario");
            cmbEvento_22MS.Items.Add("Modificar usuario");
            cmbEvento_22MS.Items.Add("Bloqueo de usuario");
            cmbEvento_22MS.Items.Add("Desbloquear usuario");
            cmbEvento_22MS.Items.Add("Cambio de contraseña");
            cmbEvento_22MS.Items.Add("Usuario desactivado");
            cmbEvento_22MS.Items.Add("Usuario activado");         
            cmbEvento_22MS.SelectedIndex = 0;
        }

        private void CargarCriticidad()
        {
            cmbCriticidad_22MS.Items.Add("1");
            cmbCriticidad_22MS.Items.Add("2");
            cmbCriticidad_22MS.Items.Add("3");
            cmbCriticidad_22MS.Items.Add("4");
            cmbCriticidad_22MS.Items.Add("5");
        }

        private void CargarModulos()
        {
            cmbModulo_22MS.Items.Add("Usuarios");
            cmbModulo_22MS.Items.Add("Ventas");
            cmbModulo_22MS.Items.Add("Compras");
            cmbModulo_22MS.Items.Add("Seguridad");
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            CargarGrilla_22MS();
        }

        private void CargarGrilla_22MS()
        {
            BLLBitacoraEvento_22MS bll = new BLLBitacoraEvento_22MS();

            string login = cmbLogin_22MS.Text;
            string modulo = cmbModulo_22MS.Text;
            string evento = cmbEvento_22MS.Text;
            string criticidad = cmbCriticidad_22MS.Text;

            DateTime fechaIni = dateTimePickerFechaIni_22MS.Value.Date;
            DateTime fechaFin = dateTimePickerFechaFin_22MS.Value.Date;

            DataTable tabla = bll.ObtenerEventosFiltrados_22MS(
                login,
                modulo,
                evento,
                criticidad,
                fechaIni,
                fechaFin
            );

            dataGridViewEventos_22MS.DataSource = tabla;

            dataGridViewEventos_22MS.AllowUserToAddRows = false;
            dataGridViewEventos_22MS.AllowUserToResizeRows = false;
            dataGridViewEventos_22MS.AllowUserToResizeColumns = false;

            dataGridViewEventos_22MS.ReadOnly = true;

            dataGridViewEventos_22MS.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewEventos_22MS.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbLogin_22MS.SelectedIndex = -1;
            cmbModulo_22MS.SelectedIndex = -1;
            cmbEvento_22MS.SelectedIndex = 0;
            cmbCriticidad_22MS.SelectedIndex = -1;

            txtNombre_22MS.Clear();
            txtApellido_22MS.Clear();

            dateTimePickerFechaIni_22MS.Value =
                DateTime.Now.AddDays(-3);

            dateTimePickerFechaFin_22MS.Value =
                DateTime.Now;

            CargarGrilla_22MS();
        }

        private void dataGridViewEventos_22MS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string login =
                dataGridViewEventos_22MS.Rows[e.RowIndex]
                .Cells["Username_22MS"]
                .Value.ToString();

            BLLUsuario_22MS bll = new BLLUsuario_22MS();

            DataRow usuario =
                bll.ObtenerUsuarioPorLogin_22MS(login);

            if (usuario != null)
            {
                txtNombre_22MS.Text =
                    usuario["Nombre_22MS"].ToString();

                txtApellido_22MS.Text =
                    usuario["Apellido_22MS"].ToString();
            }
        }

        private void btnSalir_22MS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "BitacoraEventos.pdf";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    ExportarPDF_22MS(save.FileName);

                    MessageBox.Show("PDF generado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ExportarPDF_22MS(string ruta)
        {
            Document doc = new Document(PageSize.A4, 10, 10, 10, 10);

            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph("BITACORA DE EVENTOS");
            titulo.Alignment = Element.ALIGN_CENTER;

            doc.Add(titulo);
            doc.Add(new Paragraph(" "));

            PdfPTable tabla = new PdfPTable(dataGridViewEventos_22MS.Columns.Count);

            tabla.WidthPercentage = 100;

            
            foreach (DataGridViewColumn columna in dataGridViewEventos_22MS.Columns)
            {
                PdfPCell cell = new PdfPCell(
                    new Phrase(columna.HeaderText));

                tabla.AddCell(cell);
            }

            
            foreach (DataGridViewRow row in dataGridViewEventos_22MS.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        tabla.AddCell(
                            cell.Value?.ToString() ?? "");
                    }
                }
            }

            doc.Add(tabla);

            doc.Close();
        }
    }
}
