using BLL_22MS;
using Servicios_22MS;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Proyecto_final
{
    public class FrmBaseIdioma_22MS : Form, IIdiomaObserver_22MS
    {
        private BLLIdioma_22MS bllIdioma_22MS;
        private bool suscriptoIdioma_22MS;

        public FrmBaseIdioma_22MS()
        {
           
        }

        protected BLLIdioma_22MS ObtenerBLLIdioma_22MS()
        {
            if (bllIdioma_22MS == null)
                bllIdioma_22MS = new BLLIdioma_22MS();

            return bllIdioma_22MS;
        }

        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);

            if (EstaEnModoDiseno_22MS())
                return;

            if (!suscriptoIdioma_22MS)
            {
                IdiomaManager_22MS
                    .GetInstance_22MS()
                    .Suscribir_22MS(this);

                suscriptoIdioma_22MS = true;
            }

            SincronizarEspañolSiCorresponde_22MS();
            ActualizarIdioma_22MS();
        }

        private void SincronizarEspañolSiCorresponde_22MS()
        {
            Idioma_22MS idiomaActual =
                IdiomaManager_22MS
                    .GetInstance_22MS()
                    .IdiomaActual_22MS;

           
            if (idiomaActual == null ||
                idiomaActual.Codigo_22MS == "es")
            {
                TraductorControles_22MS
                    .SincronizarIdiomaBase_22MS(
                        this,
                        ObtenerBLLIdioma_22MS()
                    );
            }
        }

        public virtual void ActualizarIdioma_22MS()
        {
            if (EstaEnModoDiseno_22MS())
                return;

            TraductorControles_22MS
                .TraducirFormulario_22MS(
                    this,
                    ObtenerBLLIdioma_22MS()
                );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && suscriptoIdioma_22MS)
            {
                IdiomaManager_22MS
                    .GetInstance_22MS()
                    .Desuscribir_22MS(this);

                suscriptoIdioma_22MS = false;
            }

            base.Dispose(disposing);
        }

        private bool EstaEnModoDiseno_22MS()
        {
            return LicenseManager.UsageMode ==
                       LicenseUsageMode.Designtime ||
                   (Site != null && Site.DesignMode);
        }

        protected string Traducir_22MS(string etiqueta)
        {
            return ObtenerBLLIdioma_22MS()
                .Traducir_22MS(etiqueta);
        }

        protected string Traducir_22MS(
            string etiqueta,
            params object[] valores)
        {
            string texto = Traducir_22MS(etiqueta);

            return string.Format(texto, valores);
        }

        protected void MostrarInformacion_22MS(
            string etiquetaMensaje,
            string etiquetaTitulo = "TIT_INFORMACION")
        {
            MessageBox.Show(
                Traducir_22MS(etiquetaMensaje),
                Traducir_22MS(etiquetaTitulo),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        protected void MostrarError_22MS(
            string etiquetaMensaje,
            string etiquetaTitulo = "TIT_ERROR")
        {
            MessageBox.Show(
                Traducir_22MS(etiquetaMensaje),
                Traducir_22MS(etiquetaTitulo),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        protected void MostrarAdvertencia_22MS(
            string etiquetaMensaje,
            string etiquetaTitulo = "TIT_ADVERTENCIA")
        {
            MessageBox.Show(
                Traducir_22MS(etiquetaMensaje),
                Traducir_22MS(etiquetaTitulo),
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        protected DialogResult MostrarConfirmacion_22MS(
            string etiquetaMensaje,
            string etiquetaTitulo = "TIT_CONFIRMACION")
        {
            return MessageBox.Show(
                Traducir_22MS(etiquetaMensaje),
                Traducir_22MS(etiquetaTitulo),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
        }
    }
}