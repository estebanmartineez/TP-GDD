using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class Consulta
    {
        public int NumeroDeTurno { get; set; }
        public DateTime FechaYHora { get; set; }
        public string Sintoma { get; set; }
        public string Diagnostico { get; set; }
    }
}
