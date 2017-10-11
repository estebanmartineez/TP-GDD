using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Repository.Entities;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaIntegranteFamiliaAfiliado : Form
    {
        public AltaIntegranteFamiliaAfiliado()
        {
            InitializeComponent();
        }

        public int CodigoPlan { get; set; }

        public AltaIntegranteFamiliaAfiliado(int codPlan)
        {
            this.CodigoPlan = codPlan;
            InitializeComponent();
        }

        /// <summary>
        /// Carga Inicial del formulario Alta Integrante Familia Afiliado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AltaIntegranteFamiliaAfiliado_Load(object sender, EventArgs e)
        {
            this.CargarComboEstadoCivil();
            this.CargarComboSexo();
        }

        /// <summary>
        /// Se encarga de realizar el guardado del afiliado asociado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos()) { 
                this.Afiliado = new Usuario();

                this.Afiliado.EstadoCivil = this.cboEstadoCivil.SelectedItem.ToString();
                this.Afiliado.Apellido = this.txtApellido.Text;
                this.Afiliado.Nombre = this.txtNombre.Text;
                this.Afiliado.Direccion = this.txtDireccion.Text;
                this.Afiliado.FechaNacimiento = Convert.ToDateTime(this.dtpFechaDeNacimiento.Text);
                this.Afiliado.TipoDocumento = this.txtTipoDoc.Text;
                this.Afiliado.NroDocumento = Convert.ToInt32(this.txtNroDoc.Text);
                this.Afiliado.Sexo = this.cboSexo.SelectedItem.ToString();
                this.Afiliado.Mail = this.txtMail.Text;
                this.Afiliado.Telefono = Convert.ToInt32(this.txtTelefono.Text);
                this.Afiliado.CodigoPlanMedico = CodigoPlan;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos incorrectos", "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Comportamiento del botón cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Cargar el combo sexo
        /// </summary>
        private void CargarComboSexo()
        {
            this.cboSexo.Items.Add("M");
            this.cboSexo.Items.Add("F");
        }


        /// <summary>
        /// Carga el combo estado civil 
        /// </summary>
        private void CargarComboEstadoCivil()
        {
            this.cboEstadoCivil.DisplayMember = "Text";
            this.cboEstadoCivil.ValueMember = "Value";

            this.cboEstadoCivil.Items.Add("Soltero");
            this.cboEstadoCivil.Items.Add("Casado");
            this.cboEstadoCivil.Items.Add("Concubinato");
            this.cboEstadoCivil.Items.Add("Divorciado");
            this.cboEstadoCivil.Items.Add("Viudo");
        }

        /// <summary>
        /// Valida cada uno de los datos, de los TextBox del formulario
        /// </summary>
        /// <returns></returns>
        private bool DatosValidos()
        {
            if (this.cboEstadoCivil.SelectedItem == null) { return false; }
            if (!Regex.IsMatch(this.txtApellido.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$")) { return false; }
            if (!Regex.IsMatch(this.txtNombre.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$")) { return false; }
            if (Convert.ToDateTime(this.dtpFechaDeNacimiento.Text) == null) { return false; }
            if (!Regex.IsMatch(this.txtTipoDoc.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$")) { return false; }
            if (!Regex.IsMatch(this.txtNroDoc.Text, @"^[0-9]+$")) { return false; }
            if (this.cboSexo.SelectedItem == null) { return false; }
            if (!EmailValido(this.txtMail.Text)) { return false; }
            if (!Regex.IsMatch(this.txtTelefono.Text, @"^[0-9]+$")) { return false; }
            return true;
        }

        public bool EmailValido(string emailaddress)
        {
            try
            {
                if (!string.IsNullOrEmpty(emailaddress))
                {
                    MailAddress m = new MailAddress(emailaddress);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public Usuario Afiliado { get; set; }
    }
}
