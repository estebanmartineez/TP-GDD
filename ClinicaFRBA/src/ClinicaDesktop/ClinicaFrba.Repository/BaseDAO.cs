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
    public abstract class BaseDao<T> where T : class
    {
        public SqlConnection Connector { get; set; }
        public SqlDataAdapter Adapter { get; set; }
        public DataSet Dataset { get; set; }
        public SqlCommand Command { get; set; }

        protected BaseDao()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            Connector = new SqlConnection(connectionString);
        }

        public abstract void Add(T entidad);
        public abstract void Update(T entidad);
        public abstract void Delete(int id);
        public abstract T GetById(int id);

    }
}
