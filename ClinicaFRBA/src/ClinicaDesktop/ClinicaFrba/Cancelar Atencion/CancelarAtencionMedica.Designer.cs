namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelarAtencionMedica
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
            this.lblDíasACancelar = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txBoxDetalle = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.cmbBoxTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDíasACancelar
            // 
            this.lblDíasACancelar.AutoSize = true;
            this.lblDíasACancelar.Location = new System.Drawing.Point(142, 19);
            this.lblDíasACancelar.Name = "lblDíasACancelar";
            this.lblDíasACancelar.Size = new System.Drawing.Size(86, 13);
            this.lblDíasACancelar.TabIndex = 0;
            this.lblDíasACancelar.Text = "Días a cancelar:";
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(16, 46);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(126, 13);
            this.lblInicio.TabIndex = 1;
            this.lblInicio.Text = "Inicio rango cancelación:";
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(16, 81);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(115, 13);
            this.lblFin.TabIndex = 2;
            this.lblFin.Text = "Fin rango cancelación:";
            // 
            // FechaDesde
            // 
            this.FechaDesde.Location = new System.Drawing.Point(145, 46);
            this.FechaDesde.Name = "FechaDesde";
            this.FechaDesde.Size = new System.Drawing.Size(200, 20);
            this.FechaDesde.TabIndex = 3;
            // 
            // FechaHasta
            // 
            this.FechaHasta.Location = new System.Drawing.Point(145, 81);
            this.FechaHasta.Name = "FechaHasta";
            this.FechaHasta.Size = new System.Drawing.Size(200, 20);
            this.FechaHasta.TabIndex = 4;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(56, 323);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(270, 323);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Volver";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txBoxDetalle
            // 
            this.txBoxDetalle.Location = new System.Drawing.Point(36, 174);
            this.txBoxDetalle.MaxLength = 50;
            this.txBoxDetalle.Multiline = true;
            this.txBoxDetalle.Name = "txBoxDetalle";
            this.txBoxDetalle.Size = new System.Drawing.Size(309, 127);
            this.txBoxDetalle.TabIndex = 11;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(125, 147);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(128, 13);
            this.lblDetalle.TabIndex = 10;
            this.lblDetalle.Text = "Detalle de la Cacelación :";
            // 
            // cmbBoxTipo
            // 
            this.cmbBoxTipo.FormattingEnabled = true;
            this.cmbBoxTipo.Location = new System.Drawing.Point(145, 113);
            this.cmbBoxTipo.Name = "cmbBoxTipo";
            this.cmbBoxTipo.Size = new System.Drawing.Size(200, 21);
            this.cmbBoxTipo.TabIndex = 9;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(41, 116);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(93, 13);
            this.lblTipo.TabIndex = 8;
            this.lblTipo.Text = "Tipo Cancelación:";
            // 
            // CancelarAtencionMedica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 371);
            this.Controls.Add(this.txBoxDetalle);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.cmbBoxTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.FechaHasta);
            this.Controls.Add(this.FechaDesde);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.lblDíasACancelar);
            this.Name = "CancelarAtencionMedica";
            this.Text = "Cancelar Atencion Medica";
            this.Load += new System.EventHandler(this.CancelarAtencionMedica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDíasACancelar;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.DateTimePicker FechaDesde;
        private System.Windows.Forms.DateTimePicker FechaHasta;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txBoxDetalle;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.ComboBox cmbBoxTipo;
        private System.Windows.Forms.Label lblTipo;
    }
}