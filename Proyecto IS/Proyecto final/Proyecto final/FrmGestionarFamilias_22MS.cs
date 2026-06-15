using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL_22MS;
using Servicios_22MS;

namespace Proyecto_final
{
    public partial class FrmGestionarFamilias_22MS : Form
    {
        private BLLFamilia_22MS bllFamilia_22MS = new BLLFamilia_22MS();
        private BLLPermiso_22MS bllPermiso_22MS = new BLLPermiso_22MS();

        public FrmGestionarFamilias_22MS()
        {
            InitializeComponent();
        }

        private void btnFormRoles_Click(object sender, EventArgs e)
        {
            new FrmGestionarRoles_22MS().Show();
            this.Close();
        }

        private void FrmGestionarFamilias_22MS_Load(object sender, EventArgs e)
        {
            ConfigurarGrillas_22MS();
            CargarFamilias_22MS();
            CargarSubFamilias_22MS();
            CargarPermisos_22MS();
            LimpiarSeleccion_22MS();
        }

        private void ConfigurarGrillas_22MS()
        {
            dgvFamilias.AutoGenerateColumns = true;
            dgvSubFamilias.AutoGenerateColumns = true;
            dgvPermisos.AutoGenerateColumns = true;
            dgvCompleta.AutoGenerateColumns = true;

            dgvFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompleta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvFamilias.MultiSelect = false;
            dgvSubFamilias.MultiSelect = false;
            dgvPermisos.MultiSelect = false;
            dgvCompleta.MultiSelect = false;

            dgvFamilias.ReadOnly = true;
            dgvSubFamilias.ReadOnly = true;
            dgvPermisos.ReadOnly = true;
            dgvCompleta.ReadOnly = true;

            dgvFamilias.AllowUserToAddRows = false;
            dgvSubFamilias.AllowUserToAddRows = false;
            dgvPermisos.AllowUserToAddRows = false;
            dgvCompleta.AllowUserToAddRows = false;
        }

        private void CargarFamilias_22MS()
        {
            dgvFamilias.DataSource = null;
            dgvFamilias.DataSource = bllFamilia_22MS.ObtenerFamilias_22MS();

            if (dgvFamilias.Columns["IdFamilia_22MS"] != null)
                dgvFamilias.Columns["IdFamilia_22MS"].HeaderText = "ID";

            if (dgvFamilias.Columns["NombreFamilia_22MS"] != null)
                dgvFamilias.Columns["NombreFamilia_22MS"].HeaderText = "Familia";

            if (dgvFamilias.Columns["IdRol_22MS"] != null)
                dgvFamilias.Columns["IdRol_22MS"].Visible = false;

            if (dgvFamilias.Columns["NombreRol_22MS"] != null)
                dgvFamilias.Columns["NombreRol_22MS"].Visible = false;
        }

        private void CargarSubFamilias_22MS()
        {
            dgvSubFamilias.DataSource = null;
            dgvSubFamilias.DataSource = bllFamilia_22MS.ObtenerFamilias_22MS();

            if (dgvSubFamilias.Columns["IdFamilia_22MS"] != null)
                dgvSubFamilias.Columns["IdFamilia_22MS"].HeaderText = "ID";

            if (dgvSubFamilias.Columns["NombreFamilia_22MS"] != null)
                dgvSubFamilias.Columns["NombreFamilia_22MS"].HeaderText = "Familia";

            if (dgvSubFamilias.Columns["IdRol_22MS"] != null)
                dgvSubFamilias.Columns["IdRol_22MS"].Visible = false;

            if (dgvSubFamilias.Columns["NombreRol_22MS"] != null)
                dgvSubFamilias.Columns["NombreRol_22MS"].Visible = false;
        }

        private void CargarPermisos_22MS()
        {
            dgvPermisos.DataSource = null;
            dgvPermisos.DataSource = bllPermiso_22MS.ObtenerPermisos_22MS();

            if (dgvPermisos.Columns["IdPermiso_22MS"] != null)
                dgvPermisos.Columns["IdPermiso_22MS"].HeaderText = "ID";

            if (dgvPermisos.Columns["NombrePermiso_22MS"] != null)
                dgvPermisos.Columns["NombrePermiso_22MS"].HeaderText = "Permiso";

            if (dgvPermisos.Columns["IdRol_22MS"] != null)
                dgvPermisos.Columns["IdRol_22MS"].Visible = false;

            if (dgvPermisos.Columns["NombreRol_22MS"] != null)
                dgvPermisos.Columns["NombreRol_22MS"].Visible = false;
        }

        private void dgvFamilias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (dgvFamilias.CurrentRow == null)
                    return;

                int idFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                txtNombreFamilia.Text = dgvFamilias.CurrentRow.Cells["NombreFamilia_22MS"].Value.ToString();

