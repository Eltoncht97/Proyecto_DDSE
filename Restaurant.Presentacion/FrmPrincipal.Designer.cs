namespace Restaurant.Presentacion
{
    partial class FrmPrincipal
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuMantenimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlatos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMesas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOperaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNuevoPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReporteVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuPrincipal.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            //
            // menuPrincipal
            //
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMantenimientos,
            this.mnuOperaciones,
            this.mnuReportes,
            this.mnuSalir});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(984, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuPrincipal";
            //
            // mnuMantenimientos
            //
            this.mnuMantenimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCategorias,
            this.mnuPlatos,
            this.mnuMesas,
            this.mnuEmpleados,
            this.mnuClientes});
            this.mnuMantenimientos.Name = "mnuMantenimientos";
            this.mnuMantenimientos.Size = new System.Drawing.Size(112, 20);
            this.mnuMantenimientos.Text = "&Mantenimientos";
            //
            // mnuCategorias
            //
            this.mnuCategorias.Name = "mnuCategorias";
            this.mnuCategorias.Size = new System.Drawing.Size(180, 22);
            this.mnuCategorias.Text = "Categorías";
            this.mnuCategorias.Click += new System.EventHandler(this.mnuCategorias_Click);
            //
            // mnuPlatos
            //
            this.mnuPlatos.Name = "mnuPlatos";
            this.mnuPlatos.Size = new System.Drawing.Size(180, 22);
            this.mnuPlatos.Text = "Platos (Carta)";
            this.mnuPlatos.Click += new System.EventHandler(this.mnuPlatos_Click);
            //
            // mnuMesas
            //
            this.mnuMesas.Name = "mnuMesas";
            this.mnuMesas.Size = new System.Drawing.Size(180, 22);
            this.mnuMesas.Text = "Mesas";
            this.mnuMesas.Click += new System.EventHandler(this.mnuMesas_Click);
            //
            // mnuEmpleados
            //
            this.mnuEmpleados.Name = "mnuEmpleados";
            this.mnuEmpleados.Size = new System.Drawing.Size(180, 22);
            this.mnuEmpleados.Text = "Empleados";
            this.mnuEmpleados.Click += new System.EventHandler(this.mnuEmpleados_Click);
            //
            // mnuClientes
            //
            this.mnuClientes.Name = "mnuClientes";
            this.mnuClientes.Size = new System.Drawing.Size(180, 22);
            this.mnuClientes.Text = "Clientes";
            this.mnuClientes.Click += new System.EventHandler(this.mnuClientes_Click);
            //
            // mnuOperaciones
            //
            this.mnuOperaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNuevoPedido,
            this.mnuFacturacion});
            this.mnuOperaciones.Name = "mnuOperaciones";
            this.mnuOperaciones.Size = new System.Drawing.Size(86, 20);
            this.mnuOperaciones.Text = "&Operaciones";
            //
            // mnuNuevoPedido
            //
            this.mnuNuevoPedido.Name = "mnuNuevoPedido";
            this.mnuNuevoPedido.Size = new System.Drawing.Size(180, 22);
            this.mnuNuevoPedido.Text = "Registrar Pedido";
            this.mnuNuevoPedido.Click += new System.EventHandler(this.mnuNuevoPedido_Click);
            //
            // mnuFacturacion
            //
            this.mnuFacturacion.Name = "mnuFacturacion";
            this.mnuFacturacion.Size = new System.Drawing.Size(180, 22);
            this.mnuFacturacion.Text = "Facturación";
            this.mnuFacturacion.Click += new System.EventHandler(this.mnuFacturacion_Click);
            //
            // mnuReportes
            //
            this.mnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReporteVentas});
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(66, 20);
            this.mnuReportes.Text = "&Reportes";
            //
            // mnuReporteVentas
            //
            this.mnuReporteVentas.Name = "mnuReporteVentas";
            this.mnuReporteVentas.Size = new System.Drawing.Size(180, 22);
            this.mnuReporteVentas.Text = "Reporte de Ventas";
            this.mnuReporteVentas.Click += new System.EventHandler(this.mnuReporteVentas_Click);
            //
            // mnuSalir
            //
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(46, 20);
            this.mnuSalir.Text = "&Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            //
            // statusBar
            //
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblFecha});
            this.statusBar.Location = new System.Drawing.Point(0, 639);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(984, 22);
            this.statusBar.TabIndex = 1;
            //
            // lblUsuario
            //
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(800, 17);
            this.lblUsuario.Spring = true;
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsuario.Text = "Usuario:";
            //
            // lblFecha
            //
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 17);
            this.lblFecha.Text = "Fecha";
            //
            // FrmPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión de Restaurante";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenimientos;
        private System.Windows.Forms.ToolStripMenuItem mnuCategorias;
        private System.Windows.Forms.ToolStripMenuItem mnuPlatos;
        private System.Windows.Forms.ToolStripMenuItem mnuMesas;
        private System.Windows.Forms.ToolStripMenuItem mnuEmpleados;
        private System.Windows.Forms.ToolStripMenuItem mnuClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuOperaciones;
        private System.Windows.Forms.ToolStripMenuItem mnuNuevoPedido;
        private System.Windows.Forms.ToolStripMenuItem mnuFacturacion;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem mnuReporteVentas;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblFecha;
    }
}
