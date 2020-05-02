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
                    new Principal(usuario).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(usuario.validarUsuario(), "Error");
                }            
            }      
        }


    }
}
