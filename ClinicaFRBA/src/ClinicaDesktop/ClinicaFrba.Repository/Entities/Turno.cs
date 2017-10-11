using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class Turno
    {
        public int NumeroDeTurno { get; set; }
        public DateTime FechaTurno { get; set; }
        public int IdPaciente { get; set; }
        public int IdDoctor { get; set; }
        public bool EstadoTurno { get; set; }
    }
}
