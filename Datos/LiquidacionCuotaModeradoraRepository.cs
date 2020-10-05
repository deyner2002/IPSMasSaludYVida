using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class LiquidacionCuotaModeradoraRepository
    {
        private string fileName = "Liquidaciones Cuotas Moderadoras";
        public void guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            FileStream file = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(liquidacionCuotaModeradora.DameDatosFormatoArchivo());
            writer.Close();
            file.Close();
        }

        public List<LiquidacionCuotaModeradora> ConsultarTodos()
        {
            List<LiquidacionCuotaModeradora> lista = new List<LiquidacionCuotaModeradora>();
            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea=reader.ReadLine())!=null)
            {
                LiquidacionCuotaModeradora liquidacionCuotaModeradora = Map(linea);
                lista.Add(liquidacionCuotaModeradora);
            }
            reader.Close();
            file.Close();
            return lista;
        }

        private LiquidacionCuotaModeradora Map(string linea)
        {
            LiquidacionCuotaModeradora liquidacionCuotaModeradora;
            char delimeter = ';';
            string[] vectorLiquidacion = linea.Split(delimeter);
            if (vectorLiquidacion[0] == "c")
            {
                liquidacionCuotaModeradora = new Contributivo();
            }
            else
            {
                liquidacionCuotaModeradora = new Subsidiado();
            }
            liquidacionCuotaModeradora.Tipo = char.Parse(vectorLiquidacion[0]);
            liquidacionCuotaModeradora.Numero = int.Parse(vectorLiquidacion[1]);
            liquidacionCuotaModeradora.Identificacion = vectorLiquidacion[2];
            liquidacionCuotaModeradora.Fecha = vectorLiquidacion[3];
            liquidacionCuotaModeradora.SalarioDevengado = int.Parse(vectorLiquidacion[4]);
            liquidacionCuotaModeradora.ValorServicioHospitalizacion = double.Parse(vectorLiquidacion[5]);
            liquidacionCuotaModeradora.CuotaModeradora = double.Parse(vectorLiquidacion[6]);
            return liquidacionCuotaModeradora;
        }
    }
}
