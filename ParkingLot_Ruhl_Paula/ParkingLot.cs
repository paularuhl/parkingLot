using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot_Ruhl_Paula
{
    class ParkingLot : IParkingLot
    {
        #region Propiedades

        public int? CantidadEstacionados { get; set; } = null;
        public int EspaciosDisponibles { get; set; } = 100;
        public int PrecioPorDia { get; set; } = 20;

        #endregion

        #region Metodos

        public void FacturarEstadia(int precio)
        {
            string mensaje = "";
            if (CantidadEstacionados != null)
            {
                int montoTotal = precio * (int)CantidadEstacionados;
                mensaje = "Valor facturado total: $" + montoTotal;
            }
            ServicioExterno.EnviarEmail("Facturacion del dia", mensaje, "contadores@estacionamiento.com");
        }

        public void IngresoDetectado()
        {
            if (CantidadEstacionados == null)
            {
                CantidadEstacionados = 1;
                EspaciosDisponibles--;
            }
            else if (CantidadEstacionados < 100)
            {
                CantidadEstacionados++;
                EspaciosDisponibles--;
            }
            else
            {
                Console.WriteLine("No quedan espacios disponibles");
                Console.ReadKey();

            }
        }
        public void EgresoDetectado()
        {
            if (CantidadEstacionados != null)
            {
                CantidadEstacionados--;
                EspaciosDisponibles++;
                if (CantidadEstacionados == 0) CantidadEstacionados = null;
            }
            else
            {
                Console.WriteLine("Error, no hay autos estacionados");
                Console.ReadKey();

            }
        }
        #endregion

    }
}
