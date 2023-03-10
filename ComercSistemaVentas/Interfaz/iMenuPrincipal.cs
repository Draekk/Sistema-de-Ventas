using ComercSistemaVentas.Conexion;
using ComercSistemaVentas.Interfaz;
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

namespace ComercSistemaVentas
{
    public partial class iMenuPrincipal : Form
    {
        public static int nVentanas_V = 0;

        public iMenuPrincipal()
        {
            InitializeComponent();

            Caja_O oc = new Caja_O();
            if (oc.VerificarCajaInicial(DateTime.Today) && oc.VerificarCajaCerrada(DateTime.Today))
            {
                pnlAbrirCaja.Visible = false;
                btnAperturaCaja.Enabled = false;
            }
            else if (oc.VerificarCajaInicial(DateTime.Today))
            {
                pnlAbrirCaja.Visible = false;
                btnAperturaCaja.Enabled = false;
            }
            else
            {
                pnlAbrirCaja.Visible = true;
                btnVentas.Enabled = false;
                btnCierreCaja.Enabled = false;
                pnlPrincipal.Enabled = false;
                txtCajaInicial.Focus();
            }

            txtPassword.Visible = false;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            iProductos ip = new iProductos();
            ip.Show();
            Visible = false;
        }

        private void iMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form[] forms = OwnedForms;
            foreach (Form form in forms)
            {
                form.Close();
            }
            Application.Exit();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            iVentas iv = new iVentas();
            iv.Show();
            nVentanas_V++;
            Visible = false;
        }

        private void btnRegistroVentas_Click(object sender, EventArgs e)
        {
            iRegistroVentas irv = new iRegistroVentas();
            irv.Show();
            Visible = false;
        }

        private void btnCloseCI_Click(object sender, EventArgs e)
        {
            pnlAbrirCaja.Visible = false;
            pnlPrincipal.Enabled = true;
        }

        private void btnAperturaCaja_Click(object sender, EventArgs e)
        {
            pnlAbrirCaja.Visible = true;
            pnlPrincipal.Enabled = false;
        }

        private void btnGuardarCaja_Click(object sender, EventArgs e)
        {
            Caja_O oc = new Caja_O();
            try
            {
                if(int.TryParse(txtCajaInicial.Text.Trim(), out int caja) && oc.RegistrarCajaInicial(caja))
                {
                    MessageBox.Show("Caja registrada satisfactoriamente.");
                    pnlPrincipal.Enabled = true;
                    btnVentas.Enabled = true;
                    btnCierreCaja.Enabled = true;
                    pnlAbrirCaja.Visible = false;
                    btnAperturaCaja.Enabled = false;
                    pnlPrincipal.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error al crear el registro.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error. " + ex.Message);
            }


        }

        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
            iCierreCaja icc = new iCierreCaja();
            icc.Show();
            Visible = false;
        }

        private void btnCierreCaja_VisibleChanged(object sender, EventArgs e)
        {
            Caja_O oc = new Caja_O();
            if (oc.VerificarCajaCerrada(DateTime.Today) && !oc.VerificarCajaInicial(DateTime.Today))
            {
                btnCierreCaja.Enabled = false;
                btnVentas.Enabled = false;
                btnAperturaCaja.Enabled = true;
                pnlPrincipal.Enabled = false;
            }
        }

        private void btnUsoProgramador_Click(object sender, EventArgs e)
        {
            txtPassword.Visible = true;
            txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtPassword.Text == "THEHELl9000.")
                {
                    iUsoProgramador iup = new iUsoProgramador();
                    iup.Show();
                    txtPassword.Text = "";
                    txtPassword.Visible = false;
                }
                else
                {
                    MessageBox.Show("Wrong password.");
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            
        }
    }
}
