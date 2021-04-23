using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMG.DapperEntities.CrossCutting.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Compare String (Ignore CaseSensitive)
        /// </summary>
        /// <param name="current"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool CompareIgnoreCase(this string current, params string[] compare) 
        {
            return compare.Any(x => string.Equals(current, x, StringComparison.OrdinalIgnoreCase));
        }
    }
}
