using System;
using CapaNegocio;
using Entidades;
using System.Windows.Forms;
using System.Diagnostics;

/// <author> Francisco David Manzanedo Valle.</author>
namespace Presentacion
{
    public partial class FormLogin : Form
    {
        private FormMDIMenuPrincipal _formMenuPrincipal;
        private readonly Universidad _universidad;
        private byte _intentos;
        private readonly Usuario _usuario;

        public FormLogin()
        {
            InitializeComponent();
            _universidad = new Universidad();
            _usuario = new Usuario();
            _intentos = 3;
            lblResultado.Visible = false;

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool resultado = _universidad.LoginUsuario(TxtUsername.Text, TxtPass.Text);
            if (resultado)
            {
                lblResultado.Visible = false;
                _formMenuPrincipal = new FormMDIMenuPrincipal(TxtUsername.Text);
                _formMenuPrincipal.Show();
                this.Hide();
            }
            else
            {
                _intentos--;
                lblResultado.Visible = true;
                lblResultado.Text = "Acceso denegado. Quedan: " + _intentos + " intentos.";
            }

            if (_intentos == 0)
                Application.Exit();

        }

        private void TxtUsername_MouseClick(object sender, MouseEventArgs e) => TxtUsername.Text = "";

        private void TxtPass_MouseClick(object sender, MouseEventArgs e) => TxtPass.Text = "";
       
    }
}
