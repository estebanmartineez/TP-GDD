using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Service.Common
{
    public class ObtenerListadoPlanesResponse
    {
        public ObtenerListadoPlanesResponse()
        {
            DescPlanes = new List<string>();
        }

        public List<string> DescPlanes { get; set; }
    }
}
