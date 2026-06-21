using System;
using System.Data;
using System.Windows.Forms;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmReportePlatosVendidos : Form
    {
        private readonly ReporteBLL _bll = new ReporteBLL();

        public FrmReportePlatosVendidos()
        {
            InitializeComponent();
        }

        private void FrmReportePlatosVendidos_Load(object sender, EventArgs e)
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
                DataTable dt = _bll.PlatosMasVendidos(dtpDesde.Value.Date, dtpHasta.Value.Date);
                dgvReporte.DataSource = dt;
                FormatearGrilla();

                object suma = dt.Compute("SUM(TotalIngreso)", string.Empty);
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
            if (dgvReporte.Columns.Contains("Plato"))
                dgvReporte.Columns["Plato"].HeaderText = "Plato";
            if (dgvReporte.Columns.Contains("Categoria"))
                dgvReporte.Columns["Categoria"].HeaderText = "Categoría";
            if (dgvReporte.Columns.Contains("TotalVendido"))
                dgvReporte.Columns["TotalVendido"].HeaderText = "Cant. Vendida";
            if (dgvReporte.Columns.Contains("PrecioUnit"))
            {
                dgvReporte.Columns["PrecioUnit"].HeaderText = "Precio Unit.";
                dgvReporte.Columns["PrecioUnit"].DefaultCellStyle.Format = "N2";
            }
            if (dgvReporte.Columns.Contains("TotalIngreso"))
            {
                dgvReporte.Columns["TotalIngreso"].HeaderText = "Total Ingreso";
                dgvReporte.Columns["TotalIngreso"].DefaultCellStyle.Format = "N2";
            }
        }
    }
}
