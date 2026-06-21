using System;
using System.Data;
using System.Windows.Forms;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmReporteVentas : Form
    {
        private readonly ReporteBLL _bll = new ReporteBLL();

        public FrmReporteVentas()
        {
            InitializeComponent();
        }

        private void FrmReporteVentas_Load(object sender, EventArgs e)
        {
            TemaModerno.EstilizarFormulario(this);
            TemaModerno.EstilizarTitulo(lblTitulo);
            TemaModerno.EstilizarDateTimePicker(dtpDesde);
            TemaModerno.EstilizarDateTimePicker(dtpHasta);
            TemaModerno.EstilizarBotonSuccess(btnGenerar);
            TemaModerno.EstilizarDataGridView(dgvReporte);
            TemaModerno.EstilizarTotal(lblTotal);
            btnGenerar.Text = IconosUI.Generar;

            DateTime hoy = DateTime.Today;
            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = hoy;

            TemaModerno.AgregarTarjetaReferencia(this, "reporte.png");
            TemaModerno.AplicarBarraTitulo(this);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = _bll.VentasPorFecha(dtpDesde.Value.Date, dtpHasta.Value.Date);
                dgvReporte.DataSource = dt;
                FormatearGrilla();

                // Tema 4 - Cálculo agregado en memoria con DataTable.Compute.
                object suma = dt.Compute("SUM(Total)", string.Empty);
                decimal total = suma == DBNull.Value ? 0 : Convert.ToDecimal(suma);
                lblTotal.Text = "S/ " + total.ToString("N2");
                lblRegistros.Text = "Registros: " + dt.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormatearGrilla()
        {
            if (dgvReporte.Columns.Count == 0) return;
            if (dgvReporte.Columns.Contains("Fecha"))
                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            if (dgvReporte.Columns.Contains("SubTotal"))
                dgvReporte.Columns["SubTotal"].DefaultCellStyle.Format = "N2";
            if (dgvReporte.Columns.Contains("Igv"))
                dgvReporte.Columns["Igv"].DefaultCellStyle.Format = "N2";
            if (dgvReporte.Columns.Contains("Total"))
                dgvReporte.Columns["Total"].DefaultCellStyle.Format = "N2";
        }
    }
}
