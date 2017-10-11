using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class AfiliadoHistoricoPlan
    {
        public int IdAfiliadoHistoricoPlan { get; set; }
        public int IdUsuario { get; set; }
        public string Motivo { get; set; }
        public int Plan { get; set; }
        public DateTime FechaCambio { get; set; }
    }
}
