namespace SCreditos.views.dialogs
{
    partial class EliminarAbonoView
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
            this.lblCapital = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorRestante = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminarAbono = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCapital
            // 
            this.lblCapital.AutoSize = true;
            this.lblCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapital.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCapital.Location = new System.Drawing.Point(34, 28);
            this.lblCapital.Name = "lblCapital";
            this.lblCapital.Size = new System.Drawing.Size(46, 13);
            this.lblCapital.TabIndex = 19;
            this.lblCapital.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(83, 25);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(73, 20);
            this.txtFecha.TabIndex = 20;
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(233, 25);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.ReadOnly = true;
            this.txtValorPago.Size = new System.Drawing.Size(73, 20);
            this.txtValorPago.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(162, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Valor Pago:";
            // 
            // txtValorRestante
            // 
            this.txtValorRestante.Location = new System.Drawing.Point(404, 25);
            this.txtValorRestante.Name = "txtValorRestante";
            this.txtValorRestante.ReadOnly = true;
            this.txtValorRestante.Size = new System.Drawing.Size(73, 20);
            this.txtValorRestante.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(310, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Valor Restante:";
            // 
            // btnEliminarAbono
            // 
            this.btnEliminarAbono.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarAbono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarAbono.Image = global::SCreditos.Properties.Resources.documento;
            this.btnEliminarAbono.Location = new System.Drawing.Point(494, 21);
            this.btnEliminarAbono.Name = "btnEliminarAbono";
            this.btnEliminarAbono.Size = new System.Drawing.Size(29, 28);
            this.btnEliminarAbono.TabIndex = 31;
            this.btnEliminarAbono.Click += new System.EventHandler(this.btnEliminarAbono_Click);
            this.btnEliminarAbono.MouseEnter += new System.EventHandler(this.btnEliminarAbono_MouseEnter);
            this.btnEliminarAbono.MouseLeave += new System.EventHandler(this.btnEliminarAbono_MouseLeave);
            // 
            // EliminarAbonoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 64);
            this.Controls.Add(this.btnEliminarAbono);
            this.Controls.Add(this.txtValorRestante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.lblCapital);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EliminarAbonoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle Abono";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCapital;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValorRestante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnEliminarAbono;
    }
}