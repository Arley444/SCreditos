using SCreditos.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCreditos.views.dialogs
{
    public partial class CambiarContrasenna : Form
    {
        private Usuario usuario;

        public CambiarContrasenna()
        {
            InitializeComponent();
        }

        private void cambiarContrasenna()
        {
            string nombewUsuario = txtUsuario.Text.Trim().ToUpper();
            string contrasennaActual = txtContrasennaActual.Text.Trim().ToUpper();
            string contrasennaNueva = txtContrasennaNueva.Text.Trim().ToUpper();
            string confirmacionNuevaContrasenna = txtConfirmacionNuevaContrasenna.Text.Trim().ToUpper();

            if (!(String.IsNullOrEmpty(nombewUsuario) | String.IsNullOrEmpty(contrasennaActual) | String.IsNullOrEmpty(contrasennaNueva) | String.IsNullOrEmpty(confirmacionNuevaContrasenna)))
            {
                usuario = new Usuario();
                usuario.setUsuario(nombewUsuario);
                usuario.setContrasenna(contrasennaActual);

                if (usuario.existeUsuario())
                {
                    if (usuario.considenContrasennaUsuario())
                    {
                        if (contrasennaNueva.Equals(confirmacionNuevaContrasenna))
                        {
                            if (usuario.cambiarContraseña(contrasennaNueva))
                            {
                                MessageBox.Show("El cambio de la contraseña se logro con exito.");
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("La contraseña no se logro cambiar.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La nueva contraseña no coinside con su confirmación.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña actual no coinside con el usuario.");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no existe.");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios.");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            cambiarContrasenna();
        }
    }
}
