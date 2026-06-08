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
    public partial class FrmGestionarRoles_22MS : Form
    {
        private BLLRol_22MS bllRol_22MS = new BLLRol_22MS();
        private BLLFamilia_22MS bllFamilia_22MS = new BLLFamilia_22MS();
        private BLLPermiso_22MS bllPermiso_22MS = new BLLPermiso_22MS();

        public FrmGestionarRoles_22MS()
        {
            InitializeComponent();
        }

        private void FrmGestionarRoles_22MS_Load(object sender, EventArgs e)
        {
            ConfigurarGrillas_22MS();
            CargarRoles_22MS();
            CargarFamilias_22MS();
            CargarPermisos_22MS();
            LimpiarSeleccion_22MS();
        }

        private void ConfigurarGrillas_22MS()
        {
            dgvRoles.AutoGenerateColumns = true;
            dgvFamilias.AutoGenerateColumns = true;
            dgvPermisos.AutoGenerateColumns = true;
            dgvCompleta.AutoGenerateColumns = true;

            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompleta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvRoles.MultiSelect = false;
            dgvFamilias.MultiSelect = false;
            dgvPermisos.MultiSelect = false;
            dgvCompleta.MultiSelect = false;

            dgvRoles.ReadOnly = true;
            dgvFamilias.ReadOnly = true;
            dgvPermisos.ReadOnly = true;
            dgvCompleta.ReadOnly = true;

            dgvRoles.AllowUserToAddRows = false;
            dgvFamilias.AllowUserToAddRows = false;
            dgvPermisos.AllowUserToAddRows = false;
            dgvCompleta.AllowUserToAddRows = false;
        }

        private void CargarRoles_22MS()
        {
            dgvRoles.DataSource = null;
            dgvRoles.DataSource = bllRol_22MS.ObtenerRoles_22MS();

            if (dgvRoles.Columns["IdRol_22MS"] != null)
                dgvRoles.Columns["IdRol_22MS"].HeaderText = "ID";

            if (dgvRoles.Columns["NombreRol_22MS"] != null)
                dgvRoles.Columns["NombreRol_22MS"].HeaderText = "Rol";

            if (dgvRoles.Columns["Componentes_22MS"] != null)
                dgvRoles.Columns["Componentes_22MS"].Visible = false;
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

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (dgvRoles.CurrentRow == null)
                    return;

                int idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRol_22MS"].Value);
                string nombreRol = dgvRoles.CurrentRow.Cells["NombreRol_22MS"].Value.ToString();

                txtNombreRol.Text = nombreRol;

                PintarFamiliasAsignadas_22MS(idRol);
                PintarPermisosAsignados_22MS(idRol);
                CargarResumenRol_22MS(idRol);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarResumenRol_22MS(int idRol)
        {
            dgvCompleta.DataSource = null;
            dgvCompleta.DataSource = bllRol_22MS.ObtenerRolFamiliaPermiso_22MS(idRol);

            if (dgvCompleta.Columns["Rol"] != null)
                dgvCompleta.Columns["Rol"].HeaderText = "Rol";

            if (dgvCompleta.Columns["Familia"] != null)
                dgvCompleta.Columns["Familia"].HeaderText = "Familia";

            if (dgvCompleta.Columns["Permiso"] != null)
                dgvCompleta.Columns["Permiso"].HeaderText = "Permiso";
        }

        private void PintarFamiliasAsignadas_22MS(int idRol)
        {
            List<Familia_22MS> familiasRol = bllRol_22MS.ObtenerFamiliasPorRol_22MS(idRol);

            foreach (DataGridViewRow fila in dgvFamilias.Rows)
            {
                if (fila.Cells["IdFamilia_22MS"].Value == null)
                    continue;

                int idFamilia = Convert.ToInt32(fila.Cells["IdFamilia_22MS"].Value);

                bool asignada = familiasRol.Any(familia => familia.IdFamilia_22MS == idFamilia);

                if (asignada)
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                else
                    fila.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void PintarPermisosAsignados_22MS(int idRol)
        {
            List<Permiso_22MS> permisosDirectos = bllRol_22MS.ObtenerPermisosDirectosPorRol_22MS(idRol);
            List<Permiso_22MS> permisosTotales = bllRol_22MS.ObtenerPermisosPorRol_22MS(idRol);

            foreach (DataGridViewRow fila in dgvPermisos.Rows)
            {
                if (fila.Cells["IdPermiso_22MS"].Value == null)
                    continue;

                int idPermiso = Convert.ToInt32(fila.Cells["IdPermiso_22MS"].Value);

                bool esDirecto = permisosDirectos.Any(permiso => permiso.IdPermiso_22MS == idPermiso);
                bool estaEnElRol = permisosTotales.Any(permiso => permiso.IdPermiso_22MS == idPermiso);

                if (esDirecto)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if (estaEnElRol)
                {
                    fila.DefaultCellStyle.BackColor = Color.Khaki;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void LimpiarSeleccion_22MS()
        {
            txtNombreRol.Clear();

            dgvRoles.ClearSelection();
            dgvFamilias.ClearSelection();
            dgvPermisos.ClearSelection();

            dgvCompleta.DataSource = null;

            foreach (DataGridViewRow fila in dgvFamilias.Rows)
                fila.DefaultCellStyle.BackColor = Color.White;

            foreach (DataGridViewRow fila in dgvPermisos.Rows)
                fila.DefaultCellStyle.BackColor = Color.White;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                bllRol_22MS.CrearRol_22MS(txtNombreRol.Text.Trim());

                MessageBox.Show("Rol creado correctamente.");

                CargarRoles_22MS();
                CargarFamilias_22MS();
                CargarPermisos_22MS();
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
                if (dgvRoles.CurrentRow == null)
                    throw new Exception("Debe seleccionar un rol.");

                int idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRol_22MS"].Value);

                DialogResult respuesta = MessageBox.Show(
                    "¿Seguro que desea eliminar este rol?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta != DialogResult.Yes)
                    return;

                bllRol_22MS.EliminarRol_22MS(idRol);

                MessageBox.Show("Rol eliminado correctamente.");

                CargarRoles_22MS();
                CargarFamilias_22MS();
                CargarPermisos_22MS();
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
                if (dgvRoles.CurrentRow == null)
                    throw new Exception("Debe seleccionar un rol.");

                int idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRol_22MS"].Value);

                bllRol_22MS.ModificarRol_22MS(idRol, txtNombreRol.Text.Trim());

                MessageBox.Show("Rol modificado correctamente.");

                CargarRoles_22MS();
                CargarFamilias_22MS();
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

        private void btnAsignarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoles.CurrentRow == null)
                    throw new Exception("Debe seleccionar un rol.");

                if (dgvFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar una familia.");

                int idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRol_22MS"].Value);
                int idFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                bllRol_22MS.AgregarFamiliaARol_22MS(idRol, idFamilia);

                MessageBox.Show("Familia asignada correctamente.");

                PintarFamiliasAsignadas_22MS(idRol);
                PintarPermisosAsignados_22MS(idRol);
                CargarResumenRol_22MS(idRol);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuitarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoles.CurrentRow == null)
                    throw new Exception("Debe seleccionar un rol.");

                if (dgvFamilias.CurrentRow == null)
                    throw new Exception("Debe seleccionar una familia.");

                int idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRol_22MS"].Value);
                int idFamilia = Convert.ToInt32(dgvFamilias.CurrentRow.Cells["IdFamilia_22MS"].Value);

                bllRol_22MS.EliminarFamiliaDeRol_22MS(idRol, idFamilia);

                PintarFamiliasAsignadas_22MS(idRol);
                PintarPermisosAsignados_22MS(idRol);
                CargarResumenRol_22MS(idRol);

                MessageBox.Show("Familia quitada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoles.CurrentRow == null)
                    throw new Exception("Debe seleccionar un rol.");

                if (dgvPermisos.CurrentRow == null)
                    throw new Exception("Debe seleccionar un permiso.");

                int idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRol_22MS"].Value);
                int idPermiso = Convert.ToInt32(dgvPermisos.CurrentRow.Cells["IdPermiso_22MS"].Value);

                bllRol_22MS.AgregarPermisoARol_22MS(idRol, idPermiso);

                PintarPermisosAsignados_22MS(idRol);
                CargarResumenRol_22MS(idRol);

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
                if (dgvRoles.CurrentRow == null)
                    throw new Exception("Debe seleccionar un rol.");

                if (dgvPermisos.CurrentRow == null)
                    throw new Exception("Debe seleccionar un permiso.");

                int idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IdRol_22MS"].Value);
                int idPermiso = Convert.ToInt32(dgvPermisos.CurrentRow.Cells["IdPermiso_22MS"].Value);

                List<Permiso_22MS> permisosDirectos = bllRol_22MS.ObtenerPermisosDirectosPorRol_22MS(idRol);
                List<Permiso_22MS> permisosTotales = bllRol_22MS.ObtenerPermisosPorRol_22MS(idRol);

                bool esDirecto = permisosDirectos.Any(permiso => permiso.IdPermiso_22MS == idPermiso);
                bool estaEnElRol = permisosTotales.Any(permiso => permiso.IdPermiso_22MS == idPermiso);

                if (!estaEnElRol)
                    throw new Exception("El rol no tiene asignado ese permiso.");

                if (!esDirecto)
                    throw new Exception("No se puede eliminar un permiso de una familia desde Admin de Rol.");

                bllRol_22MS.QuitarPermisoDeRol_22MS(idRol, idPermiso);

                PintarPermisosAsignados_22MS(idRol);
                CargarResumenRol_22MS(idRol);

                MessageBox.Show("Permiso quitado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFormFamilias_Click(object sender, EventArgs e)
        {
            new FrmGestionarFamilias_22MS().Show();
            this.Close();
        }
    }
}