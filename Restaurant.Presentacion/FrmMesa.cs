using System;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;

namespace Restaurant.Presentacion
{
    public partial class FrmMesa : Form
    {
        private readonly MesaBLL _bll = new MesaBLL();
        private int _idActual = 0;

        public FrmMesa()
        {
            InitializeComponent();
        }

        private void FrmMesa_Load(object sender, EventArgs e)
        {
            cboSituacion.Items.AddRange(new object[] { "Libre", "Ocupada", "Reservada" });
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
            dgvLista.Columns["IdMesa"].HeaderText = "Código";
            dgvLista.Columns["IdMesa"].Width = 70;
            dgvLista.Columns["Numero"].HeaderText = "N°";
            dgvLista.Columns["Capacidad"].HeaderText = "Capacidad";
            dgvLista.Columns["Ubicacion"].HeaderText = "Ubicación";
            dgvLista.Columns["Situacion"].HeaderText = "Situación";
            dgvLista.Columns["Estado"].HeaderText = "Activo";
        }

        private void LimpiarFormulario()
        {
            _idActual = 0;
            nudNumero.Value = 1;
            nudCapacidad.Value = 4;
            txtUbicacion.Clear();
            cboSituacion.SelectedItem = "Libre";
            chkEstado.Checked = true;
            nudNumero.Focus();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            _idActual = Convert.ToInt32(fila.Cells["IdMesa"].Value);
            nudNumero.Value = Convert.ToInt32(fila.Cells["Numero"].Value);
            nudCapacidad.Value = Convert.ToInt32(fila.Cells["Capacidad"].Value);
            txtUbicacion.Text = fila.Cells["Ubicacion"].Value == DBNull.Value
                ? string.Empty : fila.Cells["Ubicacion"].Value.ToString();
            cboSituacion.SelectedItem = fila.Cells["Situacion"].Value.ToString();
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
                Mesa m = new Mesa
                {
                    IdMesa = _idActual,
                    Numero = (int)nudNumero.Value,
                    Capacidad = (int)nudCapacidad.Value,
                    Ubicacion = txtUbicacion.Text.Trim(),
                    Situacion = cboSituacion.SelectedItem == null ? "Libre" : cboSituacion.SelectedItem.ToString(),
                    Estado = chkEstado.Checked
                };

                if (_idActual == 0)
                {
                    _bll.Registrar(m);
                    MessageBox.Show("Mesa registrada correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _bll.Modificar(m);
                    MessageBox.Show("Mesa actualizada correctamente.", "Información",
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
                MessageBox.Show("Seleccione una mesa de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea dar de baja la mesa seleccionada?", "Confirmar",
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
