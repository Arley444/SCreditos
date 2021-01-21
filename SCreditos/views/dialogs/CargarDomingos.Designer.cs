namespace SCreditos.views.dialogs
{
    partial class CargarDomingos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargarDomingos));
            this.chkAbono = new System.Windows.Forms.CheckBox();
            this.cboDomingos = new System.Windows.Forms.ComboBox();
            this.lblDomingos = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAbono
            // 
            this.chkAbono.AutoSize = true;
            this.chkAbono.Location = new System.Drawing.Point(67, 81);
            this.chkAbono.Name = "chkAbono";
            this.chkAbono.Size = new System.Drawing.Size(15, 14);
            this.chkAbono.TabIndex = 0;
            this.chkAbono.UseVisualStyleBackColor = true;
            this.chkAbono.CheckStateChanged += new System.EventHandler(this.chkAbono_CheckStateChanged);
            // 
            // cboDomingos
            // 
            this.cboDomingos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDomingos.FormattingEnabled = true;
            this.cboDomingos.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cboDomingos.Location = new System.Drawing.Point(109, 29);
            this.cboDomingos.Name = "cboDomingos";
            this.cboDomingos.Size = new System.Drawing.Size(121, 21);
            this.cboDomingos.TabIndex = 1;
            // 
            // lblDomingos
            // 
            this.lblDomingos.AutoSize = true;
            this.lblDomingos.Location = new System.Drawing.Point(39, 32);
            this.lblDomingos.Name = "lblDomingos";
            this.lblDomingos.Size = new System.Drawing.Size(54, 13);
            this.lblDomingos.TabIndex = 2;
            this.lblDomingos.Text = "Domingos";
            // 
            // txtAbono
            // 
            this.txtAbono.Location = new System.Drawing.Point(88, 78);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.Size = new System.Drawing.Size(100, 20);
            this.txtAbono.TabIndex = 3;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(42, 149);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(139, 149);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // CargarDomingos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 200);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtAbono);
            this.Controls.Add(this.lblDomingos);
            this.Controls.Add(this.cboDomingos);
            this.Controls.Add(this.chkAbono);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CargarDomingos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CargarDomingos";
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAbono;
        private System.Windows.Forms.ComboBox cboDomingos;
        private System.Windows.Forms.Label lblDomingos;
        private System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ErrorProvider error;
    }
}