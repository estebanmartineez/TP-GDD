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

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class SeleccionarProfecional : Form
    {

 

        public SeleccionarProfecional()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregarAgenda_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();

            DataGridViewSelectedRowCollection rows = dataGridViewProfecionales.SelectedRows;
            var id = rows[0].Cells[0].Value.ToString();

            //MessageBox.Show("alerta", row.Cells[0].Value.ToString(), MessageBoxButtons.OK);
            //capturo los datos del row y abro la otra ventana
        
            RegistrarAgenda registrar = new RegistrarAgenda(id);
            registrar.Show();
        }

        private void SeleccionarProfecional_Load(object sender, EventArgs e)
        {
            dataGridViewProfecionales.MultiSelect = false;

            ProfesionalDao dao = new ProfesionalDao();

            List<Usuario> lista = dao.GetProfesionales();

            foreach (Usuario usuario in lista)
            {

                DataGridViewTextBoxCell id = new DataGridViewTextBoxCell();
                id.Value = usuario.Username;
                DataGridViewTextBoxCell nombre = new DataGridViewTextBoxCell();
                nombre.Value = usuario.Nombre;
                DataGridViewTextBoxCell apellido = new DataGridViewTextBoxCell();
                apellido.Value = usuario.Apellido;
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(id);
                row.Cells.Add(nombre);
                row.Cells.Add(apellido);

                dataGridViewProfecionales.Rows.Add(row);
            }
        }
    }
}
