using System;
using System.Drawing;

namespace Shared.Layer
{
    public class Functions
    {
        /// <summary>
        /// Calcula la edad en base a una fecha indicada.
        /// </summary>
        /// <param name="birthday">Fecha de nacimiento.</param>
        /// <returns>Int - Edad en años.</returns>
        public static int GetAge(DateTime birthday)
        {
            var age = DateTime.Now.Year - birthday.Year;

            if (DateTime.Now.Month < birthday.Month || DateTime.Now.Month == birthday.Month && DateTime.Now.Day < birthday.Day)
                age--;

            return age;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string HexadecimalConverter(Color c)
        {
            return $"{c.R:X2}{c.G:X2}{c.B:X2}";
        }
    }
}
