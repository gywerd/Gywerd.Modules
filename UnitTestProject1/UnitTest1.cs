﻿using Gywerd.Modules.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        /// <summary>
        /// Tests Executing a sqlQuery and receiving a DataSet
        /// </summary>
        public void TestMethod1()
        {
            // arrange
            string sqlQuery = "SELECT * FROM Persons";
            Executor executor = new Executor();
            bool expected = false;

            // act  
            DataSet ds = executor.Execute(sqlQuery);
            string d = Convert.ToString(ds);
            // assert  
            bool actual = ds.Equals(null);
            Assert.AreEqual(expected, actual, "NOT EQUAL");
        }

        [TestMethod]
        /// <summary>
        /// Tests Executing a stored procedure and receiving a DataSet
        /// </summary>
        public void TestMethod2()
        {
            // arrange
            string storedProcedureName = "GetPersonFromName";
            string first = "John";
            string last = "Smith";
            Executor executor = new Executor();
            bool expected = false;

            // act  
            DataSet ds = executor.Execute(storedProcedureName, first, last);
            string d = Convert.ToString(ds);
            // assert  
            bool actual = ds.Equals(null);
            Assert.AreEqual(expected, actual, "NOT EQUAL");
        }

        [TestMethod]
        /// <summary>
        /// Tests receiving the expected exception when provided amount of parameters 
        /// differs from required amount of parameters for Stored Procedure
        /// </summary>
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod3()
        {
            // arrange
            string storedProcedureName = "GetPersonFromName";
            string first = "John";
            Executor executor = new Executor();

            // act
                DataSet ds = executor.Execute(storedProcedureName, first);
                Assert.Fail("no exception thrown");

        }
    }
}
