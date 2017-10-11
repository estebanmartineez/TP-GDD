namespace ClinicaFrba.Registro_Resultado
{
    partial class ConfirmarDiagnostico
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
            this.lblDatos = new System.Windows.Forms.Label();
            this.txtBoxDiagnostico = new System.Windows.Forms.RichTextBox();
            this.txtBoxSintomas = new System.Windows.Forms.RichTextBox();
            this.lblSintomas = new System.Windows.Forms.Label();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Location = new System.Drawing.Point(12, 9);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(90, 13);
            this.lblDatos.TabIndex = 0;
            this.lblDatos.Text = "-seAutoCompleta-";
            this.lblDatos.Click += new System.EventHandler(this.lblDatos_Click);
            // 
            // txtBoxDiagnostico
            // 
            this.txtBoxDiagnostico.Location = new System.Drawing.Point(12, 126);
            this.txtBoxDiagnostico.Name = "txtBoxDiagnostico";
            this.txtBoxDiagnostico.Size = new System.Drawing.Size(260, 124);
            this.txtBoxDiagnostico.TabIndex = 2;
            this.txtBoxDiagnostico.Text = "";
            this.txtBoxDiagnostico.TextChanged += new System.EventHandler(this.txtBoxDiagnostico_TextChanged);
            // 
            // txtBoxSintomas
            // 
            this.txtBoxSintomas.Location = new System.Drawing.Point(15, 49);
            this.txtBoxSintomas.Name = "txtBoxSintomas";
            this.txtBoxSintomas.Size = new System.Drawing.Size(257, 54);
            this.txtBoxSintomas.TabIndex = 3;
            this.txtBoxSintomas.Text = "";
            this.txtBoxSintomas.TextChanged += new System.EventHandler(this.txtBoxSintomas_TextChanged);
            // 
            // lblSintomas
            // 
            this.lblSintomas.AutoSize = true;
            this.lblSintomas.Location = new System.Drawing.Point(15, 30);
            this.lblSintomas.Name = "lblSintomas";
            this.lblSintomas.Size = new System.Drawing.Size(53, 13);
            this.lblSintomas.TabIndex = 4;
            this.lblSintomas.Text = "Sintomas:";
            this.lblSintomas.Click += new System.EventHandler(this.lblSintomas_Click);
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Location = new System.Drawing.Point(15, 110);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(66, 13);
            this.lblDiagnostico.TabIndex = 5;
            this.lblDiagnostico.Text = "Diagnostico:";
            this.lblDiagnostico.Click += new System.EventHandler(this.lblDiagnostico_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(12, 281);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(199, 281);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ConfirmarDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 316);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.lblSintomas);
            this.Controls.Add(this.txtBoxSintomas);
            this.Controls.Add(this.txtBoxDiagnostico);
            this.Controls.Add(this.lblDatos);
            this.Name = "ConfirmarDiagnostico";
            this.Text = "Confirmar Diagnostico";
            this.Load += new System.EventHandler(this.ConfirmarDiagnostico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.RichTextBox txtBoxDiagnostico;
        private System.Windows.Forms.RichTextBox txtBoxSintomas;
        private System.Windows.Forms.Label lblSintomas;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}