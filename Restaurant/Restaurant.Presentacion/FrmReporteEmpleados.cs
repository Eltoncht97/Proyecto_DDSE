using System;
using System.Data;
using System.Windows.Forms;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmReporteEmpleados : Form
    {
        private readonly ReporteBLL _bll = new ReporteBLL();

        public FrmReporteEmpleados()
        {
            InitializeComponent();
        }

        private void FrmReporteEmpleados_Load(object sender, EventArgs e)
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
                DataTable dt = _bll.VentasPorEmpleado(dtpDesde.Value.Date, dtpHasta.Value.Date);
                dgvReporte.DataSource = dt;
                FormatearGrilla();

                object suma = dt.Compute("SUM(TotalVentas)", string.Empty);
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
            if (dgvReporte.Columns.Contains("Empleado"))
                dgvReporte.Columns["Empleado"].HeaderText = "Empleado";
            if (dgvReporte.Columns.Contains("Cargo"))
                dgvReporte.Columns["Cargo"].HeaderText = "Cargo";
            if (dgvReporte.Columns.Contains("TotalPedidos"))
                dgvReporte.Columns["TotalPedidos"].HeaderText = "Pedidos";
            if (dgvReporte.Columns.Contains("TotalVentas"))
            {
                dgvReporte.Columns["TotalVentas"].HeaderText = "Total Ventas";
                dgvReporte.Columns["TotalVentas"].DefaultCellStyle.Format = "N2";
            }
        }
    }
}
