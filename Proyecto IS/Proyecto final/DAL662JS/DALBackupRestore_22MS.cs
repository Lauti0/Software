using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_22MS
{
    public class DALBackupRestore_22MS
    {
        private string nombreBaseDatos_22MS = "ProyectoFinal1";

        public void GenerarBackup_22MS(string rutaBackup)
        {
            string query = $@"
                BACKUP DATABASE [{nombreBaseDatos_22MS}]
                TO DISK = @RutaBackup
                WITH INIT";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@RutaBackup", rutaBackup);

            Acceso_22MS.GetInstance_22MS().EscribirMaster_22MS(cmd);
        }

        public void RestaurarBackup_22MS(string rutaBackup)
        {
            string query = $@"
                ALTER DATABASE [{nombreBaseDatos_22MS}]
                SET SINGLE_USER
                WITH ROLLBACK IMMEDIATE;

                RESTORE DATABASE [{nombreBaseDatos_22MS}]
                FROM DISK = @RutaBackup
                WITH REPLACE;

                ALTER DATABASE [{nombreBaseDatos_22MS}]
                SET MULTI_USER;";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@RutaBackup", rutaBackup);

            Acceso_22MS.GetInstance_22MS().EscribirMaster_22MS(cmd);
        }

        public void RegistrarBackup_22MS(string nombreBackup, string rutaBackup)
        {
            string query = @"
                           insert into Backup_22MS
                           (NombreBackup_22MS, RutaBackup_22MS, FechaBackup_22MS)
                           values
                           (@NombreBackup_22MS, @RutaBackup_22MS, @FechaBackup_22MS)";

            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@NombreBackup_22MS", nombreBackup);
            cmd.Parameters.AddWithValue("@RutaBackup_22MS", rutaBackup);
            cmd.Parameters.AddWithValue("@FechaBackup_22MS", DateTime.Now);

            Acceso_22MS.GetInstance_22MS().Escribir_22MS(cmd);
        }

        public DataTable ObtenerBackupsRegistrados_22MS()
        {
            string query = @"
                           select IdBackup_22MS,
                                  NombreBackup_22MS,
                                  RutaBackup_22MS,
                                  FechaBackup_22MS
                           from Backup_22MS
                           order by FechaBackup_22MS desc";

            SqlCommand cmd = new SqlCommand(query);

            return Acceso_22MS.GetInstance_22MS().Leer_22MS(cmd);
        }


    }
}