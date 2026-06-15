using DAL_22MS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BLL_22MS
{
    public class BLLBackupRestore_22MS
    {
        private DALBackupRestore_22MS dalBackupRestore_22MS = new DALBackupRestore_22MS();

        //private string carpetaBackups_22MS = @"C:\Backups_22MS";

        public void GenerarBackup_22MS(string rutaBackup)
        {
            if (string.IsNullOrWhiteSpace(rutaBackup))
                throw new Exception("Debe seleccionar una ubicación para guardar el backup.");

            string carpeta = Path.GetDirectoryName(rutaBackup);

            if (string.IsNullOrWhiteSpace(carpeta))
                throw new Exception("La ruta seleccionada no es válida.");

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            try
            {
                dalBackupRestore_22MS.GenerarBackup_22MS(rutaBackup);

                string nombreBackup = Path.GetFileName(rutaBackup);

                dalBackupRestore_22MS.RegistrarBackup_22MS(nombreBackup, rutaBackup);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Access is denied") ||
                    ex.Message.Contains("Acceso denegado") ||
                    ex.Message.Contains("Operating system error 5"))
                {
                    throw new Exception(
                        "No se pudo generar el backup porque SQL Server no tiene permisos para escribir en la carpeta seleccionada.\n\n" +
                        "Seleccione otra ubicación o configure permisos de escritura sobre esa carpeta."
                    );
                }

                throw;
            }
        }

        public DataTable ObtenerBackups_22MS()
        {
            return dalBackupRestore_22MS.ObtenerBackupsRegistrados_22MS();
        }

        public void RestaurarBackup_22MS(string rutaBackup)
        {
            if (string.IsNullOrWhiteSpace(rutaBackup))
                throw new Exception("Debe seleccionar un backup.");

            if (!File.Exists(rutaBackup))
                throw new Exception("El archivo de backup no existe.");

            dalBackupRestore_22MS.RestaurarBackup_22MS(rutaBackup);
        }
    }
}
