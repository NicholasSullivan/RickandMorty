using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace COMPE_361_Final_Project
{
    class SQLgate
    {
        public static List<Table> LoadTable()
        {
            using (IDbConnection a = new SQLiteConnection(LoadConnection()))
            {
                var output = a.Query<Table>("select * from Q", new DynamicParameters());
                return output.ToList();
            }
        }

        // SQL connection
        public static void SaveTable(Table table)
        {
            using (IDbConnection a = new SQLiteConnection(LoadConnection()))
            {
                a.Execute("insert into QSQLite (Question1, Answer1, Answer2, Answer3) values (@Question1, @Answer1, @Answer2, @Answer3)", table);
            }
        }

        private static string LoadConnection(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
