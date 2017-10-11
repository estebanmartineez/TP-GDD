using System;

namespace ClinicaFrba.Repository.Entities
{
    public class Bono
    {
        public int Id { get; set; }
        public int CodigoPlan { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaImpresion { get; set; }
        public int IdAfiliadoCompro { get; set; }
        public int IdAfiliadoUtilizo { get; set; }
        public int NumeroConsultaMedica { get; set; }
    }
}
