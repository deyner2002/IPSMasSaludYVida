using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public abstract class LiquidacionCuotaModeradora
    {
        public LiquidacionCuotaModeradora(int numero, string identificacion, string fecha, int salarioDevengado, double valorServicioHospitalizacion)
        {
            Identificacion = identificacion;
            Fecha = fecha;
            Numero = numero;
            SalarioDevengado = salarioDevengado;
            ValorServicioHospitalizacion = valorServicioHospitalizacion;
            CuotaModeradora = 0;
        }

        public string Identificacion { get; set; }
        public string Fecha { get; set; }
        public int Numero { get; set; }
        public int SalarioDevengado { get; set; }
        public double ValorServicioHospitalizacion { get; set; }
        public double CuotaModeradora { get; set; }

        public string DameDatosFormatoArchivo()
        {
            return Numero + ";" + Identificacion + ";" + Fecha + ";" + SalarioDevengado + ";" + ValorServicioHospitalizacion + ";"+CuotaModeradora;
        }
    }
}
