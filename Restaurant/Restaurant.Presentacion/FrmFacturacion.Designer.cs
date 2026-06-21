namespace Restaurant.Presentacion
{
    partial class FrmFacturacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPedidos = new System.Windows.Forms.Label();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblTotalTexto = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblTitulo.Location = new System.Drawing.Point(16, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(269, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Facturación de Pedidos";
            //
            // lblPedidos
            //
            this.lblPedidos.AutoSize = true;
            this.lblPedidos.Location = new System.Drawing.Point(16, 48);
            this.lblPedidos.Name = "lblPedidos";
            this.lblPedidos.Size = new System.Drawing.Size(140, 15);
            this.lblPedidos.TabIndex = 1;
            this.lblPedidos.Text = "Pedidos pendientes de pago:";
            //
            // dgvPedidos
            //
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(16, 68);
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(760, 190);
            this.dgvPedidos.TabIndex = 2;
            this.dgvPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellClick);
            //
            // lblDetalle
            //
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(16, 268);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(101, 15);
            this.lblDetalle.TabIndex = 3;
            this.lblDetalle.Text = "Detalle del pedido:";
            //
            // dgvDetalle
            //
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(16, 288);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(500, 170);
            this.dgvDetalle.TabIndex = 4;
            //
            // lblTipo
            //
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(540, 295);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(110, 15);
            this.lblTipo.TabIndex = 5;
            this.lblTipo.Text = "Tipo de comprobante:";
            //
            // cboTipo
            //
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Location = new System.Drawing.Point(540, 315);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(180, 23);
            this.cboTipo.TabIndex = 6;
            //
            // lblTotalTexto
            //
            this.lblTotalTexto.AutoSize = true;
            this.lblTotalTexto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalTexto.Location = new System.Drawing.Point(540, 360);
            this.lblTotalTexto.Name = "lblTotalTexto";
            this.lblTotalTexto.Size = new System.Drawing.Size(78, 21);
            this.lblTotalTexto.TabIndex = 7;
            this.lblTotalTexto.Text = "Total S/:";
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblTotal.Location = new System.Drawing.Point(625, 360);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(40, 21);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "0.00";
            //
            // btnFacturar
            //
            this.btnFacturar.BackColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturar.ForeColor = System.Drawing.Color.White;
            this.btnFacturar.Location = new System.Drawing.Point(540, 400);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(180, 38);
            this.btnFacturar.TabIndex = 9;
            this.btnFacturar.Text = "Generar Comprobante";
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            //
            // btnRefrescar
            //
            this.btnRefrescar.Location = new System.Drawing.Point(636, 64);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(140, 28);
            this.btnRefrescar.TabIndex = 10;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            //
            // FrmFacturacion
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 480);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalTexto);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.lblPedidos);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación";
            this.Load += new System.EventHandler(this.FrmFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPedidos;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnRefrescar;
    }
}
