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

namespace Proyecto_final
{
    public partial class FrmCambiarIdioma_22MS : FrmBaseIdioma_22MS
    {
        private BLLIdioma_22MS bllIdioma_22MS = new BLLIdioma_22MS();
        private BLLBitacoraEvento_22MS bllBitacora_22MS = new BLLBitacoraEvento_22MS();
        private BLLUsuario_22MS bllUsuario_22MS = new BLLUsuario_22MS();

        public FrmCambiarIdioma_22MS()
        {
            InitializeComponent();
        }

        private void btnCambiarIdioma_22MS_Click(object sender, EventArgs e)
        {
            try
            {
                Idioma_22MS idiomaSeleccionado_22MS =
                    cmbIdiomas_22MS.SelectedItem as Idioma_22MS;

                if (idiomaSeleccionado_22MS == null)
                {
                    throw new Exception(
                        bllIdioma_22MS.Traducir_22MS("error_idioma_no_seleccionado")
                    );
                }

                Idioma_22MS idiomaActual_22MS =
                    IdiomaManager_22MS
                        .GetInstance_22MS()
                        .IdiomaActual_22MS;

                if (idiomaActual_22MS != null &&
                    idiomaActual_22MS.Codigo_22MS ==
                    idiomaSeleccionado_22MS.Codigo_22MS)
                {
                    throw new Exception(
                        bllIdioma_22MS.Traducir_22MS("error_idioma_ya_activo")
                    );
                }

                Idioma_22MS idiomaActualizado_22MS =
                    bllIdioma_22MS.ObtenerIdioma_22MS(
                        idiomaSeleccionado_22MS.Codigo_22MS
                    );

                SessionManager_22MS sesion_22MS =
                    SessionManager_22MS.GetInstance_22MS();


                if (sesion_22MS != null &&
                    sesion_22MS.Usuario_22MS != null)
                {
                    UsuarioServicios_22MS usuario_22MS =
                        sesion_22MS.Usuario_22MS;

                    bllUsuario_22MS.ActualizarIdiomaUsuario_22MS(
                        usuario_22MS.IdUsuario_22MS,
                        idiomaActualizado_22MS.Codigo_22MS
                    );

                    // Actualiza también el usuario guardado en memoria
                    usuario_22MS.CodigoIdioma_22MS =
                        idiomaActualizado_22MS.Codigo_22MS;
                }

                // Se aplica después de guardar correctamente
                IdiomaManager_22MS
                    .GetInstance_22MS()
                    .CambiarIdioma_22MS(
                        idiomaActualizado_22MS
                    );

                bllBitacora_22MS.RegistrarEvento_22MS(
                    ObtenerUsuarioActual_22MS(),
                    "Idiomas",
                    "Cambio de idioma a: " +
                    idiomaActualizado_22MS.Nombre_22MS,
                    1
                );

                MessageBox.Show(
                    bllIdioma_22MS.Traducir_22MS(
                        "mensaje_idioma_cambiado"
                    ),
                    bllIdioma_22MS.Traducir_22MS(
                        "titulo_cambio_idioma"
                    ),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Close();
            }
            catch (Exception)
            {
                throw new Exception("mensaje_debe_seleccionar_idioma");
            }
        }


        private void CargarIdiomas_22MS()
        {
            List<Idioma_22MS> idiomas =
                bllIdioma_22MS.ObtenerIdiomas_22MS();

            cmbIdiomas_22MS.DataSource = null;
            cmbIdiomas_22MS.DataSource = idiomas;
            cmbIdiomas_22MS.DisplayMember = "Nombre_22MS";
            cmbIdiomas_22MS.DropDownStyle = ComboBoxStyle.DropDownList;

            Idioma_22MS idiomaActual =
                IdiomaManager_22MS
                    .GetInstance_22MS()
                    .IdiomaActual_22MS;

            if (idiomaActual == null)
                return;

            Idioma_22MS idiomaEncontrado =
                idiomas.FirstOrDefault(i =>
                    i.Codigo_22MS ==
                    idiomaActual.Codigo_22MS);

            if (idiomaEncontrado != null)
                cmbIdiomas_22MS.SelectedItem = idiomaEncontrado;
        }

        private string ObtenerUsuarioActual_22MS()
        {
            if (SessionManager_22MS.GetInstance_22MS() != null &&
                SessionManager_22MS
                    .GetInstance_22MS()
                    .Usuario_22MS != null)
            {
                return SessionManager_22MS
                    .GetInstance_22MS()
                    .Usuario_22MS
                    .Username_22MS;
            }

            return "Sistema";
        }

        private void btnSalir_22MS_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void FrmCambiarIdioma_22MS_Load(object sender, EventArgs e)
        {
            CargarIdiomas_22MS();
        }
    }
}
