namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBono
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
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDownCantBonos = new System.Windows.Forms.NumericUpDown();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalNum = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCompraAf = new System.Windows.Forms.Label();
            this.lblNombreAfiliado = new System.Windows.Forms.Label();
            this.lblprecioBono = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad";
            // 
            // numUpDownCantBonos
            // 
            this.numUpDownCantBonos.Location = new System.Drawing.Point(75, 111);
            this.numUpDownCantBonos.Name = "numUpDownCantBonos";
            this.numUpDownCantBonos.Size = new System.Drawing.Size(55, 20);
            this.numUpDownCantBonos.TabIndex = 1;
            this.numUpDownCantBonos.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 153);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(89, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total a Pagar:   $";
            // 
            // lblTotalNum
            // 
            this.lblTotalNum.AutoSize = true;
            this.lblTotalNum.Location = new System.Drawing.Point(98, 153);
            this.lblTotalNum.Name = "lblTotalNum";
            this.lblTotalNum.Size = new System.Drawing.Size(13, 13);
            this.lblTotalNum.TabIndex = 3;
            this.lblTotalNum.Text = "0";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(16, 185);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(120, 185);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCompraAf
            // 
            this.lblCompraAf.AutoSize = true;
            this.lblCompraAf.Location = new System.Drawing.Point(13, 21);
            this.lblCompraAf.Name = "lblCompraAf";
            this.lblCompraAf.Size = new System.Drawing.Size(117, 13);
            this.lblCompraAf.TabIndex = 6;
            this.lblCompraAf.Text = "Compra para el afiliado:";
            // 
            // lblNombreAfiliado
            // 
            this.lblNombreAfiliado.AutoSize = true;
            this.lblNombreAfiliado.Location = new System.Drawing.Point(12, 43);
            this.lblNombreAfiliado.Name = "lblNombreAfiliado";
            this.lblNombreAfiliado.Size = new System.Drawing.Size(35, 13);
            this.lblNombreAfiliado.TabIndex = 7;
            this.lblNombreAfiliado.Text = "Lablel";
            this.lblNombreAfiliado.Click += new System.EventHandler(this.lblNombreAfiliado_Click);
            // 
            // lblprecioBono
            // 
            this.lblprecioBono.AutoSize = true;
            this.lblprecioBono.Location = new System.Drawing.Point(16, 76);
            this.lblprecioBono.Name = "lblprecioBono";
            this.lblprecioBono.Size = new System.Drawing.Size(142, 13);
            this.lblprecioBono.TabIndex = 8;
            this.lblprecioBono.Text = "Precio Unitario del Bono:   $ ";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(154, 76);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(13, 13);
            this.lblMonto.TabIndex = 9;
            this.lblMonto.Text = "0";
            // 
            // CompraBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 229);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblprecioBono);
            this.Controls.Add(this.lblNombreAfiliado);
            this.Controls.Add(this.lblCompraAf);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTotalNum);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.numUpDownCantBonos);
            this.Controls.Add(this.label1);
            this.Name = "CompraBono";
            this.Text = "Compra de Bono";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownCantBonos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalNum;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCompraAf;
        private System.Windows.Forms.Label lblNombreAfiliado;
        private System.Windows.Forms.Label lblprecioBono;
        private System.Windows.Forms.Label lblMonto;
    }
}