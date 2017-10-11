using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository
{
    public class ProfesionalDao : BaseDao<Usuario>
    {

        public ProfesionalDao() : base()
        {

        }


        public List<Usuario> GetProfesionales()
        {

            List<Usuario> lista = new List<Usuario>();

            String query = "select varNombre, varApellido, u.intIdUsuario from [INTERNAL_SERVER_ERROR].Usuario u inner join [INTERNAL_SERVER_ERROR].UsuarioXRol ur on u.intIdUsuario = ur.intIdUsuario where varNombreRol = 'Profesional'";

            this.Command = new SqlCommand(query, this.Connector);
            this.Connector.Open();

            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Username = Int32.Parse(reader["intIdUsuario"].ToString());
                usuario.Nombre = reader["varNombre"].ToString();
                usuario.Apellido = reader["varApellido"].ToString();

                lista.Add(usuario);
            }

            this.Connector.Close();

            return lista;
        }

        //este lo uso para la funcionalidad de registrar llegada
        public List<Profesional> getProfesionalesPorEspecialidad(string apellido, string especialidad)
        {
            List<Profesional> lista = new List<Profesional>();

            string query = "select u.intIdUsuario id, u.varNombre nombre, u.varApellido apellido, e.varDescripcion esp from [INTERNAL_SERVER_ERROR].Usuario u inner join [INTERNAL_SERVER_ERROR].ProfesionalXEspecialidad pe on pe.intIdUsuario = u.intIdUsuario inner join [INTERNAL_SERVER_ERROR].Especialidad e on e.intEspecialidadCodigo = pe.intEspecialidadCodigo where u.varApellido like '%" + apellido + "%'";
            if (especialidad != "-") query += " and e.varDescripcion = '" + @especialidad + "'";

            this.Command = new SqlCommand(query, this.Connector);
            // this.Command.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido;
            //if (especialidad != "") this.Command.Parameters.Add("@especialidad", SqlDbType.VarChar).Value = especialidad;
            this.Connector.Open();


            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                Profesional prof = new Profesional();
                prof.id = Int32.Parse(reader["id"].ToString());
                prof.nombre = reader["nombre"].ToString();
                prof.apellido = reader["apellido"].ToString();
                prof.especialidad = reader["esp"].ToString();

                lista.Add(prof);
            }

            this.Connector.Close();


            return lista;

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
