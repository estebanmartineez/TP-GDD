using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.AbmRol;
using ClinicaFrba.Properties;
using ClinicaFrba.Service;
using ClinicaFrba.Repository;

namespace ClinicaFrba
{
    public partial class Login : Form
    {

        LoginFunciones login;
        string user;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblRol.Visible = false;
            cbRoles.Visible = false;
            btnEntrar.Visible = false;

            this.CargarConfiguracionFecha();

            login = new LoginFunciones();
        }

        private void CargarConfiguracionFecha()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("FechaSistema", Resources.FechaSistema);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var pass = txtPassword.Text;

            ClinicaService service = new ClinicaService();
            LoginFunciones login = new LoginFunciones();

            if(username.Equals("admin") && pass.Equals("w23e"))
            {
                List<String> funcionalidades = login.TodasLasFuncionalidades();
                this.Hide();
                new Menu(funcionalidades, "admin", "admin").ShowDialog();
                this.Close();
                return;
            }
            else{
                if (!(new ClinicaService().EsCampoNumerico(username))){
                    MessageBox.Show("Usuario o Contraseña Incorrecta", "Alerta", MessageBoxButtons.OK);
                    return;
                }

            }

            var userValido = login.esUsuarioHabilitado(username);
            if (!userValido){
                MessageBox.Show("Ese usuario no esta habilitado", "Alerta", MessageBoxButtons.OK);
                return;
            }

            List<String> roles = login.Logearse(username, pass);
            if (roles.Count().Equals(0)){
                MessageBox.Show("Usuario o Contraseña Incorrecta", "Alerta", MessageBoxButtons.OK);
                return;
            }

            if (roles.Count == 0) {
                MessageBox.Show("Usuario o Contraseña Incorrecta", "Alerta", MessageBoxButtons.OK);
                login.IntentoFallido(username);
            }
            else {

                lblRol.Visible = true;
                cbRoles.Visible = true;
                btnEntrar.Visible = true;

                roles.ForEach(rol => cbRoles.Items.Add(rol));
                this.user = username;
            }

            
            cbRoles.SelectedItem = cbRoles.Items[0];
            //var roles = new GestionarRoles();
            //roles.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var rol = cbRoles.SelectedItem.ToString();
            List<String> funcionalidades = login.GetFuncionalidadesDeRol(rol);
            new Menu(funcionalidades, rol, this.user).Show();
        }
    }
}