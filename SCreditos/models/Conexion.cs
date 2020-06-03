using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCreditos.models
{
    class Conexion
    {
        // Conexion
        public static NpgsqlConnection conexion = new NpgsqlConnection("Host=127.0.0.1;Username=postgres;Password=123456789;Database=TEST_1");        

        
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
                MessageBox.Show(e.Message, "Canectando DB");
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
