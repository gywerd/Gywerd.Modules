using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gywerd.Modules.DataAccess
{
    public class Executor
    {
        #region Fields
        private string connectionString = ConfigurationManager.GetConnectionString("", "");
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Executor() { }

        #endregion

        #region Methods
        /// <summary>
        /// Executes a sqlQuery and returns a DataSet
        /// </summary>
        /// <param name="sqlQuery">string</param>
        /// <returns>Dataset</returns>
        public DataSet Execute(string sqlQuery)
        {
            DataSet res = new DataSet();
            return res;
        }

        /// <summary>
        /// Executes a stored Procedure with multiple parameters and returns a DataSet
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="procedureParameters"></param>
        /// <returns></returns>
        public DataSet Execute(string storedProcedureName, params string[] procedureParameters)
        {
            DataSet res = new DataSet();
            return res;
        }
        #endregion

        #region Properties
        public string ConnectionString { get => connectionString;}
        #endregion
    }
}
