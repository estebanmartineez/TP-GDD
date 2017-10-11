namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class SeleccionarProfecional
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
            this.dataGridViewProfecionales = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAgregarAgenda = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnHorasAcumuladas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfecionales)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProfecionales
            // 
            this.dataGridViewProfecionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProfecionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.columnNombre,
            this.columnApellido,
            this.columnHorasAcumuladas});
            this.dataGridViewProfecionales.Location = new System.Drawing.Point(53, 26);
            this.dataGridViewProfecionales.Name = "dataGridViewProfecionales";
            this.dataGridViewProfecionales.Size = new System.Drawing.Size(436, 232);
            this.dataGridViewProfecionales.TabIndex = 0;
            this.dataGridViewProfecionales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(139, 274);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Vovler";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAgregarAgenda
            // 
            this.btnAgregarAgenda.Location = new System.Drawing.Point(287, 274);
            this.btnAgregarAgenda.Name = "btnAgregarAgenda";
            this.btnAgregarAgenda.Size = new System.Drawing.Size(116, 23);
            this.btnAgregarAgenda.TabIndex = 2;
            this.btnAgregarAgenda.Text = "Agregar Agenda";
            this.btnAgregarAgenda.UseVisualStyleBackColor = true;
            this.btnAgregarAgenda.Click += new System.EventHandler(this.btnAgregarAgenda_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // columnNombre
            // 
            this.columnNombre.HeaderText = "Nombre";
            this.columnNombre.Name = "columnNombre";
            // 
            // columnApellido
            // 
            this.columnApellido.HeaderText = "Apellido";
            this.columnApellido.Name = "columnApellido";
            // 
            // columnHorasAcumuladas
            // 
            this.columnHorasAcumuladas.HeaderText = "Horas Acumuladas";
            this.columnHorasAcumuladas.Name = "columnHorasAcumuladas";
            // 
            // SeleccionarProfecional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 309);
            this.Controls.Add(this.btnAgregarAgenda);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dataGridViewProfecionales);
            this.Name = "SeleccionarProfecional";
            this.Text = "SeleccionarProfecional";
            this.Load += new System.EventHandler(this.SeleccionarProfecional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfecionales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProfecionales;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAgregarAgenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnHorasAcumuladas;
    }
}