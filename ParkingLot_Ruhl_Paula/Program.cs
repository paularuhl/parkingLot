using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot_Ruhl_Paula
{
    public interface IParkingLot
    {
        int? CantidadEstacionados
        {
            get;
        }
        int EspaciosDisponibles
        {
            get;
        }
        int PrecioPorDia
        {
            get;
            set;
        }
        void facturarEstadia(int precio);

        void ingresoDetectado();

        void egresoDetectado();

    }

    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot p = new ParkingLot();
            int opcion, salir = 0;
            do
            {
                Console.Write("Opciones\n1. Ingreso de auto\n2. Egreso de auto\n3. Cambiar precio actual ${0}\n4. Facturar Estadia\n5. Salir\n", p.PrecioPorDia);
                opcion = int.Parse(Console.ReadLine());
                if (opcion > 5 || opcion < 1)
                {
                    Console.WriteLine("Error, esa opcion no existe\n");
                    Console.ReadKey();
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            p.ingresoDetectado();
                            break;
                        case 2:
                            p.egresoDetectado();
                            break;
                        case 3:
                            Console.Write("Ingrese nuevo precio: ");
                            p.PrecioPorDia = int.Parse(Console.ReadLine());
                            break;
                        case 4:
                            p.facturarEstadia(p.PrecioPorDia);
                            Console.ReadKey();
                            break;
                        case 5:
                            salir = 1;
                            break;
                    }

                }
                Console.Clear();
            } while (salir == 0);

        }
    }

}
