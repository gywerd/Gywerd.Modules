using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gywerd.Modules.DataAccess
{
    public static class ConfigurationManager
    {
        #region Methods
        /// <summary>
        /// Returns a ConnationString based on path and eventual name
        /// </summary>
        /// <param name="path">string</param>
        /// <param name="name">string</param>
        /// <returns>string</returns>
        public static string GetConnectionString(string path, string name = null)
        {
            string res = "";
            return res;
        }
        #endregion
    }
}
