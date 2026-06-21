namespace Restaurant.Presentacion
{
    partial class FrmLogin
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.lblTitulo.Location = new System.Drawing.Point(40, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(290, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Restaurante - Inicio de Sesión";
            //
            // lblUsuario
            //
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(45, 80);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 15);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";
            //
            // txtUsuario
            //
            this.txtUsuario.Location = new System.Drawing.Point(48, 98);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(280, 23);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Text = "admin";
            //
            // lblClave
            //
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(45, 135);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(70, 15);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Contraseña:";
            //
            // txtClave
            //
            this.txtClave.Location = new System.Drawing.Point(48, 153);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(280, 23);
            this.txtClave.TabIndex = 4;
            //
            // btnIngresar
            //
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(48, 200);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(130, 35);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(198, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 35);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // FrmLogin
            //
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(600, 270);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
