namespace SCreditos.views.dialogs
{
    partial class EditarCedulaClienteView
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
            this.btnCambiarCedula = new System.Windows.Forms.Button();
            this.lblCapital = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCambiarCedula
            // 
            this.btnCambiarCedula.Location = new System.Drawing.Point(69, 72);
            this.btnCambiarCedula.Name = "btnCambiarCedula";
            this.btnCambiarCedula.Size = new System.Drawing.Size(75, 23);
            this.btnCambiarCedula.TabIndex = 15;
            this.btnCambiarCedula.Text = "Cambiar";
            this.btnCambiarCedula.UseVisualStyleBackColor = true;
            this.btnCambiarCedula.Click += new System.EventHandler(this.btnCambiarCedula_Click);
            // 
            // lblCapital
            // 
            this.lblCapital.AutoSize = true;
            this.lblCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapital.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCapital.Location = new System.Drawing.Point(30, 31);
            this.lblCapital.Name = "lblCapital";
            this.lblCapital.Size = new System.Drawing.Size(50, 13);
            this.lblCapital.TabIndex = 16;
            this.lblCapital.Text = "Cedula:";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(86, 28);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(100, 20);
            this.txtCedula.TabIndex = 17;
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // EditarCedulaClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 108);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.lblCapital);
            this.Controls.Add(this.btnCambiarCedula);
            this.MaximizeBox = false;
            this.Name = "EditarCedulaClienteView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Cedula ";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCambiarCedula;
        private System.Windows.Forms.Label lblCapital;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.ErrorProvider error;
    }
}