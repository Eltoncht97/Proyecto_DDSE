using System;
using System.Data;
using System.Windows.Forms;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmReporteClientes : Form
    {
        private readonly ReporteBLL _bll = new ReporteBLL();

        public FrmReporteClientes()
        {
            InitializeComponent();
        }

        private void FrmReporteClientes_Load(object sender, EventArgs e)
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
                DataTable dt = _bll.ReporteClientes(dtpDesde.Value.Date, dtpHasta.Value.Date);
                dgvReporte.DataSource = dt;
                FormatearGrilla();

                object suma = dt.Compute("SUM(TotalGastado)", string.Empty);
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
            if (dgvReporte.Columns.Contains("Cliente"))
                dgvReporte.Columns["Cliente"].HeaderText = "Cliente";
            if (dgvReporte.Columns.Contains("Documento"))
                dgvReporte.Columns["Documento"].HeaderText = "Documento";
            if (dgvReporte.Columns.Contains("TotalVisitas"))
                dgvReporte.Columns["TotalVisitas"].HeaderText = "Visitas";
            if (dgvReporte.Columns.Contains("TotalGastado"))
            {
                dgvReporte.Columns["TotalGastado"].HeaderText = "Total Gastado";
                dgvReporte.Columns["TotalGastado"].DefaultCellStyle.Format = "N2";
            }
            if (dgvReporte.Columns.Contains("UltimaVisita"))
            {
                dgvReporte.Columns["UltimaVisita"].HeaderText = "Última Visita";
                dgvReporte.Columns["UltimaVisita"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
    }
}
