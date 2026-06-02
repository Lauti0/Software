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
        private BLLRol_22MS bllRol_22MS = new BLLRol_22MS();
         
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
            dgvFamilias.DataSource = bllRol_22MS.ObtenerFamilias_22MS();

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
            dgvSubFamilias.DataSource = bllRol_22MS.ObtenerFamilias_22MS();

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
            dgvPermisos.DataSource = bllRol_22MS.ObtenerPermisos_22MS();

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

                int IdFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                txtNombreFamilia.Text = dgvFamilias.CurrentRow.Cells["NombreFamilia_22MS"].Value.ToString();

                PintarPermisosFamilia_22MS(IdFamilia);
                PintarSubFamilias_22MS(IdFamilia);
                CargarResumenFamilia_22MS(IdFamilia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PintarPermisosFamilia_22MS(int IdFamilia)
        {
            List<Permiso_22MS> permisosDirectos = bllRol_22MS.ObtenerPermisosPorFamilia_22MS(IdFamilia);
            List<Permiso_22MS> permisosHeredados = bllRol_22MS.ObtenerPermisosHeredadosPorFamilia_22MS(IdFamilia);

            foreach (DataGridViewRow row in dgvPermisos.Rows)
            {
                if (row.Cells["IdPermiso_22MS"].Value == null)
                    continue;

                int IdPermiso = Convert.ToInt32(row.Cells["IdPermiso_22MS"].Value);

                bool esDirecto = permisosDirectos.Any(p => p.IdPermiso_22MS == IdPermiso);
                bool esHeredado = permisosHeredados.Any(p => p.IdPermiso_22MS == IdPermiso);

                if (esDirecto)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if (esHeredado)
                {
                    row.DefaultCellStyle.BackColor = Color.Khaki;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void PintarSubFamilias_22MS(int IdFamiliaPadre)
        {
            List<Familia_22MS> hijas = bllRol_22MS.ObtenerFamiliasHijas_22MS(IdFamiliaPadre);

            foreach (DataGridViewRow row in dgvSubFamilias.Rows)
            {
                if (row.Cells["IdFamilia_22MS"].Value == null)
                    continue;

                int IdFamilia = Convert.ToInt32(row.Cells["IdFamilia_22MS"].Value);

                bool asignada = hijas.Any(f => f.IdFamilia_22MS == IdFamilia);

                if (asignada)
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                else
                    row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void CargarResumenFamilia_22MS(int idFamilia)
        {
            dgvCompleta.DataSource = null;
            dgvCompleta.DataSource = bllRol_22MS.ObtenerResumenFamilia_22MS(idFamilia);
        }

        private void LimpiarSeleccion_22MS()
        {
            txtNombreFamilia.Clear();

            dgvFamilias.ClearSelection();
            dgvSubFamilias.ClearSelection();
            dgvPermisos.ClearSelection();

            dgvCompleta.DataSource = null;

            foreach (DataGridViewRow row in dgvSubFamilias.Rows)
                row.DefaultCellStyle.BackColor = Color.White;

            foreach (DataGridViewRow row in dgvPermisos.Rows)
                row.DefaultCellStyle.BackColor = Color.White;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                bllRol_22MS.CrearFamilia_22MS(txtNombreFamilia.Text.Trim());

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

                int IdFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                bllRol_22MS.ModificarFamilia_22MS(IdFamilia, txtNombreFamilia.Text.Trim());

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

                int IdFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                DialogResult respuesta = MessageBox.Show(
                    "¿Seguro que desea eliminar esta familia?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta != DialogResult.Yes)
                    return;

                bllRol_22MS.EliminarFamilia_22MS(IdFamilia);

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

                int IdFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);
                int IdPermiso = Convert.ToInt32(dgvPermisos.CurrentRow.Cells["IdPermiso_22MS"].Value);

                bllRol_22MS.AgregarPermisoAFamilia_22MS(IdFamilia, IdPermiso);

                PintarPermisosFamilia_22MS(IdFamilia);
                CargarResumenFamilia_22MS(IdFamilia);

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

                int IdFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);
                int IdPermiso = Convert.ToInt32(dgvPermisos.CurrentRow.Cells["IdPermiso_22MS"].Value);

                bllRol_22MS.EliminarPermisoDeFamilia_22MS(IdFamilia, IdPermiso);

                PintarPermisosFamilia_22MS(IdFamilia);
                CargarResumenFamilia_22MS(IdFamilia);

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

                int IdFamiliaPadre = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);
                int IdFamiliaHija = Convert.ToInt32(dgvSubFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                bllRol_22MS.AgregarFamiliaAFamilia_22MS(IdFamiliaPadre, IdFamiliaHija);

                PintarSubFamilias_22MS(IdFamiliaPadre);
                PintarPermisosFamilia_22MS(IdFamiliaPadre);
                CargarResumenFamilia_22MS(IdFamiliaPadre);

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

                int IdFamiliaPadre = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);
                int IdFamiliaHija = Convert.ToInt32(dgvSubFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                bllRol_22MS.QuitarFamiliaDeFamilia_22MS(IdFamiliaPadre, IdFamiliaHija);

                PintarSubFamilias_22MS(IdFamiliaPadre);
                PintarPermisosFamilia_22MS(IdFamiliaPadre);
                CargarResumenFamilia_22MS(IdFamiliaPadre);

                MessageBox.Show("Familia quitada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
