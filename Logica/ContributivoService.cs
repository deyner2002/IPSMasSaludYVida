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
    }
}
