using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.AbmRol;
using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.Registro_Resultado;
using ClinicaFrba.RegistroResultado;
using ClinicaFrba.Registrar_Agenta_Medico;
using ClinicaFrba.Cancelar_Atencion;
using ClinicaFrba.Listados;
using ClinicaFrba.Registro_Llegada;

namespace ClinicaFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
