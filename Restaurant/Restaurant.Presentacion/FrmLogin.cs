using System;
using System.Windows.Forms;
using Restaurant.Entidades;
using Restaurant.Negocio;
using Restaurant.Presentacion.Estilos;
using Restaurant.Presentacion.Iconos;

namespace Restaurant.Presentacion
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioBLL _bll = new UsuarioBLL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TemaModerno.EstilizarFormulario(this);
            TemaModerno.EstilizarTextBox(txtUsuario);
            TemaModerno.EstilizarTextBox(txtClave);
            TemaModerno.EstilizarBotonSuccess(btnIngresar);
            TemaModerno.EstilizarBotonSecundario(btnCancelar);
            btnIngresar.Text = IconosUI.Login;
            btnCancelar.Text = IconosUI.Cancelar;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario u = _bll.IniciarSesion(txtUsuario.Text.Trim(), txtClave.Text);
                Program.UsuarioActual = u;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
