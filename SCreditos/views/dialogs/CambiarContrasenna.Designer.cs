namespace SCreditos.views.dialogs
{
    partial class CambiarContrasenna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarContrasenna));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasennaActual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmacionNuevaContrasenna = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContrasennaNueva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(111, 250);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(269, 48);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // txtContrasennaActual
            // 
            this.txtContrasennaActual.Location = new System.Drawing.Point(269, 89);
            this.txtContrasennaActual.Name = "txtContrasennaActual";
            this.txtContrasennaActual.PasswordChar = '*';
            this.txtContrasennaActual.Size = new System.Drawing.Size(100, 20);
            this.txtContrasennaActual.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña Actual:";
            // 
            // txtConfirmacionNuevaContrasenna
            // 
            this.txtConfirmacionNuevaContrasenna.Location = new System.Drawing.Point(269, 175);
            this.txtConfirmacionNuevaContrasenna.Name = "txtConfirmacionNuevaContrasenna";
            this.txtConfirmacionNuevaContrasenna.PasswordChar = '*';
            this.txtConfirmacionNuevaContrasenna.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmacionNuevaContrasenna.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirmación Nueva Contraseña:";
            // 
            // txtContrasennaNueva
            // 
            this.txtContrasennaNueva.Location = new System.Drawing.Point(269, 127);
            this.txtContrasennaNueva.Name = "txtContrasennaNueva";
            this.txtContrasennaNueva.PasswordChar = '*';
            this.txtContrasennaNueva.Size = new System.Drawing.Size(100, 20);
            this.txtContrasennaNueva.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nueva Contraseña:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(249, 250);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // CambiarContrasenna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 311);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtContrasennaNueva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConfirmacionNuevaContrasenna);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContrasennaActual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CambiarContrasenna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CambiarContrasenna";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasennaActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfirmacionNuevaContrasenna;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContrasennaNueva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnviar;
    }
}