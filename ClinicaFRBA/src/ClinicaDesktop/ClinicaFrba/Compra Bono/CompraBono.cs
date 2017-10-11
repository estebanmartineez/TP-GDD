using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBono : Form
    {

        private float _precioBono;
        private Usuario _user;
        public CompraBono(Usuario usuario)
        {
            InitializeComponent();
            lblNombreAfiliado.Text = usuario.Nombre + " " + usuario.Apellido;
            //precioBono = new FuncionesVarias().getPrecioBono(usuario.CodigoPlanMedico);
            _precioBono = new BonoDao().GetPrecioBono(555556);

            lblMonto.Text = _precioBono.ToString();

            this._user = usuario;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            new BonoDao().ConfirmarCompraBono(_user, Int32.Parse(numUpDownCantBonos.Value.ToString()));

            if (MessageBox.Show("Bonos comprados con exito!!!!", "Alerta",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                 == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void lblNombreAfiliado_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            float montoTotal = float.Parse(numUpDownCantBonos.Value.ToString()) * _precioBono;
            lblTotalNum.Text = montoTotal.ToString();
        }
    }
}
