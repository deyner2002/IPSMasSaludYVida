using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Subsidiado : LiquidacionCuotaModeradora
    {
        public Subsidiado(char tipo, int numero, string identificacion, string fecha, int salarioDevengado, double valorServicioHospitalizacion): base(tipo,numero, identificacion,fecha,salarioDevengado,valorServicioHospitalizacion)
        {
            
        }

        public Subsidiado(): base()
        {

        }
    }
}
