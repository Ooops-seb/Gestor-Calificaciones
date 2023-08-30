using System.Text.RegularExpressions;

namespace StreamingManagement.Resources
{
    public class StringsManager
    {
        public static string StringIdGenerator(int longitudTotal, string letras, int numero)
        {
            string cadenaLetras = letras.PadRight(longitudTotal - numero.ToString().Length, '0');
            string cadenaNumero = numero.ToString().PadLeft(longitudTotal - cadenaLetras.Length, '0');
            return cadenaLetras + cadenaNumero;
        }
    }
}
