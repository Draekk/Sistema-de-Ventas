using ComercSistemaVentas.Objetos;
using ComercSistemaVentas.Operadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercSistemaVentas.Interfaz
{
    public partial class iVentas : Form
    {
        private DataTable dtVenta = new DataTable();
        private DataTable dtBusqueda = new DataTable();

        private bool buscando = false;
        private bool modificando = false;
        private string[] producto;
        private int descuento = 0;

        public static string codigoP;

        public iVentas()
        {
            InitializeComponent();
            dtVenta.Columns.Add("CÓDIGO");
            dtVenta.Columns.Add("PRODUCTO");
            dtVenta.Columns.Add("CANT");
            dtVenta.Columns.Add("PRECIO");

            pnlCant.Enabled = false;
            btnPagar.Enabled = false;
            pnlEgresos.Visible = false;
            pnlCambio.Visible = false;
            pnlExportarExcel.Visible = false;
            pnlDescuento.Enabled = false;

            chbxDescuento.Checked = false;
            lblMensajeDesc.Visible = false;

            txtMonto_C.Text = "";
            lblCambio.Text = "$0";

            lblTotal.Text = "$0";
            lblnVenta.Text = NumeroVenta();
        }

        private bool ComprobarStock()
        {
            for(int i = 0; i < dgvListaVenta.Rows.Count; i++)
            {
                Producto aComprobar = new Producto(
                    dgvListaVenta.Rows[i].Cells[0].Value.ToString(),
                    dgvListaVenta.Rows[i].Cells[1].Value.ToString(),
                    int.Parse(dgvListaVenta.Rows[i].Cells[2].Value.ToString()),
                    int.Parse(dgvListaVenta.Rows[i].Cells[3].Value.ToString())
                    );
                Productos_O op = new Productos_O();
                Producto p = op.B_ProductoCod(aComprobar.codigo);

                if( p != null && aComprobar.cant > p.cant)
                {
                    MessageBox.Show($"Error al comprobar stock. El producto {p.nombre} excede el maximo en existencia. (MAX: {p.cant})");
                    return false;
                }
            }
            return true;
        }

        private int PrecioTotal()
        {
            if(!buscando && dtVenta.Rows.Count > 0)
            {
                int[] valores = new int[dtVenta.Rows.Count];

                for(int i = 0; i < dtVenta.Rows.Count; i++)
                {
                    valores[i] = int.Parse(dtVenta.Rows[i][3].ToString());
                }

                int total = valores.Sum() - descuento;
                return total;
            }
            return 0;
        }

        private void FormatoDGV()
        {
            try
            {
                dgvListaVenta.Columns[0].Width = 120;
                dgvListaVenta.Columns[1].Width = 430;
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private int TotalCambio(string sMonto, int total)
        {
            if(int.TryParse(sMonto.Trim(), out int monto))
            {
                int cambio = monto - total;
                if(cambio > 0)
                return cambio;
                return 0;

            }
            return 0;
        }

        private string NumeroVenta()
        {
            Ventas_O ov = new Ventas_O();
            int nv = ov.GetNumeroVenta();
            if (nv != 1) nv = ov.GetNumeroVenta() + 1;
            string nVenta = nv.ToString();
            if(nVenta != "0")
            {
                return nVenta;
            }
            MessageBox.Show("Error al obtener el numero de venta");
            return "##ERROR##";
        }

        private void LimpiarCampos()
        {
            buscando = false;
            dtVenta.Rows.Clear();
            dtBusqueda.Rows.Clear();
            cbxTipoPago.SelectedIndex = -1;
            txtMonto_C.Text = "";
            pnlCambio.Visible = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCant.Text = "";
            lblCambio.Text = "$0";
            lblTotal.Text = "$0";
            chbxDescuento.Checked = false;
            descuento = 0;
        }

        private void iVentas_FormClosed(object sender, FormClosedEventArgs e)
        {
            iMenuPrincipal imp = new iMenuPrincipal();
            iMenuPrincipal.nVentanas_V--;
            if(iMenuPrincipal.nVentanas_V == 0) imp.Visible = true;
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtCodigo.Text != "")
                {
                    Productos_O op = new Productos_O();
                    Producto p = op.B_ProductoCod(txtCodigo.Text.Trim().ToUpper());
                    if (p == null)
                    {
                        MessageBox.Show("Producto no existente en la base de datos.", "Advertencia");
                        return;
                    }
                    else if(p.cant >= 1)
                    {
                        producto = new string[4] { p.codigo, p.nombre, "1", p.venta.ToString() };
                    }
                    else
                    {
                        MessageBox.Show($"No hay suficiente stock. Max: {p.cant}.");
                        return;
                    }
                    if (p != null && dtVenta.Rows.Count > 0)
                    {
                        for(int i = 0; i < dtVenta.Rows.Count; i++)
                        {
                            if(p.codigo == dtVenta.Rows[i][0].ToString())
                            {
                                int n1 = int.Parse(dtVenta.Rows[i][2].ToString());
                                int n2 = n1 + 1;
                                if(n2 > p.cant)
                                {
                                    MessageBox.Show($"No hay suficiente stock. Max: {p.cant}.");
                                    return;
                                }
                                else
                                {
                                    dtVenta.Rows[i][2] = n2;
                                }

                                n2 = p.venta * int.Parse(dtVenta.Rows[i][2].ToString());
                                dtVenta.Rows[i][3] = n2;
                                break;
                            }
                            if(i == dtVenta.Rows.Count -1)
                            {
                                dtVenta.Rows.Add(producto);
                                break;
                            }
                        }
                    }
                    else
                    {
                        dtVenta.Rows.Add(producto);
                    }
                    dgvListaVenta.DataSource = dtVenta;
                    FormatoDGV();
                    txtCodigo.Text = "";
                    txtCodigo.Focus();

                    lblTotal.Text = PrecioTotal().ToString("C", CultureInfo.CurrentCulture);
                }
            }
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if(txtNombre.Text != "")
            {
                buscando = true;
                Ventas_O ov = new Ventas_O();
                dtBusqueda = ov.B_ProductoNombre(txtNombre.Text.Trim().ToUpper());
                dgvListaVenta.DataSource = dtBusqueda;
                FormatoDGV();
            }
            else if(txtNombre.Text == "")
            {
                buscando = false;
                dgvListaVenta.DataSource = dtVenta;
                FormatoDGV();
            }
        }

        private void dgvListaVenta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (buscando)
            {
                producto = new string[4]
                {
                    dgvListaVenta.CurrentRow.Cells[0].Value.ToString(),
                    dgvListaVenta.CurrentRow.Cells[1].Value.ToString(),
                    "1",
                    dgvListaVenta.CurrentRow.Cells[3].Value.ToString()
                };

                pnlCant.Enabled = true;
                txtCant.Focus();

            }
            else
            {
                producto = new string[4]
                {
                    dgvListaVenta.CurrentRow.Cells[0].Value.ToString(),
                    dgvListaVenta.CurrentRow.Cells[1].Value.ToString(),
                    dgvListaVenta.CurrentRow.Cells[2].Value.ToString(),
                    dgvListaVenta.CurrentRow.Cells[3].Value.ToString()
                };
                modificando = true;
                pnlCant.Enabled = true;
                txtCant.Focus();
            }


        }

        private void txtCant_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtCant.Text != "")
                    {
                        if (buscando)
                        {
                            producto[2] = txtCant.Text.Trim();
                        }
                        else
                        {
                            producto[2] = txtCant.Text.Trim();
                            //producto[2] = (int.Parse(txtCant.Text) + int.Parse(producto[2])).ToString();
                        }

                        Productos_O op = new Productos_O();
                        Producto p = op.B_ProductoCod(producto[0]);

                        if(p.cant < int.Parse(txtCant.Text.Trim()))
                        {
                            MessageBox.Show($"No hay suficiente stock. Max: {p.cant}.");
                            return;
                        }

                        if (p != null && dtVenta.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtVenta.Rows.Count; i++)
                            {
                                if (p.codigo == dtVenta.Rows[i][0].ToString())
                                {
                                    int n1, n2 = 0;
                                    if (modificando)
                                    {
                                        if (int.Parse(producto[2]) > p.cant)
                                        {
                                            MessageBox.Show($"No hay suficiente stock. Max: {p.cant}.");
                                            producto[2] = (int.Parse(producto[2]) - int.Parse(txtCant.Text.Trim())).ToString();
                                            modificando = false;
                                            return;
                                        }
                                        dtVenta.Rows[i][2] = producto[2];
                                        dtVenta.Rows[i][3] = int.Parse(producto[2]) * p.venta;
                                        modificando = false;
                                        break;
                                    }
                                    n1 = int.Parse(dtVenta.Rows[i][2].ToString());
                                    n2 = n1 + int.Parse(producto[2]);
                                    if (n2 > p.cant)
                                    {
                                        MessageBox.Show($"No hay suficiente stock. Max{p.cant}.");
                                        return;
                                    }
                                    else
                                    {
                                        dtVenta.Rows[i][2] = n2;
                                    }

                                    n2 = p.venta * int.Parse(dtVenta.Rows[i][2].ToString());
                                    dtVenta.Rows[i][3] = n2;
                                    break;
                                }
                                if (i == dtVenta.Rows.Count - 1)
                                {
                                    int n1 = int.Parse(producto[2]) * int.Parse(producto[3]);
                                    producto[3] = n1.ToString();
                                    dtVenta.Rows.Add(producto);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            int n1 = int.Parse(producto[2]);
                            int n2 = n1 * p.venta;
                            producto[3] = n2.ToString();
                            dtVenta.Rows.Add(producto);
                        }
                    }

                    buscando = false;
                    txtCant.Text = "";
                    txtNombre.Text = "";
                    pnlCant.Enabled = false;
                    producto[2] = "";
                    txtCodigo.Focus();
                    FormatoDGV();
                    lblTotal.Text = PrecioTotal().ToString("C", CultureInfo.CurrentCulture);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Se ha producido un error: {ex.Message}", "Error");
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                buscando = false;
                txtCant.Text = "";
                txtNombre.Text = "";
                pnlCant.Enabled = false;
                txtCodigo.Focus();
                dgvListaVenta.DataSource = dtVenta;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnNuevaV_Click(object sender, EventArgs e)
        {
            iVentas iVentas = new iVentas();
            iVentas.Show();
            iMenuPrincipal.nVentanas_V++;
        }

        private void btnEditarP_Click(object sender, EventArgs e)
        {
            if(dgvListaVenta.Rows.Count > 0)
            {
                try
                {
                    codigoP = dgvListaVenta.SelectedCells[0].Value.ToString();
                    iProductos iProductos = new iProductos();
                    iProductos.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir la ventana Produtos." + ex.Message);
                }
            }
            else
            {
                try
                {
                    iProductos iProductos = new iProductos();
                    iProductos.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir la ventana Produtos." + ex.Message);
                }
            }
        }

        private void txtEgresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMonto_E.Text != "" && DialogResult.Yes == MessageBox.Show("¿Desea generar un nuevo egreso?", "Confirmación", MessageBoxButtons.YesNo))
                {
                    if (int.TryParse(txtMonto_E.Text, out int monto))
                    {
                        string motivo = txtMotivo_E.Text.Trim().ToUpper();
                        Egresos_O oe = new Egresos_O();
                        if (oe.InsertarEgreso(motivo, monto))
                        {
                            MessageBox.Show("Egreso generado exitosamente.");
                            txtMonto_E.Text = "";
                            txtMotivo_E.Text = "";
                            pnlEgresos.Visible = false;
                            pnlPrincipal.Enabled = true;
                        }
                        else MessageBox.Show("Se ha producido un error");
                    }
                    else MessageBox.Show("Error de formato, introduzca un monto solo con numeros");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEgresos_Click(object sender, EventArgs e)
        {
            pnlEgresos.Visible = true;
            pnlPrincipal.Enabled = false;
        }

        private void btnCerrar_E_Click(object sender, EventArgs e)
        {
            pnlEgresos.Visible = false;
            pnlPrincipal.Enabled = true;
        }

        private void cbxTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTipoPago.SelectedIndex)
            {
                case -1:
                    btnPagar.Enabled = false;
                    pnlCambio.Visible = false;
                    break;

                case 0:
                    pnlCambio.Visible = true;
                    btnPagar.Enabled = true;
                    break;

                case 1:
                    btnPagar.Enabled = true;
                    pnlCambio.Visible = false;
                    break;

                case 2:
                    btnPagar.Enabled = true;
                    pnlCambio.Visible = false;
                    break;

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvListaVenta.Rows.Count > 0 && !buscando)
                {
                    dtVenta.Rows.RemoveAt(dgvListaVenta.Rows.IndexOf(dgvListaVenta.CurrentRow));
                    dgvListaVenta.DataSource = dtVenta;
                    lblTotal.Text = PrecioTotal().ToString("C", CultureInfo.CurrentCulture);
                }
                else if(dgvListaVenta.Rows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un producto de la lista primero.");
                }
                else
                {
                    MessageBox.Show("No puede eliminar productos de esta lista.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMonto_C_TextChanged(object sender, EventArgs e)
        {
            lblCambio.Text = TotalCambio(txtMonto_C.Text.Trim(), PrecioTotal()).ToString("C", CultureInfo.CurrentCulture);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("¿Desea ejecutar la venta?", "Confirmación", MessageBoxButtons.YesNo))
                {
                    Productos_O op = new Productos_O();
                    Ventas_O ov = new Ventas_O();
                    Producto[] cajaProductos = new Producto[dgvListaVenta.RowCount];

                    for (int i = 0; i < cajaProductos.Length; i++)
                    {
                        Producto p = op.B_ProductoCod(dgvListaVenta.Rows[i].Cells[0].Value.ToString());

                        cajaProductos[i] = new Producto
                            (
                                p.codigo,
                                p.nombre,
                                int.Parse(dgvListaVenta.Rows[i].Cells[2].Value.ToString()),
                                int.Parse(dgvListaVenta.Rows[i].Cells[3].Value.ToString())
                            );

                    }

                    if (!ComprobarStock())
                    {
                        return;
                    }

                    if (ov.ActualizarStock(cajaProductos) && ov.GenerarReporte(PrecioTotal(), cbxTipoPago.SelectedItem.ToString(), descuento) && ov.RegistrarVenta(dtVenta, ov.GetNumeroVenta(), PrecioTotal(), cbxTipoPago.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Venta registrada exitosamente.");
                        LimpiarCampos();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error." + ex.Message);
            }

        }

        private void chbxDescuento_CheckStateChanged(object sender, EventArgs e)
        {
            if(chbxDescuento.Checked)
            {
                pnlDescuento.Enabled = true;
                txtDescuento.Focus();
            }
            else
            {
                txtDescuento.Text = "";
                pnlDescuento.Enabled = false;
                lblMensajeDesc.Visible = false;
                descuento = 0;
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(txtDescuento.Text, out int d))
            {
                descuento = d;
            }
            else
            {
                descuento = 0;
            }

            lblMensajeDesc.Visible = true;
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lblTotal.Text = PrecioTotal().ToString("C", CultureInfo.CurrentCulture);
                lblMensajeDesc.Visible = false;
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            pnlExportarExcel.Visible = true;
            pnlPrincipal.Enabled = false;
        }

        private void btnCloseExportarExcel_Click(object sender, EventArgs e)
        {
            pnlExportarExcel.Visible = false;
            pnlPrincipal.Enabled = true;
        }

        private void btnSaveSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFileName.Text != "" && dtVenta.Rows.Count > 0)
                {
                    CreacionXLSX creacionXLSX = new CreacionXLSX(txtFileName.Text.Trim() + DateTime.Now.ToLongDateString());
                    creacionXLSX.DocumentCreation(dtVenta);
                }
                else if(txtFileName.Text == "")
                {
                    CreacionXLSX creacionXLSX = new CreacionXLSX("Venta-N" + NumeroVenta() + "-" + DateTime.Now.ToLongDateString());
                    creacionXLSX.DocumentCreation(dtVenta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtFileName.Text = "";
            pnlExportarExcel.Visible = false;
            pnlPrincipal.Enabled = true;
        }
    }
}
