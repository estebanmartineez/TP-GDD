using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegadaTurno : Form
    {
        int idProfesional;

        public RegistroLlegadaTurno(int idProfesional)
        {
            InitializeComponent();
            this.idProfesional = idProfesional;
        }

        List<int> idsUsuario;
        List<int> idsTurnos;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var rowTurno = dgvTurno.SelectedRows[0].Index;
            int idAfiliado = idsUsuario.GetRange(rowTurno, 1).First();
            int idTurno = idsTurnos.GetRange(rowTurno, 1).First();
            string nombreAfiliado = dgvTurno.SelectedRows[0].Cells[1].ToString();

            new RegistroLlegadaBono(idAfiliado, nombreAfiliado, idTurno).Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            dgvTurno.MultiSelect = false;

            idsUsuario = new List<int>();
            idsTurnos = new List<int>();

            TurnoDao dao = new TurnoDao();
            List<TurnoYUsuario> turnos = dao.turnosDeHoy(idProfesional);

            for (int i = 0; i < turnos.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell fecha = new DataGridViewTextBoxCell();
                fecha.Value = turnos[i].FechaTurno;
                DataGridViewCell afiliado = new DataGridViewTextBoxCell();
                afiliado.Value = turnos[i].Nombre + " " + turnos[i].Apellido;
                idsUsuario.Add(turnos[i].idUsuario);
                idsTurnos.Add(turnos[i].IdTurno);

                row.Cells.Add(fecha);
                row.Cells.Add(afiliado);

                dgvTurno.Rows.Add(row);
            }

        }
    }
}
