using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmPedido : Form
    {
        private readonly PedidoBLL _pedidoBll = new PedidoBLL();
        private readonly MesaBLL _mesaBll = new MesaBLL();
        private readonly EmpleadoBLL _empleadoBll = new EmpleadoBLL();
        private readonly ClienteBLL _clienteBll = new ClienteBLL();
        private readonly PlatoBLL _platoBll = new PlatoBLL();

        private BindingList<DetallePedido> _detalle = new BindingList<DetallePedido>();

        public FrmPedido()
        {
            InitializeComponent();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            TemaModerno.EstilizarFormulario(this);
            TemaModerno.EstilizarComboBox(cboMesa);
            TemaModerno.EstilizarComboBox(cboMozo);
            TemaModerno.EstilizarComboBox(cboCliente);
            TemaModerno.EstilizarComboBox(cboPlato);
            TemaModerno.EstilizarNumericUpDown(nudCantidad);
            TemaModerno.EstilizarBotonSuccess(btnAgregar);
            TemaModerno.EstilizarBotonDanger(btnQuitar);
            TemaModerno.EstilizarBotonSuccess(btnRegistrar);
            TemaModerno.EstilizarBotonSecundario(btnNuevo);
            btnAgregar.Text = IconosUI.Agregar;
            btnQuitar.Text = IconosUI.Quitar;
            btnRegistrar.Text = IconosUI.Guardar;
            btnNuevo.Text = IconosUI.Nuevo;

            cboMesa.DataSource = _mesaBll.ListarActivas();
            cboMesa.DisplayMember = "Numero";
            cboMesa.ValueMember = "IdMesa";

            cboMozo.DataSource = _empleadoBll.ListarMozos();
            cboMozo.DisplayMember = "NombreCompleto";
            cboMozo.ValueMember = "IdEmpleado";

            cboCliente.DataSource = _clienteBll.ListarActivos();
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "IdCliente";
            cboCliente.SelectedIndex = -1;

            cboPlato.DataSource = _platoBll.ListarDisponibles();
            cboPlato.DisplayMember = "Nombre";
            cboPlato.ValueMember = "IdPlato";
            cboPlato.SelectedIndex = -1;

            dgvDetalle.AutoGenerateColumns = true;
            dgvDetalle.DataSource = _detalle;
            FormatearDetalle();
            TemaModerno.EstilizarDataGridView(dgvDetalle);
            ActualizarTotal();
        }

        private void FormatearDetalle()
        {
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Plato plato = cboPlato.SelectedItem as Plato;
            if (plato == null)
            {
                MessageBox.Show("Seleccione un plato.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si el plato ya está en el detalle, acumula la cantidad.
            DetallePedido existente = _detalle.FirstOrDefault(d => d.IdPlato == plato.IdPlato);
            if (existente != null)
            {
                existente.Cantidad += cantidad;
                dgvDetalle.Refresh();
            }
            else
            {
                _detalle.Add(new DetallePedido
                {
                    IdPlato = plato.IdPlato,
                    Plato = plato.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = plato.Precio
                });
                FormatearDetalle();
            }

            ActualizarTotal();
            cboPlato.SelectedIndex = -1;
            nudCantidad.Value = 1;
            cboPlato.Focus();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;
            DetallePedido item = dgvDetalle.CurrentRow.DataBoundItem as DetallePedido;
            if (item != null)
            {
                _detalle.Remove(item);
                ActualizarTotal();
            }
        }

        private void ActualizarTotal()
        {
            decimal total = _detalle.Sum(d => d.Subtotal);
            lblTotal.Text = total.ToString("N2");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Pedido pedido = new Pedido
                {
                    Fecha = DateTime.Now,
                    IdMesa = cboMesa.SelectedValue == null ? 0 : Convert.ToInt32(cboMesa.SelectedValue),
                    IdEmpleado = cboMozo.SelectedValue == null ? 0 : Convert.ToInt32(cboMozo.SelectedValue),
                    IdCliente = cboCliente.SelectedValue == null ? (int?)null : Convert.ToInt32(cboCliente.SelectedValue),
                    Situacion = "Atendido",
                    Detalles = _detalle.ToList()
                };

                int idPedido = _pedidoBll.RegistrarPedido(pedido);
                MessageBox.Show("Pedido registrado correctamente. N° " + idPedido, "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            _detalle = new BindingList<DetallePedido>();
            dgvDetalle.DataSource = _detalle;
            FormatearDetalle();
            if (cboMesa.Items.Count > 0) cboMesa.SelectedIndex = 0;
            if (cboMozo.Items.Count > 0) cboMozo.SelectedIndex = 0;
            cboCliente.SelectedIndex = -1;
            cboPlato.SelectedIndex = -1;
            nudCantidad.Value = 1;
            ActualizarTotal();
        }
    }
}
