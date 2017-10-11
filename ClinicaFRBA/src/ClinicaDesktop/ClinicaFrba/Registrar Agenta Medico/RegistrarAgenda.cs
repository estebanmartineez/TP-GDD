using ClinicaFrba.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class RegistrarAgenda : Form
    {

        List<CheckBox> dias;
        List<NumericUpDown> horaInicio;
        List<NumericUpDown> horaFin;
        public RegistrarAgenda(string idProfesional)
        {
            InitializeComponent();
            txDniProfesional.Text = idProfesional;
        }

        private void RegistrarAgenda_Load(object sender, EventArgs e)
        {
            this.cargarComboEspecialidades();
        }

        public void cargarComboEspecialidades()
        {

            dias = new List<CheckBox>();
            dias.Add(checkBoxLunes);dias.Add(checkBoxMartes);dias.Add(checkBoxMiercoles); dias.Add(checkBoxJueves); dias.Add(checkBoxViernes); dias.Add(checkBoxSabado);
            horaInicio = new List<NumericUpDown>();
            horaInicio.Add(inicioLunes); horaInicio.Add(inicioMartes); horaInicio.Add(inicioMiercoles); horaInicio.Add(inicioJueves); horaInicio.Add(inicioViernes); horaInicio.Add(inicioSabado);
            horaFin = new List<NumericUpDown>();
            horaFin.Add(finLunes); horaFin.Add(finMartes); horaFin.Add(finMiercoles); horaFin.Add(finJueves); horaFin.Add(finViernes); horaFin.Add(finSabado);

        }

        private void checkBoxLunes_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBoxMiercoles_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = false;
            if (Regex.IsMatch(this.txDniProfesional.Text, @"^[0-9]+$"))
            {
                List<int> posiciones = new List<int>();
                List<TimeSpan> inicioSeleccionados = new List<TimeSpan>();
                List<TimeSpan> finSeleccionados = new List<TimeSpan>();
                List<string> diasSeleccionados = new List<string>();
                List<CheckBox> diasRecorrer = new List<CheckBox>();

                diasRecorrer = this.dias;
                for (int i = 0; i < diasRecorrer.Count(); i++)
                {
                    if (diasRecorrer[i].Checked)
                    {
                        posiciones.Add(i);
                        diasSeleccionados.Add(diasRecorrer[i].Text);
                    }
                }

                for (int j = 0; j < posiciones.Count(); j++)
                {
                    var inicio = new TimeSpan(Convert.ToInt32(this.horaInicio.GetRange(j, 1).First().Value), 0, 0);
                    var fin = new TimeSpan(Convert.ToInt32(this.horaFin.GetRange(j, 1).First().Value), 0, 0);

                    if (esHorarioDisponible(inicio, fin, diasRecorrer[j].Text))
                    {
                        inicioSeleccionados.Add(inicio);
                        finSeleccionados.Add(fin);
                    }
                    else
                    {
                       error = true;
                    }
                 
                }
                if (!error)
                {
                    if (!trabajaMasDeDosDias(inicioSeleccionados, finSeleccionados))
                    {
                        TurnoFunciones turno = new TurnoFunciones();
                        turno.eliminarHorariosAnteriores(Int32.Parse(txDniProfesional.Text));
                        turno.RegistrarNuevaAgenda(Int32.Parse(txDniProfesional.Text), diasSeleccionados, inicioSeleccionados, finSeleccionados, dateTimePickerFechaInicio.Value.ToShortDateString(), dateTimePickerFechaFin.Value.ToShortDateString());
                        MessageBox.Show("La agenda se registro correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No Puede Trabajar Mas de 48 hs");
                    }
                }
                else
                {
                    MessageBox.Show("El Hospital No Atiende En El Horario Seleccionado");
                }
                
            }
            else
            {
                MessageBox.Show("Datos incorrectos.");
            }
        }

        private bool esHorarioDisponible(TimeSpan inicio,TimeSpan fin, string dia)
        {
            //List<string> dias = new List<string> {"Lunes" ,"Martes","Miercoles","Jueves","Viernes"};

            if(dia == "Sabado" && (inicio.Hours < 10 || fin.Hours > 15)) return false;
            else if (inicio.Hours < 7 || fin.Hours > 20) return false;

            return true;
        }

        private bool trabajaMasDeDosDias(List<TimeSpan> inicio, List<TimeSpan> fin)
        {
            int horasInicio = 0;
            int horasFin = 0;

            for(int i = 0; i < inicio.Count; i++)
            {
                horasInicio = horasInicio + inicio[i].Hours;
                horasFin = horasFin + fin[i].Hours;
            }

            return horasFin - horasInicio > 48 ? true : false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxJueves_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxViernes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxSabado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxMartes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
