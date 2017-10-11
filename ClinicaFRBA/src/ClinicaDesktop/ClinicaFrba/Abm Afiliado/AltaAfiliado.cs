using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClinicaFrba.Repository.Entities;
using ClinicaFrba.Service;
using System.Net.Mail;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaAfiliado : Form
    {
        public AltaAfiliado()
        {
            InitializeComponent();
        }

        public int CodigoPlan { get; set; }
        /// <summary>
        /// Comportamiento del botón Guardar, en el caso de que el afiliado sea casado o viva en concubinato
        /// se le ofrece la posibilidad de asociarlo, ademas permite agregar tantos miembros familiares como desee 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var service = new ClinicaService();
            if (DatosValidos())
            {
                CodigoPlan = service.GetCodigoPlanByDescripcion(this.cboPlanes.SelectedItem.ToString());

                List<Usuario> afiliados = new List<Usuario>();

                var afiliado = new Usuario()
                {
                    Nombre = this.txtNombre.Text,
                    Apellido = this.txtApellido.Text,
                    NroDocumento = Convert.ToInt32(this.txtNroDoc.Text),
                    NroAfiliado = Convert.ToInt32(this.txtNroDoc.Text),
                    TipoDocumento = this.txtTipoDoc.Text,
                    FechaNacimiento = Convert.ToDateTime(this.dtpFechaNacimiento.Value),
                    Mail = this.txtMail.Text,
                    EstadoCivil = this.cboEstadoCivil.SelectedItem.ToString(),
                    Direccion = this.txtDireccion.Text,
                    Telefono = Convert.ToInt32(this.txtTelefono.Text),
                    Sexo = this.cboSexo.SelectedItem.ToString(),
                    CodigoPlanMedico = CodigoPlan
                };

                if (!service.ValidarExistenciaUsuario(afiliado.NroDocumento).NroDocumento.Equals(afiliado.NroDocumento))
                {
                    afiliados.Add(afiliado);

                    if (service.EsCasadoOViveEnConcubinato(afiliado))
                    {
                        if ((MessageBox.Show("¿Desea afiliar a su cónyuge?", "Confirmar",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                        {
                            this.AfiliarIntegranteFamilia(afiliados);
                        }
                    }

                    while ((MessageBox.Show("¿Desea afiliar algun otro miembro de su familia?", "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        this.AfiliarIntegranteFamilia(afiliados);
                    }

                    service.GuardarRegistroAfiliado(afiliados);

                    MessageBox.Show("El registro del afiliado se guardó correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El DNI del afiliado que ha ingresado ya se encuentra dado de alta.");
                }
            }
            else
            {
                MessageBox.Show("Alguno de los datos ingresados no son correctos. Intente de nuevo.");
            }
        }


        /// <summary>
        /// Abre el formulario de alta de integrante familiar, luego este
        /// devuelve un objeto del tipo Usuario con las properties seteadas y lo agrega 
        /// a la lista de la familia de la afiliado en cuestión.
        /// </summary>
        /// <param name="users">Familiares del Afiliado</param>
        private void AfiliarIntegranteFamilia(List<Usuario> users)
        {
            using (var integranteFamilia = new AltaIntegranteFamiliaAfiliado(this.CodigoPlan))
            {
                var resultado = integranteFamilia.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    users.Add(integranteFamilia.Afiliado);
                }
            }
        }

        /// <summary>
        /// Carga inicial del formulario AltaAfiliado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AltaAfiliado_Load(object sender, EventArgs e)
        {
            this.ConfigurarFormatoFechaDeNacimiento();
            this.CargarComboEstadoCivil();
            this.CargarComboPlanesMedicos();
            this.CargarComboSexo();
        }


        /// <summary>
        /// Completa el combo de estado civil 
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
        /// Configura el formato de la fecha del DateTimePicker
        /// </summary>
        private void ConfigurarFormatoFechaDeNacimiento()
        {
            this.dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.CustomFormat = "dd-MM-yyyy";
        }

        /// <summary>
        /// Carga el combo de planes medicos segun los que se encuentren en la base datos
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
        /// Carga el combo de sexo
        /// </summary>
        private void CargarComboSexo()
        {
            this.cboSexo.Items.Add("M");
            this.cboSexo.Items.Add("F");
        }

        /// <summary>
        /// Comportamiento del botón cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (Convert.ToDateTime(this.dtpFechaNacimiento.Text) == null) { return false; }
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

        private void btnAfiliarFamiliar_Click(object sender, EventArgs e)
        {
            var afiliadoPpal = new IngresarAfiliadoPrincipal();

            afiliadoPpal.ShowDialog();

            this.Close();
        }
    }
}
