using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot_Ruhl_Paula
{
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
            string mensaje = "";

            if (CantidadEstacionados != null)
            {
                int montoTotal = precio * (int)CantidadEstacionados;
                mensaje = "Valor facturado total: $" + montoTotal;
                Console.WriteLine(mensaje);
            }
            ServicioExterno.EnviarEmail("Facturacion del dia", mensaje, "contadores@estacionamiento.com");
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
}
