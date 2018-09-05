using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot_Ruhl_Paula
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot p = new ParkingLot();
            int salir = 0;

            do
            {
                Console.Write("Menu\n1. Ingreso de auto\n2. Egreso de auto\n3. Cambiar precio actual ${0}\n4. Facturar Estadia\n5. Salir\n\nIngrese opcion: ", p.PrecioPorDia);

                //validates string or not
                if (int.TryParse(Console.ReadLine(), out int opcion) == false)
                { opcion = 0; }

                switch (opcion)
                {
                    case 1:
                        p.IngresoDetectado();
                        break;
                    case 2:
                        p.EgresoDetectado();
                        break;
                    case 3:
                        Console.Write("Ingrese nuevo precio: ");
                        p.PrecioPorDia = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        p.FacturarEstadia(p.PrecioPorDia);
                        Console.ReadKey();
                        break;
                    case 5:
                        salir = 1;
                        break;
                    default:
                        Console.Write("Error, la opcion no existe");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();

            } while (salir == 0);

        }
    }

}
