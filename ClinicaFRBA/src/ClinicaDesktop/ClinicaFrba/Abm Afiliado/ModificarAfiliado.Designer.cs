namespace ClinicaFrba.Abm_Afiliado
{
    partial class ModificarAfiliado
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.gboxDatosFundamentales = new System.Windows.Forms.GroupBox();
            this.cboSexo = new System.Windows.Forms.ComboBox();
            this.dtpFechaDeNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lvlSexo = new System.Windows.Forms.Label();
            this.lblFecNac = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.gboxDatosAdicionales = new System.Windows.Forms.GroupBox();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.txtMotivoCambio = new System.Windows.Forms.TextBox();
            this.llbMotivoCambio = new System.Windows.Forms.Label();
            this.cboPlanes = new System.Windows.Forms.ComboBox();
            this.cboEstadoCivil = new System.Windows.Forms.ComboBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblPlanMedico = new System.Windows.Forms.Label();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.gboxDatosFundamentales.SuspendLayout();
            this.gboxDatosAdicionales.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(73, 27);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(73, 53);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(31, 79);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(89, 13);
            this.lblTipoDoc.TabIndex = 2;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(35, 105);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(85, 13);
            this.lblNroDoc.TabIndex = 3;
            this.lblNroDoc.Text = "Nro Documento:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(65, 25);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Direccion:";
            // 
            // gboxDatosFundamentales
            // 
            this.gboxDatosFundamentales.Controls.Add(this.cboSexo);
            this.gboxDatosFundamentales.Controls.Add(this.dtpFechaDeNacimiento);
            this.gboxDatosFundamentales.Controls.Add(this.txtNroDoc);
            this.gboxDatosFundamentales.Controls.Add(this.txtTipoDoc);
            this.gboxDatosFundamentales.Controls.Add(this.txtApellido);
            this.gboxDatosFundamentales.Controls.Add(this.txtNombre);
            this.gboxDatosFundamentales.Controls.Add(this.lvlSexo);
            this.gboxDatosFundamentales.Controls.Add(this.lblFecNac);
            this.gboxDatosFundamentales.Controls.Add(this.lblNombre);
            this.gboxDatosFundamentales.Controls.Add(this.lblApellido);
            this.gboxDatosFundamentales.Controls.Add(this.lblNroDoc);
            this.gboxDatosFundamentales.Controls.Add(this.lblTipoDoc);
            this.gboxDatosFundamentales.Location = new System.Drawing.Point(33, 22);
            this.gboxDatosFundamentales.Name = "gboxDatosFundamentales";
            this.gboxDatosFundamentales.Size = new System.Drawing.Size(491, 200);
            this.gboxDatosFundamentales.TabIndex = 5;
            this.gboxDatosFundamentales.TabStop = false;
            this.gboxDatosFundamentales.Text = "Datos Fundamentales";
            // 
            // cboSexo
            // 
            this.cboSexo.FormattingEnabled = true;
            this.cboSexo.Location = new System.Drawing.Point(126, 151);
            this.cboSexo.Name = "cboSexo";
            this.cboSexo.Size = new System.Drawing.Size(48, 21);
            this.cboSexo.TabIndex = 17;
            // 
            // dtpFechaDeNacimiento
            // 
            this.dtpFechaDeNacimiento.Location = new System.Drawing.Point(126, 127);
            this.dtpFechaDeNacimiento.Name = "dtpFechaDeNacimiento";
            this.dtpFechaDeNacimiento.Size = new System.Drawing.Size(149, 20);
            this.dtpFechaDeNacimiento.TabIndex = 16;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(126, 102);
            this.txtNroDoc.MaxLength = 8;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(149, 20);
            this.txtNroDoc.TabIndex = 13;
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Location = new System.Drawing.Point(126, 76);
            this.txtTipoDoc.MaxLength = 50;
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.Size = new System.Drawing.Size(149, 20);
            this.txtTipoDoc.TabIndex = 12;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(126, 50);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(149, 20);
            this.txtApellido.TabIndex = 11;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(126, 24);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(149, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // lvlSexo
            // 
            this.lvlSexo.AutoSize = true;
            this.lvlSexo.Location = new System.Drawing.Point(86, 154);
            this.lvlSexo.Name = "lvlSexo";
            this.lvlSexo.Size = new System.Drawing.Size(34, 13);
            this.lvlSexo.TabIndex = 8;
            this.lvlSexo.Text = "Sexo:";
            // 
            // lblFecNac
            // 
            this.lblFecNac.AutoSize = true;
            this.lblFecNac.Location = new System.Drawing.Point(24, 129);
            this.lblFecNac.Name = "lblFecNac";
            this.lblFecNac.Size = new System.Drawing.Size(96, 13);
            this.lblFecNac.TabIndex = 7;
            this.lblFecNac.Text = "Fecha Nacimiento:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(65, 52);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Telefono:";
            // 
            // gboxDatosAdicionales
            // 
            this.gboxDatosAdicionales.Controls.Add(this.btnHistorial);
            this.gboxDatosAdicionales.Controls.Add(this.txtMotivoCambio);
            this.gboxDatosAdicionales.Controls.Add(this.llbMotivoCambio);
            this.gboxDatosAdicionales.Controls.Add(this.cboPlanes);
            this.gboxDatosAdicionales.Controls.Add(this.cboEstadoCivil);
            this.gboxDatosAdicionales.Controls.Add(this.txtMail);
            this.gboxDatosAdicionales.Controls.Add(this.txtTelefono);
            this.gboxDatosAdicionales.Controls.Add(this.txtDireccion);
            this.gboxDatosAdicionales.Controls.Add(this.lblPlanMedico);
            this.gboxDatosAdicionales.Controls.Add(this.lblEstadoCivil);
            this.gboxDatosAdicionales.Controls.Add(this.lblMail);
            this.gboxDatosAdicionales.Controls.Add(this.lblDireccion);
            this.gboxDatosAdicionales.Controls.Add(this.lblTelefono);
            this.gboxDatosAdicionales.Location = new System.Drawing.Point(33, 236);
            this.gboxDatosAdicionales.Name = "gboxDatosAdicionales";
            this.gboxDatosAdicionales.Size = new System.Drawing.Size(491, 218);
            this.gboxDatosAdicionales.TabIndex = 7;
            this.gboxDatosAdicionales.TabStop = false;
            this.gboxDatosAdicionales.Text = "Datos Adicionales";
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(308, 128);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(102, 23);
            this.btnHistorial.TabIndex = 20;
            this.btnHistorial.Text = "Historial planes";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // txtMotivoCambio
            // 
            this.txtMotivoCambio.Location = new System.Drawing.Point(126, 157);
            this.txtMotivoCambio.MaxLength = 250;
            this.txtMotivoCambio.Name = "txtMotivoCambio";
            this.txtMotivoCambio.Size = new System.Drawing.Size(284, 20);
            this.txtMotivoCambio.TabIndex = 19;
            // 
            // llbMotivoCambio
            // 
            this.llbMotivoCambio.AutoSize = true;
            this.llbMotivoCambio.Location = new System.Drawing.Point(18, 160);
            this.llbMotivoCambio.Name = "llbMotivoCambio";
            this.llbMotivoCambio.Size = new System.Drawing.Size(102, 13);
            this.llbMotivoCambio.TabIndex = 18;
            this.llbMotivoCambio.Text = "Motivo cambio plan:";
            // 
            // cboPlanes
            // 
            this.cboPlanes.FormattingEnabled = true;
            this.cboPlanes.Location = new System.Drawing.Point(126, 128);
            this.cboPlanes.Name = "cboPlanes";
            this.cboPlanes.Size = new System.Drawing.Size(149, 21);
            this.cboPlanes.TabIndex = 17;
            this.cboPlanes.TextChanged += new System.EventHandler(this.cboPlanes_TextChanged);
            // 
            // cboEstadoCivil
            // 
            this.cboEstadoCivil.FormattingEnabled = true;
            this.cboEstadoCivil.Location = new System.Drawing.Point(126, 100);
            this.cboEstadoCivil.Name = "cboEstadoCivil";
            this.cboEstadoCivil.Size = new System.Drawing.Size(149, 21);
            this.cboEstadoCivil.TabIndex = 16;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(126, 75);
            this.txtMail.MaxLength = 150;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(149, 20);
            this.txtMail.TabIndex = 11;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(126, 49);
            this.txtTelefono.MaxLength = 8;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(149, 20);
            this.txtTelefono.TabIndex = 10;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(126, 22);
            this.txtDireccion.MaxLength = 250;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(149, 20);
            this.txtDireccion.TabIndex = 9;
            // 
            // lblPlanMedico
            // 
            this.lblPlanMedico.AutoSize = true;
            this.lblPlanMedico.Location = new System.Drawing.Point(51, 129);
            this.lblPlanMedico.Name = "lblPlanMedico";
            this.lblPlanMedico.Size = new System.Drawing.Size(69, 13);
            this.lblPlanMedico.TabIndex = 8;
            this.lblPlanMedico.Text = "Plan Medico:";
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.AutoSize = true;
            this.lblEstadoCivil.Location = new System.Drawing.Point(52, 103);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(65, 13);
            this.lblEstadoCivil.TabIndex = 8;
            this.lblEstadoCivil.Text = "Estado Civil:";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(86, 78);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 8;
            this.lblMail.Text = "Mail:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(368, 476);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(449, 476);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(33, 476);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(115, 23);
            this.btnBaja.TabIndex = 10;
            this.btnBaja.Text = "DAR DE BAJA";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // ModificarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 519);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gboxDatosAdicionales);
            this.Controls.Add(this.gboxDatosFundamentales);
            this.Name = "ModificarAfiliado";
            this.Text = "Modificar afiliado";
            this.Load += new System.EventHandler(this.ModificarAfiliado_Load);
            this.gboxDatosFundamentales.ResumeLayout(false);
            this.gboxDatosFundamentales.PerformLayout();
            this.gboxDatosAdicionales.ResumeLayout(false);
            this.gboxDatosAdicionales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.GroupBox gboxDatosFundamentales;
        private System.Windows.Forms.Label lblFecNac;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lvlSexo;
        private System.Windows.Forms.GroupBox gboxDatosAdicionales;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblPlanMedico;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cboSexo;
        private System.Windows.Forms.DateTimePicker dtpFechaDeNacimiento;
        private System.Windows.Forms.ComboBox cboEstadoCivil;
        private System.Windows.Forms.ComboBox cboPlanes;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.TextBox txtMotivoCambio;
        private System.Windows.Forms.Label llbMotivoCambio;
        private System.Windows.Forms.Button btnHistorial;
    }
}