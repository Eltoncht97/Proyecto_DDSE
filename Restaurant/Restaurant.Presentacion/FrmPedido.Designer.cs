namespace Restaurant.Presentacion
{
    partial class FrmPedido
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
            this.lblMesa = new System.Windows.Forms.Label();
            this.cboMesa = new System.Windows.Forms.ComboBox();
            this.lblMozo = new System.Windows.Forms.Label();
            this.cboMozo = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.lblPlato = new System.Windows.Forms.Label();
            this.cboPlato = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblTotalTexto = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cboBuscarPedido = new System.Windows.Forms.ComboBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.gbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Pedido";
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Location = new System.Drawing.Point(13, 90);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(36, 13);
            this.lblMesa.TabIndex = 1;
            this.lblMesa.Text = "Mesa:";
            // 
            // cboMesa
            // 
            this.cboMesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesa.Location = new System.Drawing.Point(59, 87);
            this.cboMesa.Name = "cboMesa";
            this.cboMesa.Size = new System.Drawing.Size(78, 21);
            this.cboMesa.TabIndex = 2;
            // 
            // lblMozo
            // 
            this.lblMozo.AutoSize = true;
            this.lblMozo.Location = new System.Drawing.Point(153, 90);
            this.lblMozo.Name = "lblMozo";
            this.lblMozo.Size = new System.Drawing.Size(36, 13);
            this.lblMozo.TabIndex = 3;
            this.lblMozo.Text = "Mozo:";
            // 
            // cboMozo
            // 
            this.cboMozo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMozo.Location = new System.Drawing.Point(192, 87);
            this.cboMozo.Name = "cboMozo";
            this.cboMozo.Size = new System.Drawing.Size(189, 21);
            this.cboMozo.TabIndex = 4;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(398, 90);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 5;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.Location = new System.Drawing.Point(445, 87);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(189, 21);
            this.cboCliente.TabIndex = 6;
            // 
            // gbDetalle
            // 
            this.gbDetalle.Controls.Add(this.lblPlato);
            this.gbDetalle.Controls.Add(this.cboPlato);
            this.gbDetalle.Controls.Add(this.lblCantidad);
            this.gbDetalle.Controls.Add(this.nudCantidad);
            this.gbDetalle.Controls.Add(this.btnAgregar);
            this.gbDetalle.Location = new System.Drawing.Point(13, 120);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(621, 61);
            this.gbDetalle.TabIndex = 7;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Agregar plato al pedido";
            // 
            // lblPlato
            // 
            this.lblPlato.AutoSize = true;
            this.lblPlato.Location = new System.Drawing.Point(13, 31);
            this.lblPlato.Name = "lblPlato";
            this.lblPlato.Size = new System.Drawing.Size(34, 13);
            this.lblPlato.TabIndex = 0;
            this.lblPlato.Text = "Plato:";
            // 
            // cboPlato
            // 
            this.cboPlato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlato.Location = new System.Drawing.Point(51, 28);
            this.cboPlato.Name = "cboPlato";
            this.cboPlato.Size = new System.Drawing.Size(258, 21);
            this.cboPlato.TabIndex = 1;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(326, 31);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(384, 29);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(69, 20);
            this.nudCantidad.TabIndex = 3;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(480, 27);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 26);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar al pedido";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(13, 189);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(621, 199);
            this.dgvDetalle.TabIndex = 8;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(13, 397);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(120, 28);
            this.btnQuitar.TabIndex = 9;
            this.btnQuitar.Text = "Quitar línea";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lblTotalTexto
            // 
            this.lblTotalTexto.AutoSize = true;
            this.lblTotalTexto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalTexto.Location = new System.Drawing.Point(428, 399);
            this.lblTotalTexto.Name = "lblTotalTexto";
            this.lblTotalTexto.Size = new System.Drawing.Size(72, 21);
            this.lblTotalTexto.TabIndex = 10;
            this.lblTotalTexto.Text = "Total S/:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblTotal.Location = new System.Drawing.Point(513, 399);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 21);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "0.00";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(419, 432);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(120, 31);
            this.btnRegistrar.TabIndex = 12;
            this.btnRegistrar.Text = "Registrar Pedido";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(548, 432);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(86, 31);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(11, 55);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(48, 13);
            this.lblBuscar.TabIndex = 14;
            this.lblBuscar.Text = "Pedidos:";
            // 
            // cboBuscarPedido
            // 
            this.cboBuscarPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarPedido.Location = new System.Drawing.Point(69, 50);
            this.cboBuscarPedido.Name = "cboBuscarPedido";
            this.cboBuscarPedido.Size = new System.Drawing.Size(253, 21);
            this.cboBuscarPedido.TabIndex = 15;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(342, 50);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(70, 23);
            this.btnCargar.TabIndex = 16;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // FrmPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 473);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalTexto);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.gbDetalle);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboMozo);
            this.Controls.Add(this.lblMozo);
            this.Controls.Add(this.cboMesa);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.cboBuscarPedido);
            this.Controls.Add(this.btnCargar);
            this.Name = "FrmPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Pedido";
            this.Load += new System.EventHandler(this.FrmPedido_Load);
            this.gbDetalle.ResumeLayout(false);
            this.gbDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.ComboBox cboMesa;
        private System.Windows.Forms.Label lblMozo;
        private System.Windows.Forms.ComboBox cboMozo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.Label lblPlato;
        private System.Windows.Forms.ComboBox cboPlato;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox cboBuscarPedido;
        private System.Windows.Forms.Button btnCargar;
    }
}
