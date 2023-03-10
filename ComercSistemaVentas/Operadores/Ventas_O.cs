using ComercSistemaVentas.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercSistemaVentas.Objetos;
using System.Net.Configuration;

namespace ComercSistemaVentas.Operadores
{
    internal class Ventas_O
    {

		public DataTable B_ProductoNombre(string nombre)
		{
			try
			{
				ConexionDB con = new ConexionDB();
				string sql = $"select codigo as [CÓDIGO], nombre as [PRODUCTO], cant as [CANT], venta as [PRECIO] from Productos where nombre like '%{nombre}%' and estado = 1";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				SqlDataReader lector = comando.ExecuteReader();

				if (lector.HasRows)
				{
					con.Desconectar();
					DataTable dt = new DataTable();
					dt.Load(lector);
					return dt;
				}
				return null;


			}
			catch (Exception)
			{
				return null;
			}
		}

		public bool ActualizarStock(Producto[] p)
		{
			try
			{
				Productos_O op = new Productos_O();
				ConexionDB con = new ConexionDB();
				int filas = 0;
				for(int i = 0; i < p.Length; i++)
				{
					Producto p2 = op.B_ProductoCod(p[i].codigo);
					int stockfinal = p2.cant - p[i].cant;
					string sql = $"update Productos set cant = {stockfinal} where codigo = '{p[i].codigo}' and estado = 1";
					SqlCommand comando = new SqlCommand(sql, con.Conectar());
					filas += comando.ExecuteNonQuery();
					con.Desconectar();
				}

				if(filas == p.Length)
				{
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool RegistrarVenta(DataTable dt, int nVenta, int total, string tPago)
		{
			try
			{
				ConexionDB con = new ConexionDB();
                Productos_O op = new Productos_O();

                int filas = 0;
				
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					DataRow dr = dt.Rows[i];
					Producto p = op.B_ProductoCod(dr[0].ToString());

					string sql = $"insert into DiarioVentas values({nVenta}, '{dr[0]}', '{dr[1]}', {dr[2]}, {p.cant}, {p.costo * int.Parse(dr[2].ToString())}, {dr[3]}, '{tPago}', getdate())";
					SqlCommand comando = new SqlCommand(sql, con.Conectar());
					filas += comando.ExecuteNonQuery();
					con.Desconectar();

				}

				if(filas == dt.Rows.Count)
				{
					return true;
				}
				return false;

			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool GenerarReporte(int total, string tPago, int descuento)
		{
			try
			{
				ConexionDB con = new ConexionDB();
				string sql = $"insert into DiarioReportes values({GetNumeroVenta() + 1}, {total}, '{tPago}', getdate(), {descuento})";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				int filas = comando.ExecuteNonQuery();

				if(filas == 1)
				{
					con.Desconectar();
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public int GetNumeroVenta()
		{
			try
			{
				ConexionDB con = new ConexionDB();
				string sql = "select max(id) as [nVenta] from DiarioReportes";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				SqlDataReader lector = comando.ExecuteReader();
				if (lector.Read())
				{
					con.Desconectar();
					if (int.TryParse(lector["nVenta"].ToString(), out int nVenta))
					{
						return nVenta;
					}
					else if (lector["nVenta"].ToString() == "")
					{
						return 1;
					}
				}
				return -1;
			}
			catch (Exception)
			{
				return -1;
			}
		}

		public DataTable RegistroVentas()
		{
			try
			{
				ConexionDB con = new ConexionDB();
				string sql = "select nVenta as [N°], codigo as [CÓDIGO], nombre as [PRODUCTO], cVendida as [CANT], compra as [COSTO], venta as [VENTA], tPago as [M. PAGO], fecha as [FECHA] from DiarioVentas";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				SqlDataReader lector = comando.ExecuteReader();

				if (lector.HasRows)
				{
					con.Desconectar();
					DataTable dt = new DataTable();
					dt.Load(lector);
					return dt;
				}
				return null;

			}
			catch (Exception)
			{
				return null;
			}
		}

		public DataTable RegistroReportes()
		{
			try
			{
				ConexionDB con = new ConexionDB();
				string sql = "select id as [N° Venta], total as [Total], descuento as [Desc], tPago as [M. Pago], fecha as [Fecha] from DiarioReportes";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				SqlDataReader lector = comando.ExecuteReader();

				if (lector.HasRows)
				{
					con.Desconectar();
					DataTable dt = new DataTable();
					dt.Load(lector);
					return dt;
				}
				return null;

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error producido: " + ex.Message);
				return null;
			}
		}

        public DataTable RegistroEgresos()
        {
            try
            {
                ConexionDB con = new ConexionDB();
                string sql = "select id as [N°], motivo as [Motivo], monto as [Monto], fecha as [Fecha] from DiarioEgresos";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    con.Desconectar();
                    DataTable dt = new DataTable();
                    dt.Load(lector);
                    return dt;
                }
                return null;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error producido: " + ex.Message);
                return null;
            }
        }

        public DataTable RegistroCaja()
        {
            try
            {
                ConexionDB con = new ConexionDB();
                string sql = "select id as [N°], cInicial as [C. Inicial], vEfectivo as [T. Efectivo], vTarjeta as [T. Tarjeta], vOtros as [V. Otros], vTotal as [Total], tEgresos as [Egreso], cFinal as [C. Final], tCosto as [T. Costo], fecha as [Fecha] from DiarioCaja";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    con.Desconectar();
                    DataTable dt = new DataTable();
                    dt.Load(lector);
                    return dt;
                }
                return null;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error producido: " + ex.Message);
                return null;
            }
        }

    }
}
