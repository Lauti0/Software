using BLL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    public static class TraductorControles_22MS
    {
        public static void SincronizarIdiomaBase_22MS(Form formulario, BLLIdioma_22MS bllIdioma)
        {
            Idioma_22MS idiomaEspañol;

            try
            {
                idiomaEspañol =
                    bllIdioma.ObtenerIdioma_22MS("es");
            }
            catch
            {
                idiomaEspañol = new Idioma_22MS
                {
                    Codigo_22MS = "es",
                    Nombre_22MS = "Español",
                    Traducciones_22MS =
                        new Dictionary<string, string>()
                };
            }

            if (idiomaEspañol.Traducciones_22MS == null)
            {
                idiomaEspañol.Traducciones_22MS =
                    new Dictionary<string, string>();
            }

            // Registra el título del formulario.
            RegistrarEtiqueta_22MS(
                idiomaEspañol,
                formulario.Tag,
                formulario.Text
            );

            RegistrarControles_22MS(
                formulario.Controls,
                idiomaEspañol
            );
        }

        private static void RegistrarControles_22MS(
            Control.ControlCollection controles,
            Idioma_22MS idioma)
        {
            foreach (Control control in controles)
            {
                RegistrarEtiqueta_22MS(
                    idioma,
                    control.Tag,
                    control.Text
                );

                if (control is MenuStrip menuStrip)
                {
                    RegistrarItemsMenu_22MS(
                        menuStrip.Items,
                        idioma
                    );
                }

                if (control is DataGridView dgv)
                {
                    foreach (DataGridViewColumn columna in dgv.Columns)
                    {
                        RegistrarEtiqueta_22MS(
                            idioma,
                            columna.Tag,
                            columna.HeaderText
                        );
                    }
                }

                if (control.HasChildren)
                {
                    RegistrarControles_22MS(
                        control.Controls,
                        idioma
                    );
                }
            }
        }

        private static void RegistrarItemsMenu_22MS(
            ToolStripItemCollection items,
            Idioma_22MS idioma)
        {
            foreach (ToolStripItem item in items)
            {
                RegistrarEtiqueta_22MS(
                    idioma,
                    item.Tag,
                    item.Text
                );

                if (item is ToolStripDropDownItem desplegable)
                {
                    RegistrarItemsMenu_22MS(
                        desplegable.DropDownItems,
                        idioma
                    );
                }
            }
        }

        private static void RegistrarEtiqueta_22MS(
            Idioma_22MS idioma,
            object tag,
            string textoActual)
        {
            if (tag == null)
                return;

            string etiqueta = tag.ToString().Trim();

            if (string.IsNullOrWhiteSpace(etiqueta))
                return;

            if (!idioma.Traducciones_22MS.ContainsKey(etiqueta))
            {
                idioma.Traducciones_22MS.Add(
                    etiqueta,
                    textoActual
                );
            }
        }

        public static void TraducirFormulario_22MS(
            Form formulario,
            BLLIdioma_22MS bllIdioma)
        {
            TraducirTexto_22MS(
                formulario,
                formulario.Tag,
                bllIdioma
            );

            TraducirControles_22MS(
                formulario.Controls,
                bllIdioma
            );
        }

        private static void TraducirControles_22MS(
            Control.ControlCollection controles,
            BLLIdioma_22MS bllIdioma)
        {
            foreach (Control control in controles)
            {
                TraducirTexto_22MS(
                    control,
                    control.Tag,
                    bllIdioma
                );

                if (control is MenuStrip menuStrip)
                {
                    TraducirItemsMenu_22MS(
                        menuStrip.Items,
                        bllIdioma
                    );
                }

                if (control is DataGridView dgv)
                {
                    foreach (DataGridViewColumn columna in dgv.Columns)
                    {
                        if (columna.Tag == null)
                            continue;

                        string etiqueta =
                            columna.Tag.ToString().Trim();

                        string traduccion =
                            bllIdioma.Traducir_22MS(etiqueta);

                        if (!string.IsNullOrWhiteSpace(traduccion) &&
                            traduccion != etiqueta)
                        {
                            columna.HeaderText = traduccion;
                        }
                    }
                }

                if (control.HasChildren)
                {
                    TraducirControles_22MS(
                        control.Controls,
                        bllIdioma
                    );
                }
            }
        }

        private static void TraducirItemsMenu_22MS(
            ToolStripItemCollection items,
            BLLIdioma_22MS bllIdioma)
        {
            foreach (ToolStripItem item in items)
            {
                if (item.Tag != null)
                {
                    string etiqueta =
                        item.Tag.ToString().Trim();

                    string traduccion =
                        bllIdioma.Traducir_22MS(etiqueta);

                    if (!string.IsNullOrWhiteSpace(traduccion) &&
                        traduccion != etiqueta)
                    {
                        item.Text = traduccion;
                    }
                }

                if (item is ToolStripDropDownItem desplegable)
                {
                    TraducirItemsMenu_22MS(
                        desplegable.DropDownItems,
                        bllIdioma
                    );
                }
            }
        }

        private static void TraducirTexto_22MS(
            Control control,
            object tag,
            BLLIdioma_22MS bllIdioma)
        {
            if (tag == null)
                return;

            string etiqueta = tag.ToString().Trim();

            if (string.IsNullOrWhiteSpace(etiqueta))
                return;

            string traduccion =
                bllIdioma.Traducir_22MS(etiqueta);

            // Si no existe traducción, conserva el texto actual.
            if (!string.IsNullOrWhiteSpace(traduccion) &&
                traduccion != etiqueta)
            {
                control.Text = traduccion;
            }
        }
    }
}
