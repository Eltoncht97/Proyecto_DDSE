using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Restaurant.Presentacion.Estilos
{
    public static class TemaModerno
    {
        public static class Colores
        {
            // ---- Escala de grises (sin tintes de color) ----
            public static Color Primario = Color.FromArgb(70, 70, 70);            // Gris oscuro: títulos, encabezados, acento
            public static Color Texto = Color.FromArgb(40, 40, 40);              // Casi negro: texto principal
            public static Color TextoSecundario = Color.FromArgb(130, 130, 130);  // Gris medio: texto secundario
            public static Color Fondo = Color.FromArgb(245, 245, 245);            // Gris muy claro: filas alternas / hover
            public static Color FondoFormulario = Color.FromArgb(250, 250, 250);  // Blanco roto: fondo de ventana
            public static Color Borde = Color.FromArgb(215, 215, 215);            // Gris sutil: bordes
            public static Color Blanco = Color.White;

            // Botones (diferenciados solo por intensidad de gris, nunca por color)
            public static Color Exito = Color.FromArgb(70, 70, 70);               // Acción primaria (Guardar/Ingresar/…)
            public static Color ExitoHover = Color.FromArgb(50, 50, 50);
            public static Color Alerta = Color.FromArgb(140, 140, 140);           // Acción destructiva (Eliminar)
            public static Color AlertaHover = Color.FromArgb(115, 115, 115);

            // Grilla
            public static Color SeleccionGrilla = Color.FromArgb(210, 210, 210);
            public static Color EncabezadoGrilla = Color.FromArgb(70, 70, 70);
        }

        public static void EstilizarFormulario(Form form)
        {
            form.BackColor = Colores.FondoFormulario;
            form.Font = new Font("Segoe UI", 9);
        }

        // ---- Botones: planos, minimalistas ----
        public static void EstilizarBotonSuccess(Button btn)
        {
            btn.BackColor = Colores.Exito;
            btn.ForeColor = Colores.Blanco;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Colores.ExitoHover;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Height = 36;
            btn.Cursor = Cursors.Hand;
        }

        public static void EstilizarBotonDanger(Button btn)
        {
            btn.BackColor = Colores.Alerta;
            btn.ForeColor = Colores.Blanco;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Colores.AlertaHover;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Height = 36;
            btn.Cursor = Cursors.Hand;
        }

        public static void EstilizarBotonSecundario(Button btn)
        {
            btn.BackColor = Colores.Blanco;
            btn.ForeColor = Colores.Texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Colores.Borde;
            btn.FlatAppearance.MouseOverBackColor = Colores.Fondo;
            btn.Font = new Font("Segoe UI", 9);
            btn.Height = 36;
            btn.Cursor = Cursors.Hand;
        }

        public static void EstilizarBotonPrimario(Button btn)
        {
            btn.BackColor = Colores.Primario;
            btn.ForeColor = Colores.Blanco;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Colores.ExitoHover;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Height = 36;
            btn.Cursor = Cursors.Hand;
        }

        public static void EstilizarTextBox(TextBox txt)
        {
            txt.BackColor = Colores.Blanco;
            txt.ForeColor = Colores.Texto;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 9);
        }

        public static void EstilizarComboBox(ComboBox cbo)
        {
            cbo.BackColor = Colores.Blanco;
            cbo.ForeColor = Colores.Texto;
            cbo.Font = new Font("Segoe UI", 9);
            cbo.FlatStyle = FlatStyle.Flat;
        }

        public static void EstilizarCheckBox(CheckBox chk)
        {
            chk.ForeColor = Colores.Texto;
            chk.Font = new Font("Segoe UI", 9);
            // FlatStyle.Flat evita el acento azul del sistema (Windows 11) en el check.
            chk.FlatStyle = FlatStyle.Flat;
            chk.FlatAppearance.CheckedBackColor = Colores.Fondo;
            chk.FlatAppearance.BorderColor = Colores.Borde;
            chk.UseVisualStyleBackColor = false;
        }

        public static void EstilizarDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Colores.Blanco;
            dgv.GridColor = Colores.Borde;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Encabezados: gris oscuro, texto blanco (sin azul)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Colores.EncabezadoGrilla;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Colores.Blanco;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Colores.EncabezadoGrilla;
            dgv.ColumnHeadersHeight = 34;

            // Celdas: blanco con texto gris oscuro
            dgv.DefaultCellStyle.BackColor = Colores.Blanco;
            dgv.DefaultCellStyle.ForeColor = Colores.Texto;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.SelectionBackColor = Colores.SeleccionGrilla;
            dgv.DefaultCellStyle.SelectionForeColor = Colores.Texto;
            dgv.DefaultCellStyle.Padding = new Padding(4, 0, 0, 0);

            // Filas alternas: gris muy claro
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Colores.Fondo;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Colores.Texto;

            dgv.RowHeadersDefaultCellStyle.BackColor = Colores.Fondo;
            dgv.RowHeadersVisible = false;

            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 28;
            dgv.AllowUserToResizeRows = false;

            // Dibuja las columnas booleanas (checkbox) en gris, sin el acento azul del sistema.
            dgv.CellPainting -= PintarCheckGris;
            dgv.CellPainting += PintarCheckGris;
        }

        // Pinta a mano las celdas de tipo checkbox en escala de grises:
        // marcado = caja gris oscuro con check blanco; sin marcar = caja blanca con borde gris.
        private static void PintarCheckGris(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)) return;

            bool seleccion = (e.State & DataGridViewElementStates.Selected) != 0;
            e.PaintBackground(e.CellBounds, seleccion);

            bool marcado;
            try { marcado = e.Value != null && e.Value != DBNull.Value && Convert.ToBoolean(e.Value); }
            catch { marcado = false; }

            int lado = 16;
            int x = e.CellBounds.X + (e.CellBounds.Width - lado) / 2;
            int y = e.CellBounds.Y + (e.CellBounds.Height - lado) / 2;
            Rectangle caja = new Rectangle(x, y, lado, lado);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (marcado)
            {
                using (SolidBrush relleno = new SolidBrush(Colores.Primario))
                    e.Graphics.FillRectangle(relleno, caja);
                using (Pen check = new Pen(Colores.Blanco, 2f))
                {
                    check.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    check.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    e.Graphics.DrawLines(check, new Point[] {
                        new Point(x + 4, y + 8),
                        new Point(x + 7, y + 11),
                        new Point(x + 12, y + 5)
                    });
                }
            }
            else
            {
                using (SolidBrush fondo = new SolidBrush(Colores.Blanco))
                    e.Graphics.FillRectangle(fondo, caja);
                using (Pen borde = new Pen(Colores.TextoSecundario))
                    e.Graphics.DrawRectangle(borde, caja);
            }
            e.Handled = true;
        }

        public static void EstilizarLabel(Label lbl, bool esEncabezado = false)
        {
            lbl.ForeColor = esEncabezado ? Colores.Primario : Colores.Texto;
            lbl.Font = esEncabezado
                ? new Font("Segoe UI", 14, FontStyle.Bold)
                : new Font("Segoe UI", 9);
        }

        /// <summary>Título principal de la ventana (antes en azul).</summary>
        public static void EstilizarTitulo(Label lbl)
        {
            lbl.ForeColor = Colores.Primario;
            lbl.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lbl.BackColor = Color.Transparent;
        }

        /// <summary>Etiqueta de total/importe destacado (antes en azul).</summary>
        public static void EstilizarTotal(Label lbl)
        {
            lbl.ForeColor = Colores.Primario;
            lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        }

        public static void EstilizarDateTimePicker(DateTimePicker dtp)
        {
            dtp.CalendarForeColor = Colores.Texto;
            dtp.Font = new Font("Segoe UI", 9);
        }

        public static void EstilizarNumericUpDown(NumericUpDown nud)
        {
            nud.BackColor = Colores.Blanco;
            nud.ForeColor = Colores.Texto;
            nud.BorderStyle = BorderStyle.FixedSingle;
            nud.Font = new Font("Segoe UI", 9);
        }

        public static void EstilizarPanelEncabezado(Panel panel)
        {
            panel.BackColor = Colores.Primario;
            panel.Height = 80;
            panel.Dock = DockStyle.Top;
        }

        public static void EstilizarMenu(MenuStrip menu)
        {
            menu.BackColor = Colores.Primario;
            menu.ForeColor = Colores.Blanco;
            menu.Font = new Font("Segoe UI", 9);
            menu.Renderer = new ToolStripProfessionalRenderer(new ColoresMenuGris());
            foreach (ToolStripMenuItem item in menu.Items)
                item.ForeColor = Colores.Blanco;
        }

        public static void EstilizarStatus(StatusStrip status)
        {
            status.BackColor = Colores.Fondo;
            status.ForeColor = Colores.Texto;
            status.Font = new Font("Segoe UI", 9);
        }

        // Esquema de color en grises para el render del menú (hover/selección sin azul).
        private class ColoresMenuGris : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Colores.TextoSecundario;
            public override Color MenuItemSelectedGradientBegin => Colores.TextoSecundario;
            public override Color MenuItemSelectedGradientEnd => Colores.TextoSecundario;
            public override Color MenuItemPressedGradientBegin => Colores.Primario;
            public override Color MenuItemPressedGradientEnd => Colores.Primario;
            public override Color MenuItemBorder => Colores.Borde;
            public override Color MenuBorder => Colores.Borde;
            public override Color ToolStripDropDownBackground => Colores.Blanco;
            public override Color ImageMarginGradientBegin => Colores.Blanco;
            public override Color ImageMarginGradientMiddle => Colores.Blanco;
            public override Color ImageMarginGradientEnd => Colores.Blanco;
        }

        // ---------------------------------------------------------------
        //  Imágenes referenciales
        // ---------------------------------------------------------------

        /// <summary>
        /// Carga una imagen embebida como recurso (busca por nombre de archivo,
        /// p. ej. "categoria.png"). Devuelve null si no existe.
        /// </summary>
        public static Image CargarImagen(string nombreArchivo)
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

            using (Stream s = asm.GetManifestResourceStream(recurso))
            {
                if (s == null) return null;
                using (Image original = Image.FromStream(s))
                {
                    return new Bitmap(original);  // copia independiente; el stream se cierra seguro
                }
            }
        }

        /// <summary>
        /// Crea y coloca una tarjeta con la imagen referencial de la ventana en
        /// la esquina superior derecha (anclada arriba-derecha). El formulario
        /// debe tener espacio libre a la derecha (ensanchar si es necesario).
        /// </summary>
        public static PictureBox AgregarTarjetaReferencia(Form form, string nombreImagen)
        {
            Image img = CargarImagen(nombreImagen);
            if (img == null) return null;

            const int margen = 16, lado = 200;
            var pb = new PictureBox
            {
                Name = "pbReferencia",
                Image = img,
                SizeMode = PictureBoxSizeMode.Zoom,           // cuadrada: la imagen llena sin barras
                Size = new Size(lado, lado),
                Location = new Point(form.ClientSize.Width - lado - margen, margen),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.FromArgb(254, 254, 254),     // mismo blanco del fondo de las imágenes
                TabStop = false
            };
            form.Controls.Add(pb);
            pb.BringToFront();
            return pb;
        }

        /// <summary>
        /// Da el mismo ancho a todas las cajas de texto y combos del contenedor
        /// (recursivo), para que los campos queden alineados y ordenados.
        /// </summary>
        public static void UniformarEntradas(Control contenedor, int ancho)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c is TextBox || c is ComboBox)
                    c.Width = ancho;
                if (c.HasChildren)
                    UniformarEntradas(c, ancho);
            }
        }

        // ---------------------------------------------------------------
        //  Barra de título gris para ventanas hijas MDI
        // ---------------------------------------------------------------

        /// <summary>
        /// Reemplaza el marco nativo (blanco/clásico) de una ventana hija MDI por
        /// una barra de título gris plana con botones minimizar/maximizar/cerrar y
        /// arrastre, para que combine con el tema gris de la ventana principal.
        /// Llamar como ÚLTIMA línea del Load (después de agregar todos los controles).
        /// </summary>
        public static void AplicarBarraTitulo(Form form)
        {
            if (form.FormBorderStyle == FormBorderStyle.None) return; // idempotente

            const int altoBarra = 36;
            Color fondoBarra = Color.FromArgb(51, 51, 51);

            // 1) Crecer el alto para alojar la barra y mover el contenido a un panel
            form.FormBorderStyle = FormBorderStyle.None;
            form.ClientSize = new Size(form.ClientSize.Width, form.ClientSize.Height + altoBarra);

            Panel contenido = new Panel
            {
                Left = 0,
                Top = altoBarra,
                Width = form.ClientSize.Width,
                Height = form.ClientSize.Height - altoBarra,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = form.BackColor
            };
            Control[] previos = new Control[form.Controls.Count];
            form.Controls.CopyTo(previos, 0);
            foreach (Control c in previos)
            {
                form.Controls.Remove(c);
                contenido.Controls.Add(c);
            }

            // 2) Barra de título
            Panel barra = new Panel { Name = "barraTitulo", Dock = DockStyle.Top, Height = altoBarra, BackColor = fondoBarra };

            Button btnMin = BotonCaption("–", fondoBarra);
            Button btnMax = BotonCaption("□", fondoBarra);
            Button btnClose = BotonCaption("✕", fondoBarra);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(196, 70, 70);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 48, 48);

            btnMin.Click += (s, e) => form.WindowState = FormWindowState.Minimized;
            btnMax.Click += (s, e) => form.WindowState =
                form.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            btnClose.Click += (s, e) => form.Close();

            Label lbl = new Label
            {
                Text = form.Text,
                ForeColor = Colores.Blanco,
                Font = new Font("Segoe UI", 10F),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 0, 0)
            };

            // Orden de docking a la derecha: cerrar (extremo), luego max, luego min
            barra.Controls.Add(lbl);
            barra.Controls.Add(btnMin);
            barra.Controls.Add(btnMax);
            barra.Controls.Add(btnClose);

            // 3) Arrastre para mover la ventana hija dentro del área MDI
            bool arrastrando = false;
            Point desplazamiento = Point.Empty;
            MouseEventHandler abajo = (s, e) =>
            {
                if (e.Button == MouseButtons.Left) { arrastrando = true; desplazamiento = e.Location; }
            };
            MouseEventHandler mover = (s, e) =>
            {
                if (!arrastrando || form.WindowState != FormWindowState.Normal || form.Parent == null) return;
                Point enPantalla = ((Control)s).PointToScreen(e.Location);
                Point enPadre = form.Parent.PointToClient(enPantalla);
                form.Location = new Point(enPadre.X - desplazamiento.X, enPadre.Y - desplazamiento.Y);
            };
            MouseEventHandler arriba = (s, e) => arrastrando = false;
            barra.MouseDown += abajo; barra.MouseMove += mover; barra.MouseUp += arriba;
            lbl.MouseDown += abajo; lbl.MouseMove += mover; lbl.MouseUp += arriba;
            barra.DoubleClick += (s, e) => btnMax.PerformClick();
            lbl.DoubleClick += (s, e) => btnMax.PerformClick();

            form.Controls.Add(contenido);
            form.Controls.Add(barra);
            barra.BringToFront();
        }

        private static Button BotonCaption(string texto, Color fondo)
        {
            Button b = new Button
            {
                Text = texto,
                Dock = DockStyle.Right,
                Width = 46,
                FlatStyle = FlatStyle.Flat,
                BackColor = fondo,
                ForeColor = Colores.Blanco,
                Font = new Font("Segoe UI", 10F),
                TabStop = false
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
            return b;
        }
    }
}
