using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Service.Common
{
    public class ActualizarHistorialCambiosDePlanRequest
    {
        public string MotivoCambio { get; set; }
        public int CodigoPlan { get; set; }
        public int IdUsuario  { get; set; }
    }
}
