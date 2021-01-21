namespace SCreditos.views
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.lblusuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasenna = new System.Windows.Forms.TextBox();
            this.lblContrasenna = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAvisoUsuario = new System.Windows.Forms.Label();
            this.lblAvisoPassword = new System.Windows.Forms.Label();
            this.lblCambiarContrasenna = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnIniciarSesion.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.Location = new System.Drawing.Point(455, 377);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(79, 32);
            this.btnIniciarSesion.TabIndex = 0;
            this.btnIniciarSesion.Text = "Iniciar";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.Location = new System.Drawing.Point(387, 155);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(59, 20);
            this.lblusuario.TabIndex = 1;
            this.lblusuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(391, 178);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(216, 28);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Text = "SANDRA";
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContrasenna
            // 
            this.txtContrasenna.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasenna.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenna.Location = new System.Drawing.Point(391, 298);
            this.txtContrasenna.Name = "txtContrasenna";
            this.txtContrasenna.PasswordChar = '*';
            this.txtContrasenna.Size = new System.Drawing.Size(216, 28);
            this.txtContrasenna.TabIndex = 4;
            this.txtContrasenna.Text = "0987654321";
            this.txtContrasenna.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblContrasenna
            // 
            this.lblContrasenna.AutoSize = true;
            this.lblContrasenna.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenna.Location = new System.Drawing.Point(387, 275);
            this.lblContrasenna.Name = "lblContrasenna";
            this.lblContrasenna.Size = new System.Drawing.Size(83, 20);
            this.lblContrasenna.TabIndex = 3;
            this.lblContrasenna.Text = "Contraseña";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Location = new System.Drawing.Point(391, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 3);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Location = new System.Drawing.Point(391, 325);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 3);
            this.panel2.TabIndex = 10;
            // 
            // lblAvisoUsuario
            // 
            this.lblAvisoUsuario.AutoSize = true;
            this.lblAvisoUsuario.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoUsuario.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoUsuario.Location = new System.Drawing.Point(394, 213);
            this.lblAvisoUsuario.Name = "lblAvisoUsuario";
            this.lblAvisoUsuario.Size = new System.Drawing.Size(129, 13);
            this.lblAvisoUsuario.TabIndex = 11;
            this.lblAvisoUsuario.Text = "¡El usuario no es valido!";
            // 
            // lblAvisoPassword
            // 
            this.lblAvisoPassword.AutoSize = true;
            this.lblAvisoPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoPassword.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoPassword.Location = new System.Drawing.Point(393, 331);
            this.lblAvisoPassword.Name = "lblAvisoPassword";
            this.lblAvisoPassword.Size = new System.Drawing.Size(148, 13);
            this.lblAvisoPassword.TabIndex = 12;
            this.lblAvisoPassword.Text = "¡La contraseña no es valida!";
            // 
            // lblCambiarContrasenna
            // 
            this.lblCambiarContrasenna.AutoSize = true;
            this.lblCambiarContrasenna.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambiarContrasenna.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCambiarContrasenna.Location = new System.Drawing.Point(407, 485);
            this.lblCambiarContrasenna.Name = "lblCambiarContrasenna";
            this.lblCambiarContrasenna.Size = new System.Drawing.Size(170, 13);
            this.lblCambiarContrasenna.TabIndex = 13;
            this.lblCambiarContrasenna.Text = "¿Deseas cambiar tu contraseña?";
            this.lblCambiarContrasenna.Click += new System.EventHandler(this.lblCambiarContrasenna_Click);
            this.lblCambiarContrasenna.MouseEnter += new System.EventHandler(this.lblCambiarContrasenna_MouseEnter);
            this.lblCambiarContrasenna.MouseLeave += new System.EventHandler(this.lblCambiarContrasenna_MouseLeave);
            // 
            // label1
            // 
            this.label1.Image = global::SCreditos.Properties.Resources.login;
            this.label1.Location = new System.Drawing.Point(452, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 81);
            this.label1.TabIndex = 14;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Image = global::SCreditos.Properties.Resources.cancel;
            this.btnCerrar.Location = new System.Drawing.Point(614, 7);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(26, 24);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.btnCerrar_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SCreditos.Properties.Resources.Login_v1;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 533);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(649, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCambiarContrasenna);
            this.Controls.Add(this.lblAvisoPassword);
            this.Controls.Add(this.lblAvisoUsuario);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtContrasenna);
            this.Controls.Add(this.lblContrasenna);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasenna;
        private System.Windows.Forms.Label lblContrasenna;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAvisoUsuario;
        private System.Windows.Forms.Label lblAvisoPassword;
        private System.Windows.Forms.Label lblCambiarContrasenna;
        private System.Windows.Forms.Label label1;
    }
}