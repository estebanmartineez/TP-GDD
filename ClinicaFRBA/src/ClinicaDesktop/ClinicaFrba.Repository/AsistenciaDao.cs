using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository
{
    public class AsistenciaDao : BaseDao<Asistencia>
    {

        public void generarAsistenciaConBono(int idBono, int idTurno)
        {
            String query = "INSERT INTO [INTERNAL_SERVER_ERROR].Asistencia (intIdTurno, datFechaYHora, varBono) VALUES (@turno, @fechaHoy, @bono)";
            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@turno", SqlDbType.Int).Value = idTurno;
            this.Command.Parameters.Add("@bono", SqlDbType.Int).Value = idBono;
            this.Command.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void generarAsistenciaSinBono(int idTurno)
        {
            String query = "INSERT INTO [INTERNAL_SERVER_ERROR].Asistencia (intIdTurno, datFechaYHora ) VALUES (@turno, @fechaHoy))";
            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@turno", SqlDbType.Int).Value = idTurno;
            this.Command.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override void Add(Asistencia entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Asistencia GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Asistencia entidad)
        {
            throw new NotImplementedException();
        }
    }
}
