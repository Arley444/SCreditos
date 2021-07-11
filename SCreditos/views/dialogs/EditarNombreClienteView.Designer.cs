namespace SCreditos.views.dialogs
{
    partial class EditarNombreClienteView
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCapital = new System.Windows.Forms.Label();
            this.btnCambiarNombre = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(97, 21);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 26;
            // 
            // lblCapital
            // 
            this.lblCapital.AutoSize = true;
            this.lblCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapital.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCapital.Location = new System.Drawing.Point(31, 24);
            this.lblCapital.Name = "lblCapital";
            this.lblCapital.Size = new System.Drawing.Size(54, 13);
            this.lblCapital.TabIndex = 25;
            this.lblCapital.Text = "Nombre:";
            // 
            // btnCambiarNombre
            // 
            this.btnCambiarNombre.Location = new System.Drawing.Point(80, 65);
            this.btnCambiarNombre.Name = "btnCambiarNombre";
            this.btnCambiarNombre.Size = new System.Drawing.Size(75, 23);
            this.btnCambiarNombre.TabIndex = 24;
            this.btnCambiarNombre.Text = "Cambiar";
            this.btnCambiarNombre.UseVisualStyleBackColor = true;
            this.btnCambiarNombre.Click += new System.EventHandler(this.btnCambiarNombre_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // EditarNombreClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 108);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblCapital);
            this.Controls.Add(this.btnCambiarNombre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarNombreClienteView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Nombre";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCapital;
        private System.Windows.Forms.Button btnCambiarNombre;
        private System.Windows.Forms.ErrorProvider error;
    }
}