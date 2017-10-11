using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class TurnoYUsuario
    {
        public DateTime FechaTurno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int idUsuario { get; set; }
        public int IdTurno { get; set; }
        public String Sintomas { get; set; }
        public String Diagnostico { get; set; }

        public String GetHora()
        {
            String var = FechaTurno.ToString("HH:mm"); 
            return var;
        }

        public String GetNombre()
        {
            return Nombre;
        }

        public String GetApellido()
        {
            return Apellido;
        }

        public int GetIdTurno()
        {
            return IdTurno;
        }

        public String GetSintomas()
        {
            return Sintomas;
        }

        public String GetDiagnostico()
        {
            return Diagnostico;
        }
    }
   
}
