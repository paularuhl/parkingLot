using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_ConsoleApp
{
    /// esto tendria que ser una interface tho, but how do i do that
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


    class ServicioExterno
    {
        public void enviarEmail(string mail, string mensaje, string algomas)
        {
            Console.WriteLine("Facturacion enviada correctamente a contadores@estacionamiento.com");
        }
    }

    class ParkingLot
    {
        //miembros
        private int cantidadEstacionados = 0;
        private int precioPorDia = 20;

        //propiedades
        private int? CantidadEstacionados
        {
            get
            {
                int? r = null;
                if (cantidadEstacionados != 0)
                {
                    r = cantidadEstacionados;
                }
                return r;
            }
        }
        private int EspaciosDisponibles
        {
            get
            {
                int espacios = 100;
                if (CantidadEstacionados != null)
                {
                    espacios -= (int)CantidadEstacionados;
                }
                return espacios;
            }
        }
        public int PrecioPorDia
        {
            get { return precioPorDia; }
            set { precioPorDia = value; }
        }

        public void facturarEstadia(int precio)
        {
            if (CantidadEstacionados != null)
            {
                int montoTotal = precio * (int)CantidadEstacionados;
                Console.WriteLine("Valor facturado total: ${0}", montoTotal);

            }
        }

        public void ingresoDetectado()
        {
            if (CantidadEstacionados == null)
            {
                cantidadEstacionados = 1;
            }
            else if (CantidadEstacionados < 100)
            {
                cantidadEstacionados++;
            }
            else
            {
                Console.WriteLine("No quedan espacios disponibles");
                Console.ReadKey();
            }
        }
        public void egresoDetectado()
        {
            if (CantidadEstacionados != null)
            {
                cantidadEstacionados--;
            }
            else
            {
                Console.WriteLine("Error, no hay autos estacionados");
                Console.ReadKey();
            }
        }

    }

    class executeParkingLot
    {
        static void Main(string[] args)
        {
            ParkingLot p = new ParkingLot();
            ServicioExterno servicio = new ServicioExterno();
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
                            servicio.enviarEmail("contadores@estacionamiento.com", "esto es un mensaje", "data data data");
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
