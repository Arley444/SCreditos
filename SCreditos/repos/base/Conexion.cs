using Npgsql;
using System;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Conexion
    {
        public const String HOTS = "127.0.0.1";

        public const String USER_NAME = "postgres";

        public const String PASSWORD = "123456789";
        //public const String PASSWORD = "1243568790";

        public const String DATA_BASE = "TEST";
        //public const String DATA_BASE = "DB_SCREDITOS";



        // Conexion
        public static NpgsqlConnection conexion = new NpgsqlConnection("Host="+HOTS+";Username="+USER_NAME+";Password="+PASSWORD+";Database="+DATA_BASE+"");
        
        public static Boolean conectar()
        {
            Boolean bestado = true;
            try
            {//Confirmacion
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }         
            }
            catch (Exception e)
            {//Error 
                bestado = false;
                MessageBox.Show(e.Message, "Conectando DB");
            }
            return bestado;
        }
        
        public static void desconectar()
        {
            try
            {//Estado
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception e)
            {//Error 
                MessageBox.Show(e.Message);
            }
        }

    }
}
