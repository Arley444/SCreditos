namespace SCreditos.views.dialogs
{
    partial class EditarDireccionClienteView
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
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblCapital = new System.Windows.Forms.Label();
            this.btnCambiarDireccion = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(94, 21);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 23;
            // 
            // lblCapital
            // 
            this.lblCapital.AutoSize = true;
            this.lblCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapital.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCapital.Location = new System.Drawing.Point(28, 24);
            this.lblCapital.Name = "lblCapital";
            this.lblCapital.Size = new System.Drawing.Size(65, 13);
            this.lblCapital.TabIndex = 22;
            this.lblCapital.Text = "Direccion:";
            // 
            // btnCambiarDireccion
            // 
            this.btnCambiarDireccion.Location = new System.Drawing.Point(77, 65);
            this.btnCambiarDireccion.Name = "btnCambiarDireccion";
            this.btnCambiarDireccion.Size = new System.Drawing.Size(75, 23);
            this.btnCambiarDireccion.TabIndex = 21;
            this.btnCambiarDireccion.Text = "Cambiar";
            this.btnCambiarDireccion.UseVisualStyleBackColor = true;
            this.btnCambiarDireccion.Click += new System.EventHandler(this.btnCambiarDireccion_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // EditarDireccionClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 108);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblCapital);
            this.Controls.Add(this.btnCambiarDireccion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarDireccionClienteView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Direccion";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblCapital;
        private System.Windows.Forms.Button btnCambiarDireccion;
        private System.Windows.Forms.ErrorProvider error;
    }
}