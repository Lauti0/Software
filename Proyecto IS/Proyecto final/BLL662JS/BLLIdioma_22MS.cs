using Newtonsoft.Json;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BLL_22MS
{
    public class BLLIdioma_22MS
    {
        private readonly string carpetaIdiomas_22MS;

        public BLLIdioma_22MS()
        {
            carpetaIdiomas_22MS = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Idiomas"
            );

            CrearCarpetaSiNoExiste_22MS();
        }

        private void CrearCarpetaSiNoExiste_22MS()
        {
            if (!Directory.Exists(carpetaIdiomas_22MS))
            {
                Directory.CreateDirectory(
                    carpetaIdiomas_22MS
                );
            }
        }

        public Idioma_22MS ObtenerIdioma_22MS(
            string codigoIdioma)
        {
            if (string.IsNullOrWhiteSpace(codigoIdioma))
            {
                throw new Exception(
                    "El código del idioma es inválido."
                );
            }

            string rutaArchivo =
                ObtenerRutaIdioma_22MS(
                    codigoIdioma.Trim().ToLower()
                );

            if (!File.Exists(rutaArchivo))
            {
                throw new Exception(
                    "No se encontró el idioma seleccionado."
                );
            }

            string contenidoJson =
                File.ReadAllText(rutaArchivo);

            Idioma_22MS idioma =
                JsonConvert.DeserializeObject<Idioma_22MS>(
                    contenidoJson
                );

            if (idioma == null)
            {
                throw new Exception(
                    "No se pudo cargar el idioma."
                );
            }

            if (idioma.Traducciones_22MS == null)
            {
                idioma.Traducciones_22MS =
                    new Dictionary<string, string>();
            }

            return idioma;
        }

        public List<Idioma_22MS> ObtenerIdiomas_22MS()
        {
            CrearCarpetaSiNoExiste_22MS();

            List<Idioma_22MS> idiomas =
                new List<Idioma_22MS>();

            string[] archivos =
                Directory.GetFiles(
                    carpetaIdiomas_22MS,
                    "*.json"
                );

            foreach (string archivo in archivos)
            {
                try
                {
                    string contenidoJson =
                        File.ReadAllText(archivo);

                    Idioma_22MS idioma =
                        JsonConvert.DeserializeObject<Idioma_22MS>(
                            contenidoJson
                        );

                    if (idioma == null)
                        continue;

                    if (idioma.Traducciones_22MS == null)
                    {
                        idioma.Traducciones_22MS =
                            new Dictionary<string, string>();
                    }

                    idiomas.Add(idioma);
                }
                catch
                {
                    // Si un JSON está dañado,
                    // no se agrega a la lista.
                }
            }

            return idiomas
                .OrderBy(i => i.Nombre_22MS)
                .ToList();
        }

        public string ObtenerTraduccion_22MS(
            Idioma_22MS idioma,
            string etiqueta)
        {
            if (idioma == null ||
                idioma.Traducciones_22MS == null)
            {
                return etiqueta;
            }

            if (idioma.Traducciones_22MS.TryGetValue(
                etiqueta,
                out string traduccion))
            {
                return traduccion;
            }

            return etiqueta;
        }

        public string Traducir_22MS(string etiqueta)
        {
            Idioma_22MS idiomaActual =
                IdiomaManager_22MS
                    .GetInstance_22MS()
                    .IdiomaActual_22MS;

            if (idiomaActual == null)
                return etiqueta;

            return ObtenerTraduccion_22MS(
                idiomaActual,
                etiqueta
            );
        }

        private string ObtenerRutaIdioma_22MS(
            string codigoIdioma)
        {
            return Path.Combine(
                carpetaIdiomas_22MS,
                codigoIdioma + ".json"
            );
        }
    }
}
