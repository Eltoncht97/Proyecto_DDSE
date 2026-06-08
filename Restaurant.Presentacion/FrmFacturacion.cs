using System;
using System.Data;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;

namespace Restaurant.Presentacion
{
    public partial class FrmFacturacion : Form
    {
        private readonly PedidoBLL _pedidoBll = new PedidoBLL();
        private readonly ComprobanteBLL _comprobanteBll = new ComprobanteBLL();

        private int _idPedidoSel = 0;
        private decimal _totalSel = 0;

        public FrmFacturacion()
        {
            InitializeComponent();
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            cboTipo.Items.AddRange(new object[] { "Boleta", "Factura" });
            cboTipo.SelectedItem = "Boleta";
            ListarPendientes();
        }

        private void ListarPendientes()
        {
            DataTable dt = _pedidoBll.ListarTabla();
            // Tema 4 - DataView: solo pedidos aún no pagados ni anulados.
            DataView vista = new DataView(dt)
            {
                RowFilter = "Situacion <> 'Pagado' AND Situacion <> 'Anulado'"
            };
            dgvPedidos.DataSource = vista;
            FormatearPedidos();

            // limpiar selección
            _idPedidoSel = 0;
            _totalSel = 0;
            dgvDetalle.DataSource = null;
            lblTotal.Text = "0.00";
        }

        private void FormatearPedidos()
        {
            if (dgvPedidos.Columns.Count == 0) return;
            dgvPedidos.Columns["IdPedido"].HeaderText = "N°";
            dgvPedidos.Columns["IdPedido"].Width = 50;
            dgvPedidos.Columns["Fecha"].HeaderText = "Fecha";
            dgvPedidos.Columns["Mesa"].HeaderText = "Mesa";
            dgvPedidos.Columns["Mozo"].HeaderText = "Mozo";
            dgvPedidos.Columns["Cliente"].HeaderText = "Cliente";
            dgvPedidos.Columns["Situacion"].HeaderText = "Situación";
            dgvPedidos.Columns["Total"].HeaderText = "Total";
            dgvPedidos.Columns["Total"].DefaultCellStyle.Format = "N2";
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvPedidos.Rows[e.RowIndex];
            _idPedidoSel = Convert.ToInt32(fila.Cells["IdPedido"].Value);
            _totalSel = Convert.ToDecimal(fila.Cells["Total"].Value);
            lblTotal.Text = _totalSel.ToString("N2");

            CargarDetalle();
        }

        private void CargarDetalle()
        {
            var detalle = _pedidoBll.ObtenerDetalle(_idPedidoSel);
            dgvDetalle.DataSource = detalle;
            if (dgvDetalle.Columns.Count == 0) return;
            if (dgvDetalle.Columns.Contains("IdDetalle")) dgvDetalle.Columns["IdDetalle"].Visible = false;
            if (dgvDetalle.Columns.Contains("IdPedido")) dgvDetalle.Columns["IdPedido"].Visible = false;
            if (dgvDetalle.Columns.Contains("IdPlato")) dgvDetalle.Columns["IdPlato"].Visible = false;
            dgvDetalle.Columns["Plato"].HeaderText = "Plato";
            dgvDetalle.Columns["Cantidad"].HeaderText = "Cant.";
            dgvDetalle.Columns["PrecioUnitario"].HeaderText = "P. Unit.";
            dgvDetalle.Columns["PrecioUnitario"].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns["Subtotal"].HeaderText = "Subtotal";
            dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (_idPedidoSel == 0)
            {
                MessageBox.Show("Seleccione un pedido de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tipo = cboTipo.SelectedItem == null ? "Boleta" : cboTipo.SelectedItem.ToString();
                Comprobante c = _comprobanteBll.Generar(_idPedidoSel, tipo, _totalSel);

                MessageBox.Show(
                    "Comprobante generado correctamente.\n\n" +
                    "Tipo: " + c.Tipo + "\n" +
                    "Serie-Número: " + c.Serie + "-" + c.Numero.ToString("D6") + "\n" +
                    "SubTotal: S/ " + c.SubTotal.ToString("N2") + "\n" +
                    "IGV (18%): S/ " + c.Igv.ToString("N2") + "\n" +
                    "Total: S/ " + c.Total.ToString("N2"),
                    "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListarPendientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            ListarPendientes();
        }
    }
}
