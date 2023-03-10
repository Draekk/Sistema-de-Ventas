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
    public partial class iUsoProgramador : Form
    {
        public iUsoProgramador()
        {
            InitializeComponent();
        }

        private void iUsoProgramador_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Programador_O oprg = new Programador_O();
            if (txtQUERY.Text.Contains(@"select"))
            {
                DataTable dt = oprg.MostrarDatos(txtQUERY.Text.Trim());
                if (dt != null)
                {
                    dgvRegistro.DataSource = dt;
                    txtQUERY.Focus();
                }
            }
            else if (oprg.ExecuteQUERY(txtQUERY.Text.Trim()))
            {
                txtQUERY.Focus();
            }
            
        }
    }
}
