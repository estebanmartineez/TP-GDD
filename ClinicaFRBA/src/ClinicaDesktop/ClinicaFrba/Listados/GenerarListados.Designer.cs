namespace ClinicaFrba.Listados
{
    partial class GenerarListado
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
            this.lblListado = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cboListado = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCuatrimestre = new System.Windows.Forms.Label();
            this.lblAno = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.lblmes = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboSemestre = new System.Windows.Forms.ComboBox();
            this.btnHacerListado = new System.Windows.Forms.Button();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cboPlan = new System.Windows.Forms.ComboBox();
            this.cboEspecialidad = new System.Windows.Forms.ComboBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListado
            // 
            this.lblListado.AutoSize = true;
            this.lblListado.Location = new System.Drawing.Point(13, 13);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(111, 13);
            this.lblListado.TabIndex = 0;
            this.lblListado.Text = "Seleccione el Listado:";
            this.lblListado.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboListado
            // 
            this.cboListado.FormattingEnabled = true;
            this.cboListado.Location = new System.Drawing.Point(169, 10);
            this.cboListado.Name = "cboListado";
            this.cboListado.Size = new System.Drawing.Size(206, 21);
            this.cboListado.TabIndex = 1;
            this.cboListado.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(359, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblCuatrimestre
            // 
            this.lblCuatrimestre.AutoSize = true;
            this.lblCuatrimestre.Location = new System.Drawing.Point(12, 122);
            this.lblCuatrimestre.Name = "lblCuatrimestre";
            this.lblCuatrimestre.Size = new System.Drawing.Size(121, 13);
            this.lblCuatrimestre.TabIndex = 3;
            this.lblCuatrimestre.Text = "Seleccione el Semestre:";
            this.lblCuatrimestre.Click += new System.EventHandler(this.lblCuatrimestre_Click);
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(12, 94);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(96, 13);
            this.lblAno.TabIndex = 4;
            this.lblAno.Text = "Seleccione el Año:";
            this.lblAno.Click += new System.EventHandler(this.label3_Click);
            // 
            // cboAño
            // 
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(169, 91);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(206, 21);
            this.cboAño.TabIndex = 5;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lblmes
            // 
            this.lblmes.AutoSize = true;
            this.lblmes.Location = new System.Drawing.Point(12, 147);
            this.lblmes.Name = "lblmes";
            this.lblmes.Size = new System.Drawing.Size(97, 13);
            this.lblmes.TabIndex = 6;
            this.lblmes.Text = "Seleccione el Mes:";
            this.lblmes.Click += new System.EventHandler(this.lblmes_Click);
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(169, 145);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(206, 21);
            this.cboMes.TabIndex = 8;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // cboSemestre
            // 
            this.cboSemestre.FormattingEnabled = true;
            this.cboSemestre.Location = new System.Drawing.Point(169, 119);
            this.cboSemestre.Name = "cboSemestre";
            this.cboSemestre.Size = new System.Drawing.Size(206, 21);
            this.cboSemestre.TabIndex = 7;
            this.cboSemestre.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // btnHacerListado
            // 
            this.btnHacerListado.Location = new System.Drawing.Point(16, 179);
            this.btnHacerListado.Name = "btnHacerListado";
            this.btnHacerListado.Size = new System.Drawing.Size(75, 23);
            this.btnHacerListado.TabIndex = 9;
            this.btnHacerListado.Text = "Buscar";
            this.btnHacerListado.UseVisualStyleBackColor = true;
            this.btnHacerListado.Click += new System.EventHandler(this.btnHacerListado_Click_1);
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(13, 40);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(102, 13);
            this.lblPlan.TabIndex = 10;
            this.lblPlan.Text = "Seleccione un Plan:";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(13, 67);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(147, 13);
            this.lblEspecialidad.TabIndex = 11;
            this.lblEspecialidad.Text = "Seleccione una Especialidad:";
            // 
            // cboPlan
            // 
            this.cboPlan.FormattingEnabled = true;
            this.cboPlan.Location = new System.Drawing.Point(169, 37);
            this.cboPlan.Name = "cboPlan";
            this.cboPlan.Size = new System.Drawing.Size(206, 21);
            this.cboPlan.TabIndex = 12;
            this.cboPlan.SelectedIndexChanged += new System.EventHandler(this.cboPlan_SelectedIndexChanged);
            // 
            // cboEspecialidad
            // 
            this.cboEspecialidad.FormattingEnabled = true;
            this.cboEspecialidad.Location = new System.Drawing.Point(169, 64);
            this.cboEspecialidad.Name = "cboEspecialidad";
            this.cboEspecialidad.Size = new System.Drawing.Size(206, 21);
            this.cboEspecialidad.TabIndex = 13;
            this.cboEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cboEspecialidad_SelectedIndexChanged);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(300, 179);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 14;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // GenerarListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 370);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.cboEspecialidad);
            this.Controls.Add(this.cboPlan);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.lblPlan);
            this.Controls.Add(this.btnHacerListado);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.cboSemestre);
            this.Controls.Add(this.lblmes);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.lblCuatrimestre);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cboListado);
            this.Controls.Add(this.lblListado);
            this.Name = "GenerarListado";
            this.Text = "grid";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox cboListado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCuatrimestre;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label lblmes;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboSemestre;
        private System.Windows.Forms.Button btnHacerListado;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cboPlan;
        private System.Windows.Forms.ComboBox cboEspecialidad;
        private System.Windows.Forms.Button btnFinalizar;
    }
}