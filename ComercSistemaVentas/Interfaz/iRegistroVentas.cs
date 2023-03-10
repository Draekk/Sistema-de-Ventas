using ComercSistemaVentas.Operadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercSistemaVentas.Interfaz
{
    public partial class iRegistroVentas : Form
    {
        public iRegistroVentas()
        {
            InitializeComponent();
            Ventas_O ov = new Ventas_O();
            dgvVentas.DataSource = ov.RegistroVentas();
            dgvReportes.DataSource = ov.RegistroReportes();
            dgvEgresos.DataSource = ov.RegistroEgresos();
            dgvCaja.DataSource = ov.RegistroCaja();
        }

        private void iRegistroVentas_FormClosed(object sender, FormClosedEventArgs e)
        {
            iMenuPrincipal imp = new iMenuPrincipal();
            imp.Visible = true;
        }

    }
}
