using Gywerd.Modules.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program : RepositoryBase
    {
        static void Main(string[] args)
        {
            string storedProcedureName = "GetPersonFromName";
            string first = "John";
            string last = "Smith";
            Executor executor = new Executor();
            DataSet ds = executor.Execute(storedProcedureName, first, last);
            PrintRows(ds);
            Console.ReadKey();
        }

        /// <summary>
        /// Prints all rows from a Dataset on screen
        /// </summary>
        /// <param name="ds">DataSet</param>
        private static void PrintRows(DataSet ds)
        {
            DataTableReader reader = ds.CreateDataReader();
            while (reader.Read())
            {
                string first = Convert.ToString(reader["FirstName"]);
                string last = Convert.ToString(reader["LastName"]);
                string title = Convert.ToString(reader["Title"]);
                Console.WriteLine(string.Format("{0} {1} {2}", title, first, last));
            }
            Console.WriteLine("End of list");
        }
    }
}
