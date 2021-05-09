namespace SCreditos.views.dialogs
{
    partial class CargarCarteraView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tablaContabilidades = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.cboFechaInicial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFechaFinal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCobro = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaContabilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tablaContabilidades);
            this.panel1.Location = new System.Drawing.Point(23, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 290);
            this.panel1.TabIndex = 0;
            // 
            // tablaContabilidades
            // 
            this.tablaContabilidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaContabilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaContabilidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaContabilidades.Location = new System.Drawing.Point(0, 0);
            this.tablaContabilidades.Name = "tablaContabilidades";
            this.tablaContabilidades.ReadOnly = true;
            this.tablaContabilidades.Size = new System.Drawing.Size(704, 290);
            this.tablaContabilidades.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(144, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Guardar cantabilidades desde: ";
            // 
            // cboFechaInicial
            // 
            this.cboFechaInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFechaInicial.FormattingEnabled = true;
            this.cboFechaInicial.Location = new System.Drawing.Point(304, 87);
            this.cboFechaInicial.Name = "cboFechaInicial";
            this.cboFechaInicial.Size = new System.Drawing.Size(121, 21);
            this.cboFechaInicial.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "hasta";
            // 
            // cboFechaFinal
            // 
            this.cboFechaFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFechaFinal.FormattingEnabled = true;
            this.cboFechaFinal.Location = new System.Drawing.Point(474, 87);
            this.cboFechaFinal.Name = "cboFechaFinal";
            this.cboFechaFinal.Size = new System.Drawing.Size(121, 21);
            this.cboFechaFinal.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Cobro: ";
            // 
            // lblCobro
            // 
            this.lblCobro.AutoSize = true;
            this.lblCobro.Location = new System.Drawing.Point(67, 19);
            this.lblCobro.Name = "lblCobro";
            this.lblCobro.Size = new System.Drawing.Size(41, 13);
            this.lblCobro.TabIndex = 28;
            this.lblCobro.Text = "Cobro: ";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(621, 85);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // CargarCarteraView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 470);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblCobro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFechaFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboFechaInicial);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Name = "CargarCarteraView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Guardar Cartera";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaContabilidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tablaContabilidades;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboFechaInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCobro;
        private System.Windows.Forms.Button btnGuardar;
    }
}