using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Repository;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class DiasDisponibles : Form
    {
        public DiasDisponibles()
        {
            InitializeComponent();
        }

        public int IdProfesional { get; set; }
        public int IdAfiliado  { get; set; }

        public DiasDisponibles(int idProfesional, int idAfiliado)
        {
            this.IdProfesional = idProfesional;
            this.IdAfiliado = idAfiliado;
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TurnoFunciones turno = new TurnoFunciones();

            CultureInfo ci = new CultureInfo("es-ES");
            var dia = ci.DateTimeFormat.GetDayName(Convert.ToDateTime(this.dateTimePicker1.Text).DayOfWeek);

            List<string> horarios = turno.getHorariosDisponibles(this.IdProfesional, dia);

            if(horarios.Count > 0)
            { 
                    TimeSpan horaInicio = TimeSpan.Parse(horarios.First());
                    TimeSpan horaFin = TimeSpan.Parse(horarios.Last());

                    var veces = horaFin.Subtract(horaInicio);

                    TimeSpan mediaHora = new TimeSpan(0, 30, 0);

                    List<string> rangoHorario = new List<string>();

                    rangoHorario.Add(horaInicio.ToString());

                    for (int i = 0; i < (veces.TotalHours*2)-1; i++)
                    {
                        rangoHorario.Add(horaInicio.Add(mediaHora).ToString());
                        horaInicio = horaInicio.Add(mediaHora);
                    }

       

                    this.ValidarDisponibilidadDelProfesional(this.dataGridView1, rangoHorario);
            }
            else
            {
                MessageBox.Show("El profesional no se encuentra disponible en la fecha seleccionada. Por favor seleccione otra fecha.");
            }

        }

        public void ValidarDisponibilidadDelProfesional(DataGridView grd, List<string> rangoHorario)
        {
            TurnoFunciones turno = new TurnoFunciones();

            List<string> horariosProfesional = turno.GetDisponibilidadDelProfesional(this.IdProfesional, this.dateTimePicker1.Value);

            var horariosABorrar = horariosProfesional.Select(x => Convert.ToDateTime(x).TimeOfDay.ToString()).ToList();

            rangoHorario.RemoveAll(x => horariosABorrar.Contains(x));

            foreach (var hora in rangoHorario)
            {
                this.dataGridView1.Rows.Add(hora);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string horarioElegido = this.dataGridView1.Rows[e.RowIndex].Cells["Horario"].Value.ToString();
                TimeSpan hr = TimeSpan.Parse(horarioElegido);

                TurnoFunciones turno = new TurnoFunciones();

                turno.ReservarNuevoTurno(this.IdProfesional, 1123960, dateTimePicker1.Value.Date.Add(hr));

                MessageBox.Show("El turno fue reservado correctamente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
