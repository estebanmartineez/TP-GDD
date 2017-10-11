namespace ClinicaFrba.Abm_Afiliado
{
    partial class GestionarAfiliados
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
            this.gboxFiltrosBusqueda = new System.Windows.Forms.GroupBox();
            this.cboPlanes = new System.Windows.Forms.ComboBox();
            this.lblTipoPlan = new System.Windows.Forms.Label();
            this.cboEstadoActual = new System.Windows.Forms.ComboBox();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.grdAfiliados = new System.Windows.Forms.DataGridView();
            this.IdAfiliado = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NroAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.gboxFiltrosBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAfiliados)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxFiltrosBusqueda
            // 
            this.gboxFiltrosBusqueda.Controls.Add(this.cboPlanes);
            this.gboxFiltrosBusqueda.Controls.Add(this.lblTipoPlan);
            this.gboxFiltrosBusqueda.Controls.Add(this.cboEstadoActual);
            this.gboxFiltrosBusqueda.Controls.Add(this.lblEstadoActual);
            this.gboxFiltrosBusqueda.Controls.Add(this.txtApellido);
            this.gboxFiltrosBusqueda.Controls.Add(this.txtNombre);
            this.gboxFiltrosBusqueda.Controls.Add(this.lblApellido);
            this.gboxFiltrosBusqueda.Controls.Add(this.lblNombre);
            this.gboxFiltrosBusqueda.Location = new System.Drawing.Point(16, 24);
            this.gboxFiltrosBusqueda.Name = "gboxFiltrosBusqueda";
            this.gboxFiltrosBusqueda.Size = new System.Drawing.Size(844, 130);
            this.gboxFiltrosBusqueda.TabIndex = 0;
            this.gboxFiltrosBusqueda.TabStop = false;
            this.gboxFiltrosBusqueda.Text = "Filtros de búsqueda";
            // 
            // cboPlanes
            // 
            this.cboPlanes.FormattingEnabled = true;
            this.cboPlanes.Location = new System.Drawing.Point(406, 70);
            this.cboPlanes.Name = "cboPlanes";
            this.cboPlanes.Size = new System.Drawing.Size(141, 21);
            this.cboPlanes.TabIndex = 7;
            // 
            // lblTipoPlan
            // 
            this.lblTipoPlan.AutoSize = true;
            this.lblTipoPlan.Location = new System.Drawing.Point(325, 72);
            this.lblTipoPlan.Name = "lblTipoPlan";
            this.lblTipoPlan.Size = new System.Drawing.Size(31, 13);
            this.lblTipoPlan.TabIndex = 6;
            this.lblTipoPlan.Text = "Plan:";
            // 
            // cboEstadoActual
            // 
            this.cboEstadoActual.FormattingEnabled = true;
            this.cboEstadoActual.Location = new System.Drawing.Point(406, 31);
            this.cboEstadoActual.Name = "cboEstadoActual";
            this.cboEstadoActual.Size = new System.Drawing.Size(141, 21);
            this.cboEstadoActual.TabIndex = 5;
            // 
            // lblEstadoActual
            // 
            this.lblEstadoActual.AutoSize = true;
            this.lblEstadoActual.Location = new System.Drawing.Point(325, 35);
            this.lblEstadoActual.Name = "lblEstadoActual";
            this.lblEstadoActual.Size = new System.Drawing.Size(75, 13);
            this.lblEstadoActual.TabIndex = 4;
            this.lblEstadoActual.Text = "Estado actual:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(80, 72);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(135, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(80, 32);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(135, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(26, 75);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(27, 35);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(16, 160);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(785, 160);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grdAfiliados
            // 
            this.grdAfiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAfiliados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAfiliado,
            this.NroAfiliado,
            this.Plan,
            this.Nombre,
            this.Apellido,
            this.TipoDocumento,
            this.NroDocumento,
            this.Telefono,
            this.Editar});
            this.grdAfiliados.Location = new System.Drawing.Point(16, 192);
            this.grdAfiliados.Name = "grdAfiliados";
            this.grdAfiliados.Size = new System.Drawing.Size(844, 299);
            this.grdAfiliados.TabIndex = 3;
            this.grdAfiliados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAfiliados_CellContentClick);
            // 
            // IdAfiliado
            // 
            this.IdAfiliado.HeaderText = "IdAfiliado";
            this.IdAfiliado.Name = "IdAfiliado";
            this.IdAfiliado.Visible = false;
            // 
            // NroAfiliado
            // 
            this.NroAfiliado.HeaderText = "Nro Afiliado";
            this.NroAfiliado.Name = "NroAfiliado";
            // 
            // Plan
            // 
            this.Plan.HeaderText = "Plan";
            this.Plan.Name = "Plan";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.HeaderText = "Tipo Documento";
            this.TipoDocumento.Name = "TipoDocumento";
            // 
            // NroDocumento
            // 
            this.NroDocumento.HeaderText = "Numero Documento";
            this.NroDocumento.Name = "NroDocumento";
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Modificar";
            this.Editar.Name = "Editar";
            this.Editar.Text = "Modificar";
            this.Editar.ToolTipText = "Modificar";
            this.Editar.UseColumnTextForButtonValue = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(401, 525);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(785, 499);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 5;
            this.btnAlta.Text = "Dar de alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // GestionarAfiliados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 555);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.grdAfiliados);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.gboxFiltrosBusqueda);
            this.Name = "GestionarAfiliados";
            this.Text = "Gestionar afiliados";
            this.Load += new System.EventHandler(this.GestionarAfiliados_Load);
            this.gboxFiltrosBusqueda.ResumeLayout(false);
            this.gboxFiltrosBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAfiliados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxFiltrosBusqueda;
        private System.Windows.Forms.Label lblTipoPlan;
        private System.Windows.Forms.ComboBox cboEstadoActual;
        private System.Windows.Forms.Label lblEstadoActual;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataGridView grdAfiliados;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cboPlanes;
        private System.Windows.Forms.DataGridViewButtonColumn IdAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.Button btnAlta;
    }
}