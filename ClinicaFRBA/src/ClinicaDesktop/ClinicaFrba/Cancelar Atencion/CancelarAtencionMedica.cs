using ClinicaFrba.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencionMedica : Form
    {
        public CancelarAtencionMedica()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var fDesde = FechaDesde.Value.ToString("yyyy-MM-dd");
            var fHasta = FechaHasta.Value.ToString("yyyy-MM-dd");
            var tipoCancelacion = cmbBoxTipo.SelectedItem.ToString();
            var detalle = txBoxDetalle.Text;
            
            new ClinicaService().CancelarTurnosSegunRangoFecha(fDesde, fHasta, detalle, tipoCancelacion);
            MessageBox.Show("Turnos Cancelados Con Exito!!", "Alerta", MessageBoxButtons.OK);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CancelarAtencionMedica_Load(object sender, EventArgs e)
        {

            //agrego tipos de cancelacion, esto lo inventamos nosotros
            cmbBoxTipo.Items.Add("Vacaciones");
            cmbBoxTipo.Items.Add("Enfermedad");
            cmbBoxTipo.Items.Add("Un Compromiso Mayor");
            cmbBoxTipo.Items.Add("Otro");
            cmbBoxTipo.SelectedItem = cmbBoxTipo.Items[0];
        }
    }
}
