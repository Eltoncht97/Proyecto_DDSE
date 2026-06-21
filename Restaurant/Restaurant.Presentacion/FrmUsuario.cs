using System;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmUsuario : Form
    {
        private readonly UsuarioBLL _bll = new UsuarioBLL();
        private int _idActual = 0;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            TemaModerno.EstilizarFormulario(this);
            TemaModerno.EstilizarTitulo(lblTitulo);
            TemaModerno.EstilizarTextBox(txtUsuario);
            TemaModerno.EstilizarTextBox(txtClave);
            TemaModerno.EstilizarTextBox(txtNombre);
            TemaModerno.EstilizarComboBox(cboRol);
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

            cboRol.Items.Clear();
            cboRol.Items.AddRange(new object[] { "Administrador", "Cajero", "Mozo", "Cocinero" });

            Listar();
            LimpiarFormulario();

            TemaModerno.UniformarEntradas(this, 380);
            TemaModerno.AgregarTarjetaReferencia(this, "empleado.png");
            TemaModerno.AplicarBarraTitulo(this);
        }

        private void Listar()
        {
            dgvLista.DataSource = _bll.ListarTabla();
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            if (dgvLista.Columns.Count == 0) return;
            dgvLista.Columns["IdUsuario"].HeaderText = "Código";
            dgvLista.Columns["IdUsuario"].Width = 70;
            dgvLista.Columns["NombreUsuario"].HeaderText = "Usuario";
            if (dgvLista.Columns.Contains("Clave")) dgvLista.Columns["Clave"].Visible = false;
            dgvLista.Columns["NombreCompleto"].HeaderText = "Nombre completo";
            dgvLista.Columns["Rol"].HeaderText = "Rol";
            dgvLista.Columns["Estado"].HeaderText = "Activo";
        }

        private void LimpiarFormulario()
        {
            _idActual = 0;
            txtUsuario.Clear();
            txtClave.Clear();
            txtNombre.Clear();
            cboRol.SelectedIndex = -1;
            chkEstado.Checked = true;
            txtUsuario.Focus();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            _idActual = Convert.ToInt32(fila.Cells["IdUsuario"].Value);
            txtUsuario.Text = fila.Cells["NombreUsuario"].Value.ToString();
            txtClave.Text = fila.Cells["Clave"].Value == DBNull.Value
                ? string.Empty : fila.Cells["Clave"].Value.ToString();
            txtNombre.Text = fila.Cells["NombreCompleto"].Value.ToString();
            cboRol.SelectedItem = fila.Cells["Rol"].Value.ToString();
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
                Usuario u = new Usuario
                {
                    IdUsuario = _idActual,
                    NombreUsuario = txtUsuario.Text.Trim(),
                    Clave = txtClave.Text.Trim(),
                    NombreCompleto = txtNombre.Text.Trim(),
                    Rol = cboRol.SelectedItem == null ? string.Empty : cboRol.SelectedItem.ToString(),
                    Estado = chkEstado.Checked
                };

                if (_idActual == 0)
                {
                    _bll.Registrar(u);
                    MessageBox.Show("Usuario registrado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _bll.Modificar(u);
                    MessageBox.Show("Usuario actualizado correctamente.", "Información",
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
                MessageBox.Show("Seleccione un usuario de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea dar de baja el usuario seleccionado?", "Confirmar",
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
