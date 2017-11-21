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
        protected string connectionString { get; }
        #endregion

        #region Constructors
        public Executor() { }
        #endregion

        #region Methods
        public DataSet Execute(string sqlQuery)
        {
            DataSet res = new DataSet();
            return res;
        }

        public DataSet Execute(string storedProcedureName, params string[] procedureParameters)
        {
            DataSet res = new DataSet();
            return res;
        }
        #endregion
    }
}
