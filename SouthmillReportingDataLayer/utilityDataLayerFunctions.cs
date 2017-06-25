using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace SouthmillReportingDataLayer
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

    }
}
