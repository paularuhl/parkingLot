using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot_Ruhl_Paula
{
    class ServicioExterno
    {
        public static void EnviarEmail(string asunto, string mensaje, string mail)
        {
            Console.WriteLine("Facturacion enviada correctamente a {0}", mail);
        }
    }
}
