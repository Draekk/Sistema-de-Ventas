using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercSistemaVentas.Conexion
{
    internal class ConexionDB
    {
        public string server { get; set; }
        public string database { get; set; }
        public string userId { get; set; }
        public string password { get; set; }
        public string conImportar { get; set; }

        public ConexionDB()
        {
            //server = Environment.MachineName;
            server = "(local)";
            database = "Comerc";
            userId = "sa";
            password = "THEHELl9000.";
        }

        public SqlConnection Conectar()
        {
            try
            {
                //string conString = $@"Server={server}\SQLEXPRESS; Database={database}; User Id={userId}; Password={password};";
                string conString = $@"Server={server}\SQLEXPRESS; Database={database}; Trusted_Connection=True;";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Problema de conectividad con la base de datos. {ex.Message}");
                return null;
            }
        }

        public SqlConnection Desconectar()
        {
            try
            {
                //string conString = $@"Server={server}\SQLEXPRESS; Database={database}; User Id={userId}; Password={password};";
                string conString = $@"Server={server}\SQLEXPRESS; Database={database}; Integrated Security=True;";
                SqlConnection con = new SqlConnection(conString);
                con.Close();
                return con;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Problema de conectividad con la base de datos. {ex.Message}");
                return null;
            }
        }

        public void CreacionDatos(string ruta)
        {
            try
            {
                conImportar = $"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= {ruta}; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

                OleDbConnection origen = new OleDbConnection(conImportar);
                string sql = "SELECT * FROM [Hoja 1$]";
                OleDbCommand seleccion = new OleDbCommand(sql, origen);

                OleDbDataAdapter adaptador = new OleDbDataAdapter();
                adaptador.SelectCommand = seleccion;

                DataTable dt = new DataTable();

                adaptador.Fill(dt);
                origen.Close();

                Conectar();

                SqlBulkCopy importar = new SqlBulkCopy(Conectar());
                importar.DestinationTableName = "Productos";
                importar.WriteToServer(dt);
                Desconectar();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error de Importación." + ex.Message);
            }
        }
    }
}
