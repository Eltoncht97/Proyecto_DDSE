namespace Restaurant.Presentacion
{
    partial class FrmPlato
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
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.chkDisponible = new System.Windows.Forms.CheckBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblTitulo.Location = new System.Drawing.Point(16, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(225, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mantenimiento de Platos";
            //
            // lblCategoria
            //
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(20, 55);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(64, 15);
            this.lblCategoria.TabIndex = 1;
            this.lblCategoria.Text = "Categoría:";
            //
            // cboCategoria
            //
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Location = new System.Drawing.Point(120, 52);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(280, 23);
            this.cboCategoria.TabIndex = 2;
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 88);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 15);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            this.txtNombre.Location = new System.Drawing.Point(120, 85);
            this.txtNombre.MaxLength = 80;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(280, 23);
            this.txtNombre.TabIndex = 4;
            //
            // lblDescripcion
            //
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 121);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(74, 15);
            this.lblDescripcion.TabIndex = 5;
            this.lblDescripcion.Text = "Descripción:";
            //
            // txtDescripcion
            //
            this.txtDescripcion.Location = new System.Drawing.Point(120, 118);
            this.txtDescripcion.MaxLength = 200;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(450, 23);
            this.txtDescripcion.TabIndex = 6;
            //
            // lblPrecio
            //
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(20, 154);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(45, 15);
            this.lblPrecio.TabIndex = 7;
            this.lblPrecio.Text = "Precio:";
            //
            // nudPrecio
            //
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Location = new System.Drawing.Point(120, 152);
            this.nudPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(120, 23);
            this.nudPrecio.TabIndex = 8;
            //
            // chkDisponible
            //
            this.chkDisponible.AutoSize = true;
            this.chkDisponible.Checked = true;
            this.chkDisponible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisponible.Location = new System.Drawing.Point(270, 154);
            this.chkDisponible.Name = "chkDisponible";
            this.chkDisponible.Size = new System.Drawing.Size(85, 19);
            this.chkDisponible.TabIndex = 9;
            this.chkDisponible.Text = "Disponible";
            this.chkDisponible.UseVisualStyleBackColor = true;
            //
            // chkEstado
            //
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(380, 154);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(60, 19);
            this.chkEstado.TabIndex = 10;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            //
            // btnNuevo
            //
            this.btnNuevo.Location = new System.Drawing.Point(120, 190);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 32);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(226, 190);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 32);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnEliminar
            //
            this.btnEliminar.Location = new System.Drawing.Point(332, 190);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 32);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(438, 190);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 32);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // dgvLista
            //
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(16, 235);
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(760, 250);
            this.dgvLista.TabIndex = 15;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            //
            // FrmPlato
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.chkDisponible);
            this.Controls.Add(this.nudPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmPlato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Platos";
            this.Load += new System.EventHandler(this.FrmPlato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.CheckBox chkDisponible;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvLista;
    }
}
