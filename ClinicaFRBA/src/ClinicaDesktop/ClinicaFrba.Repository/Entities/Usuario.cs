using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository.Entities
{
    public class Usuario
    {
        public int Username { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long NroAfiliado { get; set; } 
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Mail { get; set; }
        public int IntentosLogin { get; set; }
        //Afiliado 
        public int EstadoHabilitacion { get; set; }
        public string EstadoCivil { get; set; }
        public int CantidadFamiliaresACargo { get; set; }
        public int CodigoPlanMedico { get; set; }
        public int NumeroConsultaMedica { get; set; }
        //Profesional
        public int Matricula { get; set; }
        public int[] Especialidades { get; set; }

    }
}
