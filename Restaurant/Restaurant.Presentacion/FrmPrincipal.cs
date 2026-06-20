using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Restaurant.Presentacion.Estilos;

namespace Restaurant.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private Image _imagenFondo;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            TemaModerno.EstilizarFormulario(this);

            if (Program.UsuarioActual != null)
            {
                lblUsuario.Text = "Usuario: " + Program.UsuarioActual.NombreCompleto +
                                  "   |   Rol: " + Program.UsuarioActual.Rol;
            }
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            AplicarFondo();
        }

        private void AplicarFondo()
        {
            _imagenFondo = CargarImagenRecurso("fondo_app.png");
            if (_imagenFondo == null) return;

            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    MdiClient area = (MdiClient)ctl;

                    // Activa el doble búfer (propiedad protegida) para evitar parpadeo.
                    typeof(Control)
                        .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                        .SetValue(area, true, null);

                    area.Paint += AreaMdi_Paint;     // dibujamos el fondo a mano
                    area.Resize += AreaMdi_Resize;   // redibujar al cambiar el tamaño
                    area.Invalidate();
                    break;
                }
            }
        }

        private void AreaMdi_Paint(object sender, PaintEventArgs e)
        {
            if (_imagenFondo == null) return;
            Control area = (Control)sender;
            e.Graphics.DrawImage(_imagenFondo, area.ClientRectangle);
        }

        private void AreaMdi_Resize(object sender, EventArgs e)
        {
            ((Control)sender).Invalidate();
        }

        private Image CargarImagenRecurso(string nombreArchivo)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string recurso = null;
            foreach (string nombre in asm.GetManifestResourceNames())
            {
                if (nombre.EndsWith(nombreArchivo, StringComparison.OrdinalIgnoreCase))
                {
                    recurso = nombre;
                    break;
                }
            }
            if (recurso == null) return null;

            using (System.IO.Stream s = asm.GetManifestResourceStream(recurso))
            {
                if (s == null) return null;
                using (Image original = Image.FromStream(s))
                {
                    return new Bitmap(original);  // copia independiente; el stream se cierra seguro
                }
            }
        }

        private void AbrirHijo(Form hijo)
        {
            foreach (Form abierto in this.MdiChildren)
            {
                if (abierto.GetType() == hijo.GetType())
                {
                    abierto.Activate();
                    hijo.Dispose();
                    return;
                }
            }
            hijo.MdiParent = this;
            hijo.Show();
        }

        private void mnuCategorias_Click(object sender, EventArgs e) { AbrirHijo(new FrmCategoria()); }
        private void mnuPlatos_Click(object sender, EventArgs e) { AbrirHijo(new FrmPlato()); }
        private void mnuMesas_Click(object sender, EventArgs e) { AbrirHijo(new FrmMesa()); }
        private void mnuEmpleados_Click(object sender, EventArgs e) { AbrirHijo(new FrmEmpleado()); }
        private void mnuClientes_Click(object sender, EventArgs e) { AbrirHijo(new FrmCliente()); }
        private void mnuNuevoPedido_Click(object sender, EventArgs e) { AbrirHijo(new FrmPedido()); }
        private void mnuFacturacion_Click(object sender, EventArgs e) { AbrirHijo(new FrmFacturacion()); }
        private void mnuReporteVentas_Click(object sender, EventArgs e) { AbrirHijo(new FrmReporteVentas()); }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
