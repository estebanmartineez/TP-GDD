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
    public class RolFuncionalidadDao : BaseDao<Rol>
    {

        public RolFuncionalidadDao() : base()
        {
         
        }

        public List<String> GetFuncionalidades()
        {
            String query = "select distinct varFuncionalidad FROM [INTERNAL_SERVER_ERROR].Funcionalidad ";
            this.Command = new SqlCommand(query, this.Connector);

            List<String> listaFuncionalidads = new List<string>();

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();
            
            for(; resultado.Read();)
            {
                listaFuncionalidads.Add(resultado[0].ToString());
            }

            this.Connector.Close();


            return listaFuncionalidads;
        }

        public void GuardarRol(String nombre, List<String> funcionalidades, bool editar)
        {

            List<int> posiciones = new List<int>();
            this.Connector.Open();
            for (var i = 0; i < funcionalidades.Count; i++)
            {
                String query2 = "select distinct intIdFuncionalidad FROM [INTERNAL_SERVER_ERROR].Funcionalidad where varFuncionalidad =  @funcionalidad";
                this.Command = new SqlCommand(query2, this.Connector);

                this.Command.Parameters.Add("@funcionalidad", SqlDbType.VarChar).Value = funcionalidades[i];

                SqlDataReader resultado = Command.ExecuteReader();
                resultado.Read();
                posiciones.Add(Int32.Parse(resultado["intIdFuncionalidad"].ToString()));

                resultado.Close();
            }
            if (!editar){

                String query4 = "INSERT INTO [INTERNAL_SERVER_ERROR].Rol (varNombreRol,bitHabilitado) " +
                    "VALUES('" + nombre + "',1)";

                this.Command = new SqlCommand(query4, this.Connector);
                this.Command.ExecuteNonQuery();

            }
           

            for (var j = 0; j < posiciones.Count; j++)
            {
                String query3 = "INSERT INTO [INTERNAL_SERVER_ERROR].FuncionalidadXRol (intIdFuncionalidad,varNombreRol) " +
                                     "VALUES('" + posiciones[j] + "','" + nombre + "')";

                this.Command = new SqlCommand(query3, this.Connector);
                this.Command.ExecuteNonQuery();
            }

            this.Connector.Close();
        }

        public List<Rol> GetRoles()
        {
            List<Rol> roles = new List<Rol>();
            this.Connector.Open();
            String query2 = "select distinct * FROM [INTERNAL_SERVER_ERROR].Rol";
            this.Command = new SqlCommand(query2, this.Connector);
            SqlDataReader resultado = Command.ExecuteReader();
            while (resultado.Read())
            {
                Rol rol = new Rol();
                rol.NombreRol = resultado["varNombreRol"].ToString();
                rol.EstadoRol = resultado.GetBoolean(1);
                roles.Add(rol);
            }
            this.Connector.Close();
            return roles;
        }

        public void ActualizarEstadoRol(String rol, int estado)
        {
            String query = "update [INTERNAL_SERVER_ERROR].Rol set bitHabilitado = @estado where varNombreRol = @rol";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@rol", SqlDbType.VarChar).Value = rol;
            this.Command.Parameters.Add("@estado", SqlDbType.Int).Value = estado;


            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }


        public List<Funcionalidad> GetFuncionalidadesEditar(String rol)
        {
            String query = "select varFuncionalidad, CASE  When (select distinct varFuncionalidad FROM [INTERNAL_SERVER_ERROR].Funcionalidad b inner join [INTERNAL_SERVER_ERROR].FuncionalidadXRol a on a.intIdFuncionalidad = b.intIdFuncionalidad and a.varNombreRol = @rol and b.varFuncionalidad = c.varFuncionalidad) is null " +
	                            "then 0 else 1 end resu "+
                                "FROM [INTERNAL_SERVER_ERROR].Funcionalidad c";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@rol", SqlDbType.VarChar).Value = rol;

            this.Connector.Open();     

            List<Funcionalidad> listaFuncionalidads = new List<Funcionalidad>();


            SqlDataReader resultado = Command.ExecuteReader();

            while(resultado.Read())
            {
                Funcionalidad func = new Funcionalidad();
                func.NombreFuncionalidad = resultado[0].ToString();
                func.Habilitado = Convert.ToBoolean(Convert.ToInt32(resultado[1]));

                listaFuncionalidads.Add(func);
            }

            this.Connector.Close();

            return listaFuncionalidads;
        }


        public void EliminarRol(String rol)
        {
            String query = "exec [INTERNAL_SERVER_ERROR].eliminarRol @rol";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@rol", SqlDbType.VarChar).Value = rol;

            this.Connector.Open();  
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

        }

        public override void Add(Rol entidad)
        {
            throw new NotImplementedException();
        }

        public override void Update(Rol entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Rol GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

