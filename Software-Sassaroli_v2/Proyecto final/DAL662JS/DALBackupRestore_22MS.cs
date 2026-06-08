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
    }
}