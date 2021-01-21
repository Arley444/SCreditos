using Devart.Data.PostgreSql;
using SCreditos.models;
using System;
using System.Diagnostics;
using System.IO;
using Devart.Common;

namespace SCreditos.usecase.backup
{
    class CrearCopiaBaseDatosUseCase
    {

        //public static void tenga()
        //{
        //    PgSqlConnection conn = new PgSqlConnection("user id = postgres;password=postgres;host=localhost;port=5432;database =testbase;schema=test");
        //    conn.Open();



        //    DbDump pgSqlDump = new DbDump
        //    {
        //        Connection = conn
        //    };
        //    pgSqlDump.Backup("d:\\sqldump1.dmp");
        //    conn.Close();








        //    Process p = new Process();
        //    p.StartInfo.FileName = "cmd.exe";
        //    p.StartInfo.UseShellExecute = false;
        //    p.StartInfo.RedirectStandardInput = true;
        //    p.StartInfo.RedirectStandardOutput = true;
        //    p.StartInfo.RedirectStandardError = true;
        //    p.StartInfo.CreateNoWindow = false;
        //    p.Start();
        //    String command = "";
        //    String outputPath = @"C:\";
        //    if (!Directory.Exists(outputPath))
        //    {
        //        Directory.CreateDirectory(outputPath);
        //    }
        //    command = @"cd C:\Program Files\PostgreSQL\10\bin";
        //    p.StandardInput.WriteLine(command);
        //    command = @"pg_dump -U " + Conexion.USER_NAME + " -d " + Conexion.PASSWORD + " - f " + outputPath + "yucas.sql";

        //    p.StandardInput.WriteLine(command);
        //}


        //public static String backup()
        //{
        //    DateTime Time = DateTime.Now;
        //    int year = Time.Year;
        //    int month = Time.Month;
        //    int day = Time.Day;
        //    int hour = Time.Hour;
        //    int minute = Time.Minute;

        //    String backupFileName = year + "-" + month + "-" + day + "-" + hour + "-" + minute;


        //    return backupDatabase(Conexion.HOTS, "5432", Conexion.USER_NAME, Conexion.PASSWORD, Conexion.DATA_BASE, "C:\\", backupFileName, "C:\\Program Files\\PostgreSQL\\10\\bin");
        //}

        //public static String backupDatabase(String server, String port, String user, String password, String dbname, String backupdir, String backupFileName, String backupCommandDir)
        //{
        //    try
        //    {
        //        string Creten = "/c pg_dump -h 127.0.0.1 -U postgres -d " + password + " -p " + port + " " + dbname + " > " + " " + backupdir + " " + "";

        //        ProcessStartInfo Pinfo = new ProcessStartInfo("cmd.exe", Creten);


        //        Pinfo.RedirectStandardError = false;

        //        Pinfo.UseShellExecute = false;

        //        string Output = string.Empty;

        //        Process p = new Process();

        //        p.StartInfo = Pinfo;

        //        p.StartInfo.CreateNoWindow = false;

        //        p.Start();

        //        while (!p.HasExited)

        //            System.Threading.Thread.Sleep(1000);

        //        p.WaitForExit();

        //        p.Close();

















        //        //Environment.SetEnvironmentVariable("PGPASSWORD", password);

        //        //String backupFile = backupdir + backupFileName + DateTime.Now.ToString("yyyy") + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd") + ".backup";
        //        //String BackupString = "-ibv -Z3 -f \"" + backupFile + "\" " +
        //        // "-Fc -h " + server + " -U " + user + " -p " + port + " " + dbname;

        //        //Process proc = new Process();
        //        //proc.StartInfo.FileName = backupCommandDir + "\\pg_dump.exe";
        //        //proc.StartInfo.Arguments = BackupString;

        //        //proc.Start();
        //        //proc.WaitForExit();
        //        //proc.Close();

        //        return backupdir;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
