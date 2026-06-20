using System;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurant.Presentacion.Estilos
{
    public static class TemaModerno
    {
        public static class Colores
        {
            public static Color Primario = Color.FromArgb(0, 102, 204);
            public static Color Secundario = Color.FromArgb(255, 107, 53);
            public static Color Exito = Color.FromArgb(76, 175, 80);
            public static Color Alerta = Color.FromArgb(231, 76, 60);
            public static Color Fondo = Color.FromArgb(245, 245, 245);
            public static Color FondoOscuro = Color.FromArgb(51, 51, 51);
            public static Color Borde = Color.FromArgb(221, 221, 221);
            public static Color Blanco = Color.White;
            public static Color Gris = Color.FromArgb(200, 200, 200);
        }

        public static void EstilizarFormulario(Form form)
        {
            form.BackColor = Colores.Fondo;
            form.Font = new Font("Segoe UI", 9);
        }

        public static void EstilizarBotonPrimario(Button btn)
        {
            btn.BackColor = Colores.Primario;
            btn.ForeColor = Colores.Blanco;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 82, 164);
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Padding = new Padding(5);
            btn.Height = 36;
        }

        public static void EstilizarBotonSuccess(Button btn)
        {
            btn.BackColor = Colores.Exito;
            btn.ForeColor = Colores.Blanco;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Padding = new Padding(5);
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
            btn.Padding = new Padding(5);
            btn.Height = 36;
        }

        public static void EstilizarBotonSecundario(Button btn)
        {
            btn.BackColor = Color.FromArgb(230, 230, 230);
            btn.ForeColor = Colores.FondoOscuro;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Colores.Borde;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 220, 220);
            btn.Font = new Font("Segoe UI", 9);
            btn.Padding = new Padding(5);
            btn.Height = 36;
        }

        public static void EstilizarTextBox(TextBox txt)
        {
            txt.BackColor = Colores.Blanco;
            txt.ForeColor = Colores.FondoOscuro;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 9);
            txt.Padding = new Padding(3);
        }

        public static void EstilizarComboBox(ComboBox cbo)
        {
            cbo.BackColor = Colores.Blanco;
            cbo.ForeColor = Colores.FondoOscuro;
            cbo.Font = new Font("Segoe UI", 9);
            cbo.FlatStyle = FlatStyle.Flat;
        }

        public static void EstilizarCheckBox(CheckBox chk)
        {
            chk.ForeColor = Colores.FondoOscuro;
            chk.Font = new Font("Segoe UI", 9);
            chk.UseVisualStyleBackColor = true;
        }

        public static void EstilizarDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Colores.Blanco;
            dgv.GridColor = Colores.Borde;
            dgv.BorderStyle = BorderStyle.Fixed3D;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Colores.Primario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Colores.Blanco;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Colores.Primario;
            dgv.ColumnHeadersHeight = 28;

            dgv.DefaultCellStyle.BackColor = Colores.Blanco;
            dgv.DefaultCellStyle.ForeColor = Colores.FondoOscuro;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 250);
            dgv.DefaultCellStyle.SelectionForeColor = Colores.FondoOscuro;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Colores.FondoOscuro;

            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv.RowHeadersVisible = true;
            dgv.RowHeadersWidth = 25;

            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 24;
        }

        public static void EstilizarLabel(Label lbl, bool esEncabezado = false)
        {
            lbl.ForeColor = esEncabezado ? Colores.Primario : Colores.FondoOscuro;
            lbl.Font = esEncabezado
                ? new Font("Segoe UI", 14, FontStyle.Bold)
                : new Font("Segoe UI", 9);
        }

        public static void EstilizarDateTimePicker(DateTimePicker dtp)
        {
            dtp.BackColor = Colores.Blanco;
            dtp.ForeColor = Colores.FondoOscuro;
            dtp.Font = new Font("Segoe UI", 9);
        }

        public static void EstilizarNumericUpDown(NumericUpDown nud)
        {
            nud.BackColor = Colores.Blanco;
            nud.ForeColor = Colores.FondoOscuro;
            nud.Font = new Font("Segoe UI", 9);
        }
    }
}
