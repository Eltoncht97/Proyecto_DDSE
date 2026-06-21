using System;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmCocinero : Form
    {
        private readonly PedidoBLL _bll = new PedidoBLL();
        private int _idPedido = 0;

        public FrmCocinero()
        {
            InitializeComponent();
        }

        private void FrmCocinero_Load(object sender, EventArgs e)
        {
            TemaModerno.EstilizarFormulario(this);
            TemaModerno.EstilizarTitulo(lblTitulo);
            TemaModerno.EstilizarLabel(lblDetalle);
            TemaModerno.EstilizarDataGridView(dgvPedidos);
            TemaModerno.EstilizarDataGridView(dgvDetalle);
            TemaModerno.EstilizarBotonSecundario(btnRefrescar);
            TemaModerno.EstilizarBotonSuccess(btnServido);
            TemaModerno.EstilizarBotonSecundario(btnSolicitado);
            btnRefrescar.Text = IconosUI.Refrescar;
            btnServido.Text = "✓ Marcar Servido";
            btnSolicitado.Text = "↺ Marcar Solicitado";

            CargarPedidos();
            TemaModerno.AplicarBarraTitulo(this);
        }

        private void CargarPedidos()
        {
            int idSel = _idPedido;
            dgvPedidos.DataSource = _bll.ListarEnPreparacion();
            FormatearPedidos();
            if (!SeleccionarPedido(idSel))
                CargarDetalle();
        }

        private void FormatearPedidos()
        {
            if (dgvPedidos.Columns.Count == 0) return;
            dgvPedidos.Columns["IdPedido"].HeaderText = "N°";
            dgvPedidos.Columns["IdPedido"].Width = 50;
            dgvPedidos.Columns["Fecha"].HeaderText = "Fecha";
            dgvPedidos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvPedidos.Columns["Mesa"].HeaderText = "Mesa";
            dgvPedidos.Columns["Mozo"].HeaderText = "Mozo";
            dgvPedidos.Columns["Cliente"].HeaderText = "Cliente";
            dgvPedidos.Columns["Situacion"].HeaderText = "Situación";
            dgvPedidos.Columns["Pendientes"].HeaderText = "Por servir";
            dgvPedidos.Columns["Items"].HeaderText = "Líneas";
        }

        private bool SeleccionarPedido(int idPedido)
        {
            if (idPedido <= 0) return false;
            foreach (DataGridViewRow fila in dgvPedidos.Rows)
            {
                object val = fila.Cells["IdPedido"].Value;
                if (val != null && Convert.ToInt32(val) == idPedido)
                {
                    dgvPedidos.CurrentCell = fila.Cells["IdPedido"];
                    return true;
                }
            }
            return false;
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        private void CargarDetalle()
        {
            if (dgvPedidos.CurrentRow == null ||
                dgvPedidos.CurrentRow.Cells["IdPedido"].Value == null)
            {
                dgvDetalle.DataSource = null;
                _idPedido = 0;
                return;
            }
            _idPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["IdPedido"].Value);
            dgvDetalle.DataSource = _bll.ObtenerDetalle(_idPedido);
            FormatearDetalle();
        }

        private void FormatearDetalle()
        {
            if (dgvDetalle.Columns.Count == 0) return;
            if (dgvDetalle.Columns.Contains("IdDetalle")) dgvDetalle.Columns["IdDetalle"].Visible = false;
            if (dgvDetalle.Columns.Contains("IdPedido")) dgvDetalle.Columns["IdPedido"].Visible = false;
            if (dgvDetalle.Columns.Contains("IdPlato")) dgvDetalle.Columns["IdPlato"].Visible = false;
            if (dgvDetalle.Columns.Contains("PrecioUnitario")) dgvDetalle.Columns["PrecioUnitario"].Visible = false;
            if (dgvDetalle.Columns.Contains("Subtotal")) dgvDetalle.Columns["Subtotal"].Visible = false;
            dgvDetalle.Columns["Plato"].HeaderText = "Plato";
            dgvDetalle.Columns["Cantidad"].HeaderText = "Cant.";
            dgvDetalle.Columns["EstadoDetalle"].HeaderText = "Estado";
        }

        private void btnServido_Click(object sender, EventArgs e)
        {
            CambiarEstado("Servido");
        }

        private void btnSolicitado_Click(object sender, EventArgs e)
        {
            CambiarEstado("Solicitado");
        }

        private void CambiarEstado(string estado)
        {
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una línea del pedido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DetallePedido item = dgvDetalle.CurrentRow.DataBoundItem as DetallePedido;
            if (item == null) return;
            try
            {
                _bll.CambiarEstadoDetalle(item.IdDetalle, estado);
                CargarPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarPedidos();
        }
    }
}
