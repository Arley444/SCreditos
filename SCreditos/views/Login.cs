using SCreditos.models;
using SCreditos.views.dialogs;
using System;
using System.Windows.Forms;

namespace SCreditos.views
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();

            lblAvisoUsuario.Visible = false;
            lblAvisoPassword.Visible = false;

            txtUsuario.Focus();

        }


        private Boolean validarFormulario()
        {
            Boolean valido = true;

            if ( String.IsNullOrEmpty(txtContrasenna.Text.Trim()) | String.IsNullOrWhiteSpace(txtContrasenna.Text.Trim()))
            {
                valido = false;
                MessageBox.Show("El valor es obligatorio", "Contraseña.");
            }

            if (String.IsNullOrEmpty(txtUsuario.Text.Trim()) | String.IsNullOrWhiteSpace(txtUsuario.Text.Trim()))
            {
                valido = false;
                MessageBox.Show("El valor es obligatorio", "Usuario.");
            }

            return valido;
        }
       

        private void btnIniciarSesion_Click(object sender, System.EventArgs e)
        {
            if (validarFormulario())
            {
                Usuario usuario = new Usuario();
                usuario.setUsuario(txtUsuario.Text.ToUpper().Trim());
                usuario.setContrasenna(txtContrasenna.Text.Trim());

                if (usuario.validarUsuario() == null)
                {
                    lblAvisoUsuario.Visible = false;
                    lblAvisoPassword.Visible = false;
                    new Principal(usuario).Show();
                    this.Hide();
                }
                else
                {
                    if (usuario.validarUsuario().Equals("La contraseña no es valida."))
                    {
                        lblAvisoPassword.Visible = true;
                    }
                    else
                    {
                        lblAvisoPassword.Visible = false;
                    }

                    if (usuario.validarUsuario().Equals("El usuario no es valido."))
                    {
                        lblAvisoUsuario.Visible = true;
                    }
                    else
                    {
                        lblAvisoUsuario.Visible = false;
                    }
                }            
            }      
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCambiarContrasenna_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContrasenna.Clear();

            CambiarContrasenna cambiarContrasenna = new CambiarContrasenna();
            cambiarContrasenna.ShowDialog();
        }

        private void lblCambiarContrasenna_MouseEnter(object sender, EventArgs e)
        {
            lblCambiarContrasenna.ForeColor = System.Drawing.Color.MediumSeaGreen;
        }

        private void lblCambiarContrasenna_MouseLeave(object sender, EventArgs e)
        {
            lblCambiarContrasenna.ForeColor = System.Drawing.Color.RoyalBlue;
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = System.Drawing.Color.MistyRose;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = System.Drawing.Color.Transparent;
        }
    }
}
