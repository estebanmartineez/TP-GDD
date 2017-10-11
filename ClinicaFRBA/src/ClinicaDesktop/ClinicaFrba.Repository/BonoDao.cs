using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ClinicaFrba.Repository.Entities;


namespace ClinicaFrba.Repository
{
    public class BonoDao : BaseDao<Bono>
    {

        public BonoDao() : base()
        {
          
        }

        public Usuario ExisteAfiliado(String numAfiliado)
        {
            String query = "select u.varNombre as nombre, u.varApellido as apellido,  af.intCodigoPlan as planMed, u.intIdUsuario as dni " +
                "from [INTERNAL_SERVER_ERROR].Usuario as u inner join [INTERNAL_SERVER_ERROR].Afiliado as af on u.intIdUsuario = af.intIdUsuario where af.intNumeroAfiliado = @intNumeroAfiliado";
            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@intNumeroAfiliado", SqlDbType.BigInt).Value = numAfiliado;

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();
            bool result = resultado.HasRows;
            resultado.Read();
            Usuario usuario = null;
            
            if (result)
            {
                usuario = new Usuario();
                usuario.Nombre = resultado["nombre"].ToString();
                usuario.Apellido = resultado["apellido"].ToString();
                usuario.NroDocumento = Int32.Parse(resultado["dni"].ToString());
                usuario.CodigoPlanMedico = Int32.Parse(resultado["planMed"].ToString());
                usuario.NroAfiliado = Int64.Parse(numAfiliado);
            }
           
            this.Connector.Close();

            return usuario;

        }


        public float GetPrecioBono(int numPlan)
        {
            String query = "select monPrecioBonoConsulta as precio from [INTERNAL_SERVER_ERROR].[Plan] where intCodigoPlan = @plan";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@plan", SqlDbType.Int).Value = numPlan;

            this.Connector.Open();

            SqlDataReader resultado = Command.ExecuteReader();
            resultado.Read();
            float precio = float.Parse(resultado["precio"].ToString());
            this.Connector.Close();

            return precio;
        }


        public void ConfirmarCompraBono(Usuario usuario, int cant)
        {
            String query = "exec [INTERNAL_SERVER_ERROR].comprarBono @Usuario=@user, @cantidad=@cant, @codigoPlan=@plan";
            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@plan", SqlDbType.Int).Value = usuario.CodigoPlanMedico;
            this.Command.Parameters.Add("@user", SqlDbType.Int).Value = usuario.NroDocumento;
            this.Command.Parameters.Add("@cant", SqlDbType.Int).Value = cant;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public List<Bono> getBonosDeAfiliado(int idAfiliado)
        {
            List<Bono> bonos = new List<Bono>();
            String query = "SELECT intIdBono id, datFechaCompra fecha FROM [INTERNAL_SERVER_ERROR].Bono WHERE intIdAfiliadoCompro=" + idAfiliado + "and intIdAfiliado utilizo is null";
            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();

            SqlDataReader resultado = this.Command.ExecuteReader();
            while (resultado.Read())
            {
                Bono bono = new Bono();
                bono.Id = Int32.Parse(resultado["id"].ToString());
                bono.FechaCompra = DateTime.Parse(resultado["fecha"].ToString());

                bonos.Add(bono);
            }

            this.Connector.Close();

            return bonos;
        }

        public void usarBono(int idAfiliado, int idBono)
        {
            String query = "UPDATE [INTERNAL_SERVER_ERROR].Bono SET intIdAfiliadoUtilizo=" + idAfiliado+"WHERE intIdBono="+idBono;
            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override void Add(Bono entidad)
        {
            throw new NotImplementedException();
        }

        public override void Update(Bono entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Bono GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
