using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.Repository
{
    public class ListadoUsuarioDao : BaseDao<Usuario>
    {



        public List<Usuario> getProfesionalesMasConsultados(InfoParaListado info)
        {
            List<Usuario> vRetorno = new List<Usuario>();
            this.Connector.Open();

            String query = "";
            if (info.Mes != 0)
            {
                query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, t.intEspecialidadCodigo as especialidad, count(t.bitEstado) as atendidos" +
                "from [INTERNAL_SERVER_ERROR].Usuario as u inner join [INTERNAL_SERVER_ERROR].Turno as t on u.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) = " + info.Mes +
                "inner join [INTERNAL_SERVER_ERROR].Asistencia as a on a.intIdTurno = t.intIdTurno" +
                "inner join [INTERNAL_SERVER_ERROR].Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
                "where a.bitAtendido = 1 AND afi.intCodigoPlan =" + info.Plan +
                "group by u.intIdUsuario, t.intEspecialidadCodigo , u.varNombre, u.varApellido " +
                "order by atendidos desc;";
                                query = "select top 25 u.varNombre as nombre, u.varApellido as apellido, 'asd' as especialidad from [INTERNAL_SERVER_ERROR].Usuario u";
            }
            if (info.Mes == 0)
            {
                if (info.Semestre == 1)
                {
                     query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, t.intEspecialidadCodigo as especialidad, count(t.bitEstado) as atendidos" +
                "from [INTERNAL_SERVER_ERROR].Usuario as u inner join [INTERNAL_SERVER_ERROR].Turno as t on u.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) < 7 " +
                "inner join [INTERNAL_SERVER_ERROR].Asistencia as a on a.intIdTurno = t.intIdTurno" +
                "inner join [INTERNAL_SERVER_ERROR].Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
                "where a.bitAtendido = 1 AND afi.intCodigoPlan =" + info.Plan +
                "group by u.intIdUsuario, t.intEspecialidadCodigo  , u.varNombre, u.varApellido" +
                "order by atendidos desc;";
                }
                else
                {
                    query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, t.intEspecialidadCodigo as especialidad, count(t.bitEstado) as atendidos" +
                "from [INTERNAL_SERVER_ERROR].Usuario as u inner join [INTERNAL_SERVER_ERROR].Turno as t on u.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) > 6 " +
                "inner join [INTERNAL_SERVER_ERROR].Asistencia as a on a.intIdTurno = t.intIdTurno" +
                "inner join [INTERNAL_SERVER_ERROR].Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
                "where a.bitAtendido = 1 AND afi.intCodigoPlan =" + info.Plan +
                "group by u.intIdUsuario, t.intEspecialidadCodigo , u.varNombre, u.varApellido" +
                "order by atendidos desc;";
                }
            }


            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = resultado["nombre"].ToString();
                usuario.Apellido = resultado["apellido"].ToString();
                usuario.EstadoCivil = resultado["especialidad"].ToString();
                vRetorno.Add(usuario);
            }


            this.Connector.Close();

            return vRetorno;

        }



        public List<Usuario> getProfesionalesConMenosHorasTrabajadas(InfoParaListado info)
        {
            List<Usuario> vRetorno = new List<Usuario>();
            this.Connector.Open();
            String query = "";

            if (info.Mes != 0)
            {

                query = "select top 5 u.varApellido as apellido, u.varNombre as nombre, sum(DATEDIFF(minute, a.timeHoraInicio, a.timeHoraFin)) as horasTrabajadas"+
                "from [INTERNAL_SERVER_ERROR].Usuario u inner join [INTERNAL_SERVER_ERROR].Profesional p on p.intIdUsuario = u.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].ProfesionalXEspecialidad pxe on pxe.intIdUsuario = p.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Especialidad e on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo" +
                "inner join [INTERNAL_SERVER_ERROR].Agenda a on a.intIdProfesional = p.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Turno t on t.intIdDoctor = p.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Afiliado afi on afi.intIdUsuario = t.intIdPaciente" +
                "where afi.intCodigoPlan = "+ info.Plan +" and e.varDescripcion = "+ info.Especialidad +" AND YEAR(t.datFechaTurno) = " + info.Ano + "AND MONTH(t.datFechaTurno) = " + info.Mes +
                "group by u.varApellido, u.varNombre"+
                "order by horasTrabajadas asc;";

                query = "select top 25 u.varNombre as nombre, u.varApellido as apellido from [INTERNAL_SERVER_ERROR].Usuario u";
            }
            if (info.Mes == 0)
            {
                if (info.Semestre == 1)
                {
                query = "select top 5 u.varApellido as apellido, u.varNombre as nombre, sum(DATEDIFF(minute, a.timeHoraInicio, a.timeHoraFin)) as horasTrabajadas" +
                "from [INTERNAL_SERVER_ERROR].Usuario u inner join [INTERNAL_SERVER_ERROR].Profesional p on p.intIdUsuario = u.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].ProfesionalXEspecialidad pxe on pxe.intIdUsuario = p.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Especialidad e on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo" +
                "inner join [INTERNAL_SERVER_ERROR].Agenda a on a.intIdProfesional = p.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Turno t on t.intIdDoctor = p.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Afiliado afi on afi.intIdUsuario = t.intIdPaciente" +
                "where afi.intCodigoPlan = " + info.Plan + " and e.varDescripcion = " + info.Especialidad + " AND YEAR(t.datFechaTurno) = " + info.Ano + "AND MONTH(t.datFechaTurno) < 7"+
                "group by u.varApellido, u.varNombre" +
                "order by horasTrabajadas asc;";
                }
                if (info.Semestre == 2)
                {
                query = "select top 5 u.varApellido as apellido, u.varNombre as nombre, sum(DATEDIFF(minute, a.timeHoraInicio, a.timeHoraFin)) as horasTrabajadas" +
                "from [INTERNAL_SERVER_ERROR].Usuario u inner join [INTERNAL_SERVER_ERROR].Profesional p on p.intIdUsuario = u.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].ProfesionalXEspecialidad pxe on pxe.intIdUsuario = p.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Especialidad e on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo" +
                "inner join [INTERNAL_SERVER_ERROR].Agenda a on a.intIdProfesional = p.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Turno t on t.intIdDoctor = p.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Afiliado afi on afi.intIdUsuario = t.intIdPaciente" +
                "where afi.intCodigoPlan = " + info.Plan + " and e.varDescripcion = " + info.Especialidad + " AND YEAR(t.datFechaTurno) = " + info.Ano + "AND MONTH(t.datFechaTurno) > 6" +
                "group by u.varApellido, u.varNombre" +
                "order by horasTrabajadas asc;";
                }
            }

                this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                Usuario user = new Usuario();
                user.Apellido = resultado["apellido"].ToString();
                user.Nombre = resultado["nombre"].ToString();
                vRetorno.Add(user);
            }


            this.Connector.Close();

            return vRetorno;
        }

  

        public List<Usuario> getAfiliadosQueCompraronMasBonos(InfoParaListado info)
        {
            List<Usuario> vRetorno = new List<Usuario>();
            this.Connector.Open();
            String query = "";

            if (info.Mes != 0) {


          query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, (select count(1) from [INTERNAL_SERVER_ERROR].Afiliado a2 where a2.intIdUsuario = a.intIdUsuario +1 OR a2.intIdUsuario = a.intIdUsuario -1) as tieneIntegrantes" +
                "from [INTERNAL_SERVER_ERROR].Usuario u inner join [INTERNAL_SERVER_ERROR].Afiliado a on u.intIdUsuario = a.intIdUsuario" +
               "inner join [INTERNAL_SERVER_ERROR].Bono b on b.intIdAfiliadoCompro = a.intIdUsuario" +
               "where year(b.datFechaCompra) = "+ info.Ano + "and month(b.datFechaCompra) = " + info.Mes +
                "group by u.varNombre, u.varApellido, a.intIdUsuario" +
                "order by count(b.intIINTERNAL_SERVER_ERRORno) desc; ";

                      query = "select top 25 u.varNombre as nombre, u.varApellido as apellido, 1 as tieneIntegrantes from [INTERNAL_SERVER_ERROR].Usuario u";
            }
            if (info.Mes == 0)
            {
                if (info.Semestre == 1)
                {
                    query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, (select count(1) from [INTERNAL_SERVER_ERROR].Afiliado a2 where a2.intIdUsuario = a.intIdUsuario +1 OR a2.intIdUsuario = a.intIdUsuario -1) as tieneIntegrantes" +
                "from [INTERNAL_SERVER_ERROR].Usuario u inner join [INTERNAL_SERVER_ERROR].Afiliado a on u.intIdUsuario = a.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Bono b on b.intIdAfiliadoCompro = a.intIdUsuario" +
                "where year(b.datFechaCompra) = " + info.Ano + "and month(b.datFechaCompra) < 7" +
                "group by u.varNombre, u.varApellido, a.intIdUsuario" +
                "order by count(b.intIINTERNAL_SERVER_ERRORno) desc; ";
                }
                if (info.Semestre == 2)
                {
                    query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, (select count(1) from [INTERNAL_SERVER_ERROR].Afiliado a2 where a2.intIdUsuario = a.intIdUsuario +1 OR a2.intIdUsuario = a.intIdUsuario -1) as tieneIntegrantes" +
                "from [INTERNAL_SERVER_ERROR].Usuario u inner join [INTERNAL_SERVER_ERROR].Afiliado a on u.intIdUsuario = a.intIdUsuario" +
                "inner join [INTERNAL_SERVER_ERROR].Bono b on b.intIdAfiliadoCompro = a.intIdUsuario" +
                "where year(b.datFechaCompra) = " + info.Ano + "and month(b.datFechaCompra) > 6" +
                "group by u.varNombre, u.varApellido, a.intIdUsuario" +
                "order by count(b.intIINTERNAL_SERVER_ERRORno) desc; ";
                }
            }
              

                this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                Usuario user = new Usuario();
                user.Apellido = resultado["apellido"].ToString();
                user.Nombre = resultado["nombre"].ToString();
                user.CantidadFamiliaresACargo = Int32.Parse(resultado["tieneIntegrantes"].ToString());
                vRetorno.Add(user);
            }


           this.Connector.Close();

           return vRetorno;
        }



        public override void Add(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Usuario entidad)
        {
            throw new NotImplementedException();
        }

    }
}
