using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;

namespace SouthmillReporting.DataLayer
{
    public static  class utilityDataLayerFunctions
    {
        public static Database getConnectionDatabase()
        {
        
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
        // Create a Database object from the factory using the connection string name.
            Database db = factory.Create("DefaultConnection");
            return db;
        }

        public static string AddArrayParameters(SqlCommand sqlCommand, string[] array, string paramName)
        {
            /* An array cannot be simply added as a parameter to a SqlCommand so we need to loop through things and add it manually. 
             * Each item in the array will end up being it's own SqlParameter so the return value for this must be used as part of the
             * IN statement in the CommandText.
             */
            var parameters = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                parameters[i] = string.Format("@{0}{1}", paramName, i);
                sqlCommand.Parameters.AddWithValue(parameters[i], array[i]);
            }

            return string.Join(", ", parameters);
        }
    }
}
