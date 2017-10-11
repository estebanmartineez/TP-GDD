using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Channels;
using ClinicaFrba.Repository.Entities;
using System.Security.Cryptography;

namespace ClinicaFrba.Repository
{
    [SuppressMessage("ReSharper", "SuggestVarOrType_Elsewhere")]
    public class AfiliadoDao : BaseDao<Usuario> 
    {

        public AfiliadoDao() : base()
        {
                
        }

        public override void Add(Usuario entidad)
        {
          
            const string query =
                "INSERT INTO [INTERNAL_SERVER_ERROR].[Usuario]([intIdUsuario],[nvarPassword],[varNombre],[varApellido],[varTipoDocumento],[intNroDocumento],[intTelefono],[varEstadoCivil],[varDireccion],[varMail],[datFechaNacimiento],[chrSexo],[intIntentosLogin])" +
                "VALUES(@intIdUsuario, @nvarPassword, @varNombre, @varApellido, @varTipoDocumento, @intNroDocumento, @intTelefono, @varEstadoCivil, @varDireccion, @varMail, @datFechaNacimiento, @chrSexo, @intIntentosLogin)"; 

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@intIdUsuario", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@varNombre", SqlDbType.VarChar, 50).Value = entidad.Nombre;
            this.Command.Parameters.Add("@varApellido", SqlDbType.VarChar, 50).Value = entidad.Apellido;
            this.Command.Parameters.Add("@varTipoDocumento", SqlDbType.VarChar, 50).Value = entidad.TipoDocumento;
            this.Command.Parameters.Add("@intNroDocumento", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@datFechaNacimiento", SqlDbType.DateTime).Value = entidad.FechaNacimiento;
            this.Command.Parameters.Add("@chrSexo", SqlDbType.Char, 1).Value = entidad.Sexo;
            this.Command.Parameters.Add("@varDireccion", SqlDbType.VarChar, 250).Value = entidad.Direccion;
            this.Command.Parameters.Add("@intTelefono", SqlDbType.Int).Value = entidad.Telefono;
            this.Command.Parameters.Add("@varMail", SqlDbType.VarChar, 150).Value = entidad.Mail;
            this.Command.Parameters.Add("@varEstadoCivil", SqlDbType.VarChar, 100).Value = entidad.EstadoCivil;
            this.Command.Parameters.Add("@nvarPassword", SqlDbType.NVarChar, 4000).Value = sha256_hash("afiliado");
            this.Command.Parameters.Add("@intIntentosLogin", SqlDbType.Int).Value = 0;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();

           const string query2 = "INSERT INTO [INTERNAL_SERVER_ERROR].[Afiliado]([intIdUsuario],[bitEstadoActual],[intCodigoPlan],[datFechaBaja],[intNumeroAfiliado],[intCantidadFamiliares],[intNumeroConsultaMedica])" +
                        "VALUES (@intIdUsuario, @bitEstadoActual, @intCodigoPlan, @datFechaBaja,@intNumeroAfiliado, @intCantidadFamiliares, @intNumeroConsultaMedica)";


            this.Command = new SqlCommand(query2, this.Connector);
            this.Command.Parameters.Add("@intIdUsuario", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@bitEstadoActual", SqlDbType.Bit).Value = 1;
            this.Command.Parameters.Add("@intCodigoPlan", SqlDbType.Int).Value = entidad.CodigoPlanMedico;
            this.Command.Parameters.Add("@datFechaBaja", SqlDbType.Date).Value = DBNull.Value;
            this.Command.Parameters.Add("@intNumeroAfiliado", SqlDbType.BigInt).Value = entidad.NroAfiliado; 
            this.Command.Parameters.Add("@intCantidadFamiliares", SqlDbType.Int).Value = entidad.CantidadFamiliaresACargo;
            this.Command.Parameters.Add("@intNumeroConsultaMedica", SqlDbType.Int).Value = entidad.NumeroConsultaMedica;

            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override void Update(Usuario entidad)
        {
            const string query =
               "UPDATE [INTERNAL_SERVER_ERROR].[Usuario]" +
                "SET" +
                "[intIdUsuario] = @intNroDocumento" +
                ",[varNombre] = @varNombre" +
                ",[varApellido] = @varApellido" +
                ",[varTipoDocumento] = @varTipoDocumento" +
                ",[intNroDocumento] = @intNroDocumento" +
                ",[intTelefono] = @intTelefono" +
                ",[varDireccion] = @varDireccion" +
                ",[varMail] = @varMail" +
                ",[datFechaNacimiento] = @datFechaNacimiento" +
                ",[chrSexo] = @varSexo" +
                ",[varEstadoCivil] = @varEstadoCivil " +
                "WHERE intIdUsuario = @intNroDocumento";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@varNombre", SqlDbType.VarChar, 50).Value = entidad.Nombre;
            this.Command.Parameters.Add("@varApellido", SqlDbType.VarChar, 50).Value = entidad.Apellido;
            this.Command.Parameters.Add("@varTipoDocumento", SqlDbType.VarChar, 50).Value = entidad.TipoDocumento;
            this.Command.Parameters.Add("@intNroDocumento", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@datFechaNacimiento", SqlDbType.DateTime).Value = entidad.FechaNacimiento;
            this.Command.Parameters.Add("@varSexo", SqlDbType.Char, 1).Value = entidad.Sexo;
            this.Command.Parameters.Add("@varDireccion", SqlDbType.VarChar, 250).Value = entidad.Direccion;
            this.Command.Parameters.Add("@intTelefono", SqlDbType.Int).Value = entidad.Telefono;
            this.Command.Parameters.Add("@varMail", SqlDbType.VarChar, 150).Value = entidad.Mail;
            this.Command.Parameters.Add("@varEstadoCivil", SqlDbType.VarChar, 100).Value = entidad.EstadoCivil;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();

            const string query2 =
                "UPDATE [INTERNAL_SERVER_ERROR].[Afiliado]" +
                "SET" +
                "[intIdUsuario] = @intId" +
                ",[intCodigoPlan] = @intCodigo" +
                ",[intCantidadFamiliares] = @intCantidadFamiliares" +
                ",[intNumeroConsultaMedica] = @intNumeroConsulta " +
                "WHERE intIdUsuario = @intId";

            this.Command = new SqlCommand(query2, this.Connector);

            this.Command.Parameters.Add("@intId", SqlDbType.Int).Value = entidad.NroDocumento;
            this.Command.Parameters.Add("@intCodigo", SqlDbType.Int).Value = entidad.CodigoPlanMedico;
            this.Command.Parameters.Add("@intCantidadFamiliares", SqlDbType.Int).Value = entidad.CantidadFamiliaresACargo;
            this.Command.Parameters.Add("@intNumeroConsulta", SqlDbType.Int).Value = entidad.NumeroConsultaMedica;

            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override void Delete(int id)
        {
            string query =
                "UPDATE [INTERNAL_SERVER_ERROR].[Afiliado] " +
                "SET [bitEstadoActual] = 0, " +
                "datFechaBaja = @fechaHoy" +
                "WHERE intIdUsuario = " + id.ToString();

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override Usuario GetById(int id)
        {
            const string query =
                "SELECT TOP 1 * FROM [INTERNAL_SERVER_ERROR].Usuario u INNER JOIN [INTERNAL_SERVER_ERROR].Afiliado a ON u.intIdUsuario = a.intIdUsuario WHERE u.intIdUsuario = @id";

            this.Command = new SqlCommand(query, this.Connector);
            this.Command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            var user = new Usuario();

            while (reader.Read())
            {
                user = new Usuario
                {
                    NroAfiliado = reader["intNumeroAfiliado"] as long? ?? default(long),
                    EstadoCivil = Convert.ToString(reader["varEstadoCivil"]),
                    Apellido = Convert.ToString(reader["varApellido"]),
                    Nombre = Convert.ToString(reader["varNombre"]),
                    TipoDocumento = Convert.ToString(reader["varTipoDocumento"]),
                    NroDocumento = reader["intNroDocumento"] as int? ?? default(int),
                    Telefono = reader["intTelefono"] as int? ?? default(int),
                    Mail = Convert.ToString(reader["varMail"]),
                    FechaNacimiento = Convert.ToDateTime(reader["datFechaNacimiento"]),
                    Sexo = Convert.ToString(reader["chrSexo"]),
                    CantidadFamiliaresACargo = reader["intCantidadFamiliares"] as int? ?? default(int),
                    NumeroConsultaMedica = reader["intNumeroConsultaMedica"] as int? ?? default(int),
                    CodigoPlanMedico = reader["intCodigoPlan"] as int? ?? default(int),
                    EstadoHabilitacion = reader["bitEstadoActual"] as int? ?? default(int),
                    Direccion = Convert.ToString(reader["varDireccion"])
                };

            }

            return user;
        }

        public static string sha256_hash(string value)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public List<Usuario> ObtenerUsuariosConFiltros(string nombre, string apellido, string descPlan, bool? estadoActual)
        {
            StringBuilder query = new StringBuilder();
                query.Append("SELECT * FROM [INTERNAL_SERVER_ERROR].Usuario u INNER JOIN [INTERNAL_SERVER_ERROR].Afiliado a ON u.intIdUsuario = a.intIdUsuario INNER JOIN [INTERNAL_SERVER_ERROR].[Plan] p ON p.intCodigoPlan = a.intCodigoPlan WHERE 1 = 1");

            if (!string.IsNullOrEmpty(nombre))
            {
                query.Append("AND u.varNombre LIKE '%" + nombre + "%'");
            }

            if (!string.IsNullOrEmpty(apellido))
            {
                query.Append("AND u.varApellido LIKE '%" + apellido + "%'");
            }

            if (!string.IsNullOrEmpty(descPlan))
            {
                query.Append("AND p.varDescripcion = " + "'" + descPlan + "'");
            }

            if (estadoActual.HasValue)
            {
                int enc = 0;

                if (estadoActual.Value == true)
                {
                    enc = 1;
                }

                query.Append("AND a.bitEstadoActual =" + enc);
            }

            this.Command = new SqlCommand(query.ToString(),this.Connector);
            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            List<Usuario> users = new List<Usuario>();

            while (reader.Read())
            {
                var user = new Usuario
                {
                    NroAfiliado = reader["intNumeroAfiliado"] as long? ?? default(long),
                    EstadoCivil = Convert.ToString(reader["varEstadoCivil"]),
                    Apellido = Convert.ToString(reader["varApellido"]),
                    Nombre = Convert.ToString(reader["varNombre"]),
                    TipoDocumento = Convert.ToString(reader["varTipoDocumento"]),
                    NroDocumento = reader["intNroDocumento"] as int? ?? default(int),
                    Telefono = reader["intTelefono"] as int? ?? default(int),
                    Mail = Convert.ToString(reader["varMail"].ToString()),
                    FechaNacimiento = Convert.ToDateTime(reader["datFechaNacimiento"]),
                    Sexo = Convert.ToString(reader["chrSexo"]),
                    CantidadFamiliaresACargo = reader["intCantidadFamiliares"] as int? ?? default(int),
                    NumeroConsultaMedica = reader["intNumeroConsultaMedica"] as int? ?? default(int),
                    CodigoPlanMedico = reader["intCodigoPlan"] as int? ?? default(int),
                    EstadoHabilitacion = reader["bitEstadoActual"] as int? ?? default(int),
                    Direccion = Convert.ToString(reader["varDireccion"])
                };

                users.Add(user);
            }

            return users;
        }

        public void AgregarHistoricoCambioPlan(int codigoPlan, int idUsuario, string motivoCambio)
        {
            const string query =
                "INSERT INTO [INTERNAL_SERVER_ERROR].[AfiliadoHistoricoPlan]([intIdUsuario],[datFechaModificacion],[varMotivoModificacion],[intCodigoPlan]) VALUES" +
                "(@intIdUsuario, @fechaHoy, @varMotivoModificacion, @intCodigoPlan)";

            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@intIdUsuario", SqlDbType.Int).Value = idUsuario;
            this.Command.Parameters.Add("@varMotivoModificacion", SqlDbType.VarChar, 250).Value = motivoCambio;
            this.Command.Parameters.Add("@intCodigoPlan", SqlDbType.Int).Value = codigoPlan;
            this.Command.Parameters.Add("@fechaHoy", SqlDbType.DateTime).Value = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();

        }

        public List<AfiliadoHistoricoPlan> ObtenerHistorialPlanesByIdUsuario(int idUsuario)
        {
            string query =
                "SELECT [intIdAfiliadoHistoricoPlan],[intIdUsuario],[datFechaModificacion],[varMotivoModificacion],[intCodigoPlan] " +
                "FROM [INTERNAL_SERVER_ERROR].[AfiliadoHistoricoPlan] " +
                "WHERE intIdUsuario = " + idUsuario.ToString();

            this.Command = new SqlCommand(query.ToString(), this.Connector);
            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            List<AfiliadoHistoricoPlan> historial = new List<AfiliadoHistoricoPlan>();

            while (reader.Read())
            {
                var hist = new AfiliadoHistoricoPlan()
                {
                    IdAfiliadoHistoricoPlan = reader["intIdAfiliadoHistoricoPlan"] as int? ?? default(int),
                    Motivo = Convert.ToString(reader["varMotivoModificacion"]),
                    Plan = reader["intCodigoPlan"] as int? ?? default(int),
                    IdUsuario = reader["intIdUsuario"] as int? ?? default(int),
                    FechaCambio = Convert.ToDateTime(reader["datFechaModificacion"]),
                };

                historial.Add(hist);
            }

            return historial;

        }

        public List<Usuario> ObtenerGrupoFamiliar(int nroDocumento)
        {

            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM INTERNAL_SERVER_ERROR.Usuario u INNER JOIN INTERNAL_SERVER_ERROR.Afiliado a ON u.intIdUsuario = a.intIdUsuario WHERE a.intNumeroAfiliado LIKE CAST(@intNroDocumento AS NVARCHAR) + '%'");

            this.Command = new SqlCommand(query.ToString(), this.Connector);

            this.Command.Parameters.Add("@intNroDocumento", SqlDbType.Int).Value = nroDocumento;

            this.Connector.Open();
            SqlDataReader reader = this.Command.ExecuteReader();

            List<Usuario> users = new List<Usuario>();

            while (reader.Read())
            {
                var user = new Usuario
                {
                    NroAfiliado = reader["intNumeroAfiliado"] as long? ?? default(long),
                    EstadoCivil = Convert.ToString(reader["varEstadoCivil"]),
                    Apellido = Convert.ToString(reader["varApellido"]),
                    Nombre = Convert.ToString(reader["varNombre"]),
                    TipoDocumento = Convert.ToString(reader["varTipoDocumento"]),
                    NroDocumento = reader["intNroDocumento"] as int? ?? default(int),
                    Telefono = reader["intTelefono"] as int? ?? default(int),
                    Mail = Convert.ToString(reader["varMail"].ToString()),
                    FechaNacimiento = Convert.ToDateTime(reader["datFechaNacimiento"]),
                    Sexo = Convert.ToString(reader["chrSexo"]),
                    CantidadFamiliaresACargo = reader["intCantidadFamiliares"] as int? ?? default(int),
                    NumeroConsultaMedica = reader["intNumeroConsultaMedica"] as int? ?? default(int),
                    CodigoPlanMedico = reader["intCodigoPlan"] as int? ?? default(int),
                    EstadoHabilitacion = reader["bitEstadoActual"] as int? ?? default(int),
                    Direccion = Convert.ToString(reader["varDireccion"]),
                };

                users.Add(user);
            }

            return users;
        }
    }
}
