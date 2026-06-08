using System;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;

namespace Restaurant.Presentacion
{
    public partial class FrmCliente : Form
    {
        private readonly ClienteBLL _bll = new ClienteBLL();
        private int _idActual = 0;

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Listar();
            LimpiarFormulario();
        }

        private void Listar()
        {
            dgvLista.DataSource = _bll.ListarTabla();
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            if (dgvLista.Columns.Count == 0) return;
            dgvLista.Columns["IdCliente"].HeaderText = "Código";
            dgvLista.Columns["IdCliente"].Width = 70;
            dgvLista.Columns["Nombres"].HeaderText = "Nombres";
            dgvLista.Columns["Apellidos"].HeaderText = "Apellidos";
            dgvLista.Columns["Documento"].HeaderText = "DNI / RUC";
            dgvLista.Columns["Telefono"].HeaderText = "Teléfono";
            dgvLista.Columns["Correo"].HeaderText = "Correo";
            dgvLista.Columns["Direccion"].HeaderText = "Dirección";
            dgvLista.Columns["Estado"].HeaderText = "Activo";
        }

        private void LimpiarFormulario()
        {
            _idActual = 0;
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            chkEstado.Checked = true;
            txtNombres.Focus();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            _idActual = Convert.ToInt32(fila.Cells["IdCliente"].Value);
            txtNombres.Text = fila.Cells["Nombres"].Value.ToString();
            txtApellidos.Text = fila.Cells["Apellidos"].Value == DBNull.Value ? string.Empty : fila.Cells["Apellidos"].Value.ToString();
            txtDocumento.Text = fila.Cells["Documento"].Value == DBNull.Value ? string.Empty : fila.Cells["Documento"].Value.ToString();
            txtTelefono.Text = fila.Cells["Telefono"].Value == DBNull.Value ? string.Empty : fila.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = fila.Cells["Correo"].Value == DBNull.Value ? string.Empty : fila.Cells["Correo"].Value.ToString();
            txtDireccion.Text = fila.Cells["Direccion"].Value == DBNull.Value ? string.Empty : fila.Cells["Direccion"].Value.ToString();
            chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente
                {
                    IdCliente = _idActual,
                    Nombres = txtNombres.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Documento = txtDocumento.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Estado = chkEstado.Checked
                };

                if (_idActual == 0)
                {
                    _bll.Registrar(c);
                    MessageBox.Show("Cliente registrado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _bll.Modificar(c);
                    MessageBox.Show("Cliente actualizado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Listar();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idActual == 0)
            {
                MessageBox.Show("Seleccione un cliente de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea dar de baja al cliente seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _bll.Eliminar(_idActual);
                    Listar();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
