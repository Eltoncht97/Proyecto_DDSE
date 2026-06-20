using System;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmCategoria : Form
    {
        private readonly CategoriaBLL _bll = new CategoriaBLL();
        private int _idActual = 0;

        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            TemaModerno.EstilizarFormulario(this);
            TemaModerno.EstilizarTextBox(txtNombre);
            TemaModerno.EstilizarTextBox(txtDescripcion);
            TemaModerno.EstilizarCheckBox(chkEstado);
            TemaModerno.EstilizarBotonSuccess(btnGuardar);
            TemaModerno.EstilizarBotonDanger(btnEliminar);
            TemaModerno.EstilizarBotonSecundario(btnNuevo);
            TemaModerno.EstilizarBotonSecundario(btnCancelar);
            btnNuevo.Text = IconosUI.Nuevo;
            btnGuardar.Text = IconosUI.Guardar;
            btnEliminar.Text = IconosUI.Eliminar;
            btnCancelar.Text = IconosUI.Cancelar;

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
            dgvLista.Columns["IdCategoria"].HeaderText = "Código";
            dgvLista.Columns["IdCategoria"].Width = 70;
            dgvLista.Columns["Nombre"].HeaderText = "Nombre";
            dgvLista.Columns["Descripcion"].HeaderText = "Descripción";
            dgvLista.Columns["Estado"].HeaderText = "Activo";
        }

        private void LimpiarFormulario()
        {
            _idActual = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();
            chkEstado.Checked = true;
            txtNombre.Focus();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            _idActual = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = fila.Cells["Descripcion"].Value == DBNull.Value
                ? string.Empty : fila.Cells["Descripcion"].Value.ToString();
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
                Categoria c = new Categoria
                {
                    IdCategoria = _idActual,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Estado = chkEstado.Checked
                };

                if (_idActual == 0)
                {
                    _bll.Registrar(c);
                    MessageBox.Show("Categoría registrada correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _bll.Modificar(c);
                    MessageBox.Show("Categoría actualizada correctamente.", "Información",
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
                MessageBox.Show("Seleccione una categoría de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea dar de baja la categoría seleccionada?", "Confirmar",
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
