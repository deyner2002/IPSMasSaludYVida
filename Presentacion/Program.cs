using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            menuPrincipal();
           
        }

        static void menuPrincipal()
        {
            int opc;
            do
            {
                Console.WriteLine("1. Registrar información para liquidar");
                Console.WriteLine("2. Lista de liquidación");
                Console.WriteLine("3. Consulta lista por tipo de afiliación");
                Console.WriteLine("4. Consultar valor total de cuotas moderadas (contributivo/subsidiado)");
                Console.WriteLine("5. Consulta de liquidaciones realizadas en un mes o año especifico");
                Console.WriteLine("6. Consulta de nombres (digitando una palabra)");
                Console.WriteLine("7. Eliminar liquidación solicitando un numero de liquidación");
                Console.WriteLine("8. Modificar valor de servicio de hospitalización");
                Console.WriteLine("0. Terminar");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 0: Console.WriteLine("Terminado");break;
                    case 1: RegistrarInformacionLiquidacion(); break;
                    case 2: ConsultarListaLiquidaciones(); break;
                    case 3: ConsultaTipoAfiliacion(); break;
                    case 4: ConsultaCuotasModeradas(); break;
                    case 5: ConsultaLiquidacionesRealizadas(); break;
                    case 6: ConsultaNombre(); break;
                    case 7: EliminarLiquidacion(); break;
                    case 8: ModoficarValor();break;
                    default: Console.WriteLine("Opcion no valida");break;
                }
            } while (opc != 0);
        }

        static void RegistrarInformacionLiquidacion()
        {
            int numero, tipoAfiliacion, salarioDevengado;
            String fecha,identificacion;
            double valorServicioHospitalizacion;
            
            Console.WriteLine("\n\nNumero de la liquidación: ");numero =int.Parse(Console.ReadLine());
            Console.WriteLine("Identificación: ");identificacion = Console.ReadLine();
            Console.WriteLine("Fecha: "); fecha = Console.ReadLine();
            Console.WriteLine("Salario devengado: "); salarioDevengado = int.Parse(Console.ReadLine());
            Console.WriteLine("Servicio de hospitalizacion: "); valorServicioHospitalizacion = double.Parse(Console.ReadLine());
            Console.WriteLine("Tipo de afiliacion: ");
            do
            {
                Console.WriteLine("1. subsidiado");
                Console.WriteLine("2. contributivo");
                tipoAfiliacion = int.Parse(Console.ReadLine());
            } while ((tipoAfiliacion!=1) && (tipoAfiliacion!=2));
            if (tipoAfiliacion == 1)
            {
                LiquidacionCuotaModeradora contributivo = new Contributivo('c',numero, identificacion, fecha, salarioDevengado, valorServicioHospitalizacion);
                ContributivoService liquidacionCuotaModeradoraService = new ContributivoService();
                contributivo.CuotaModeradora = liquidacionCuotaModeradoraService.CalcularCuotaModeradora(valorServicioHospitalizacion, salarioDevengado);
                Console.WriteLine(liquidacionCuotaModeradoraService.Guardar(contributivo));
            }
            else
            {
                Subsidiado subsidiado = new Subsidiado('s',numero, identificacion, fecha, salarioDevengado, valorServicioHospitalizacion);
                SubsidiadoService liquidacionCuotaModeradoraService = new SubsidiadoService();
                subsidiado.CuotaModeradora = liquidacionCuotaModeradoraService.CalcularCuotaModeradora(valorServicioHospitalizacion, salarioDevengado);
                Console.WriteLine(liquidacionCuotaModeradoraService.Guardar(subsidiado));

             }
            
            

        }

        static void ConsultarListaLiquidaciones()
        {
            
            ContributivoService liquidacionCuotaModeradoraService = new ContributivoService();
            LiquidacionConsultaResponse consultaResponse = liquidacionCuotaModeradoraService.Consultar();
            if (consultaResponse.Error)
            {
                Console.WriteLine(consultaResponse.Message);

            }
            else
            {
                foreach (var item in consultaResponse.Liquidaciones)
                {
                    Console.WriteLine(item.ToString());
                }
                
            }
            Console.ReadKey();
        }

        static void ConsultaTipoAfiliacion()
        {

        }

        static void ConsultaCuotasModeradas()
        {

        }

        static void ConsultaLiquidacionesRealizadas()
        {

        }

        static void ConsultaNombre()
        {

        }

        static void EliminarLiquidacion()
        {

        }

        static void ModoficarValor()
        {

        }
    }
}