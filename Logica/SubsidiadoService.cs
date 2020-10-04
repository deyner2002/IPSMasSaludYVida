using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class SubsidiadoService : LiquidacionCuotaModeradoraService
    {
        LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository;

        public SubsidiadoService()
        {
            liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();
        }

        public override double CalcularCuotaModeradora(double valorServicioHospitalizacion, int salarioDevengado)
        {
            double cuotaModeradora = valorServicioHospitalizacion * 0.05;
            if (cuotaModeradora > 200000)
            {
                cuotaModeradora = 200000;
            }
            return cuotaModeradora;
        }

        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            try
            {
                liquidacionCuotaModeradoraRepository.guardar(liquidacionCuotaModeradora);
                return "se guardó la informacion satisfactoriamente";
            }
            catch(Exception e)
            {
                return "Error: "+e.Message;
            }
        }
    }
}
