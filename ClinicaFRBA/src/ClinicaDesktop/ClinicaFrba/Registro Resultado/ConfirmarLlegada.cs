using ClinicaFrba.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class ConfirmarLlegada : Form

    {
        private int _idTurno;

        public ConfirmarLlegada(string hora, string nombre, string apellido, int id)
        {
            InitializeComponent();
            _idTurno = id;
            lblDatos.Text = "¿Confirmar Turno de " + nombre + "," + apellido + ". A las: " + hora + "?";
        }

        public ConfirmarLlegada()
        {
            InitializeComponent();
        }

        private void ConfirmarLlegada_Load(object sender, EventArgs e)
        {

        }

        private void lblDatos_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            TurnoDao turno = new TurnoDao();
            turno.ConfirmarLlegadaPaciente(this._idTurno);
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
