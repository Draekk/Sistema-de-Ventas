using ComercSistemaVentas.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ComercSistemaVentas.Operadores
{
    internal class Egresos_O
    {
        public bool InsertarEgreso(string motivo, int monto)
        {
			try
			{
                ConexionDB con = new ConexionDB();
                string sql = $"insert into DiarioEgresos values('{motivo}', {monto}, getdate())";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                int filas = comando.ExecuteNonQuery();

                if (filas == 1)
                {
                    con.Desconectar();
                    return true;
                }
                return false;
            }
			catch (Exception ex)
			{
                System.Windows.Forms.MessageBox.Show("Error Producido: " + ex.Message);
                return false;
			}
        }
    }
}
