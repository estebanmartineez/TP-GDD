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

namespace ClinicaFrba.Listados
{
    public partial class GenerarListado : Form
    {
        public GenerarListado()
        {
            InitializeComponent();
            CargarComboBoxes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblCuatrimestre_Click(object sender, EventArgs e)
        {

        }

        private void lblmes_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cboListado.Text)
            {
                case "Especialidades con más cancelaciones":
                    this.cboPlan.SelectedIndex = -1;
                    this.cboEspecialidad.SelectedIndex = -1;
                    this.cboPlan.Enabled = false;
                    this.cboEspecialidad.Enabled = false;
                    break;
                case "Profecionales más consultados":
                    this.cboEspecialidad.SelectedIndex = -1;
                    this.cboPlan.Enabled = true;
                    this.cboEspecialidad.Enabled = false;
                    break;
                case "Profesional con menos horas trabajadas":
                    this.cboPlan.Enabled = true;
                    this.cboEspecialidad.Enabled = true;
                    break;
                case "Afiliados que más bonos compraron":
                    this.cboPlan.SelectedIndex = -1;
                    this.cboEspecialidad.SelectedIndex = -1;
                    this.cboPlan.Enabled = false;
                    this.cboEspecialidad.Enabled = false;
                    break;
                case "Especialidades más consultadas":
                    this.cboPlan.SelectedIndex = -1;
                    this.cboEspecialidad.SelectedIndex = -1;
                    this.cboPlan.Enabled = false;
                    this.cboEspecialidad.Enabled = false;
                    break;
                default:
                    break;
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboSemestre.SelectedItem as ComboboxItem).Text.ToString().Equals("Primer Semestre"))
            {
                this.cboMes.Items.Clear();
                ComboboxItem item = new ComboboxItem();
                item.Text = "Enero";
                item.Value = 1;
                this.cboMes.Items.Add(item);
                item.Text = "Febrero";
                item.Value = 2;
                this.cboMes.Items.Add(item);
                item.Text = "Marzo";
                item.Value = 3;
                this.cboMes.Items.Add(item);
                item.Text = "Abril";
                item.Value = 4;
                this.cboMes.Items.Add(item);
                item.Text = "Mayo";
                item.Value = 5;
                this.cboMes.Items.Add(item);
                item.Text = "Junio";
                item.Value = 6;
                this.cboMes.Items.Add(item);
            }
            if ((cboSemestre.SelectedItem as ComboboxItem).Text.ToString().Equals("Segundo Semestre"))
            {
                this.cboMes.Items.Clear();
                ComboboxItem item = new ComboboxItem();
                item.Text = "Julio";
                item.Value = 7;
                this.cboMes.Items.Add(item);
                item.Text = "Agosto";
                item.Value = 8;
                this.cboMes.Items.Add(item);
                item.Text = "Septiembre";
                item.Value = 9;
                this.cboMes.Items.Add(item);
                item.Text = "Octubre";
                item.Value = 10;
                this.cboMes.Items.Add(item);
                item.Text = "Noviembre";
                item.Value = 11;
                this.cboMes.Items.Add(item);
                item.Text = "Diciembre";
                item.Value = 12;
                this.cboMes.Items.Add(item);
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnHacerListado_Click_1(object sender, EventArgs e)
        {

            if (todasLasComboBoxesCompletas())
            {
                InfoParaListado info = new InfoParaListado();
                info.Ano = Int32.Parse(cboAño.Text.ToString());
                info.Semestre = Int32.Parse((cboSemestre.SelectedItem as ComboboxItem).Value.ToString());
                if (this.cboMes.Text != "")
                {
                    info.Mes = Int32.Parse((cboMes.SelectedItem as ComboboxItem).Value.ToString());
                }

                   if (cboListado.Text.Equals("Especialidades con más cancelaciones"))
                   {
                       ListadoEspecialidadesDao list = new ListadoEspecialidadesDao();
                       this.generarTablaEsp(list.getEspecialidadesMasCanceladas(info));
                      return;
                  }

                if (cboListado.Text.Equals("Profecionales más consultados"))
                {
                    if(chequeoPlan())
                    {
                       info.Plan = Int32.Parse((cboPlan.SelectedItem as ComboboxItem).Value.ToString());
                        ListadoUsuarioDao list = new ListadoUsuarioDao();
                       this.generarTablaConProfYEsp(list.getProfesionalesMasConsultados(info));
                       return;
                    }
                  return;
                }

                if (cboListado.Text.Equals("Profesional con menos horas trabajadas"))
                {
                    if (chequeoEspecialidad() && chequeoPlan())
                    {
                        info.Especialidad = Int32.Parse((cboEspecialidad.SelectedItem as ComboboxItem).Value.ToString());
                        info.Plan = Int32.Parse((cboPlan.SelectedItem as ComboboxItem).Value.ToString());
                        ListadoUsuarioDao list = new ListadoUsuarioDao();
                        this.generarTabla(list.getProfesionalesConMenosHorasTrabajadas(info));
                        return;
                    }
                    return;
                }

                if (cboListado.Text.Equals("Afiliados que más bonos compraron"))
                {
                    ListadoUsuarioDao list = new ListadoUsuarioDao();
                    this.generarTablaConAfiliadoYGFam(list.getAfiliadosQueCompraronMasBonos(info));
                    return;
                }

                if (cboListado.Text.Equals("Especialidades más consultadas"))
                {
                    ListadoEspecialidadesDao list = new ListadoEspecialidadesDao();
                    this.generarTablaEsp(list.getEspecialidadesMasConsultadas(info));
                    return;
                }

                MessageBox.Show("Por favor, chequee que la lista seleccionada sea válida", "Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void generarTablaConAfiliadoYGFam(List<Usuario> lista)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Nombre";
                dataGridView1.Columns[1].Name = "Apellido";
                dataGridView1.Columns[2].Name = "Grupo familiar";
            for (int i = 1; i < lista.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = lista[i].Nombre;
                row.Cells[1].Value = lista[i].Apellido;
                if(lista[i].CantidadFamiliaresACargo == 0)
                {
                    row.Cells[2].Value = "No pertenece a un grupo familiar";
                }
                else
                {
                    row.Cells[2].Value = "Pertenece a un grupo familiar";
                }

                    dataGridView1.Rows.Add(row);
            }
        }

        private void generarTablaConProfYEsp(List<Usuario> lista)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Nombre";
            dataGridView1.Columns[1].Name = "Apellido";
            dataGridView1.Columns[2].Name = "Especialidad";
            for (int i = 1; i < lista.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = lista[i].Nombre;
                row.Cells[1].Value = lista[i].Apellido;
                row.Cells[2].Value = lista[i].EstadoCivil;
                dataGridView1.Rows.Add(row);
            }
        }

        private void generarTabla(List<Usuario> lista)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Nombre";
            dataGridView1.Columns[1].Name = "Apellido";
            for (int i = 1; i < lista.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = lista[i].Nombre;
                row.Cells[1].Value = lista[i].Apellido;
                dataGridView1.Rows.Add(row);
            }
        }

        private void generarTablaEsp(List<string> lista)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "especialidad";
            for (int i = 0; i < lista.Count; i++)
            {
                             DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                             row.Cells[0].Value = lista[i];
                             dataGridView1.Rows.Add(row);              
            }
        }


