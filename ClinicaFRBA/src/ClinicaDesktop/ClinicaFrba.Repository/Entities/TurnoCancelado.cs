using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class TurnoCancelado
    {
        public int NumeroDeTurno { get; set; }
        public string motivo { get; set; }
        public string tipo { get; set; }
    }
}
