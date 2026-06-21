using System;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmPlato : Form
    {
        private readonly PlatoBLL _bll = new PlatoBLL();
        private readonly CategoriaBLL _categoriaBll = new CategoriaBLL();
        private int _idActual = 0;

        public FrmPlato()
        {
            InitializeComponent();
        }

        private void FrmPlato_Load(object sender, EventArgs e)
        {
            TemaModerno.EstilizarFormulario(this);
            TemaModerno.EstilizarTitulo(lblTitulo);
            TemaModerno.EstilizarTextBox(txtNombre);
            TemaModerno.EstilizarTextBox(txtDescripcion);
            TemaModerno.EstilizarNumericUpDown(nudPrecio);
            TemaModerno.EstilizarComboBox(cboCategoria);
            TemaModerno.EstilizarCheckBox(chkDisponible);
            TemaModerno.EstilizarCheckBox(chkEstado);
            TemaModerno.EstilizarDataGridView(dgvLista);
            TemaModerno.EstilizarBotonSuccess(btnGuardar);
            TemaModerno.EstilizarBotonDanger(btnEliminar);
            TemaModerno.EstilizarBotonSecundario(btnNuevo);
            TemaModerno.EstilizarBotonSecundario(btnCancelar);
            btnNuevo.Text = IconosUI.Nuevo;
            btnGuardar.Text = IconosUI.Guardar;
            btnEliminar.Text = IconosUI.Eliminar;
            btnCancelar.Text = IconosUI.Cancelar;

            CargarCategorias();
            Listar();
            LimpiarFormulario();
            TemaModerno.UniformarEntradas(this, 380);
            TemaModerno.AgregarTarjetaReferencia(this, "plato.png");
            TemaModerno.AplicarBarraTitulo(this);
        }

        private void CargarCategorias()
        {
            cboCategoria.DataSource = _categoriaBll.ListarActivas();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";
            cboCategoria.SelectedIndex = -1;
        }

        private void Listar()
        {
            dgvLista.DataSource = _bll.ListarTabla();
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            if (dgvLista.Columns.Count == 0) return;
            dgvLista.Columns["IdPlato"].HeaderText = "Código";
            dgvLista.Columns["IdPlato"].Width = 70;
            dgvLista.Columns["IdCategoria"].Visible = false;
            dgvLista.Columns["Categoria"].HeaderText = "Categoría";
            dgvLista.Columns["Nombre"].HeaderText = "Plato";
            dgvLista.Columns["Descripcion"].HeaderText = "Descripción";
            dgvLista.Columns["Precio"].HeaderText = "Precio";
            dgvLista.Columns["Precio"].DefaultCellStyle.Format = "N2";
            dgvLista.Columns["Disponible"].HeaderText = "Disponible";
            dgvLista.Columns["Estado"].HeaderText = "Activo";
        }

        private void LimpiarFormulario()
        {
            _idActual = 0;
            cboCategoria.SelectedIndex = -1;
            txtNombre.Clear();
            txtDescripcion.Clear();
            nudPrecio.Value = 0;
            chkDisponible.Checked = true;
            chkEstado.Checked = true;
            txtNombre.Focus();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            _idActual = Convert.ToInt32(fila.Cells["IdPlato"].Value);
            cboCategoria.SelectedValue = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = fila.Cells["Descripcion"].Value == DBNull.Value
                ? string.Empty : fila.Cells["Descripcion"].Value.ToString();
            nudPrecio.Value = Convert.ToDecimal(fila.Cells["Precio"].Value);
            chkDisponible.Checked = Convert.ToBoolean(fila.Cells["Disponible"].Value);
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
                Plato p = new Plato
                {
                    IdPlato = _idActual,
                    IdCategoria = cboCategoria.SelectedValue == null ? 0 : Convert.ToInt32(cboCategoria.SelectedValue),
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = nudPrecio.Value,
                    Disponible = chkDisponible.Checked,
                    Estado = chkEstado.Checked
                };

                if (_idActual == 0)
                {
                    _bll.Registrar(p);
                    MessageBox.Show("Plato registrado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _bll.Modificar(p);
                    MessageBox.Show("Plato actualizado correctamente.", "Información",
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
                MessageBox.Show("Seleccione un plato de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea dar de baja el plato seleccionado?", "Confirmar",
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
