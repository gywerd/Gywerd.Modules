using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            if (name.Equals(null))
            {
                return "Data Source=10.205.44.39,49172;Initial Catalog=DanielWeb2DbApp;Integrated Security=False;User ID=Aspit;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
            else
            {
                // Assume failure.
                string returnValue = null;

                // Look for the name in the connectionStrings section.
                ConnectionStringSettings settings =
                    ConfigurationManager.ConnectionStrings[name].ConnectionString;

                // If found, return the connection string.
                if (settings != null)
                    returnValue = settings.ConnectionString;
                return returnValue;
            }
        }
        #endregion
    }
}
