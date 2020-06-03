namespace SCreditos.views.dialogs
{
    partial class CarteraTirilla
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
            this.tablaCarteras = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaCarteras)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaCarteras
            // 
            this.tablaCarteras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaCarteras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaCarteras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaCarteras.Location = new System.Drawing.Point(0, 0);
            this.tablaCarteras.MultiSelect = false;
            this.tablaCarteras.Name = "tablaCarteras";
            this.tablaCarteras.ReadOnly = true;
            this.tablaCarteras.Size = new System.Drawing.Size(1236, 352);
            this.tablaCarteras.TabIndex = 0;
            // 
            // CarteraTirilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 352);
            this.Controls.Add(this.tablaCarteras);
            this.MinimizeBox = false;
            this.Name = "CarteraTirilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarteraTirilla";
            ((System.ComponentModel.ISupportInitialize)(this.tablaCarteras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaCarteras;
    }
}