using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AMG.DapperEntities.CrossCutting.Helpers
{
    public static class ApplicationHelper
    {
        /// <summary>
        /// Application Version
        /// </summary>
        /// <returns></returns>
        public static string Version() 
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return version; 
        }
    }
}
