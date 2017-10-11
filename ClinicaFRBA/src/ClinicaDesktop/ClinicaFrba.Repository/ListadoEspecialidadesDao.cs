using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Repository.Entities;

namespace ClinicaFrba.Repository
{
    public class ListadoEspecialidadesDao : BaseDao<Especialidad>
    {


        public List<string> getEspecialidadesMasCanceladas(InfoParaListado info)
        {
            List<string> vRetorno = new List<string>();
            this.Connector.Open();
            String query = "";
            if (info.Mes != 0) {
                query = "select top 5 e.varDescripcion as descripcion " +
                        "from [INTERNAL_SERVER_ERROR].Especialidad e inner join [INTERNAL_SERVER_ERROR].Turno t on t.intEspecialidadCodigo = e.intEspecialidadCodigo " +
                        "inner join [INTERNAL_SERVER_ERROR].Asistencia a on a.intIdTurno = t.intIdTurno " +
                        "where year(t.datFechaTurno) =" + info.Ano + " and month(t.datFechaTurno)= " + info.Mes + " and t.bitEstado = 0 " +
                        " group by e.varDescripcion " +
                        " order by count(t.intIdTurno) desc; ";

                query = "select top 5 e.varDescripcion as descripcion  from [INTERNAL_SERVER_ERROR].Especialidad e";
            }
            if(info.Mes == 0)
            {
                if(info.Semestre == 1) {
                    query = "select top 5 e.varDescripcion as descripcion " +
                            "from [INTERNAL_SERVER_ERROR].Especialidad e inner join [INTERNAL_SERVER_ERROR].Turno t on t.intEspecialidadCodigo = e.intEspecialidadCodigo " +
                            "inner join [INTERNAL_SERVER_ERROR].Asistencia a on a.intIdTurno = t.intIdTurno " +
                            "where year(t.datFechaTurno) =" + info.Ano + "and month(t.datFechaTurno) < 7 and t.bitEstado = 0 " +
                            "group by e.varDescripcion " +
                            "order by count(t.intIdTurno) desc; ";
                }
                else
                {
                    query = "select top 5 e.varDescripcion as descripcion " +
                            "from [INTERNAL_SERVER_ERROR].Especialidad e inner join [INTERNAL_SERVER_ERROR].Turno t on t.intEspecialidadCodigo = e.intEspecialidadCodigo " +
                            "inner join [INTERNAL_SERVER_ERROR].Asistencia a on a.intIdTurno = t.intIdTurno " +
                            "where year(t.datFechaTurno) =" + info.Ano + " and month(t.datFechaTurno) > 6 and t.bitEstado = 0 " +
                            "group by e.varDescripcion " +
                            "order by count(t.intIdTurno) desc; ";
                }
            }
            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                vRetorno.Add(resultado["descripcion"].ToString());
            }


            this.Connector.Close();

            return vRetorno;

        }

        public List<string> getEspecialidadesMasConsultadas(InfoParaListado info)
        {
            List<string> vRetorno = new List<string>();
            this.Connector.Open();
            String query ="";
            if (info.Mes != 0)
            {
                query = "select top 5 e.varDescripcion as descripcion " +
                "from [INTERNAL_SERVER_ERROR].Especialidad e inner join [INTERNAL_SERVER_ERROR].Turno t on t.intEspecialidadCodigo = e.intEspecialidadCodigo " +
                "inner join [INTERNAL_SERVER_ERROR].Asistencia a on a.intIdTurno = t.intIdTurno " +
                "where year(t.datFechaTurno) =" + info.Ano + " and month(t.datFechaTurno) = " + info.Mes +
                "group by e.varDescripcion " +
                "order by count(a.bitAtendido) desc; ";

                query = "select top 5 e.varDescripcion as descripcion  from [INTERNAL_SERVER_ERROR].Especialidad e";

            }
            if (info.Mes == 0)
            {
                if (info.Semestre == 1)
                {
                    query = "select top 5 e.varDescripcion as descripcion " +
                    "from [INTERNAL_SERVER_ERROR].Especialidad e inner join [INTERNAL_SERVER_ERROR].Turno t on t.intEspecialidadCodigo = e.intEspecialidadCodigo " +
                    "inner join [INTERNAL_SERVER_ERROR].Asistencia a on a.intIdTurno = t.intIdTurno " +
                    "where year(t.datFechaTurno) =" + info.Ano + " and month(t.datFechaTurno) < 7 " + 
                    "group by e.varDescripcion " +
                    "order by count(a.bitAtendido) desc;";
                }
                else
                {
                    query = "select top 5 e.varDescripcion as descripcion " +
                    "from [INTERNAL_SERVER_ERROR].Especialidad e inner join [INTERNAL_SERVER_ERROR].Turno t on t.intEspecialidadCodigo = e.intEspecialidadCodigo " +
                    "inner join [INTERNAL_SERVER_ERROR].Asistencia a on a.intIdTurno = t.intIdTurno " +
                    "where year(t.datFechaTurno) =" + info.Ano + " and month(t.datFechaTurno) > 6 " +
                    "group by e.varDescripcion " +
                    "order by count(a.bitAtendido) desc; ";
                }
            }

            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                vRetorno.Add(resultado["descripcion"].ToString());
            }


                this.Connector.Close();

                return vRetorno;

        }


        public override void Add(Especialidad entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Especialidad GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Especialidad entidad)
        {
            throw new NotImplementedException();
        }
    }
    

}
