using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LoanManagementSystemApp.Utility
{
    internal class DbConnUtil
    {
        private static string _connectionString;


        static DbConnUtil()
        {
            try
            {

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();


                _connectionString = configuration.GetConnectionString("LoanManagementDb");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading connection string: {ex.Message}");
            }
        }


        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }


        internal static string? GetConnectionString()
        {
            throw new NotImplementedException();
        }
    }
}
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Data.SqlClient;
//using System.IO;

//namespace LoanManagementSystemApp.Utility
//{
//    public static class DbConnUtil
//    {
//        private static string _connectionString;

//        static DbConnUtil()
//        {
//            try
//            {
//                // Loading the configuration from appsettings.json
//                var configuration = new ConfigurationBuilder()
//                    .SetBasePath(Directory.GetCurrentDirectory()) // Ensure it is the directory where the exe runs
//                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                    .Build();

//                // Get the connection string from the configuration file
//                _connectionString = configuration.GetConnectionString("LoanManagementDb"); // Use the actual name from appsettings.json
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error loading connection string: {ex.Message}");
//                throw; // Re-throw the exception to indicate an issue during initialization
//            }
//        }

//        // Method to get a new SQL connection
//        public static SqlConnection GetConnection()
//        {
//            if (string.IsNullOrEmpty(_connectionString))
//            {
//                throw new InvalidOperationException("Connection string is not initialized.");
//            }

//            return new SqlConnection(_connectionString);
//        }

//        // Method to retrieve the connection string
//        public static string GetConnectionString()
//        {
//            return _connectionString;
//        }
//    }
//}
