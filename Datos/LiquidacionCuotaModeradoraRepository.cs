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
        
        private string fileName = "Liquidaciones Cuotas Moderadoras.txt";
        public void guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            FileStream file = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(liquidacionCuotaModeradora.DameDatosFormatoArchivo());
            writer.Close();
            file.Close();
        }

        public void GuardarListado(List<LiquidacionCuotaModeradora> lista)
        {
           
        }

        public string Eliminar(int numero)
        {
            FileStream file = new FileStream("Temporal.txt", FileMode.Create);
            StreamWriter escribir = new StreamWriter(file);
            FileStream fileReader = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader leer = new StreamReader(fileReader);
            
            
            string linea = string.Empty;
            char encontrado = 'n';
            while ((linea = leer.ReadLine()) != null)
            {
               LiquidacionCuotaModeradora liquidacionCuotaModeradora = Map(linea);
                if (liquidacionCuotaModeradora.Numero == numero)
                {
                    encontrado = 's';
                   
                }
                else
                {
                    escribir.WriteLine(liquidacionCuotaModeradora.DameDatosFormatoArchivo());
                }
                
            }
            leer.Close();
            escribir.Close();
            File.Delete("Liquidaciones Cuotas Moderadoras.txt");
            File.Move("Temporal.txt", "Liquidaciones Cuotas Moderadoras.txt");
            if (encontrado == 'n')
            {
                return "no se encontró ese registro";
            }
            else
            {
                return "se encontró el registro";
            }

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
