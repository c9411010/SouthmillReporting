using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace SouthmillReportingDataLayer
{
    public static class datalayer
    {
        public static DataSet getData()
        {
            
            // Create a Database object from the factory using the connection string name.
            Database db = utilityDataLayerFunctions.getConnectionDatabase();
            // Using a SQL statement.
            string sql = "daily_receiving_report";
            var productDataSet = db.ExecuteDataSet(CommandType.StoredProcedure, sql);
            return productDataSet;
            
        }

        public static DataSet getInternalFarms()
        {

            // Create a Database object from the factory using the connection string name.
            Database db = utilityDataLayerFunctions.getConnectionDatabase();
            // Using a SQL statement.
            string sql = "getFarms";
            var productDataSet = db.ExecuteDataSet(CommandType.StoredProcedure, sql);
            return productDataSet;

        }
    }
}
