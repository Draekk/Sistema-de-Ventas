using ComercSistemaVentas.Conexion;
using ComercSistemaVentas.Objetos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercSistemaVentas.Operadores
{
    internal class Caja_O
    {
		private string FormatoFecha(DateTime date)
		{
            string dia, mes = "";

            if (date.Day < 10)
            {
                dia = "0" + date.Day.ToString();
            }
            else
            {
                dia = date.Day.ToString();
            }
            if (date.Month < 10)
            {
                mes = "0" + date.Month.ToString();
            }
            else
            {
                mes = date.Month.ToString();
            }
            string fecha = date.Year.ToString() + mes + dia;

			return fecha;
        }

        public bool VerificarCajaInicial(DateTime date)
        {
			try
			{
				string fecha = FormatoFecha(date);

				ConexionDB con = new ConexionDB();
				string sql = $"select cInicial from DiarioCaja where fecha >= '{fecha}' and estado = 0";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				SqlDataReader lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
					string caja = lector["cInicial"].ToString();

                    if (caja != "")
					{
						return true;
					}
				}
				return false;

            }
            catch (Exception)
			{
				return false;
			}
        }

		public bool RegistrarCajaInicial(int caja)
		{
			try
			{
				ConexionDB con = new ConexionDB();
				string sql = $"insert into DiarioCaja values({caja}, 0, 0, 0, 0, 0, 0, getdate(), 0, 0)";
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

		public bool CerrarCaja(DetalleCaja dc, DateTime date)
		{
			string fecha = FormatoFecha(date);

			try
			{
				ConexionDB con = new ConexionDB();
				string sql = $"update DiarioCaja set vEfectivo = {dc.vEfectivo}, vTarjeta = {dc.vTarjeta}, vOtros = {dc.vOtros}, vTotal = {dc.vTotal}, tEgresos = {dc.tEgresos}, cFinal = {dc.cFinal}, estado = 1, tCosto = {dc.tCosto} where fecha >= '{fecha}' and estado = 0";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				int filas = comando.ExecuteNonQuery();

				if(filas == 1)
				{
					con.Desconectar();
					return true;
				}
				con.Desconectar();
				return false;

			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool VerificarCajaCerrada(DateTime date)
		{
			string fecha = FormatoFecha(date);
			try
			{
				ConexionDB con = new ConexionDB();
				string sql = $"select cFinal from DiarioCaja where fecha >= '{fecha}' and estado = 1";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				SqlDataReader lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
					if (lector["cFinal"].ToString() != "0")
					{
						return true;
					}
				}
				con.Desconectar();
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public DetalleCaja GenerarDetalleCaja(DateTime date)
		{
            string fecha = FormatoFecha(date);
            int cInicial, vEfectivo, vTarjeta, vOtros, vTotal, tEgresos, cFinal, tCosto, tDescuento = 0;
            ConexionDB con = new ConexionDB();
			SqlDataReader lector;

			//-------------Caja Inicial-----------------//
            try
			{

				string sql = $"select cInicial from DiarioCaja where fecha >= '{fecha}' and estado = 0";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
					cInicial = int.Parse(lector["cInicial"].ToString());
				}
				else
				{
					con.Desconectar();
					cInicial = -1;
				}
			}
			catch (Exception)
			{
				cInicial = -1;
			}

			//-------------Ventas Efectivo------------//
			try
			{
				string sql = $"select sum(total) as [vEfectivo] from DiarioReportes where tPago = 'EFECTIVO' and fecha >= '{fecha}'";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
					if (lector["vEfectivo"].ToString() != "")
					{
                        vEfectivo = int.Parse(lector["vEfectivo"].ToString());
                    }
					else
					{
						vEfectivo = 0;
					}
				}
				else
				{
					con.Desconectar();
					vEfectivo = -1;
				}

			}
			catch (Exception)
			{
				vEfectivo = -1;
			}

			//-------------Ventas Tarjeta--------------//
			try
			{
				string sql = $"select sum(total) as [vTarjeta] from DiarioReportes where tPago = 'TARJETA' and fecha >= '{fecha}'";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
                    if (lector["vTarjeta"].ToString() != "")
                    {
                        vTarjeta = int.Parse(lector["vTarjeta"].ToString());
                    }
                    else
                    {
                        vTarjeta = 0;
                    }
                }
				else
				{
					con.Desconectar();
					vTarjeta = -1;
				}
			}
			catch (Exception)
			{
				vTarjeta = -1;
			}

			//------------Ventas Otros------------//
			try
			{
				string sql = $"select sum(total) as [vOtros] from DiarioReportes where tPago = 'OTRO' and fecha >= '{fecha}'";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
                    if (lector["vOtros"].ToString() != "")
                    {
                        vOtros = int.Parse(lector["vOtros"].ToString());
                    }
                    else
                    {
                        vOtros = 0;
                    }
                }
				else
				{
					con.Desconectar();
					vOtros = -1;
				}

			}
			catch (Exception)
			{
				vOtros = -1;
			}

			//------------Venta Total------------//
			try
			{
				string sql = $"select sum(total) as [vTotal] from DiarioReportes where fecha >= '{fecha}'";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
                    if (lector["vTotal"].ToString() != "")
                    {
                        vTotal = int.Parse(lector["vTotal"].ToString());
                    }
                    else
                    {
                        vTotal = 0;
                    }
                }
				else
				{
					con.Desconectar();
					vTotal = -1;
				}
			}
			catch (Exception)
			{
				vTotal = -1;
			}

			//-------------Total Egresos------------//
			try
			{
                string sql = $"select sum(monto) as [tEgresos] from DiarioEgresos where fecha >= '{fecha}'";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
                    if (lector["tEgresos"].ToString() != "")
                    {
                        tEgresos = int.Parse(lector["tEgresos"].ToString());
                    }
                    else
                    {
                        tEgresos = 0;
                    }
                }
				else
				{
					con.Desconectar();
					tEgresos = -1;
				}
            }
			catch (Exception)
			{
				tEgresos = -1;
			}

			//------------Caja Final-------------//
			try
			{
				if(cInicial > -1 && vEfectivo > -1)
				{
					cFinal = cInicial + vEfectivo;
					if(tEgresos > 0 && tEgresos < cFinal)
					{
						cFinal -= tEgresos;
					}
				}
				else
				{
					cFinal = -1;
				}
			}
			catch (Exception)
			{
				cFinal = -1;
			}

			//-----------Detalle Costo-----------//
			try
			{
				string sql = $"select sum(compra) as [tCosto] from DiarioVentas where fecha >= '{fecha}'";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
					if (lector["tCosto"].ToString() == "")
					{
						tCosto = 0;
					}
					else
					{
						tCosto = int.Parse(lector["tCosto"].ToString());
					}
				}
				else
				{
					con.Desconectar();
					tCosto = -1;
				}

			}
			catch (Exception)
			{
				tCosto = -1;
			}

			//----------Total Descuentos---------//
			try
			{
				string sql = $"select sum(descuento) as [Desc] from DiarioReportes where fecha >= '{fecha}'";
				SqlCommand comando = new SqlCommand(sql, con.Conectar());
				lector = comando.ExecuteReader();

				if (lector.Read())
				{
					con.Desconectar();
					if (lector["Desc"].ToString() != "")
					{
						tDescuento = int.Parse(lector["Desc"].ToString());
					}
					else
					{
						tDescuento = 0;
					}
				}
				else
				{
					tDescuento = -1;
				}
			}
			catch (Exception)
			{
				tDescuento = -1;
			}

			//----------Detalle Caja------------//
			if(cInicial > -1 || vEfectivo > -1 || vTarjeta > -1 || vOtros > -1 || vTotal > -1 || tEgresos > -1 || cFinal > -1)
			{
				DetalleCaja dc = new DetalleCaja(cInicial, vEfectivo, vTarjeta, vOtros, vTotal, tEgresos, cFinal, tCosto, tDescuento);
				return dc;
            }
			return null;

		}

    }
}
