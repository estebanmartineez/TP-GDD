using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class Asistencia
    {
        public int NumeroDeTurno { get; set; }
        public DateTime FechaYHora{ get; set; }
        public int NumeroBono { get; set; }
        public bool Atendido { get; set; }
    }
}
