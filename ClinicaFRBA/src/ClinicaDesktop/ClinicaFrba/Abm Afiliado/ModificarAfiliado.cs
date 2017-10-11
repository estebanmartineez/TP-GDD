using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Repository.Entities;
using ClinicaFrba.Service;
using ClinicaFrba.Service.Common;
using System.Net.Mail;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        public ModificarAfiliado()
        {
            InitializeComponent();
        }

        private string NroDocumento { get; set; }

        public ModificarAfiliado(string nroDocumento)
        {
            this.NroDocumento = nroDocumento;
            InitializeComponent();
        }

        /// <summary>
        /// Comportamiento del boton guardar, ademas de guardar los datos del afiliado modificado
        /// en el caso de que haya un motivo de modificacion de plan 
        /// lo inserta en la tabla Afiliado historico plan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var service = new ClinicaService();

            if (DatosValidos())
            {
                int codPlan = service.GetCodigoPlanByDescripcion(this.cboPlanes.SelectedItem.ToString());

                var afiliado = new Usuario()
                {
                    Nombre = this.txtNombre.Text,
                    Apellido = this.txtApellido.Text,
                    NroDocumento = Convert.ToInt32(this.txtNroDoc.Text),
                    NroAfiliado = this.NroAfiliado,
                    TipoDocumento = this.txtTipoDoc.Text,
                    FechaNacimiento = Convert.ToDateTime(this.dtpFechaDeNacimiento.Value),
                    Mail = this.txtMail.Text,
                    EstadoCivil = this.cboEstadoCivil.SelectedItem.ToString(),
                    Direccion = this.txtDireccion.Text,
                    Telefono = Convert.ToInt32(this.txtTelefono.Text),
                    Sexo = this.cboSexo.SelectedItem.ToString(),
                    CodigoPlanMedico = codPlan
                };

                service.ModificarDatosDeAfiliado(new ModificarDatosDeAfiliadoRequest() {Afiliado = afiliado});

                if (!string.IsNullOrEmpty(this.txtMotivoCambio.Text))
                {
                    service.ActualizarHistorialCambiosDePlan(new ActualizarHistorialCambiosDePlanRequest()
                    {
                        MotivoCambio = this.txtMotivoCambio.Text,
                        CodigoPlan = codPlan,
                        IdUsuario = Convert.ToInt32(this.NroDocumento)
                    });
                }

                MessageBox.Show("Se actualizaron correctamente los datos del afiliado: " + this.txtApellido.Text + " " +
                                this.txtNombre.Text);
            }
            else
            {
                MessageBox.Show("Alguno de los datos ingresados no son correctos. Intente de nuevo.");
            }

            this.Close();

        }


        /// <summary>
        /// Comportamiento del boton cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
        /// Configura el formato de fecha para el datetimepicker
        /// </summary>
        private void ConfigurarFormatoFechaDeNacimiento()
        {
            this.dtpFechaDeNacimiento.Format = DateTimePickerFormat.Custom;
            this.dtpFechaDeNacimiento.CustomFormat = "dd-MM-yyyy";
        }

        /// <summary>
        /// Carga el combo planes medicos segun los que se encuentren en la base
        /// </summary>
        private void CargarComboPlanesMedicos()
        {
            var service = new ClinicaService();

            var response = service.ObtenerListadoDePlanes();

            foreach (var descPlan in response.DescPlanes)
            {
                this.cboPlanes.Items.Add(descPlan);
            }
        }

        /// <summary>
        /// Carga el combo sexo
        /// </summary>
        private void CargarComboSexo()
        {
            this.cboSexo.Items.Add("M");
            this.cboSexo.Items.Add("F");
        }

        /// <summary>
        /// Carga inicial del formulario Modificar Afiliado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModificarAfiliado_Load(object sender, EventArgs e)
        {
            this.ConfigurarFormatoFechaDeNacimiento();
            this.CargarComboEstadoCivil();
            this.CargarComboPlanesMedicos();
            this.CargarComboSexo();
            this.CargarDetalleAfiliado(Convert.ToInt32(NroDocumento));
            this.HabilitarMotivoCambioPlan(false);
        }

        /// <summary>
        /// Habilita o deshabilita el textbox/label de motivo de cambio de plan 
        /// </summary>
        /// <param name="enc"></param>
        private void HabilitarMotivoCambioPlan(bool enc)
        {
            this.llbMotivoCambio.Visible = enc;
            this.txtMotivoCambio.Visible = enc;
        }

        /// <summary>
        /// Precarga los valores en los TextBox segun corresponda
        /// </summary>
        /// <param name="nroDocumento"></param>
        private void CargarDetalleAfiliado(int nroDocumento)
        {
            var service = new ClinicaService();

            var response = service.CargarDetalleAfiliado(new CargarDetalleAfiliadoRequest() {NroDocumento = nroDocumento});

            string descPlan = service.GetDescripcionByCodigoPlan(response.Usuario.CodigoPlanMedico);

            this.txtNombre.Text = response.Usuario.Nombre ?? string.Empty;
            this.txtApellido.Text = response.Usuario.Apellido ?? string.Empty;
            this.txtNroDoc.Text = response.Usuario.NroDocumento.ToString();
            this.txtTipoDoc.Text = response.Usuario.TipoDocumento ?? string.Empty;
            this.dtpFechaDeNacimiento.Value = response.Usuario.FechaNacimiento;
            this.txtMail.Text = response.Usuario.Mail ?? string.Empty;
            this.cboEstadoCivil.SelectedItem = response.Usuario.EstadoCivil;
            this.txtDireccion.Text = response.Usuario.Direccion ?? string.Empty;
            this.txtTelefono.Text = response.Usuario.Telefono.ToString();
            this.cboSexo.SelectedItem = response.Usuario.Sexo;
            this.cboPlanes.SelectedItem = descPlan;
            NroAfiliado = response.Usuario.NroAfiliado;
            DescripcionPlan = descPlan;

        }

        /// <summary>
        /// Comportamiento boton Dar de baja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBaja_Click(object sender, EventArgs e)
        {
            var service = new ClinicaService();
           
            service.DarDeBajaUsuario(Convert.ToInt32(this.NroDocumento));

            MessageBox.Show("El usuario fue dado de baja correctamente.");

            this.Close();
        }

        /// <summary>
        /// Al cambiar el Combo planes muestra u oculta el textbox/label 
        /// motivo cambio plan segun corresponda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPlanes_TextChanged(object sender, EventArgs e)
        {
            if (DescripcionPlan != this.cboPlanes.SelectedItem.ToString())
            {
                this.HabilitarMotivoCambioPlan(true);
            }
            else
            {
                this.HabilitarMotivoCambioPlan(false);
                this.txtMotivoCambio.Text = string.Empty;
            }
        }

        /// <summary>
        /// Comportamiento del boton ver Historial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            HistorialPlanes hs = new HistorialPlanes(this.NroDocumento);

            hs.ShowDialog();
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
            if (this.cboPlanes.SelectedItem == null) { return false; }
            if (!EmailValido(this.txtMail.Text)) { return false; }
            if (!Regex.IsMatch(this.txtTelefono.Text, @"^[0-9]+$")) { return false; }
            return true;
        }

        public bool EmailValido(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public long NroAfiliado { get; set; }
        public string DescripcionPlan { get; set; }

      
    }
}
