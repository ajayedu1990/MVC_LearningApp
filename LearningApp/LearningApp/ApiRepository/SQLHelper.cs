using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LearningApp.ApiRepository
{
    public class SQLHelper : ISQLHelper
    {
        public SqlConnection GetSQLConnection()
        {
            string connString = "Data Source=AJAY-PC\\SQLEXPRESS;Initial Catalog=LearningApp;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);
           
            return conn;
        }

    }
}