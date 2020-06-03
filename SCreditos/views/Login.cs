using SCreditos.models;
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
    }
}
