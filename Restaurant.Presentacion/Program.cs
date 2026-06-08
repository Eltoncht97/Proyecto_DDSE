using System;
using System.Windows.Forms;
using Restaurant.Entidades;

namespace Restaurant.Presentacion
{
    static class Program
    {
        public static Usuario UsuarioActual;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FrmLogin login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FrmPrincipal());
                }
            }
        }
    }
}
