namespace SCreditos.views.dialogs
{
    partial class EditarTelefonoClienteView
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
            this.components = new System.ComponentModel.Container();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCapital = new System.Windows.Forms.Label();
            this.btnCambiarTelefono = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(90, 25);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 20;
            // 
            // lblCapital
            // 
            this.lblCapital.AutoSize = true;
            this.lblCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapital.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCapital.Location = new System.Drawing.Point(31, 28);
            this.lblCapital.Name = "lblCapital";
            this.lblCapital.Size = new System.Drawing.Size(61, 13);
            this.lblCapital.TabIndex = 19;
            this.lblCapital.Text = "Telefono:";
            // 
            // btnCambiarTelefono
            // 
            this.btnCambiarTelefono.Location = new System.Drawing.Point(73, 69);
            this.btnCambiarTelefono.Name = "btnCambiarTelefono";
            this.btnCambiarTelefono.Size = new System.Drawing.Size(75, 23);
            this.btnCambiarTelefono.TabIndex = 18;
            this.btnCambiarTelefono.Text = "Cambiar";
            this.btnCambiarTelefono.UseVisualStyleBackColor = true;
            this.btnCambiarTelefono.Click += new System.EventHandler(this.btnCambiarTelefono_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // EditarTelefonoClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 108);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblCapital);
            this.Controls.Add(this.btnCambiarTelefono);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarTelefonoClienteView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Telefono";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCapital;
        private System.Windows.Forms.Button btnCambiarTelefono;
        private System.Windows.Forms.ErrorProvider error;
    }
}