// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Lan ETS">
//   
// </copyright>
// <summary>
//   Defines the Extensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LanSoft.Helpers
{
    using System;

    public static class Extensions
    {
        public static string ToMySqlDate(this DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public static int ToUnixDate(this DateTime dateTime)
        {
            var ts = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);

            // Oui mais on veut juste les secondes pas les fucking virgules

            return (int)decimal.Truncate((decimal)ts.TotalSeconds);
        }

        /// <summary>
        /// Fonction pour parser le stupide type de date de phpbb
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToPhpBbDateTime(this DateTime datetime)
        {
            // 1985-10-01
            //  1-10-1985

            string output = "";

            if (datetime.Day < 10)
                output += " ";

            output += datetime.Day;
            output += "-";

            if (datetime.Month < 10)
                output += " ";

            output += datetime.Month;
            output += "-";

            output += datetime.Year;

            return output;
        }
    }
}
