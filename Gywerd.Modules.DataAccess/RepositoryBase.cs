using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gywerd.Modules.DataAccess
{
    public class RepositoryBase
    {
        #region Fields
        public Executor executor;
        #endregion

        #region Constructors
        #endregion

        #region Methods
        /// <summary>
        /// Initiates new or Clears content of executor
        /// </summary>
        public void InitOrClearExecutor()
        {
            executor = new Executor();
        }

        /// <summary>
        /// Sets the connectionstring
        /// </summary>
        /// <param name="path">string</param>
        /// <param name="name">strng</param>
        public void InitConnection(string path, string name = null)
        {
            if (name == null)
            {
                executor.ConnectionString = GetConnectionString(path);

            }
            else
            {
                executor.ConnectionString = GetConnectionString(path, name);
            }
        }

        /// <summary>
        /// Returns a ConnationString based on path and eventual name
        /// </summary>
        /// <param name="path">string - ip or path to SQL-server</param>
        /// <param name="name">string - name of database</param>
        /// <returns>string</returns>
        private static string GetConnectionString(string path, string name = null)
        {
            string[] data = ReadFromFile();
            if (name == null)
            {
                name = data[0];
            }
            string user = data[1];
            string password = data[2];
            string res = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", path, name, user, password);
            return res;
        }

        /// <summary>
        /// Reads data string from file and separates string
        /// </summary>
        /// <returns>string[]</returns>
        private static string[] ReadFromFile()
        {
            string text = System.IO.File.ReadAllText(@".\DBPath\conn.config");
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] resData = text.Split(';');

            return resData;
        }
        #endregion
    }
}
