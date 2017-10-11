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

namespace ClinicaFrba.AbmRol
{
    public partial class GestionarRoles : Form
    {
        public GestionarRoles()
        {
            InitializeComponent();
            
        }


        private void grdRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell rolCell = (DataGridViewTextBoxCell)grdRoles.Rows[e.RowIndex].Cells[0];
            String rol = (String)rolCell.Value;


            if (e.ColumnIndex == grdRoles.Columns[2].Index && e.RowIndex >= 0) //boton editar
            {
                DataGridViewTextBoxCell estadoCell = (DataGridViewTextBoxCell)grdRoles.Rows[e.RowIndex].Cells[1];
             
                int estado = (estadoCell.Value.Equals("Habilitado")) ? 1 : 0;

                EditarRol ventanaEditar = new EditarRol(rol, estado, this);
                ventanaEditar.Show();
            }

            if (e.ColumnIndex == grdRoles.Columns[3].Index && e.RowIndex >= 0) //boton eliminar
            {
                DialogResult res = MessageBox.Show("¿Esta seguro que desea eliminar el Rol " + rol + "?", "Alerta", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes) {
                    new RolFuncionalidadDao().EliminarRol(rol);
                    grdRoles.Rows.RemoveAt(e.RowIndex);
                }
            }

        }

        private void AgregarRol_Click(object sender, EventArgs e)
        {
            var agregarRol = new AgregarRol(this) {StartPosition = FormStartPosition.CenterParent};
            agregarRol.ShowDialog();
        }

        private void GestionarRoles_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarRoles()
        {

            grdRoles.Rows.Clear();

            RolFuncionalidadDao func = new RolFuncionalidadDao();
            List<Rol> roles = func.GetRoles();

            for (int i = 0; i < roles.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell estado = new DataGridViewTextBoxCell();
                DataGridViewButtonCell botonEditar = new DataGridViewButtonCell();
                botonEditar.Value = "Editar";
                DataGridViewButtonCell botonEliminar = new DataGridViewButtonCell();
                botonEliminar.Value = "Eliminar";
                
                estado.Value = roles[i].EstadoRol == true ? "Habilitado" : "Deshabilitado";
                DataGridViewCell text = new DataGridViewTextBoxCell();
                text.Value = roles[i].NombreRol;

                row.Cells.Add(text);
                row.Cells.Add(estado);
                row.Cells.Add(botonEditar);
                row.Cells.Add(botonEliminar);

                grdRoles.Rows.Add(row);

                estado.ReadOnly = true;
                text.ReadOnly = true;
            }
        }
    }
}
