using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot_Ruhl_Paula
{
    public class ServicioExterno
    {
        public static void EnviarEmail(string asunto, string cuerpo, string destinatario)
        {
            Console.WriteLine("{0}\n{1}\n\nEmail enviado correctamente a: {2}", asunto, cuerpo, destinatario);
        }
    }
}
