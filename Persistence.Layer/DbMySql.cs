using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Layer
{
    public class DbMySql : IDisposable
    {
        public MySqlConnection Connection { get; }

        public DbMySql(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
