using ClinicaFrba.Service;
using ClinicaFrba.Service.Common;
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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class GestionarAfiliados : Form
    {
        public GestionarAfiliados()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botón Modificar de la grilla que abre el formulario Modificar Afiliado
        /// se le pasa el nro de documento a la otra pantalla 
        /// para que precargue los valores del Afiliado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdAfiliados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string nroDocumento = this.grdAfiliados.Rows[e.RowIndex].Cells["NroDocumento"].Value.ToString();

                ModificarAfiliado f2 = new ModificarAfiliado(nroDocumento);

                f2.ShowDialog();
            }

        }

        /// <summary>
        /// Comportamiento del botón Buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Regex r = new Regex("^[a-zA-Z]*$");
            if (r.IsMatch(txtNombre.Text) && r.IsMatch(txtApellido.Text))
            {
                var service = new ClinicaService();

                CargarGrillaAfiliadoResponse response = new CargarGrillaAfiliadoResponse();

                response = service.CargarGrillaAfiliados(new CargarGrillaAfiliadoRequest()
                {
                    Apellido = (string.IsNullOrEmpty(this.txtApellido.Text)) ? string.Empty : this.txtApellido.Text,
                    Nombre = (string.IsNullOrEmpty(this.txtNombre.Text)) ? string.Empty : this.txtNombre.Text,
                    EstadoActual = (cboEstadoActual.SelectedItem.ToString() == "Habilitado") ? true : false,
                    DescripcionPlan = this.cboPlanes.SelectedItem?.ToString() ?? string.Empty
                });

                this.CargarGrillaAfiliado(response.Usuarios);
            }
            else
            {
                MessageBox.Show("Ingrese nombre y apellido válido");
            }
        }


        /// <summary>
        /// Carga la grilla de afiliados segun los filtros que fueron elegidos
        /// </summary>
        /// <param name="users"></param>
        private void CargarGrillaAfiliado(List<Usuario> users)
        {
            DataTable dt = new DataTable();

            this.grdAfiliados.AutoGenerateColumns = false;
            this.grdAfiliados.Columns[1].DataPropertyName = "NroAfiliado";
            this.grdAfiliados.Columns[2].DataPropertyName = "Plan";
            this.grdAfiliados.Columns[3].DataPropertyName = "Nombre";
            this.grdAfiliados.Columns[4].DataPropertyName = "Apellido";
            this.grdAfiliados.Columns[5].DataPropertyName = "TipoDocumento";
            this.grdAfiliados.Columns[6].DataPropertyName = "NroDocumento";
            this.grdAfiliados.Columns[7].DataPropertyName = "Telefono";
            this.grdAfiliados.Columns[8].DataPropertyName = "Modificar";

            dt.Columns.Add("NroAfiliado");
            dt.Columns.Add("Plan");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("TipoDocumento");
            dt.Columns.Add("NroDocumento");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Modificar");

            DataRow dw;

            foreach (var usuario in users)
            {
                dw = dt.NewRow();
                dw["NroAfiliado"] = usuario.NroAfiliado.ToString();
                dw["Plan"] = usuario.CodigoPlanMedico.ToString();
                dw["Nombre"] = usuario.Nombre;
                dw["Apellido"] = usuario.Apellido;
                dw["TipoDocumento"] = usuario.TipoDocumento;
                dw["NroDocumento"] = usuario.NroDocumento.ToString();
                dw["Telefono"] = usuario.Telefono.ToString();
                dt.Rows.Add(dw);
            }

            this.grdAfiliados.DataSource = dt;
        }

        /// <summary>
        /// Carga el combo planes
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
        /// Carga el combo estado actual
        /// </summary>
        private void CargarComboEstadoActual()
        {
            this.cboEstadoActual.Items.Add("Habilitado");
            this.cboEstadoActual.Items.Add("Deshabilitado");
            this.cboEstadoActual.SelectedIndex = 0;
        }

        /// <summary>
        /// Carga inicial del formulario Gestionar Afiliados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GestionarAfiliados_Load(object sender, EventArgs e)
        {
            this.CargarComboPlanesMedicos();
            this.CargarComboEstadoActual();
        }

        /// <summary>
        /// Comportamiento del boton limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.grdAfiliados.DataSource = null;
            this.grdAfiliados.Rows.Clear();
            this.grdAfiliados.Refresh();
        }

        /// <summary>
        /// Comportamiento del boton Volver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Comportamiento del boton Dar de alta, redirige a Alta Afiliado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaAfiliado af = new AltaAfiliado();

            af.ShowDialog();
        }
    }
}
