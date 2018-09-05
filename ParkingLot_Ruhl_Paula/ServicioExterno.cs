using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot_Ruhl_Paula
{
    public class ServicioExterno
    {
        /// <summary>
        /// Genera el cuerpo de un e-mail para enviar la facturación correspondiente.
        /// </summary>
        public static void EnviarEmail(string asunto, string cuerpo, string destinatario)
        {
            Console.Write("{0}\n{1}\n\nEmail enviado correctamente a: {2}", asunto, cuerpo, destinatario);
        }
    }
}
