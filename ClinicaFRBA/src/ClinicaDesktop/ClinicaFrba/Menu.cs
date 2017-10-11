using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Abm_Especialidades_Medicas;
using ClinicaFrba.Abm_Planes;
using ClinicaFrba.Abm_Profesional;
using ClinicaFrba.AbmRol;
using ClinicaFrba.Cancelar_Atencion;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Listados;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.Registrar_Agenta_Medico;
using ClinicaFrba.Registro_Llegada;
using ClinicaFrba.Registro_Resultado;
using ClinicaFrba.RegistroResultado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class Menu : Form
    {

        List<String> funcionalidades;
        string rol;
        string username;

        public Menu(List<String> funcs, string rol, string username)
        {
            InitializeComponent();

            this.funcionalidades = funcs;
            this.rol = rol;
            this.username = username;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            var distY = 50;

            for (int i = 0; i < funcionalidades.Count(); i++)
            {

                Button boton = crearBoton(distY, funcionalidades[i]);
                this.Controls.Add(boton);

                distY += 50;

                this.Height += 40;
            }

        }

        Button crearBoton(int distY, String func)
        {
            Button boton = new Button();
            boton.Width = 200;
            boton.Left = 50;
            boton.Top = distY;
            boton.Text = func;
            switch (func)
            {
                case "ABM Rol":
                    boton.Click += new EventHandler(this.lanzarABMRol);
                    break;
                case "ABM Afiliado":
                    boton.Click += new EventHandler(this.lanzarABMAfiliado);
                    break;
                case "ABM Profesional":
                    boton.Click += new EventHandler(this.lanzarABMProfesional);
                    break;
                case "ABM Esp Medicas":
                    boton.Click += new EventHandler(this.lanzarABMEspecialidades);
                    break;
                case "ABM Planes":
                    boton.Click += new EventHandler(this.lanzarABMPlanes);
                    break;
                case "Registrar Agenda":
                    boton.Click += new EventHandler(this.lanzarRegistrarAgenda);
                    break;
                case "Comprar Bonos":
                    boton.Click += new EventHandler(this.lanzarComprarBonos);
                    break;
                case "Pedir Turnos":
                    if(this.username.Equals("admin"))
                        boton.Click += new EventHandler(this.lanzarPedirTurnosAdmin);
                    else
                        boton.Click += new EventHandler(this.lanzarPedirTurnos);
                    break;
                case "Registro Llegada Atencion Medica":
                    boton.Click += new EventHandler(this.lanzarLlegadaAtencion);
                    break;
                case "Registro Resultado Atencion Medica":
                    if (this.username.Equals("admin"))
                        boton.Click += new EventHandler(this.lanzarResultadoAtencionAdmin);
                    else
                        boton.Click += new EventHandler(this.lanzarResultadoAtencion);
                    break;
                case "Cancelar Atencion Medica":
                    if(this.rol.Equals("Profesional") || this.rol.Equals("admin"))
                        boton.Click += new EventHandler(this.lanzarCancelarAtencionProfesional);
                    else
                         boton.Click += new EventHandler(this.lanzarCancelarAtencionAfiliado);
                    break;
                case "Listado Estadistico":
                    boton.Click += new EventHandler(this.lanzarListadoEstadistico);
                    break;
            }
            
            return boton;
        }

        private void lanzarABMRol(object sender, EventArgs e)
        {
            this.Hide();
            new GestionarRoles().ShowDialog();
            this.Show();
        }

        private void lanzarABMAfiliado(object sender, EventArgs e)
        {
            this.Hide();
            new GestionarAfiliados().ShowDialog();
            this.Show();
        }

        private void lanzarABMProfesional(object sender, EventArgs e)
        {
            this.Hide();
            new GestionarProfesional().ShowDialog();
            this.Show();
        }

        private void lanzarABMEspecialidades(object sender, EventArgs e)
        {
            this.Hide();
            new GestionarEspecialidades().ShowDialog();
            this.Show();
        }

        private void lanzarABMPlanes(object sender, EventArgs e)
        {
            this.Hide();
            new GestionarPlanes().ShowDialog();
            this.Show();
        }

        private void lanzarRegistrarAgenda(object sender, EventArgs e)
        {
            this.Hide();
            new SeleccionarProfecional().ShowDialog();
            this.Show();
        }

        private void lanzarComprarBonos(object sender, EventArgs e)
        {
            this.Hide();
            new VentanaIntermedioAdministrativo().ShowDialog();
            this.Show();
        }

        private void lanzarPedirTurnosAdmin(object sender, EventArgs e)
        {
            this.Hide();
            new PedidoDeTurno().ShowDialog();
            this.Show();
        }

        private void lanzarPedirTurnos(object sender, EventArgs e)
        {
            this.Hide();
            new PedidoDeTurno(Int32.Parse(this.username)).ShowDialog();
            this.Show();
        }

        private void lanzarLlegadaAtencion(object sender, EventArgs e)
        {
            this.Hide();
            new RegistroLlegadaBusqueda().ShowDialog();
            this.Show();
        }

        private void lanzarResultadoAtencion(object sender, EventArgs e)
        {
            this.Hide();
            new AccesoPlanillas(Int32.Parse(this.username)).ShowDialog();
            this.Show();
        }

        private void lanzarResultadoAtencionAdmin(object sender, EventArgs e)
        {
            this.Hide();
            new AccesoPlanillas().ShowDialog();
            this.Show();
        }

        private void lanzarCancelarAtencionAfiliado(object sender, EventArgs e)
        {
            this.Hide();
            new CancelarTurno().ShowDialog();
            this.Show();
        }

        private void lanzarCancelarAtencionProfesional(object sender, EventArgs e)
        {
            this.Hide();
            new CancelarAtencionMedica().ShowDialog();
            this.Show();
        }

        private void lanzarListadoEstadistico(object sender, EventArgs e)
        {
            this.Hide();
            new GenerarListado().ShowDialog();
            this.Show();
        }





    }
}
