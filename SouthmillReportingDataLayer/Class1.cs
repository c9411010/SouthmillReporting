using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using SouthMillReporting.Model;

namespace SouthmillReporting.DataLayer
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

        //GrowerProductionDataByDay
        public static DataSet getDailyProductionData(growingReportFilter sqlParams)
        {
            Database db = utilityDataLayerFunctions.getConnectionDatabase();
            string storedProcName = "daily_production_report_pivot";
            DataSet productDataSet;
            using (DbCommand sprocCmd = db.GetStoredProcCommand(storedProcName))
            {
                db.AddInParameter(sprocCmd, "from_date", DbType.String, sqlParams.fromDate);
                db.AddInParameter(sprocCmd, "to_date", DbType.Date, sqlParams.toDate);
                db.AddInParameter(sprocCmd, "growerid", DbType.String, sqlParams.growerID);
                productDataSet = db.ExecuteDataSet(sprocCmd);
            }
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
