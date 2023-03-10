using ComercSistemaVentas.Objetos;
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
    public partial class iProductos : Form
    {
        DataTable dt = new DataTable();

        public iProductos()
        {
            InitializeComponent();
            MostrarProductos();
            if(iVentas.codigoP != "")
            {
                txtCodigo.Text = iVentas.codigoP;
                txtCodigo.Focus();
                txtCodigo.KeyDown += txtCodigo_KeyDown;
            }
            FormatoDGV();
        }

        public void MostrarProductos()
        {
            Productos_O op= new Productos_O();
            dt = op.ListaProductos();
            dgvProductos.DataSource = dt;
        }

        public void FormatoDGV()
        {
            if(dgvProductos.Columns.Count == 5)
            {
                dgvProductos.Columns[0].Width = 145;
                dgvProductos.Columns[1].Width = 415;
                dgvProductos.Columns[2].Width = 70;
                dgvProductos.Columns[3].Width = 85;
                dgvProductos.Columns[4].Width = 80;
            }
        }

        public void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCant.Text = "";
            txtCosto.Text = "";
            txtVenta.Text = "";
            MostrarProductos();
        }

        private void iProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            iMenuPrincipal imp = new iMenuPrincipal();
            if(iMenuPrincipal.nVentanas_V == 0) imp.Visible = true;
            if (iVentas.codigoP != "") iVentas.codigoP = "";
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtCodigo.Text != "")
                {
                    Productos_O op = new Productos_O();
                    Producto p = op.B_ProductoCod(txtCodigo.Text.Trim().ToUpper());
                    if(p != null)
                    {
                        dt = op.ListaProductos(p.codigo);
                        dgvProductos.DataSource= dt;
                        txtCodigo.Enabled = false;
                        txtNombre.Text = p.nombre;
                        txtCant.Text = p.cant.ToString();
                        txtCosto.Text = p.costo.ToString();
                        txtVenta.Text = p.venta.ToString();
                    }
                    txtNombre.Focus();
                }
            }
        }

        private void btnRegistrarP_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("¿Desea registrar este producto?", "Confirmación", MessageBoxButtons.YesNo))
            {
                Productos_O p_O = new Productos_O();
                string[] datos =
                {
                    txtCodigo.Text.Trim().ToUpper(),
                    txtNombre.Text.Trim().ToUpper(),
                    txtCant.Text.Trim(),
                    txtCosto.Text.Trim(),
                    txtVenta.Text.Trim()
                };

                if(p_O.B_ProductoCod(datos[0]) != null)
                {
                    MessageBox.Show($"El producto con código: {datos[0]} ya existe, use un código diferente");
                }
                else if (datos[0] != "" && datos[1] != "" && datos[2] != "" && datos[3] != "" && datos[4] != "")
                {
                    Producto p = new Producto(datos);
                    if(p.codigo != "000000")
                    {
                        if (p_O.R_Producto(p) == true)
                        {
                            MessageBox.Show("Producto registrado exitosamente.");
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Se ha producido un error al realizar el registro.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, rellene los campos correctamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, rellene los campos correctamente.");
                }

                
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            if (!txtCodigo.Enabled) txtCodigo.Enabled = true;
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvProductos.Rows.Count > 0)
            {
                string[] datos =
                {
                    dgvProductos.CurrentRow.Cells[0].Value.ToString(),
                    dgvProductos.CurrentRow.Cells[1].Value.ToString(),
                    dgvProductos.CurrentRow.Cells[2].Value.ToString(),
                    dgvProductos.CurrentRow.Cells[3].Value.ToString(),
                    dgvProductos.CurrentRow.Cells[4].Value.ToString()
                };
                txtCodigo.Text = datos[0];
                txtCodigo.Enabled = false;
                txtNombre.Text = datos[1];
                txtCant.Text = datos[2];
                txtCosto.Text = datos[3];
                txtVenta.Text = datos[4];
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if(txtNombre.Text != "" && txtCodigo.Enabled)
            {
                Productos_O op = new Productos_O();
                dgvProductos.DataSource = dt;
                dt = op.B_ProductoNombre(txtNombre.Text.Trim().ToUpper());

            }
            else
            {
                MostrarProductos();
            }
        }

        private void btnActualizarP_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("¿Desea guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo))
            {
                if (!txtCodigo.Enabled)
                {
                    string[] datos =
                    {
                    txtCodigo.Text.Trim().ToUpper(),
                    txtNombre.Text.Trim().ToUpper(),
                    txtCant.Text.Trim(),
                    txtCosto.Text.Trim(),
                    txtVenta.Text.Trim()
                    };

                    if (datos[1] != "" && datos[2] != "" && datos[4] != "")
                    {
                        Productos_O op = new Productos_O();
                        Producto p = new Producto(datos);
                        if (op.ActualizarProducto(p))
                        {
                            MessageBox.Show("Producto actualizado exitosamente.");
                            LimpiarCampos();
                            txtCodigo.Enabled = true;
                            txtCodigo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Se ha producido un error.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un producto primero.");
                }
            }
        }

        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Enabled && DialogResult.Yes == MessageBox.Show("¿Desea eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo))
            {
                Productos_O op = new Productos_O();
                if (op.EliminarProducto(txtCodigo.Text.Trim().ToUpper()))
                {
                    MessageBox.Show("Producto eliminado exitosamente.");
                    LimpiarCampos();
                    txtCodigo.Enabled = true;
                    txtCodigo.Focus();
                }
                else
                {
                    MessageBox.Show("Se ha producido un error.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto primero.");
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult = ofd.ShowDialog();

                if (ofd.CheckFileExists && ofd.FileName != "")
                {
                    Conexion.ConexionDB con = new Conexion.ConexionDB();
                    con.CreacionDatos(ofd.FileName);
                    MessageBox.Show("Datos importados correctamente.");
                    MostrarProductos();
                }
                else return;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Importación.");
            }
        }
    }
}
