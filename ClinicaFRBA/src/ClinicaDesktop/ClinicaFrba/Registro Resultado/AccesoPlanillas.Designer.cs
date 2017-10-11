namespace ClinicaFrba.RegistroResultado
{
    partial class AccesoPlanillas
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
            this.grdResultado = new System.Windows.Forms.DataGridView();
            this.colHoraTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cofirmarLlegada = new System.Windows.Forms.DataGridViewButtonColumn();
            this.confimarDiagnostico = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.btbBuscarTurno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // grdResultado
            // 
            this.grdResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHoraTurno,
            this.nombreAfiliado,
            this.apellidoAfiliado,
            this.cofirmarLlegada,
            this.confimarDiagnostico,
            this.IdTurno});
            this.grdResultado.Location = new System.Drawing.Point(15, 72);
            this.grdResultado.Name = "grdResultado";
            this.grdResultado.Size = new System.Drawing.Size(553, 282);
            this.grdResultado.TabIndex = 0;
            this.grdResultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResultado_CellContentClick);
            // 
            // colHoraTurno
            // 
            this.colHoraTurno.HeaderText = "Hora Turno";
            this.colHoraTurno.Name = "colHoraTurno";
            this.colHoraTurno.ReadOnly = true;
            // 
            // nombreAfiliado
            // 
            this.nombreAfiliado.HeaderText = "Nombre Afiliado";
            this.nombreAfiliado.Name = "nombreAfiliado";
            this.nombreAfiliado.ReadOnly = true;
            // 
            // apellidoAfiliado
            // 
            this.apellidoAfiliado.HeaderText = "Apellido Afiliado";
            this.apellidoAfiliado.Name = "apellidoAfiliado";
            this.apellidoAfiliado.ReadOnly = true;
            // 
            // cofirmarLlegada
            // 
            this.cofirmarLlegada.HeaderText = "Cofirmar Llegada";
            this.cofirmarLlegada.Name = "cofirmarLlegada";
            this.cofirmarLlegada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cofirmarLlegada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // confimarDiagnostico
            // 
            this.confimarDiagnostico.HeaderText = "Cofirmar Diagnostico";
            this.confimarDiagnostico.Name = "confimarDiagnostico";
            this.confimarDiagnostico.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.confimarDiagnostico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IdTurno
            // 
            this.IdTurno.HeaderText = "IdTurno";
            this.IdTurno.Name = "IdTurno";
            this.IdTurno.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(456, 361);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(112, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Busqueda De Turno";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 37);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(202, 37);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(65, 34);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(255, 34);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 7;
            // 
            // btbBuscarTurno
            // 
            this.btbBuscarTurno.Location = new System.Drawing.Point(400, 32);
            this.btbBuscarTurno.Name = "btbBuscarTurno";
            this.btbBuscarTurno.Size = new System.Drawing.Size(75, 23);
            this.btbBuscarTurno.TabIndex = 8;
            this.btbBuscarTurno.Text = "Buscar";
            this.btbBuscarTurno.UseVisualStyleBackColor = true;
            this.btbBuscarTurno.Click += new System.EventHandler(this.btbBuscarTurno_Click);
            // 
            // AccesoPlanillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 396);
            this.Controls.Add(this.btbBuscarTurno);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.grdResultado);
            this.Name = "AccesoPlanillas";
            this.Text = "Registro Turnos del Día";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoraTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoAfiliado;
        private System.Windows.Forms.DataGridViewButtonColumn cofirmarLlegada;
        private System.Windows.Forms.DataGridViewButtonColumn confimarDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTurno;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btbBuscarTurno;
    }
}