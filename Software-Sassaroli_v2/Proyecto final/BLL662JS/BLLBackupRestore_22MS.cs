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

        private string carpetaBackups_22MS = @"C:\Backups_22MS";

        public void GenerarBackup_22MS()
        {
            if (!Directory.Exists(carpetaBackups_22MS))
                Directory.CreateDirectory(carpetaBackups_22MS);

            string nombreArchivo = "Backup_22MS_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
            string rutaBackup = Path.Combine(carpetaBackups_22MS, nombreArchivo);

            dalBackupRestore_22MS.GenerarBackup_22MS(rutaBackup);
        }

        public DataTable ObtenerBackups_22MS()
        {
            if (!Directory.Exists(carpetaBackups_22MS))
                Directory.CreateDirectory(carpetaBackups_22MS);

            DataTable tabla = new DataTable();

            tabla.Columns.Add("NombreBackup_22MS");
            tabla.Columns.Add("RutaBackup_22MS");
            tabla.Columns.Add("FechaCreacion_22MS");

            string[] archivos = Directory.GetFiles(carpetaBackups_22MS, "*.bak");

            foreach (string archivo in archivos)
            {
                tabla.Rows.Add(
                    Path.GetFileName(archivo),
                    archivo,
                    File.GetCreationTime(archivo).ToString("dd/MM/yyyy HH:mm:ss")
                );
            }

            return tabla;
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
