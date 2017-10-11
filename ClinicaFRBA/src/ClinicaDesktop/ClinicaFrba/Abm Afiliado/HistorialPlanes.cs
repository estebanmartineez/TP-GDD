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
using ClinicaFrba.Service;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class HistorialPlanes : Form
    {
        public HistorialPlanes()
        {
            InitializeComponent();
        }

        private string NroDocumento { get; set; }

        public HistorialPlanes(string nroDocumento)
        {
            this.NroDocumento = nroDocumento;
            InitializeComponent();
        }

        /// <summary>
        /// Comportamiento del boton volver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Carga el historial de las modificaciones que tuvieron los planes para el usuario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistorialPlanes_Load(object sender, EventArgs e)
        {
            var service = new ClinicaService();

            List<AfiliadoHistoricoPlan> historial = service.ObtenerHistorialCambioPlanes(Convert.ToInt32(this.NroDocumento));


            for (int i = 0; i < historial.Count(); i++)
            {
                AfiliadoHistoricoPlan hist = new AfiliadoHistoricoPlan();
                hist = historial[i];

                grdHistorial.Rows.Add(hist.IdAfiliadoHistoricoPlan, hist.IdUsuario, hist.Plan,hist.FechaCambio,hist.Motivo);
            }

        }
    }
}
