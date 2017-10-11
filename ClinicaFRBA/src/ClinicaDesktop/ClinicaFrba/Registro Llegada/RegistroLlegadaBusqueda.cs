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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegadaBusqueda : Form
    {

        List<int> ids;

        public RegistroLlegadaBusqueda()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TurnoFunciones turno = new TurnoFunciones();

            List<String> especialidades = turno.getEspecialidadesDB();

            cmbEspecialidades.Items.Add("-");
            especialidades.ForEach(esp => cmbEspecialidades.Items.Add(esp));
            cmbEspecialidades.SelectedItem = cmbEspecialidades.Items[0];

            ids = new List<int>();

            dgvProfesionales.MultiSelect = false;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void lblNombreProf_Click(object sender, EventArgs e)
        {

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ProfesionalDao dao = new ProfesionalDao();
            List<Profesional> lista = dao.getProfesionalesPorEspecialidad(txtNombre.Text, cmbEspecialidades.SelectedItem.ToString());

            dgvProfesionales.Rows.Clear();

            for (int i = 0; i < lista.Count(); i++)
            {
                ids.Add(lista[0].id);

                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell nombre = new DataGridViewTextBoxCell();
                nombre.Value = lista[i].nombre;
                DataGridViewCell apellido = new DataGridViewTextBoxCell();
                apellido.Value = lista[i].apellido;
                DataGridViewCell esp = new DataGridViewTextBoxCell();
                esp.Value = lista[i].especialidad;

                row.Cells.Add(nombre);
                row.Cells.Add(apellido);
                row.Cells.Add(esp);
                dgvProfesionales.Rows.Add(row);
            }
        }

        private void brnTurnos_Click(object sender, EventArgs e)
        {
            if (dgvProfesionales.SelectedRows.Count == 0)
                MessageBox.Show("No se a seleccionado un Profesional", "Alerta", MessageBoxButtons.OK);
            else
            {
                var index = dgvProfesionales.SelectedRows[0].Index;
                var id = ids.GetRange(index, 1).First();

                new RegistroLlegadaTurno(id).Show();
            }
           
        }
    }
}
