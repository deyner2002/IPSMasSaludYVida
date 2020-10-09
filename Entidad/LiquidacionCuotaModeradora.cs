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
        public LiquidacionCuotaModeradora(char tipo,int numero, string identificacion, string fecha, int salarioDevengado, double valorServicioHospitalizacion)
        {
            Identificacion = identificacion;
            Fecha = fecha;
            Numero = numero;
            SalarioDevengado = salarioDevengado;
            ValorServicioHospitalizacion = valorServicioHospitalizacion;
            CuotaModeradora = 0;
            Tipo = tipo;
        }

        public LiquidacionCuotaModeradora()
        {

        }

        public string Identificacion { get; set; }
        public string Fecha { get; set; }
        public int Numero { get; set; }
        public int SalarioDevengado { get; set; }
        public double ValorServicioHospitalizacion { get; set; }
        public double CuotaModeradora { get; set; }
        public char Tipo { get; set; }

        public abstract double CalcularCuotaModeradora(double valorServicioHospitalizacion, int salarioDevengado);

        public override string ToString()
        {
            return $"tipo afiliacion:{Tipo}-NumeroLiquidacion: {Numero}-Identificacion: {Identificacion}-fecha: {Fecha}-salario devengado: {SalarioDevengado}- valor servicio hospitalizacion: {ValorServicioHospitalizacion}-Cuota Moderadora: {CuotaModeradora}";
        }
        public string DameDatosFormatoArchivo()
        {
            return Tipo+";"+Numero + ";" + Identificacion + ";" + Fecha + ";" + SalarioDevengado + ";" + ValorServicioHospitalizacion + ";"+CuotaModeradora;
        }
    }
}
