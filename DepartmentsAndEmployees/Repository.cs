using System.Collections.Generic;
using System.Data.SqlClient;
using DapperDepartments.Models;

namespace StudentExercises.Data
{
    /// <summary>
    ///  An object to contain all database interactions.
    /// </summary>
    public class Repository
    {
        /// <summary>
        ///  Represents a connection to the database.
        ///   This is a "tunnel" to connect the application to the database.
        ///   All communication between the application and database passes through this connection.
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "___YOUR CONNNECTION STRING HERE____";
                return new SqlConnection(_connectionString);
            }
        }
    }
}
