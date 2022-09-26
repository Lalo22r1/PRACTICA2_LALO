using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Lalo
{
    class Conexion
    {
        static SqlConnection cnx;
        static string cadena = @"Server=localhost;Database=BDPRACTICA2;Trusted_Connection=True;";
        private static void Conectar()
        {
            cnx = new SqlConnection(cadena);
            cnx.Open();
        }

        private static void Desconectar()
        {
            cnx.Close();
            cnx = null;
        }

        public static int EjecutaConsulta(string consulta)
        {
            int filasAfectadas = 0;
            Conectar();
            SqlCommand cmd = new SqlCommand(consulta, cnx);
            filasAfectadas = cmd.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }

        public static DataTable EjecutaSeleccion(string consulta)
        {
            DataTable dt = new DataTable();
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public static Object EjecutarEscalar(string consulta)
        {
            DataTable dt = new DataTable();
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt.Rows[0].ItemArray[0];
        }
    }
}
