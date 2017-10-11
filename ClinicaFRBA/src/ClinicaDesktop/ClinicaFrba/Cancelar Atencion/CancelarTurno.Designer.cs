namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelarTurno
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
            this.cmbBoxTurno = new System.Windows.Forms.ComboBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbBoxTipo = new System.Windows.Forms.ComboBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txBoxMotivo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbBoxTurno
            // 
            this.cmbBoxTurno.FormattingEnabled = true;
            this.cmbBoxTurno.Location = new System.Drawing.Point(117, 27);
            this.cmbBoxTurno.Name = "cmbBoxTurno";
            this.cmbBoxTurno.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxTurno.TabIndex = 0;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(22, 30);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(89, 13);
            this.lblTurno.TabIndex = 1;
            this.lblTurno.Text = "Turno a Cancelar";
            this.lblTurno.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(25, 267);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(163, 267);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(22, 71);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(90, 13);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo Cancelación";
            // 
            // cmbBoxTipo
            // 
            this.cmbBoxTipo.FormattingEnabled = true;
            this.cmbBoxTipo.Location = new System.Drawing.Point(117, 68);
            this.cmbBoxTipo.Name = "cmbBoxTipo";
            this.cmbBoxTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxTipo.TabIndex = 5;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(22, 108);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(127, 13);
            this.lblDetalle.TabIndex = 6;
            this.lblDetalle.Text = "Motivo de la Cacelación :";
            // 
            // txBoxMotivo
            // 
            this.txBoxMotivo.Location = new System.Drawing.Point(25, 134);
            this.txBoxMotivo.MaxLength = 50;
            this.txBoxMotivo.Multiline = true;
            this.txBoxMotivo.Name = "txBoxMotivo";
            this.txBoxMotivo.Size = new System.Drawing.Size(213, 127);
            this.txBoxMotivo.TabIndex = 7;
            // 
            // CancelarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 310);
            this.Controls.Add(this.txBoxMotivo);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.cmbBoxTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.cmbBoxTurno);
            this.Name = "CancelarTurno";
            this.Text = "Cancelar Turno";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBoxTurno;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbBoxTipo;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txBoxMotivo;
    }
}