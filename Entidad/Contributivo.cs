using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Contributivo: LiquidacionCuotaModeradora
    {
        public Contributivo(char tipo,int numero, string identificacion, string fecha, int salarioDevengado,double valorServicioHospitalizacion) : base(tipo,numero,identificacion,fecha,salarioDevengado,valorServicioHospitalizacion)
        {
            
        }

        public Contributivo(): base()
        {

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
    }
}
