using Entidad;
using System;
using System.Collections.Generic;
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
    }
}
