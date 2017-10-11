using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Repository.Entities;

namespace ClinicaFrba.Service.Common
{
    public class CargarGrillaAfiliadoResponse
    {

        public CargarGrillaAfiliadoResponse()
        {
              Usuarios = new List<Usuario>();  
        }

        public List<Usuario> Usuarios { get; set; }
    }
}