                PintarPermisosFamilia_22MS(idFamilia);
                PintarSubFamilias_22MS(idFamilia);
                CargarResumenFamilia_22MS(idFamilia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PintarPermisosFamilia_22MS(int idFamilia)
        {
            List<Permiso_22MS> permisosDirectos = bllFamilia_22MS.ObtenerPermisosPorFamilia_22MS(idFamilia);
            List<Permiso_22MS> permisosHeredados = bllFamilia_22MS.ObtenerPermisosHeredadosPorFamilia_22MS(idFamilia);

            foreach (DataGridViewRow fila in dgvPermisos.Rows)
            {
                if (fila.Cells["IdPermiso_22MS"].Value == null)
                    continue;

                int idPermiso = Convert.ToInt32(fila.Cells["IdPermiso_22MS"].Value);

                bool esDirecto = permisosDirectos.Any(permiso => permiso.IdPermiso_22MS == idPermiso);
                bool esHeredado = permisosHeredados.Any(permiso => permiso.IdPermiso_22MS == idPermiso);

                if (esDirecto)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if (esHeredado)
                {
                    fila.DefaultCellStyle.BackColor = Color.Khaki;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void PintarSubFamilias_22MS(int idFamiliaPadre)
        {
            List<Familia_22MS> familiasHijas = bllFamilia_22MS.ObtenerFamiliasHijas_22MS(idFamiliaPadre);

            foreach (DataGridViewRow fila in dgvSubFamilias.Rows)
            {
                if (fila.Cells["IdFamilia_22MS"].Value == null)
                    continue;

                int idFamilia = Convert.ToInt32(fila.Cells["IdFamilia_22MS"].Value);

                bool asignada = familiasHijas.Any(familia => familia.IdFamilia_22MS == idFamilia);

                if (asignada)
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                else
                    fila.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void CargarResumenFamilia_22MS(int idFamilia)
        {
            dgvCompleta.DataSource = null;
            dgvCompleta.DataSource = bllFamilia_22MS.ObtenerResumenFamilia_22MS(idFamilia);
        }

        private void LimpiarSeleccion_22MS()
        {
            txtNombreFamilia.Clear();

            dgvFamilias.ClearSelection();
            dgvSubFamilias.ClearSelection();
            dgvPermisos.ClearSelection();

            dgvCompleta.DataSource = null;

            foreach (DataGridViewRow fila in dgvSubFamilias.Rows)
                fila.DefaultCellStyle.BackColor = Color.White;

            foreach (DataGridViewRow fila in dgvPermisos.Rows)
                fila.DefaultCellStyle.BackColor = Color.White;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                bllFamilia_22MS.CrearFamilia_22MS(txtNombreFamilia.Text.Trim());

                MessageBox.Show("Familia creada correctamente.");

                CargarFamilias_22MS();
                CargarSubFamilias_22MS();
                LimpiarSeleccion_22MS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar una familia.");

                int idFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                bllFamilia_22MS.ModificarFamilia_22MS(idFamilia, txtNombreFamilia.Text.Trim());

                MessageBox.Show("Familia modificada correctamente.");

                CargarFamilias_22MS();
                CargarSubFamilias_22MS();
                LimpiarSeleccion_22MS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar una familia.");

                int idFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                DialogResult respuesta = MessageBox.Show(
                    "¿Seguro que desea eliminar esta familia?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta != DialogResult.Yes)
                    return;

                bllFamilia_22MS.EliminarFamilia_22MS(idFamilia);

                MessageBox.Show("Familia eliminada correctamente.");

                CargarFamilias_22MS();
                CargarSubFamilias_22MS();
                CargarPermisos_22MS();
                LimpiarSeleccion_22MS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarSeleccion_22MS();
        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar una familia.");

                if (dgvPermisos.CurrentRow == null)
                    throw new Exception("Debe seleccionar un permiso.");

                int idFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);
                int idPermiso = Convert.ToInt32(dgvPermisos.CurrentRow.Cells["IdPermiso_22MS"].Value);

                bllFamilia_22MS.AgregarPermisoAFamilia_22MS(idFamilia, idPermiso);

                PintarPermisosFamilia_22MS(idFamilia);
                CargarResumenFamilia_22MS(idFamilia);

                MessageBox.Show("Permiso asignado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuitarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar una familia.");

                if (dgvPermisos.CurrentRow == null)
                    throw new Exception("Debe seleccionar un permiso.");

                int idFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);
                int idPermiso = Convert.ToInt32(dgvPermisos.CurrentRow.Cells["IdPermiso_22MS"].Value);

                bllFamilia_22MS.EliminarPermisoDeFamilia_22MS(idFamilia, idPermiso);

                PintarPermisosFamilia_22MS(idFamilia);
                CargarResumenFamilia_22MS(idFamilia);

                MessageBox.Show("Permiso quitado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAsignarFH_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar la familia padre.");

                if (dgvSubFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar la familia hija.");

                int idFamiliaPadre = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);
                int idFamiliaHija = Convert.ToInt32(dgvSubFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                bllFamilia_22MS.AgregarFamiliaAFamilia_22MS(idFamiliaPadre, idFamiliaHija);

                PintarSubFamilias_22MS(idFamiliaPadre);
                PintarPermisosFamilia_22MS(idFamiliaPadre);
                CargarResumenFamilia_22MS(idFamiliaPadre);

                MessageBox.Show("Familia asignada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuitarFH_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar la familia padre.");

                if (dgvSubFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar la familia hija.");

                int idFamiliaPadre = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);
                int idFamiliaHija = Convert.ToInt32(dgvSubFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                bllFamilia_22MS.QuitarFamiliaDeFamilia_22MS(idFamiliaPadre, idFamiliaHija);

                PintarSubFamilias_22MS(idFamiliaPadre);
                PintarPermisosFamilia_22MS(idFamiliaPadre);
                CargarResumenFamilia_22MS(idFamiliaPadre);

                MessageBox.Show("Familia quitada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}