using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_22MS
{
    public class DigitoVerificador_22MS
    {
        public long CalcularDigito_22MS(string valor)
        {
            if (valor == null)
                valor = string.Empty;

            long resultado = 0;

            for (int i = 0; i < valor.Length; i++)
            {
                int valorCaracterDecimal = Convert.ToInt32(valor[i]);

                string valorCaracterHexadecimal = valorCaracterDecimal.ToString("X");

                long valorHexadecimalDecimal = Convert.ToInt64(valorCaracterHexadecimal, 16);

                resultado += valorHexadecimalDecimal;
            }

            return resultado;
        }

        //metodo para probar el error
        /*public long CalcularDigito_22MS(string cadena)
        {
            if (cadena == null)
                cadena = string.Empty;

            long resultado = 0;

            for (int i = 0; i < cadena.Length; i++)
            {
                int valorAscii = cadena[i];

                string hexadecimal = valorAscii.ToString("X");

                long valorHexadecimal = Convert.ToInt64(hexadecimal, 16);

                resultado += valorHexadecimal * (i + 1);
            }

            return resultado;
        }*/
    }
}
