using System;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;

namespace Restaurant.Presentacion
{
    public partial class FrmEmpleado : Form
    {
        private readonly EmpleadoBLL _bll = new EmpleadoBLL();
        private int _idActual = 0;

        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            cboCargo.Items.AddRange(new object[] { "Mozo", "Cajero", "Cocinero", "Administrador" });
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
            dgvLista.Columns["IdEmpleado"].HeaderText = "Código";
            dgvLista.Columns["IdEmpleado"].Width = 70;
            dgvLista.Columns["Nombres"].HeaderText = "Nombres";
            dgvLista.Columns["Apellidos"].HeaderText = "Apellidos";
            dgvLista.Columns["Dni"].HeaderText = "DNI";
            dgvLista.Columns["Cargo"].HeaderText = "Cargo";
            dgvLista.Columns["Telefono"].HeaderText = "Teléfono";
            dgvLista.Columns["Estado"].HeaderText = "Activo";
        }

        private void LimpiarFormulario()
        {
            _idActual = 0;
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDni.Clear();
            cboCargo.SelectedItem = "Mozo";
            txtTelefono.Clear();
            chkEstado.Checked = true;
            txtNombres.Focus();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            _idActual = Convert.ToInt32(fila.Cells["IdEmpleado"].Value);
            txtNombres.Text = fila.Cells["Nombres"].Value.ToString();
            txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
            txtDni.Text = fila.Cells["Dni"].Value.ToString();
            cboCargo.SelectedItem = fila.Cells["Cargo"].Value.ToString();
            txtTelefono.Text = fila.Cells["Telefono"].Value == DBNull.Value
                ? string.Empty : fila.Cells["Telefono"].Value.ToString();
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
                Empleado emp = new Empleado
                {
                    IdEmpleado = _idActual,
                    Nombres = txtNombres.Text.Trim(),
                    Apellidos = txtApellidos.Text.Trim(),
                    Dni = txtDni.Text.Trim(),
                    Cargo = cboCargo.SelectedItem == null ? "Mozo" : cboCargo.SelectedItem.ToString(),
                    Telefono = txtTelefono.Text.Trim(),
                    Estado = chkEstado.Checked
                };

                if (_idActual == 0)
                {
                    _bll.Registrar(emp);
                    MessageBox.Show("Empleado registrado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _bll.Modificar(emp);
                    MessageBox.Show("Empleado actualizado correctamente.", "Información",
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
                MessageBox.Show("Seleccione un empleado de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea dar de baja al empleado seleccionado?", "Confirmar",
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
