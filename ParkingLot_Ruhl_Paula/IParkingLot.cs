using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot_Ruhl_Paula
{
    public interface IParkingLot
    {
        int? CantidadEstacionados { get; set; }

        int EspaciosDisponibles { get; set; }

        int PrecioPorDia { get; set; }

        void FacturarEstadia(int precio);

        void IngresoDetectado();

        void EgresoDetectado();

    }
}
