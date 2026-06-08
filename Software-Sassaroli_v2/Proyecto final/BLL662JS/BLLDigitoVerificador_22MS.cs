using DAL_22MS;
using Servicios_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL_22MS
{
    public class BLLDigitoVerificador_22MS
    {
        private DALDigitoVerificador_22MS dalDigito_22MS = new DALDigitoVerificador_22MS();
        private DigitoVerificador_22MS digito_22MS = new DigitoVerificador_22MS();

        private List<ConfigTablaDigito_22MS> ObtenerConfiguraciones_22MS()
        {
            List<ConfigTablaDigito_22MS> configs = new List<ConfigTablaDigito_22MS>();

            configs.Add(new ConfigTablaDigito_22MS
            {
                NombreTabla_22MS = "Usuario_22MS",
                ColumnasClave_22MS = new List<string> { "IdUsuario_22MS" },
                ColumnasControladas_22MS = new List<string>
                {
                    "IdUsuario_22MS",
                    "Username_22MS",
                    "Password_22MS",
                    "DNI_22MS",
                    "Bloqueado_22MS",
                    "Nombre_22MS",
                    "Apellido_22MS",
                    "Email_22MS",
                    "Activo_22MS",
                    "IdRol_22MS"
                }
            });

            configs.Add(new ConfigTablaDigito_22MS
            {
                NombreTabla_22MS = "Rol_22MS",
                ColumnasClave_22MS = new List<string> { "IdRol_22MS" },
                ColumnasControladas_22MS = new List<string>
                {
                    "IdRol_22MS",
                    "NombreRol_22MS"
                }
            });

            configs.Add(new ConfigTablaDigito_22MS
            {
                NombreTabla_22MS = "Familia_22MS",
                ColumnasClave_22MS = new List<string> { "IdFamilia_22MS" },
                ColumnasControladas_22MS = new List<string>
                {
                    "IdFamilia_22MS",
                    "NombreFamilia_22MS"
                }
            });

            configs.Add(new ConfigTablaDigito_22MS
            {
                NombreTabla_22MS = "Permiso_22MS",
                ColumnasClave_22MS = new List<string> { "IdPermiso_22MS" },
                ColumnasControladas_22MS = new List<string>
                {
                    "IdPermiso_22MS",
                    "NombrePermiso_22MS"
                }
            });

            configs.Add(new ConfigTablaDigito_22MS
            {
                NombreTabla_22MS = "RolFamilia_22MS",
                ColumnasClave_22MS = new List<string> { "IdRol_22MS", "IdFamilia_22MS" },
                ColumnasControladas_22MS = new List<string>
                {
                    "IdRol_22MS",
                    "IdFamilia_22MS"
                }
            });

            configs.Add(new ConfigTablaDigito_22MS
            {
                NombreTabla_22MS = "RolPermiso_22MS",
                ColumnasClave_22MS = new List<string> { "IdRol_22MS", "IdPermiso_22MS" },
                ColumnasControladas_22MS = new List<string>
                {
                    "IdRol_22MS",
                    "IdPermiso_22MS"
                }
            });

            configs.Add(new ConfigTablaDigito_22MS
            {
                NombreTabla_22MS = "FamiliaPermiso_22MS",
                ColumnasClave_22MS = new List<string> { "IdFamilia_22MS", "IdPermiso_22MS" },
                ColumnasControladas_22MS = new List<string>
                {
                    "IdFamilia_22MS",
                    "IdPermiso_22MS"
                }
            });

            configs.Add(new ConfigTablaDigito_22MS
            {
                NombreTabla_22MS = "FamiliaFamilia_22MS",
                ColumnasClave_22MS = new List<string> { "IdFamiliaPadre_22MS", "IdFamiliaHijo_22MS" },
                ColumnasControladas_22MS = new List<string>
                {
                    "IdFamiliaPadre_22MS",
                    "IdFamiliaHijo_22MS"
                }
            });

            return configs;
        }

        private string ArmarCadenaFila_22MS(DataRow row, ConfigTablaDigito_22MS config)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string columna in config.ColumnasControladas_22MS)
            {
                if (row[columna] != DBNull.Value)
                    sb.Append(row[columna].ToString().Trim());
                else
                    sb.Append("");
            }

            return sb.ToString();
        }

        private string ArmarClaveRegistro_22MS(DataRow row, ConfigTablaDigito_22MS config)
        {
            List<string> partes = new List<string>();

            foreach (string columnaClave in config.ColumnasClave_22MS)
            {
                partes.Add(columnaClave + " = " + row[columnaClave].ToString());
            }

            return string.Join(" / ", partes);
        }

        private long CalcularDVColumna_22MS(DataTable dt, string columna)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                if (row[columna] != DBNull.Value)
                    sb.Append(row[columna].ToString().Trim());
                else
                    sb.Append("");
            }

            return digito_22MS.CalcularDigito_22MS(sb.ToString());
        }

        private void RecalcularTabla_22MS(ConfigTablaDigito_22MS config)
        {
            DataTable dt = dalDigito_22MS.ObtenerRegistros_22MS(config);

            foreach (DataRow row in dt.Rows)
            {
                string cadenaFila = ArmarCadenaFila_22MS(row, config);
                long dvh = digito_22MS.CalcularDigito_22MS(cadenaFila);

                dalDigito_22MS.ActualizarDVH_22MS(config, row, dvh);
            }

            DataTable dtActualizado = dalDigito_22MS.ObtenerRegistros_22MS(config);

            dalDigito_22MS.EliminarDigitosVerticalesTabla_22MS(config.NombreTabla_22MS);

            long dvvTabla = 0;

            foreach (string columna in config.ColumnasControladas_22MS)
            {
                long dvColumna = CalcularDVColumna_22MS(dtActualizado, columna);

                dalDigito_22MS.GuardarDigitoVertical_22MS(
                    config.NombreTabla_22MS,
                    columna,
                    dvColumna
                );

                dvvTabla += dvColumna;
            }

            dalDigito_22MS.GuardarDigitoVertical_22MS(
                config.NombreTabla_22MS,
                "DVV_TABLA",
                dvvTabla
            );
        }

        public void RecalcularTodos_22MS()
        {
            List<ConfigTablaDigito_22MS> configs = ObtenerConfiguraciones_22MS();

            foreach (ConfigTablaDigito_22MS config in configs)
            {
                RecalcularTabla_22MS(config);
            }
        }

        private List<ErrorIntegridad_22MS> VerificarTabla_22MS(ConfigTablaDigito_22MS config)
        {
            List<ErrorIntegridad_22MS> errores = new List<ErrorIntegridad_22MS>();

            DataTable dt = dalDigito_22MS.ObtenerRegistros_22MS(config);

            foreach (DataRow row in dt.Rows)
            {
                string cadenaFila = ArmarCadenaFila_22MS(row, config);
                long dvhCalculado = digito_22MS.CalcularDigito_22MS(cadenaFila);

                long dvhGuardado = 0;

                if (row["DVH_22MS"] != DBNull.Value)
                    dvhGuardado = Convert.ToInt64(row["DVH_22MS"]);

                if (dvhGuardado != dvhCalculado)
                {
                    errores.Add(new ErrorIntegridad_22MS
                    {
                        NombreTabla_22MS = config.NombreTabla_22MS,
                        NombreColumna_22MS = "Registro completo",
                        ClaveRegistro_22MS = ArmarClaveRegistro_22MS(row, config),
                        TipoError_22MS = "DVH incorrecto",
                        DVGuardado_22MS = dvhGuardado,
                        DVCalculado_22MS = dvhCalculado,
                        Detalle_22MS = "El registro fue modificado o el DVH no fue actualizado."
                    });
                }
            }

            DataTable dvGuardados = dalDigito_22MS.ObtenerDigitosVerticalesGuardados_22MS(config.NombreTabla_22MS);

            long dvvCalculado = 0;

            foreach (string columna in config.ColumnasControladas_22MS)
            {
                long dvColumnaCalculado = CalcularDVColumna_22MS(dt, columna);

                DataRow[] filasDV = dvGuardados.Select("NombreColumna_22MS = '" + columna + "'");

                long dvColumnaGuardado = 0;

                if (filasDV.Length > 0)
                    dvColumnaGuardado = Convert.ToInt64(filasDV[0]["DV_22MS"]);

                if (dvColumnaGuardado != dvColumnaCalculado)
                {
                    errores.Add(new ErrorIntegridad_22MS
                    {
                        NombreTabla_22MS = config.NombreTabla_22MS,
                        NombreColumna_22MS = columna,
                        ClaveRegistro_22MS = "Columna completa",
                        TipoError_22MS = "DV vertical incorrecto",
                        DVGuardado_22MS = dvColumnaGuardado,
                        DVCalculado_22MS = dvColumnaCalculado,
                        Detalle_22MS = "Se detectó una inconsistencia en la columna " + columna
                    });
                }

                dvvCalculado += dvColumnaCalculado;
            }

            DataRow[] filasDVV = dvGuardados.Select("NombreColumna_22MS = 'DVV_TABLA'");

            long dvvGuardado = 0;

            if (filasDVV.Length > 0)
                dvvGuardado = Convert.ToInt64(filasDVV[0]["DV_22MS"]);

            if (dvvGuardado != dvvCalculado)
            {
                errores.Add(new ErrorIntegridad_22MS
                {
                    NombreTabla_22MS = config.NombreTabla_22MS,
                    NombreColumna_22MS = "DVV_TABLA",
                    ClaveRegistro_22MS = "Tabla completa",
                    TipoError_22MS = "DVV incorrecto",
                    DVGuardado_22MS = dvvGuardado,
                    DVCalculado_22MS = dvvCalculado,
                    Detalle_22MS = "El dígito verificador vertical total de la tabla no coincide."
                });
            }

            return errores;
        }

        public List<ErrorIntegridad_22MS> VerificarIntegridad_22MS()
        {
            List<ErrorIntegridad_22MS> errores = new List<ErrorIntegridad_22MS>();

            List<ConfigTablaDigito_22MS> configs = ObtenerConfiguraciones_22MS();

            foreach (ConfigTablaDigito_22MS config in configs)
            {
                errores.AddRange(VerificarTabla_22MS(config));
            }

            return errores;
        }



    }
}
