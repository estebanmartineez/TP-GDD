using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class Especialidad
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int CodigoTipo { get; set; }
        public string  DescripcionCodigoTipo { get; set; }
    }
}
