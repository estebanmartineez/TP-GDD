namespace ClinicaFrba.Registro_Llegada
{
    partial class RegistroLlegadaBono
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
            this.lblNombreAfiliado = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dgvBonos = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.NumeroBono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreAfiliado
            // 
            this.lblNombreAfiliado.AutoSize = true;
            this.lblNombreAfiliado.Location = new System.Drawing.Point(12, 18);
            this.lblNombreAfiliado.Name = "lblNombreAfiliado";
            this.lblNombreAfiliado.Size = new System.Drawing.Size(44, 13);
            this.lblNombreAfiliado.TabIndex = 0;
            this.lblNombreAfiliado.Text = "Afiliado:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(62, 18);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "label2";
            // 
            // dgvBonos
            // 
            this.dgvBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroBono,
            this.FechaCompra});
            this.dgvBonos.Location = new System.Drawing.Point(12, 54);
            this.dgvBonos.Name = "dgvBonos";
            this.dgvBonos.Size = new System.Drawing.Size(247, 190);
            this.dgvBonos.TabIndex = 4;
            this.dgvBonos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(162, 260);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(22, 260);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Usar Bono";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // NumeroBono
            // 
            this.NumeroBono.HeaderText = "Numero de Bono";
            this.NumeroBono.Name = "NumeroBono";
            // 
            // FechaCompra
            // 
            this.FechaCompra.HeaderText = "Fecha de Compra";
            this.FechaCompra.Name = "FechaCompra";
            // 
            // RegistroLlegadaBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 309);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvBonos);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblNombreAfiliado);
            this.Name = "RegistroLlegadaBono";
            this.Text = "Seleccion de Bono";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreAfiliado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DataGridView dgvBonos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroBono;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompra;
    }
}