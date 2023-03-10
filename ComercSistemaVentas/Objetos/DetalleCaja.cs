using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercSistemaVentas.Objetos
{
    internal class DetalleCaja
    {
        public int cInicial { get; set; }
        public int vEfectivo { get; set; }
        public int vTarjeta { get; set; }
        public int vOtros { get; set; }
        public int vTotal { get; set; }
        public int tEgresos { get; set; }
        public int cFinal { get; set; }
        public int tCosto { get; set; }
        public int tDescuento { get; set; }

        public DetalleCaja(int cInicial, int vEfectivo, int vTarjeta, int vOtros, int vTotal, int tEgresos, int cFinal, int tCosto, int tDescuento)
        {
            this.cInicial = cInicial;
            this.vEfectivo = vEfectivo;
            this.vTarjeta = vTarjeta;
            this.vOtros = vOtros;
            this.vTotal = vTotal;
            this.tEgresos = tEgresos;
            this.cFinal = cFinal;
            this.tCosto = tCosto;
            this.tDescuento = tDescuento;
        }
    }
}
