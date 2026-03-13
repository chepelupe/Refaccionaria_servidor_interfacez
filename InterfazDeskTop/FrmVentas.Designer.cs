namespace InterfazDeskTop
{
    partial class FrmVentas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_fecha_hora = new System.Windows.Forms.Label();
            this.txb_busqueda = new System.Windows.Forms.TextBox();
            this.btn_pagar = new System.Windows.Forms.Button();
            this.btn_ver_precios = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_cambio = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_precio_total = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Nombre,
            this.Precio});
            this.dataGridView1.Location = new System.Drawing.Point(53, 67);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1084, 424);
            this.dataGridView1.TabIndex = 0;
            // 
            // lbl_fecha_hora
            // 
            this.lbl_fecha_hora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_fecha_hora.AutoSize = true;
            this.lbl_fecha_hora.Location = new System.Drawing.Point(974, 33);
            this.lbl_fecha_hora.Name = "lbl_fecha_hora";
            this.lbl_fecha_hora.Size = new System.Drawing.Size(99, 20);
            this.lbl_fecha_hora.TabIndex = 1;
            this.lbl_fecha_hora.Text = "__________";
            this.lbl_fecha_hora.Click += new System.EventHandler(this.lbl_fecha_hora_Click);
            // 
            // txb_busqueda
            // 
            this.txb_busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txb_busqueda.Location = new System.Drawing.Point(53, 514);
            this.txb_busqueda.Name = "txb_busqueda";
            this.txb_busqueda.Size = new System.Drawing.Size(611, 26);
            this.txb_busqueda.TabIndex = 2;
            // 
            // btn_pagar
            // 
            this.btn_pagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_pagar.Location = new System.Drawing.Point(53, 557);
            this.btn_pagar.Name = "btn_pagar";
            this.btn_pagar.Size = new System.Drawing.Size(190, 58);
            this.btn_pagar.TabIndex = 3;
            this.btn_pagar.Text = "Pagar";
            this.btn_pagar.UseVisualStyleBackColor = true;
            // 
            // btn_ver_precios
            // 
            this.btn_ver_precios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ver_precios.Location = new System.Drawing.Point(474, 557);
            this.btn_ver_precios.Name = "btn_ver_precios";
            this.btn_ver_precios.Size = new System.Drawing.Size(190, 58);
            this.btn_ver_precios.TabIndex = 4;
            this.btn_ver_precios.Text = "Ver precios";
            this.btn_ver_precios.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cambio:";
            // 
            // lbl_cambio
            // 
            this.lbl_cambio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cambio.AutoSize = true;
            this.lbl_cambio.Location = new System.Drawing.Point(104, 54);
            this.lbl_cambio.Name = "lbl_cambio";
            this.lbl_cambio.Size = new System.Drawing.Size(99, 20);
            this.lbl_cambio.TabIndex = 6;
            this.lbl_cambio.Text = "__________";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbl_precio_total);
            this.groupBox1.Controls.Add(this.lbl_cambio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(772, 499);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 93);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Precio total:";
            // 
            // lbl_precio_total
            // 
            this.lbl_precio_total.AutoSize = true;
            this.lbl_precio_total.Location = new System.Drawing.Point(104, 22);
            this.lbl_precio_total.Name = "lbl_precio_total";
            this.lbl_precio_total.Size = new System.Drawing.Size(99, 20);
            this.lbl_precio_total.TabIndex = 1;
            this.lbl_precio_total.Text = "__________";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(1052, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 100);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ver precios";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 8;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 109;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre del producto";
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 8;
            this.Precio.Name = "Precio";
            this.Precio.Width = 89;
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 627);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ver_precios);
            this.Controls.Add(this.btn_pagar);
            this.Controls.Add(this.txb_busqueda);
            this.Controls.Add(this.lbl_fecha_hora);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmVentas";
            this.Text = "Módulo de ventas";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_fecha_hora;
        private System.Windows.Forms.TextBox txb_busqueda;
        private System.Windows.Forms.Button btn_pagar;
        private System.Windows.Forms.Button btn_ver_precios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_cambio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_precio_total;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
    }
}

