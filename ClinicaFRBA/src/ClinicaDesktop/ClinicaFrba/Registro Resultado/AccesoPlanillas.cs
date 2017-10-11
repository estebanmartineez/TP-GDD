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
using ClinicaFrba.Registro_Resultado;

namespace ClinicaFrba.RegistroResultado
{
    public partial class AccesoPlanillas : Form
    {

        public AccesoPlanillas()
        {
            InitializeComponent();
        }


        public AccesoPlanillas(int idDoctor)
        {
            InitializeComponent();
            CargarTurnosDelDia(idDoctor);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grdResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(grdResultado.Rows[e.RowIndex].Cells[0].Value != null && grdResultado.Rows[e.RowIndex].Cells[1].Value != null && grdResultado.Rows[e.RowIndex].Cells[2].Value != null)
            { 

            if (e.ColumnIndex >= grdResultado.Columns[3].Index && e.RowIndex >= 0)
            {
                DataGridViewTextBoxCell idTurnoCell = (DataGridViewTextBoxCell)grdResultado.Rows[e.RowIndex].Cells[5];
                int idTurno = (int)idTurnoCell.Value;

                DataGridViewTextBoxCell horaCell = (DataGridViewTextBoxCell)grdResultado.Rows[e.RowIndex].Cells[0];
                String hora = (String)horaCell.Value;

                DataGridViewTextBoxCell nombreCell = (DataGridViewTextBoxCell)grdResultado.Rows[e.RowIndex].Cells[1];
                String nombre = (String)nombreCell.Value;

                DataGridViewTextBoxCell apellidoCell = (DataGridViewTextBoxCell)grdResultado.Rows[e.RowIndex].Cells[2];
                String apellido = (String)apellidoCell.Value;

                if (e.ColumnIndex == grdResultado.Columns[4].Index)
                    { 
                    ConfirmarDiagnostico ventanaConfirmar = new ConfirmarDiagnostico(hora, nombre, apellido, idTurno);
                    ventanaConfirmar.Show();
                    }
                if (e.ColumnIndex == grdResultado.Columns[3].Index)
                {
                    ConfirmarLlegada ventanaLlegada = new ConfirmarLlegada(hora, nombre, apellido, idTurno);
                    ventanaLlegada.Show();
                }
            }
            }
        }
        private void CargarTurnosDelDia(int idDoctor)
        {
            TurnoDao dao = new TurnoDao();
            List<TurnoYUsuario> listaTurnos = dao.GetTurnos(idDoctor);

            for (int i = 0; i < listaTurnos.Count ; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell horaTurno = new DataGridViewTextBoxCell();
                horaTurno.Value = listaTurnos[i].GetHora();
                DataGridViewCell nombre = new DataGridViewTextBoxCell();
                nombre.Value = listaTurnos[i].Nombre;
                DataGridViewCell apellido = new DataGridViewTextBoxCell();
                apellido.Value = listaTurnos[i].Apellido;
                DataGridViewCell idTurno = new DataGridViewTextBoxCell();
                idTurno.Value = listaTurnos[i].IdTurno;
                DataGridViewButtonCell boton1 = new DataGridViewButtonCell();
                boton1.Value = "Confirmar";
                DataGridViewButtonCell boton2 = new DataGridViewButtonCell();
                boton2.Value = "Diagnosticar";

                row.Cells.Add(horaTurno);
                row.Cells.Add(nombre);
                row.Cells.Add(apellido);
                row.Cells.Add(boton1);
                row.Cells.Add(boton2);
                row.Cells.Add(idTurno);
                
                grdResultado.Rows.Add(row);

            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btbBuscarTurno_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;

        }
    }
}
