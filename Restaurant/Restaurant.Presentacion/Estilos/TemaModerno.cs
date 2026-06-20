using System;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurant.Presentacion.Estilos
{
    public static class TemaModerno
    {
        public static class Colores
        {
            public static Color Primario = Color.FromArgb(52, 152, 219);         // Azul profesional
            public static Color Texto = Color.FromArgb(44, 62, 80);               // Gris oscuro (casi negro)
            public static Color TextoSecundario = Color.FromArgb(127, 140, 141);  // Gris medio
            public static Color Fondo = Color.FromArgb(236, 240, 241);            // Blanco roto claro
            public static Color FondoFormulario = Color.FromArgb(250, 251, 252);  // Blanco casi puro
            public static Color Borde = Color.FromArgb(189, 195, 199);            // Gris borde sutil
            public static Color Blanco = Color.White;
            public static Color Exito = Color.FromArgb(39, 174, 96);              // Verde minimalista
            public static Color Alerta = Color.FromArgb(231, 76, 60);             // Rojo (mantener para eliminar)
        }

        public static void EstilizarFormulario(Form form)
        {
            form.BackColor = Colores.FondoFormulario;
            form.Font = new Font("Segoe UI", 9);
        }

        // Botones: Diseño minimalista sin relleno, solo borde
        public static void EstilizarBotonSuccess(Button btn)
        {
            btn.BackColor = Colores.Exito;
            btn.ForeColor = Colores.Blanco;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 148, 81);
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Height = 36;
        }

        public static void EstilizarBotonDanger(Button btn)
        {
            btn.BackColor = Colores.Alerta;
            btn.ForeColor = Colores.Blanco;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Height = 36;
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
        }

        public static void EstilizarBotonPrimario(Button btn)
        {
            btn.BackColor = Colores.Primario;
            btn.ForeColor = Colores.Blanco;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Height = 36;
        }

        public static void EstilizarTextBox(TextBox txt)
        {
            txt.BackColor = Colores.Blanco;
            txt.ForeColor = Colores.Texto;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 9);
            txt.Padding = new Padding(3);
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
            chk.UseVisualStyleBackColor = true;
        }

        public static void EstilizarDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Colores.Blanco;
            dgv.GridColor = Colores.Borde;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Encabezados: azul profesional
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Colores.Primario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Colores.Blanco;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Colores.Primario;
            dgv.ColumnHeadersHeight = 32;

            // Celdas: blanco con texto gris oscuro
            dgv.DefaultCellStyle.BackColor = Colores.Blanco;
            dgv.DefaultCellStyle.ForeColor = Colores.Texto;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(174, 214, 241);
            dgv.DefaultCellStyle.SelectionForeColor = Colores.Texto;

            // Filas alternas: gris muy claro (minimalista)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Colores.Fondo;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Colores.Texto;

            dgv.RowHeadersDefaultCellStyle.BackColor = Colores.Fondo;
            dgv.RowHeadersVisible = true;
            dgv.RowHeadersWidth = 25;

            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 26;
            dgv.Dock = DockStyle.Fill;  // Ajustar al ancho completo
        }

        public static void EstilizarLabel(Label lbl, bool esEncabezado = false)
        {
            lbl.ForeColor = esEncabezado ? Colores.Primario : Colores.Texto;
            lbl.Font = esEncabezado
                ? new Font("Segoe UI", 14, FontStyle.Bold)
                : new Font("Segoe UI", 9);
        }

        public static void EstilizarDateTimePicker(DateTimePicker dtp)
        {
            dtp.BackColor = Colores.Blanco;
            dtp.ForeColor = Colores.Texto;
            dtp.Font = new Font("Segoe UI", 9);
        }

        public static void EstilizarNumericUpDown(NumericUpDown nud)
        {
            nud.BackColor = Colores.Blanco;
            nud.ForeColor = Colores.Texto;
            nud.Font = new Font("Segoe UI", 9);
        }

        public static void EstilizarPanelEncabezado(Panel panel)
        {
            panel.BackColor = Colores.Primario;
            panel.Height = 80;
            panel.Dock = DockStyle.Top;
        }

        public static void AjustarDataGridViewAlAncho(DataGridView dgv, Control contenedor)
        {
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
