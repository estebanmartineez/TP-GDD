namespace ClinicaFrba.Abm_Afiliado
{
    partial class HistorialPlanes
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
            this.grdHistorial = new System.Windows.Forms.DataGridView();
            this.IdHistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // grdHistorial
            // 
            this.grdHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdHistorico,
            this.IdUsuario,
            this.CodPlan,
            this.FechaModificacion,
            this.MotivoModificacion});
            this.grdHistorial.Location = new System.Drawing.Point(32, 26);
            this.grdHistorial.Name = "grdHistorial";
            this.grdHistorial.Size = new System.Drawing.Size(444, 176);
            this.grdHistorial.TabIndex = 0;
            // 
            // IdHistorico
            // 
            this.IdHistorico.HeaderText = "IdHistorico";
            this.IdHistorico.Name = "IdHistorico";
            this.IdHistorico.Visible = false;
            // 
            // IdUsuario
            // 
            this.IdUsuario.HeaderText = "Usuario";
            this.IdUsuario.Name = "IdUsuario";
            // 
            // CodPlan
            // 
            this.CodPlan.HeaderText = "Codigo Plan";
            this.CodPlan.Name = "CodPlan";
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.HeaderText = "Fecha Modificacion";
            this.FechaModificacion.Name = "FechaModificacion";
            // 
            // MotivoModificacion
            // 
            this.MotivoModificacion.HeaderText = "Motivo modificacion";
            this.MotivoModificacion.Name = "MotivoModificacion";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(217, 227);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // HistorialPlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 270);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.grdHistorial);
            this.Name = "HistorialPlanes";
            this.Text = "HistorialPlanes";
            this.Load += new System.EventHandler(this.HistorialPlanes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoModificacion;
        private System.Windows.Forms.Button btnVolver;
    }
}