        private void CargarComboBoxes()
        {

            this.cboAño.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboListado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboMes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboSemestre.DropDownStyle = ComboBoxStyle.DropDownList;


            this.cboListado.Items.Add("Especialidades con más cancelaciones");
            this.cboListado.Items.Add("Profecionales más consultados");
            this.cboListado.Items.Add("Profesional con menos horas trabajadas");
            this.cboListado.Items.Add("Afiliados que más bonos compraron");
            this.cboListado.Items.Add("Especialidades más consultadas");


            ComboboxItem item = new ComboboxItem();
            item.Text = "Primer Semestre";
            item.Value = 1;
            cboSemestre.Items.Add(item);
            ComboboxItem item2 = new ComboboxItem();
            item2.Text = "Segundo Semestre";
            item2.Value = 2;
            cboSemestre.Items.Add(item2);

            cargarAños();
            cargarPlanes();
            cargarEspecialidades();

        }

        private void CargarTurnosDelDia(int idDoctor)
        {


        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool todasLasComboBoxesCompletas()
        {

            if (cboListado.SelectedIndex == -1)
            {
                MessageBox.Show("No se seleccionó un tipo de Listado", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (cboSemestre.SelectedIndex == -1)
            {
                MessageBox.Show("No se seleccionó un Semestre para la búsqueda", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (cboListado.Text.Equals("Profesional con menos horas trabajadas"))
            {
                if (cboPlan.SelectedIndex == -1)
                {
                    MessageBox.Show("No se seleccionó un Plan para la búsqueda", "Error", MessageBoxButtons.OK);
                    return false;
                }
                if (cboEspecialidad.SelectedIndex == -1)
                {
                    MessageBox.Show("No se seleccionó una Especialidad para la búsqueda", "Error", MessageBoxButtons.OK);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(cboAño.Text))
            {
                MessageBox.Show("No se seleccionó un Año para la búsqueda", "Error", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private bool chequeoPlan()
        {
            if (string.IsNullOrEmpty(cboPlan.Text.ToString()))
            {
                MessageBox.Show("No se seleccionó un Plan para la búsqueda", "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private bool chequeoEspecialidad()
        {
            if (string.IsNullOrEmpty(cboEspecialidad.Text.ToString()))
            {
                MessageBox.Show("No se seleccionó una Especialidad para la búsqueda", "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void cboPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarEspecialidades()
        {
            TurnoFunciones turno = new TurnoFunciones();

            List<Especialidad> especialidades = turno.getIdEspecialidadesDB();


            foreach (Especialidad esp in especialidades)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = esp.Descripcion;
                item.Value = esp.Codigo;
                this.cboEspecialidad.Items.Add(item);
            }


        }

        private void cargarPlanes()
        {
            PlanDao plan = new PlanDao();

            List<Plan> planesVigentes = plan.ListarPlanesMedicosVigentes();

            foreach (Plan pln in planesVigentes)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = pln.Descripcion;
                item.Value = pln.Codigo;
                this.cboPlan.Items.Add(item);
            }

        }

        private void cargarAños()
        {
            TurnoDao turno = new TurnoDao();

            List<int> añosAMostrar = turno.añosConTurnos();

            añosAMostrar.ForEach(año => this.cboAño.Items.Add(año));
        }
    }
}
