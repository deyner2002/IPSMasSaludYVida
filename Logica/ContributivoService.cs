using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class ContributivoService : LiquidacionCuotaModeradoraService
    {
        LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository;
        public ContributivoService()
        {
            liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();
        }

        public override double CalcularCuotaModeradora(double valorServicioHospitalizacion, int salarioDevengado)
        {
            double cuotaModeradora;
            if (salarioDevengado < 2)
            {
                cuotaModeradora = valorServicioHospitalizacion * 0.15;
                if (cuotaModeradora > 250000)
                {
                    cuotaModeradora = 250000;
                    
                }
                return cuotaModeradora;
            }
            else
            {
                if (salarioDevengado < 6)
                {
                    cuotaModeradora = valorServicioHospitalizacion * 0.2;
                    if (cuotaModeradora > 900000)
                    {
                        cuotaModeradora = 900000;
                    }
                }
                else
                {
                    cuotaModeradora = valorServicioHospitalizacion * 0.25;
                    if (cuotaModeradora > 1500000)
                    {
                        cuotaModeradora = 1500000;
                    }
                }
                return cuotaModeradora;
            }
         

        }

        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            try
            {
                liquidacionCuotaModeradoraRepository.guardar(liquidacionCuotaModeradora);
                return "se guardó la informacion satisfactoriamente";
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
        }

        public LiquidacionConsultaResponse Consultar()
        {
            try
            {
                List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras = liquidacionCuotaModeradoraRepository.ConsultarTodos();
                var response = new LiquidacionConsultaResponse(liquidacionCuotaModeradoras);
                return response;
            }
            catch (Exception e)
            {
                var response = new LiquidacionConsultaResponse("Error de Aplicacion:" + e.Message);
                return response;
            }

        }

    }
    public class LiquidacionConsultaResponse
    {
        public List<LiquidacionCuotaModeradora> Liquidaciones { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
        public LiquidacionConsultaResponse(string message)
        {
            Error = true;
            Message = message;
        }
        public LiquidacionConsultaResponse(List<LiquidacionCuotaModeradora> liquidaciones)
        {
            Liquidaciones = liquidaciones;
            Error = false;
        }
    }
}
