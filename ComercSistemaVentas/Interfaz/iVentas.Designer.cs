namespace ComercSistemaVentas.Interfaz
{
    partial class iVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iVentas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlDescuento = new System.Windows.Forms.Panel();
            this.lblMensajeDesc = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.chbxDescuento = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblnVenta = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditarP = new System.Windows.Forms.Button();
            this.btnNuevaV = new System.Windows.Forms.Button();
            this.btnEgresos = new System.Windows.Forms.Button();
            this.cbxTipoPago = new System.Windows.Forms.ComboBox();
            this.pnlCambio = new System.Windows.Forms.Panel();
            this.lblCambio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonto_C = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlCant = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.dgvListaVenta = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.pnlEgresos = new System.Windows.Forms.Panel();
            this.btnCerrar_E = new System.Windows.Forms.PictureBox();
            this.txtEgresar = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMotivo_E = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMonto_E = new System.Windows.Forms.TextBox();
            this.pnlPrincipal.SuspendLayout();
            this.pnlDescuento.SuspendLayout();
            this.pnlCambio.SuspendLayout();
            this.pnlCant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVenta)).BeginInit();
            this.pnlEgresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar_E)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEgresar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.pnlDescuento);
            this.pnlPrincipal.Controls.Add(this.chbxDescuento);
            this.pnlPrincipal.Controls.Add(this.label9);
            this.pnlPrincipal.Controls.Add(this.lblnVenta);
            this.pnlPrincipal.Controls.Add(this.label8);
            this.pnlPrincipal.Controls.Add(this.btnEditarP);
            this.pnlPrincipal.Controls.Add(this.btnNuevaV);
            this.pnlPrincipal.Controls.Add(this.btnEgresos);
            this.pnlPrincipal.Controls.Add(this.cbxTipoPago);
            this.pnlPrincipal.Controls.Add(this.pnlCambio);
            this.pnlPrincipal.Controls.Add(this.btnEliminar);
            this.pnlPrincipal.Controls.Add(this.btnLimpiar);
            this.pnlPrincipal.Controls.Add(this.btnPagar);
            this.pnlPrincipal.Controls.Add(this.lblTotal);
            this.pnlPrincipal.Controls.Add(this.pnlCant);
            this.pnlPrincipal.Controls.Add(this.dgvListaVenta);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.txtNombre);
            this.pnlPrincipal.Controls.Add(this.label1);
            this.pnlPrincipal.Controls.Add(this.txtCodigo);
            this.pnlPrincipal.Location = new System.Drawing.Point(4, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(874, 587);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // pnlDescuento
            // 
            this.pnlDescuento.Controls.Add(this.lblMensajeDesc);
            this.pnlDescuento.Controls.Add(this.txtDescuento);
            this.pnlDescuento.Location = new System.Drawing.Point(714, 467);
            this.pnlDescuento.Name = "pnlDescuento";
            this.pnlDescuento.Size = new System.Drawing.Size(153, 63);
            this.pnlDescuento.TabIndex = 19;
            // 
            // lblMensajeDesc
            // 
            this.lblMensajeDesc.AutoSize = true;
            this.lblMensajeDesc.Location = new System.Drawing.Point(0, 38);
            this.lblMensajeDesc.Name = "lblMensajeDesc";
            this.lblMensajeDesc.Size = new System.Drawing.Size(152, 13);
            this.lblMensajeDesc.TabIndex = 6;
            this.lblMensajeDesc.Text = "Presione ENTER para ingresar";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(7, 5);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(140, 30);
            this.txtDescuento.TabIndex = 5;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuento_KeyDown);
            // 
            // chbxDescuento
            // 
            this.chbxDescuento.AutoSize = true;
            this.chbxDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxDescuento.Location = new System.Drawing.Point(714, 440);
            this.chbxDescuento.Name = "chbxDescuento";
            this.chbxDescuento.Size = new System.Drawing.Size(110, 24);
            this.chbxDescuento.TabIndex = 18;
            this.chbxDescuento.Text = "Descuento:";
            this.chbxDescuento.UseVisualStyleBackColor = true;
            this.chbxDescuento.CheckStateChanged += new System.EventHandler(this.chbxDescuento_CheckStateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(716, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Tipo de pago:";
            // 
            // lblnVenta
            // 
            this.lblnVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnVenta.Location = new System.Drawing.Point(515, 23);
            this.lblnVenta.Name = "lblnVenta";
            this.lblnVenta.Size = new System.Drawing.Size(200, 20);
            this.lblnVenta.TabIndex = 16;
            this.lblnVenta.Text = "0";
            this.lblnVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(632, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "N° Venta:";
            // 
            // btnEditarP
            // 
            this.btnEditarP.BackColor = System.Drawing.Color.HotPink;
            this.btnEditarP.FlatAppearance.BorderColor = System.Drawing.Color.LightPink;
            this.btnEditarP.FlatAppearance.BorderSize = 2;
            this.btnEditarP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarP.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarP.Image")));
            this.btnEditarP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarP.Location = new System.Drawing.Point(719, 114);
            this.btnEditarP.Name = "btnEditarP";
            this.btnEditarP.Size = new System.Drawing.Size(152, 48);
            this.btnEditarP.TabIndex = 14;
            this.btnEditarP.Text = "EDITAR P.";
            this.btnEditarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarP.UseVisualStyleBackColor = false;
            this.btnEditarP.Click += new System.EventHandler(this.btnEditarP_Click);
            // 
            // btnNuevaV
            // 
            this.btnNuevaV.BackColor = System.Drawing.Color.PeachPuff;
            this.btnNuevaV.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnNuevaV.FlatAppearance.BorderSize = 2;
            this.btnNuevaV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaV.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaV.Image")));
            this.btnNuevaV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaV.Location = new System.Drawing.Point(719, 60);
            this.btnNuevaV.Name = "btnNuevaV";
            this.btnNuevaV.Size = new System.Drawing.Size(152, 48);
            this.btnNuevaV.TabIndex = 13;
            this.btnNuevaV.Text = "N. VENTA";
            this.btnNuevaV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaV.UseVisualStyleBackColor = false;
            this.btnNuevaV.Click += new System.EventHandler(this.btnNuevaV_Click);
            // 
            // btnEgresos
            // 
            this.btnEgresos.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEgresos.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btnEgresos.FlatAppearance.BorderSize = 2;
            this.btnEgresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEgresos.Image = ((System.Drawing.Image)(resources.GetObject("btnEgresos.Image")));
            this.btnEgresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEgresos.Location = new System.Drawing.Point(719, 168);
            this.btnEgresos.Name = "btnEgresos";
            this.btnEgresos.Size = new System.Drawing.Size(152, 48);
            this.btnEgresos.TabIndex = 12;
            this.btnEgresos.Text = "EGRESOS";
            this.btnEgresos.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnEgresos.UseVisualStyleBackColor = false;
            this.btnEgresos.Click += new System.EventHandler(this.btnEgresos_Click);
            // 
            // cbxTipoPago
            // 
            this.cbxTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipoPago.FormattingEnabled = true;
            this.cbxTipoPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "TARJETA",
            "OTRO"});
            this.cbxTipoPago.Location = new System.Drawing.Point(719, 295);
            this.cbxTipoPago.Name = "cbxTipoPago";
            this.cbxTipoPago.Size = new System.Drawing.Size(145, 24);
            this.cbxTipoPago.TabIndex = 11;
            this.cbxTipoPago.SelectedIndexChanged += new System.EventHandler(this.cbxTipoPago_SelectedIndexChanged);
            // 
            // pnlCambio
            // 
            this.pnlCambio.Controls.Add(this.lblCambio);
            this.pnlCambio.Controls.Add(this.label5);
            this.pnlCambio.Controls.Add(this.label4);
            this.pnlCambio.Controls.Add(this.txtMonto_C);
            this.pnlCambio.Location = new System.Drawing.Point(714, 325);
            this.pnlCambio.Name = "pnlCambio";
            this.pnlCambio.Size = new System.Drawing.Size(153, 109);
            this.pnlCambio.TabIndex = 10;
            // 
            // lblCambio
            // 
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.ForeColor = System.Drawing.Color.Green;
            this.lblCambio.Location = new System.Drawing.Point(8, 72);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(140, 34);
            this.lblCambio.TabIndex = 7;
            this.lblCambio.Text = "$12.345";
            this.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Monto pagado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cambio:";
            // 
            // txtMonto_C
            // 
            this.txtMonto_C.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto_C.Location = new System.Drawing.Point(8, 22);
            this.txtMonto_C.Name = "txtMonto_C";
            this.txtMonto_C.Size = new System.Drawing.Size(140, 30);
            this.txtMonto_C.TabIndex = 4;
            this.txtMonto_C.TextChanged += new System.EventHandler(this.txtMonto_C_TextChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(719, 222);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(152, 48);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Aquamarine;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.btnLimpiar.FlatAppearance.BorderSize = 2;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(719, 6);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(152, 48);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPagar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPagar.FlatAppearance.BorderSize = 2;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Image = ((System.Drawing.Image)(resources.GetObject("btnPagar.Image")));
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(725, 536);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(146, 48);
            this.btnPagar.TabIndex = 7;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(346, 536);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(373, 50);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "$1.234.567.890";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlCant
            // 
            this.pnlCant.Controls.Add(this.label3);
            this.pnlCant.Controls.Add(this.txtCant);
            this.pnlCant.Location = new System.Drawing.Point(625, 55);
            this.pnlCant.Name = "pnlCant";
            this.pnlCant.Size = new System.Drawing.Size(90, 58);
            this.pnlCant.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad:";
            // 
            // txtCant
            // 
            this.txtCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCant.Location = new System.Drawing.Point(11, 22);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(79, 35);
            this.txtCant.TabIndex = 3;
            this.txtCant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCant_KeyDown);
            // 
            // dgvListaVenta
            // 
            this.dgvListaVenta.AllowUserToAddRows = false;
            this.dgvListaVenta.AllowUserToDeleteRows = false;
            this.dgvListaVenta.AllowUserToResizeRows = false;
            this.dgvListaVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaVenta.BackgroundColor = System.Drawing.Color.LightYellow;
            this.dgvListaVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaVenta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaVenta.Location = new System.Drawing.Point(7, 116);
            this.dgvListaVenta.Name = "dgvListaVenta";
            this.dgvListaVenta.RowHeadersVisible = false;
            this.dgvListaVenta.RowHeadersWidth = 62;
            this.dgvListaVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaVenta.Size = new System.Drawing.Size(701, 417);
            this.dgvListaVenta.TabIndex = 4;
            this.dgvListaVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaVenta_CellContentDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre del Producto:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(7, 78);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(612, 35);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código del Producto:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(7, 23);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(188, 29);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // pnlEgresos
            // 
            this.pnlEgresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEgresos.Controls.Add(this.btnCerrar_E);
            this.pnlEgresos.Controls.Add(this.txtEgresar);
            this.pnlEgresos.Controls.Add(this.label7);
            this.pnlEgresos.Controls.Add(this.txtMotivo_E);
            this.pnlEgresos.Controls.Add(this.label6);
            this.pnlEgresos.Controls.Add(this.txtMonto_E);
            this.pnlEgresos.Location = new System.Drawing.Point(412, 168);
            this.pnlEgresos.Name = "pnlEgresos";
            this.pnlEgresos.Size = new System.Drawing.Size(262, 116);
            this.pnlEgresos.TabIndex = 1;
            // 
            // btnCerrar_E
            // 
            this.btnCerrar_E.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar_E.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar_E.Image")));
            this.btnCerrar_E.Location = new System.Drawing.Point(239, 0);
            this.btnCerrar_E.Name = "btnCerrar_E";
            this.btnCerrar_E.Size = new System.Drawing.Size(23, 20);
            this.btnCerrar_E.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar_E.TabIndex = 7;
            this.btnCerrar_E.TabStop = false;
            this.btnCerrar_E.Click += new System.EventHandler(this.btnCerrar_E_Click);
            // 
            // txtEgresar
            // 
            this.txtEgresar.BackColor = System.Drawing.Color.Transparent;
            this.txtEgresar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEgresar.Image = ((System.Drawing.Image)(resources.GetObject("txtEgresar.Image")));
            this.txtEgresar.Location = new System.Drawing.Point(201, 23);
            this.txtEgresar.Name = "txtEgresar";
            this.txtEgresar.Size = new System.Drawing.Size(51, 49);
            this.txtEgresar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.txtEgresar.TabIndex = 6;
            this.txtEgresar.TabStop = false;
            this.txtEgresar.Click += new System.EventHandler(this.txtEgresar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Motivo:";
            // 
            // txtMotivo_E
            // 
            this.txtMotivo_E.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo_E.Location = new System.Drawing.Point(7, 78);
            this.txtMotivo_E.Name = "txtMotivo_E";
            this.txtMotivo_E.Size = new System.Drawing.Size(245, 29);
            this.txtMotivo_E.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Monto:";
            // 
            // txtMonto_E
            // 
            this.txtMonto_E.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto_E.Location = new System.Drawing.Point(7, 23);
            this.txtMonto_E.Name = "txtMonto_E";
            this.txtMonto_E.Size = new System.Drawing.Size(188, 29);
            this.txtMonto_E.TabIndex = 2;
            // 
            // iVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(879, 594);
            this.Controls.Add(this.pnlEgresos);
            this.Controls.Add(this.pnlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "iVentas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comerc - Ventas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.iVentas_FormClosed);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.pnlDescuento.ResumeLayout(false);
            this.pnlDescuento.PerformLayout();
            this.pnlCambio.ResumeLayout(false);
            this.pnlCambio.PerformLayout();
            this.pnlCant.ResumeLayout(false);
            this.pnlCant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaVenta)).EndInit();
            this.pnlEgresos.ResumeLayout(false);
            this.pnlEgresos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar_E)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEgresar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListaVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Panel pnlCant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cbxTipoPago;
        private System.Windows.Forms.Panel pnlCambio;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonto_C;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnEditarP;
        private System.Windows.Forms.Button btnNuevaV;
        private System.Windows.Forms.Button btnEgresos;
        private System.Windows.Forms.Panel pnlEgresos;
        private System.Windows.Forms.PictureBox txtEgresar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMotivo_E;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMonto_E;
        private System.Windows.Forms.PictureBox btnCerrar_E;
        private System.Windows.Forms.Label lblnVenta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.CheckBox chbxDescuento;
        private System.Windows.Forms.Label lblMensajeDesc;
    }
}