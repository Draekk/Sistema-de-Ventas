using ComercSistemaVentas.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercSistemaVentas.Operadores
{
    internal class Programador_O
    {
        public bool ExecuteQUERY(string sql)
        {
			try
			{
				ConexionDB con = new ConexionDB();
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				comando.ExecuteNonQuery();
				con.Desconectar();
				System.Windows.Forms.MessageBox.Show("Comando ejecutado correctamente");
				return true;

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error producido: " + ex.Message);
				return false;
			}

        }

		public DataTable MostrarDatos(string sql)
		{
			try
			{
                ConexionDB con = new ConexionDB();
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                SqlDataReader lector = comando.ExecuteReader();
				DataTable dt = new DataTable();
				con.Desconectar();
				dt.Load(lector);
				System.Windows.Forms.MessageBox.Show("Comando ejecutado correctamente.");
				return dt;

            }
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error producido: " + ex.Message);
				return null;
			}
		}


    }
}
