using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ComercSistemaVentas.Objetos
{
    internal class Producto
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int cant { get; set; }
        public int costo { get; set; }
        public int venta { get; set; }

        public Producto()
        {

        }

        public Producto(string codigo, string nombre, int cant, int venta)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.cant = cant;
            this.venta = venta;
        }

        public Producto(string[] datos)
        {
            try
            {
                codigo = datos[0];
                nombre = datos[1];
                cant = int.Parse(datos[2]);
                costo = int.Parse(datos[3]);
                venta = int.Parse(datos[4]);

            }
            catch (Exception)
            {
                codigo = "000000";
            }
        }

    }
}
