using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class InfoParaListado
    {
        public int Plan { get; set; }
        public int Especialidad { get; set; }
        public int Ano { get; set; }
        public int Semestre { get; set; }
        public int Mes { get; set; }
    }
}