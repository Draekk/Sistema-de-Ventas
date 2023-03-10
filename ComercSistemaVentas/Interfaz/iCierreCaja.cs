using ComercSistemaVentas.Objetos;
using ComercSistemaVentas.Operadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercSistemaVentas.Interfaz
{
    public partial class iCierreCaja : Form
    {
        public iCierreCaja()
        {
            InitializeComponent();
            Caja_O oc = new Caja_O();
            DetalleCaja dc = oc.GenerarDetalleCaja(DateTime.Today);

            lblFecha.Text = DateTime.Today.ToShortDateString();

            if(dc != null)
            {
                lblCajaInicial.Text = dc.cInicial.ToString("C", CultureInfo.CurrentCulture);
                lblVentasEfectivo.Text = dc.vEfectivo.ToString("C", CultureInfo.CurrentCulture);
                lblVentasTarjeta.Text = dc.vTarjeta.ToString("C", CultureInfo.CurrentCulture);
                lblVentasOtros.Text = dc.vOtros.ToString("C", CultureInfo.CurrentCulture);
                lblVentaTotal.Text = dc.vTotal.ToString("C", CultureInfo.CurrentCulture);
                lblTotalEgresos.Text = dc.tEgresos.ToString("C", CultureInfo.CurrentCulture);
                lblCajaFinal.Text = dc.cFinal.ToString("C", CultureInfo.CurrentCulture);
                lbltCosto.Text = dc.tCosto.ToString("C", CultureInfo.CurrentCulture);
            }
            else
            {
                MessageBox.Show("Error al cargar los datos.");
            }
        }

        private void iCierreCaja_FormClosed(object sender, FormClosedEventArgs e)
        {
            iMenuPrincipal imp = new iMenuPrincipal();
            imp.Visible = true;
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("¿Desea realizar el cierre de caja?", "Confirmación", MessageBoxButtons.YesNo))
            {
                Caja_O oc = new Caja_O();
                DetalleCaja dc = oc.GenerarDetalleCaja(DateTime.Today);
                if(oc.CerrarCaja(dc, DateTime.Today))
                {
                    MessageBox.Show("Cierre de caja exitoso.");

                    lblCajaInicial.Text = "$0";
                    lblVentasEfectivo.Text = "$0";
                    lblVentasTarjeta.Text = "$0";
                    lblVentasOtros.Text = "$0";
                    lblVentaTotal.Text = "$0";
                    lblTotalEgresos.Text = "$0";
                    lblCajaFinal.Text = "$0";
                    lbltCosto.Text = "$0";

                    btnCerrarCaja.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error al realizar el cierre de caja");
                }
            }


        }
    }
}
