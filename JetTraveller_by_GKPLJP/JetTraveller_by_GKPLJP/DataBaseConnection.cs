using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace JetTraveller_by_GKPLJP
{
    class DataBaseConnection
    {
        private const string SOURCE = "data source=JetTravellerDataBase.db";
        private SQLiteConnection connection = new SQLiteConnection(SOURCE);

        public SQLiteConnection getConnection()
        {
            return this.connection;
        }

        public void openConnection()
        {
            if (this.connection.State == System.Data.ConnectionState.Closed)
            {
                this.connection.Open();
            }
        }

        public void closeConnection()
        {
            if (this.connection.State == System.Data.ConnectionState.Open)
            {
                this.connection.Close();
            }
        }

        public override string ToString()
        {
            return this.connection.ToString();
        }
    }
}
