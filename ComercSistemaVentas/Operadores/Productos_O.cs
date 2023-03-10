using ComercSistemaVentas.Conexion;
using ComercSistemaVentas.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ComercSistemaVentas.Operadores
{
    internal class Productos_O
    {
        public bool R_Producto(Producto p)
        {
            try
            {
                ConexionDB con = new ConexionDB();
                string sql = $"insert into Productos values('{p.codigo}', '{p.nombre}', {p.cant}, {p.costo}, {p.venta}, 1)";
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

        public bool ActualizarProducto(Producto p)
        {
            try
            {
                ConexionDB con = new ConexionDB();
                string sql = $"update Productos set nombre = '{p.nombre}', cant = {p.cant}, costo = {p.costo}, venta = {p.venta} where codigo = '{p.codigo}'";
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

        public bool EliminarProducto(string codigo)
        {
            try
            {
                ConexionDB con = new ConexionDB();
                string sql = $"update Productos set estado = 0 where codigo = '{codigo}'";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                int filas = comando.ExecuteNonQuery();

                if (filas == 1)
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

        public DataTable ListaProductos()
        {
            try
            {
                ConexionDB con = new ConexionDB();
                string sql = "select codigo as [CÓDIGO], nombre as [NOMBRE], cant as [CANT], costo as [COSTO], venta as [VENTA] from Productos where estado = 1";
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

        public DataTable ListaProductos(string codigo)
        {
            try
            {
                ConexionDB con = new ConexionDB();
                string sql = $"select codigo as [CÓDIGO], nombre as [NOMBRE], cant as [CANT], costo as [COSTO], venta as [VENTA] from Productos where estado = 1 and codigo = '{codigo}'";
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

        public Producto B_ProductoCod(string codigo)
        {
            try
            {
                ConexionDB con = new ConexionDB();
                string sql = $"select * from Productos where codigo = '{codigo}' and estado = 1";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                SqlDataReader lector = comando.ExecuteReader();

                if(lector.Read())
                {
                    Producto p = new Producto();
                    p.codigo = lector["codigo"].ToString();
                    p.nombre = lector["nombre"].ToString();
                    p.cant = int.Parse(lector["cant"].ToString());
                    p.costo = int.Parse(lector["costo"].ToString());
                    p.venta = int.Parse(lector["venta"].ToString());

                    con.Desconectar();
                    return p;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable B_ProductoNombre(string nombre)
        {
            try
            {
                ConexionDB con = new ConexionDB();
                string sql = $"select codigo as [CÓDIGO], nombre as [NOMBRE], cant as [CANT], costo as [COSTO], venta as [VENTA] from Productos where nombre like '%{nombre}%' and estado = 1";
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
        

    }
}
