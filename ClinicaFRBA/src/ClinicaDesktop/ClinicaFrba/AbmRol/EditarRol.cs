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
    public partial class EditarRol : Form
    {
        GestionarRoles formPadre;
        public EditarRol(String nombreRol, int estado, GestionarRoles g)
        {
            InitializeComponent();
            lblNombreRol.Text = nombreRol;
            this.formPadre = g;
            
            cbEstado.Items.Add("Deshabilitado");
            cbEstado.Items.Add("Habilitado");
            cbEstado.SelectedIndex = estado;
            

            this.CargarListaFuncionalidades();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            RolFuncionalidadDao dao = new RolFuncionalidadDao();

            List<String> funcionalidades = new List<string>();
            var funcionalidadesSeleccionadas = grdFuncionalidades.Rows.Cast<DataGridViewRow>().Where(row => Convert.ToBoolean(row.Cells["Agregar"].Value) == true).ToList();
            funcionalidadesSeleccionadas.ForEach(row => funcionalidades.Add(row.Cells[0].Value.ToString()));

            dao.EliminarRol(lblNombreRol.Text);

            dao.GuardarRol(lblNombreRol.Text, funcionalidades, true);

            int estado = cbEstado.SelectedIndex;
            dao.ActualizarEstadoRol(lblNombreRol.Text, estado);

            MessageBox.Show("Rol Modificado Con Exito", "Aviso", MessageBoxButtons.OK);

            formPadre.CargarRoles();

            this.Dispose();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void grdFuncionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditarRol_Load(object sender, EventArgs e)
        {

        }

        private void CargarListaFuncionalidades()
        {
            RolFuncionalidadDao  dao = new RolFuncionalidadDao();
            List<Funcionalidad> listaFuncionalidades = dao.GetFuncionalidadesEditar(lblNombreRol.Text);

            for (int i = 0; i < listaFuncionalidades.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell nombre = new DataGridViewTextBoxCell();
                DataGridViewCheckBoxCell estado = new DataGridViewCheckBoxCell();
                nombre.Value = listaFuncionalidades[i].NombreFuncionalidad;
                estado.Value = listaFuncionalidades[i].Habilitado ? true : false;         

                row.Cells.Add(nombre);
                row.Cells.Add(estado);

                this.grdFuncionalidades.Rows.Add(row);
             

            }
        }
    }
}
