using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot_Ruhl_Paula
{
    //
    class ParkingLot : IParkingLot
    {
        #region Propiedades

        public int? CantidadEstacionados { get; set; } = null;
        public int EspaciosDisponibles { get; set; } = 100;
        public int PrecioPorDia { get; set; } = 20;

        #endregion

        #region Metodos

        /// <summary>
        /// Calcula la facturación del dia en base al precio actual, 
        /// multiplicado por la cantidad de autos estacionados.
        /// Luego la envia a quien corresponda por medio del servicio externo.
        /// </summary>
        public void FacturarEstadia(int precio)
        {
            int montoTotal;
            string mensaje;

            if (CantidadEstacionados != null)
                mensaje = "Valor facturado total: $" + (montoTotal = precio * (int)CantidadEstacionados);
            else
                mensaje = "No se pudo facturar: no hay autos estacionados hoy.";

            ServicioExterno.EnviarEmail("Facturacion del dia", mensaje, "contadores@estacionamiento.com");
        }

        /// <summary>
        /// Ingresa un auto sumandolo a los estacionados y restando un espacio libre.
        /// </summary>
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
                Console.Write("No quedan espacios disponibles");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Egresa un auto restandolo de los estacionados y sumando su espacio libre.
        /// </summary>
        public void EgresoDetectado()
        {
            if (CantidadEstacionados != null)
            {
                CantidadEstacionados--;
                EspaciosDisponibles++;

                if (CantidadEstacionados == 0)
                    CantidadEstacionados = null;
            }
            else
            {
                Console.Write("Error, no hay autos estacionados");
                Console.ReadKey();
            }
        }

        #endregion

    }
}
