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
using System.Text.RegularExpressions;

namespace ClinicaFrba.AbmRol
{
    public partial class AgregarRol : Form
    {
        GestionarRoles formPadre;
        public AgregarRol(GestionarRoles g)
        {
            InitializeComponent();
            this.formPadre = g;
        }

        private void AgregarRol_Load(object sender, EventArgs e)
        {
            var lstFuncionalidades = new List<string>();
            CargarListaFuncionalidades();
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void grdFuncionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Carga la grdFuncionalidades con las funcionalidades fijas que tiene el sistema
        /// </summary>
        private void CargarListaFuncionalidades()
        {
            RolFuncionalidadDao dao = new RolFuncionalidadDao();
            List<String> listaFuncionalidades = dao.GetFuncionalidades();

            for(int i=0; i < listaFuncionalidades.Count; i++)
            {
                this.grdFuncionalidades.Rows.Add(listaFuncionalidades[i]);
            }
        }

        /// <summary>
        /// Cierra la ventana descartando los cambios y vuelve a gestionar Roles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Se insertan los datos correspondientes en las tablas de Roles y Funcionalidades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Regex r = new Regex("^[a-zA-Z]*$");
            if (r.IsMatch(txtNombre.Text))
            {

                List<String> funcionalidades = new List<string>();
                var funcionalidadesSeleccionadas = grdFuncionalidades.Rows.Cast<DataGridViewRow>().Where(row => Convert.ToBoolean(row.Cells["Agregar"].Value) == true).ToList();

                funcionalidadesSeleccionadas.ForEach(row => funcionalidades.Add(row.Cells[0].Value.ToString()));
                RolFuncionalidadDao depi = new RolFuncionalidadDao();
                depi.GuardarRol(txtNombre.Text, funcionalidades, false);

                MessageBox.Show("Rol Creado Exitosamente!!!", "Aviso", MessageBoxButtons.OK);
                formPadre.CargarRoles();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Nombre de Rol Inválido", "Error", MessageBoxButtons.OK);
                return;
            }
         }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

    }
}
