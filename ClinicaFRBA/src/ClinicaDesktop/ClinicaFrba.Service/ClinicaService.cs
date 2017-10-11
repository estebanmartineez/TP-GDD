using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Repository;
using ClinicaFrba.Repository.Entities;
using ClinicaFrba.Service.Common;
using System.Text.RegularExpressions;

namespace ClinicaFrba.Service
{
    public class ClinicaService
    {

        /// <summary>
        /// Toma al afiliado principal calcula la cantidad de familiares a cargo y luego procesa los afiliados 
        /// restantes que esten asociados seteando el nro de Afiliado de manera incremental
        /// </summary>
        /// <param name="afiliados"></param>
        public void GuardarRegistroAfiliado(List<Usuario> afiliados)
        {
            try
            { 
                if (afiliados != null)
                {
                    var repo = new AfiliadoDao();

                    afiliados[0].CantidadFamiliaresACargo = afiliados.Count - 1;
                    var nroAfiliado = afiliados[0].NroAfiliado;
                    afiliados[0].NroAfiliado = Convert.ToInt64(nroAfiliado + "01");
                    repo.Add(afiliados[0]);
                    afiliados.Remove(afiliados[0]);

                    var i = 2;

                    foreach (var afiliado in afiliados)
                    {
                        afiliado.NroAfiliado = Convert.ToInt64(nroAfiliado + "0" + i.ToString());
                        afiliado.CantidadFamiliaresACargo = 0;
                        repo.Add(afiliado);
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public bool EsCampoNumerico(string username)
        {
            Regex reg = new Regex("[0-9]");
            return reg.IsMatch(username);
        }

        public void ActualizarHistorialCambiosDePlan(ActualizarHistorialCambiosDePlanRequest req)
        {
            var repo = new AfiliadoDao();

            repo.AgregarHistoricoCambioPlan(req.CodigoPlan, req.IdUsuario, req.MotivoCambio);

        }

        /// <summary>
        /// Devuelve true si el afiliado es casado o vive en concubinato
        /// </summary>
        /// <param name="afiliado">Afiliado</param>
        /// <returns></returns>
        public bool EsCasadoOViveEnConcubinato(Usuario afiliado)
        {
            return afiliado.EstadoCivil == "Casado" || afiliado.EstadoCivil == "Concubinato";
        }

        /// <summary>
        /// Devuelve listado de usuarios según los filtros elegidos
        /// </summary>
        /// <param name="request">Request con los filtros elegidos</param>
        /// <returns></returns>
        public CargarGrillaAfiliadoResponse CargarGrillaAfiliados(CargarGrillaAfiliadoRequest request)
        {
            var repo = new AfiliadoDao();

            var usuarios = repo.ObtenerUsuariosConFiltros(request.Nombre, request.Apellido, request.DescripcionPlan, request.EstadoActual);

            var response = new CargarGrillaAfiliadoResponse {Usuarios = usuarios};


            return response;
        }


        /// <summary>
        /// Carga el detalle de un afiliado según su número de documento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CargarDetalleAfiliadoResponse CargarDetalleAfiliado(CargarDetalleAfiliadoRequest request)
        {
            var repo = new AfiliadoDao();

            var response = new CargarDetalleAfiliadoResponse {Usuario = repo.GetById(request.NroDocumento)};

            return response;
        }

        public ObtenerListadoPlanesResponse ObtenerListadoDePlanes()
        {
            var repo = new PlanDao();

            var response = new ObtenerListadoPlanesResponse();

            var planes = repo.ListarPlanesMedicosVigentes();

            if (planes != null)
            { 
                foreach (var plan in planes)
                {
                    response.DescPlanes.Add(plan.Descripcion);
                }
            }

            return response;
        }

        public void ModificarDatosDeAfiliado(ModificarDatosDeAfiliadoRequest request)
        {
            var repo = new AfiliadoDao();

            if (request != null)
            {
                repo.Update(request.Afiliado);
            }

        }

        public void GuardarTurnoCancelado(TurnoCancelado turno)
        {
            new TurnoDao().GuardarTurnoCancelado(turno);
        }

        public void CancelarTurnosSegunRangoFecha(String fechaDesde, string fechaHasta, string motivo, string tipo)
        {
            new TurnoDao().CancelarTurnosPorRangoDeFechas(fechaDesde, fechaHasta, motivo, tipo);
        }

        public List<TurnoYUsuario> turnosDeAfiliado(int id)
        {
            return new TurnoDao().turnosDeAfiliado(id);
        }


        public int GetCodigoPlanByDescripcion(string descripcion)
        {
            var repo = new PlanDao();

            return repo.GetCodigoPlanByDescripcion(descripcion);

        }

        public string GetDescripcionByCodigoPlan(int codigoPlan)
        {
            var repo = new PlanDao();

            return repo.GetDescripcionByCodigoPlan(codigoPlan);

        }

        public void DarDeBajaUsuario(int nroDocumento)
        {
            var repo = new AfiliadoDao();

            repo.Delete(nroDocumento);
        }

        public List<AfiliadoHistoricoPlan> ObtenerHistorialCambioPlanes(int idUsuario)
        {
            var repo = new AfiliadoDao();

            return repo.ObtenerHistorialPlanesByIdUsuario(idUsuario); ;

        }

        public Usuario ValidarExistenciaUsuario(int dni)
        {
            var repo = new AfiliadoDao();

            return repo.GetById(dni);
        }

        public void AfiliarFamiliar(Usuario afiliadoPrincipal, Usuario familiar)
        {
            var repo = new AfiliadoDao();

            var ultimoAfiliado = this.ObtenerGrupoFamiliar(afiliadoPrincipal.NroDocumento).OrderByDescending(x => x.NroAfiliado).FirstOrDefault();

            if (ultimoAfiliado != null)
            {
                familiar.NroAfiliado = ultimoAfiliado.NroAfiliado + 1;
            }
            
            afiliadoPrincipal.CantidadFamiliaresACargo = afiliadoPrincipal.CantidadFamiliaresACargo + 1;

            repo.Add(familiar);
            repo.Update(afiliadoPrincipal);
        }

        private List<Usuario> ObtenerGrupoFamiliar(int dni)
        {
            var repo = new AfiliadoDao();

            return repo.ObtenerGrupoFamiliar(dni);
        }
    }
}
