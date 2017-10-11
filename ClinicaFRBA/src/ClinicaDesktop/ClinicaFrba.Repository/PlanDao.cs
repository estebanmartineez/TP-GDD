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
    public class PlanDao : BaseDao<Plan>
    {
        public override void Add(Plan entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Plan GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Plan entidad)
        {
            throw new NotImplementedException();
        }

        public List<Plan> ListarPlanesMedicosVigentes()
        {
            const string query = "SELECT [intCodigoPlan],[varDescripcion],[monPrecioBonoConsulta],[monPrecioBonoFarmacia] FROM [INTERNAL_SERVER_ERROR].[Plan]";

            this.Command = new SqlCommand(query.ToString(), this.Connector);
            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            List<Plan> planes = new List<Plan>();

            while (reader.Read())
            {
                var plan = new Plan
                {
                    Codigo = Convert.ToInt32(reader["intCodigoPlan"]),
                    Descripcion = Convert.ToString(reader["varDescripcion"]),
                    PrecioBonoConsulta = Convert.ToDecimal(reader["monPrecioBonoConsulta"]),
                    PrecioBonoFarmacia = Convert.ToDecimal(reader["monPrecioBonoFarmacia"]),

                };

                planes.Add(plan);
            }



            return planes;
        }

        public int GetCodigoPlanByDescripcion(string descripcion)
        {
            string query = "SELECT [intCodigoPlan],[varDescripcion],[monPrecioBonoConsulta],[monPrecioBonoFarmacia] FROM [INTERNAL_SERVER_ERROR].[Plan] WHERE varDescripcion ="
                + "'" + descripcion + "'";

            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            int codigoPlan = 0;

            while (reader.Read())
            {
                codigoPlan = Convert.ToInt32(reader["intCodigoPlan"]);
            }

            return codigoPlan;
        }

        public string GetDescripcionByCodigoPlan(int codPlan)
        {
            string query = "SELECT [intCodigoPlan],[varDescripcion],[monPrecioBonoConsulta],[monPrecioBonoFarmacia] FROM [INTERNAL_SERVER_ERROR].[Plan] WHERE intCodigoPlan =" + codPlan.ToString();

            this.Command = new SqlCommand(query, this.Connector);

            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            string descPlan = string.Empty;

            while (reader.Read())
            {
                descPlan = Convert.ToString(reader["varDescripcion"]);
            }

            return descPlan;
        }
    }
}
