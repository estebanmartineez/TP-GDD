using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Repository.Entities;

namespace ClinicaFrba.Repository
{
    public class TurnoDao : BaseDao<TurnoYUsuario> 
    {
     
        public TurnoDao() : base()
        {
                
        }
    

        public List<TurnoYUsuario> GetTurnos(int idDoctor)
        {
            DateTime dt = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            List<TurnoYUsuario> vRetorno = new List<TurnoYUsuario>();
            DateTime thisDay = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            this.Connector.Open();
            String query = "SELECT u.varNombre AS nombre, u.varApellido AS apellido, t.intIdTurno AS idTurno, t.datFechaTurno AS fecha " +
                "FROM [INTERNAL_SERVER_ERROR].Turno AS t INNER JOIN [INTERNAL_SERVER_ERROR].Afiliado AS af  on t.intIdPaciente = af.intIdUsuario INNER JOIN [INTERNAL_SERVER_ERROR].Usuario as u on u.intIdUsuario = af.intIdUsuario " +
                "WHERE t.intIdDoctor = " + idDoctor + " AND CAST(t.datFechaTurno AS DATE) =  CAST('20150101' AS DATE);" ;
            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();
            
            
            while (resultado.Read())
            {
                  TurnoYUsuario turno = new TurnoYUsuario();
                  turno.Nombre = resultado["nombre"].ToString();
                  turno.Apellido = resultado["apellido"].ToString();
                  DateTime fechaBuscada = DateTime.Parse(resultado ["fecha"].ToString());
                  turno.FechaTurno = fechaBuscada;
                  turno.IdTurno = Int32.Parse(resultado["idTurno"].ToString());
                  vRetorno.Add(turno);
            }

           
            this.Connector.Close();

            return vRetorno;

        }

