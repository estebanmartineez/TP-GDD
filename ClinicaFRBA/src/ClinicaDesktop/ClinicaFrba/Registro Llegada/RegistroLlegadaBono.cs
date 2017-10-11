using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegadaBono : Form
    {
        int idAfiliado;
        string nombre;
        int idTurno;

        public RegistroLlegadaBono(int idAfiliado, string nombre, int idTurno)
        {
            InitializeComponent();
            this.idAfiliado = idAfiliado;
            this.nombre = nombre;
            this.idTurno = idTurno;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvBonos.MultiSelect = false;

            lblNombre.Text = nombre;

            BonoDao dao = new BonoDao();
            List <Bono> bonos = dao.getBonosDeAfiliado(idAfiliado);

            for(int i = 0; i < bonos.Count; i++){
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell id = new DataGridViewTextBoxCell();
                id.Value = bonos[i].Id;
                DataGridViewCell fecha = new DataGridViewTextBoxCell();
                fecha.Value = bonos[i].FechaCompra;

                row.Cells.Add(id);
                row.Cells.Add(fecha);

                dgvBonos.Rows.Add(row);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AsistenciaDao dao = new AsistenciaDao();

            var hayBonoSeleccionado = (bool)(dgvBonos.SelectedRows.Count == 1);
            if (!hayBonoSeleccionado)
            {
                DialogResult dialogResult = MessageBox.Show("¿Esta seguro que no desea utilizar un bono en la consulta?", "Alerta", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dao.generarAsistenciaSinBono(idTurno);
                }

            }
            else{
                int idBono = Int32.Parse(dgvBonos.SelectedRows[0].Cells[0].ToString());
                new BonoDao().usarBono(idAfiliado, idBono);
                dao.generarAsistenciaConBono(idTurno, idBono);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
