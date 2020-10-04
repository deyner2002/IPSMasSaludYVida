using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public abstract class LiquidacionCuotaModeradoraService
    {
        public LiquidacionCuotaModeradoraService()
        {

        }

        public abstract double CalcularCuotaModeradora(double valorServicioHospitalizacion,int salarioDevengado);
    }
}
