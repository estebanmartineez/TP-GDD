using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;
using System.Text.RegularExpressions;

namespace ClinicaFrba.Compra_Bono
{
    public partial class VentanaIntermedioAdministrativo : Form
    {
        public VentanaIntermedioAdministrativo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Regex r = new Regex("^[0-9]*$");
            if (r.IsMatch(txBoxNumeroAfiliado.Text))
            {
                 
            var numAfiliado = txBoxNumeroAfiliado.Text;

            try { 
                Int64.Parse(numAfiliado);
            }catch(Exception exp){
                resu.Visible = true;
                resu.Text = "Número de Afiliado Invalido";

                return;
            }


                BonoDao f = new BonoDao();
                Usuario usuario = f.ExisteAfiliado(numAfiliado);

            if (usuario == null)
            {
                resu.Visible = true;
                resu.Text = "Número de Afiliado Invalido";
            }
            else
            {
                CompraBono formCompraBono = new CompraBono(usuario);
                formCompraBono.Show();
            }

            }
            else
            {
                MessageBox.Show("Numero de Afiliado inválido", "Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void VentanaIntermedioAdministrativo_Load(object sender, EventArgs e)
        {

        }

        private void txBoxNumeroAfiliado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
