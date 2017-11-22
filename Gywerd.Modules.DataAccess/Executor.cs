using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gywerd.Modules.DataAccess
{
    public class Executor
    {
        #region Fields
        private string connectionString = ConfigurationManager.GetConnectionString("10.205.44.39,49172");
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
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(
                sqlQuery, new SqlConnection(connectionString)))
            {
                cmd.Connection.Open();
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);
            }
            return ds;
        }

        /// <summary>
        /// Executes a stored procedure with multiple parameters and returns a DataSet
        /// Amount of parameters must correspond required parametres in stored Procedure 
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="procedureParameters"></param>
        /// <returns>DataSet</returns>
        public DataSet Execute(string storedProcedureName, params string[] procedureParameters)
        {
            DataSet ds = new DataSet();
            List<string> paramList = GetListOfProcedureParams(storedProcedureName);
            int iMax = paramList.Count;
            if (iMax != procedureParameters.Length)
            {
                throw new ArgumentException("Amount of actual parameters is different from required amount of parameters for Stored Procedure");
            }
            using (SqlCommand command = new SqlCommand(
            storedProcedureName, new SqlConnection(connectionString)))
            {
                command.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < iMax; i++)
                {
                    command.Parameters.AddWithValue(paramList[i], procedureParameters[i]);
                }
                command.Connection.Open();
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                ds.Tables.Add(table);

            }
            return ds;
        }

        /// <summary>
        /// Retrieves a list of reqiired parameters for stored Procedure from DataBase
        /// </summary>
        /// <param name="storedProcedureName">string</param>
        /// <returns>List<string></returns>
        private List<string> GetListOfProcedureParams(string storedProcedureName)
        {
            List<string> resList = new List<string>();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(storedProcedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlCommandBuilder.DeriveParameters(cmd);
            foreach (SqlParameter p in cmd.Parameters)
            {
                resList.Add(p.ParameterName);
            }
            resList.RemoveAt(0);
            return resList;
        }
        #endregion

        #region Properties
        public string ConnectionString { get => connectionString;}
        #endregion
    }
}