        public void ConfirmarLlegadaPaciente (int id)
        {
            String idUtilizado = (id.ToString());
            String query = "UPDATE [INTERNAL_SERVER_ERROR].Asistencia set bitAtendido = 1 where intIdTurno =" + idUtilizado +";" ;
            this.Command = new SqlCommand(query, this.Connector);
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void ActualizarTurnoCompletado (TurnoYUsuario turno)
        {   

           String query = "UPDATE [INTERNAL_SERVER_ERROR].Consulta SET varSintomas = '" + turno.Sintomas.ToString()+
                          "', varEnfermedad = '"+turno.Diagnostico.ToString() +
                          "' where intIdTurno = "+turno.IdTurno.ToString()+";" ;
            this.Command = new SqlCommand(query, this.Connector);
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

        }


        public void GuardarTurnoCancelado(TurnoCancelado turno)
        {
            string query = "INSERT INTO [INTERNAL_SERVER_ERROR].TurnoCancelado (intIdTurno, varMotivo, varTipo) VALUES (@id, @motivo, @turno)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = turno.NumeroDeTurno;
            this.Command.Parameters.Add("@motivo", SqlDbType.VarChar, 50).Value = turno.motivo;
            this.Command.Parameters.Add("@turno", SqlDbType.VarChar, 50).Value = turno.tipo;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

            String query2 = "DELETA FROM [INTERNAL_SERVER_ERROR].Turno WHERE intIdTurno = @id";
            this.Command = new SqlCommand(query2, this.Connector);
            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = turno.NumeroDeTurno;
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        //funcionalidad del profesional 
        public void CancelarTurnosPorRangoDeFechas(String fechaDesde, string fechaHasta, string motivo, string tipo)
        {
            String query = "INSERT INTO [INTERNAL_SERVER_ERROR].TurnoCancelado (intIdTurno, varMotivo, varTipo) " +
               " SELECT intIdTurno, '@motivo', '@tipoCancelacion' FROM [INTERNAL_SERVER_ERROR].Turno where CONVERT(date, datFechaTurno) > '" + @fechaDesde+"' and CONVERT(date, datFechaTurno) < '"+@fechaHasta+"'";


            this.Command = new SqlCommand(query, this.Connector);
            //this.Command.Parameters.Add("@fechaDesde", SqlDbType.VarChar, 20).Value = fechaDesde;
            //this.Command.Parameters.Add("@fechaDesde", SqlDbType.VarChar, 20).Value = fechaDesde;
            this.Command.Parameters.Add("@motivo", SqlDbType.VarChar, 100).Value = motivo;
            this.Command.Parameters.Add("@tipoCancelacion", SqlDbType.VarChar, 40).Value = tipo;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

            String query2 = "DELETE FROM [INTERNAL_SERVER_ERROR].Turno WHERE CONVERT(date, datFechaTurno) > '" + @fechaDesde+"' and CONVERT(date, datFechaTurno) < '"+@fechaHasta+"'";
            this.Command = new SqlCommand(query2, this.Connector);
            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public List<TurnoYUsuario> turnosDeAfiliado(int id)
        {
            List<TurnoYUsuario> turnos = new List<TurnoYUsuario>();

            string query = "SELECT t.intIdTurno id, t.datFechaTurno fecha, u.varNombre nombre, u.varApellido apellido from [INTERNAL_SERVER_ERROR].Turno  t inner join [INTERNAL_SERVER_ERROR].Usuario u on t.intIdDoctor = u.intIdUsuario where t.intIdPaciente = @id and CONVERT(date, t.datFechaTurno) > @fechaHoy";
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            this.Command.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            this.Connector.Open();
            SqlDataReader dataTurnos = this.Command.ExecuteReader();

            while (dataTurnos.Read())
            {
                //si bien usuario creo que hacia refencia al afiliado, uso la entidad para traer datos del medico
                TurnoYUsuario turno = new TurnoYUsuario();
                turno.IdTurno = Int32.Parse(dataTurnos["id"].ToString());
                turno.FechaTurno = DateTime.Parse(dataTurnos["fecha"].ToString());
                turno.Nombre = dataTurnos["nombre"].ToString();
                turno.Apellido = dataTurnos["apellido"].ToString();

                turnos.Add(turno);
            }


            this.Connector.Close();

            return turnos;
        }

        public List<int> añosConTurnos()
        {
            this.Connector.Open();
            List<int> años = new List<int>();
            string query = "SELECT distinct(YEAR(t.datFechaTurno)) fecha from [INTERNAL_SERVER_ERROR].Turno t";
            this.Command = new SqlCommand(query, this.Connector);

             SqlDataReader resultado = Command.ExecuteReader();

            while (resultado.Read())
            {
                años.Add(Int32.Parse(resultado["fecha"].ToString()));
            }
            this.Connector.Close();
            return años;
        }

        public List<TurnoYUsuario> turnosDeHoy(int idProfesional)
        {
            string query = "SELECT t.intIdTurno idTurno, u.intIdUsuario id t.datFechaYHora fecha, u.varNombre nombre, u.varApellido apellido from [INTERNAL_SERVER_ERROR].Turno t INNER JOIN [INTERNAL_SERVER_ERROR].Usuario u ON t.intIdPaciente=u.intIdUsuario where t.datFechaYHora = @fechaHoy and t.intIdDoctor=" + idProfesional;

         
            List<TurnoYUsuario> turnos = new List<TurnoYUsuario>();

            this.Connector.Open();
            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            SqlDataReader resultado = Command.ExecuteReader();

            while (resultado.Read())
            {
                TurnoYUsuario turno = new TurnoYUsuario();
                turno.Apellido = resultado["apellido"].ToString();
                turno.Nombre = resultado["nombre"].ToString();
                turno.FechaTurno = DateTime.Parse(resultado["fecha"].ToString());
                turno.idUsuario = Int32.Parse(resultado["id"].ToString());
                turno.IdTurno = Int32.Parse(resultado["idTurno"].ToString());
            }

            this.Connector.Close();
            return turnos;
        }

        public override void Add(TurnoYUsuario entidad)
        {
            throw new NotImplementedException();
        }

        public override void Update(TurnoYUsuario entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override TurnoYUsuario GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
