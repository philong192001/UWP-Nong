using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_UWP.Adapters
{
    class Ass2Adapter
    {
        private readonly string DB_Name = "user.db";
        private static Ass2Adapter _sQLiteHelper;

        public static Ass2Adapter createInstance()
        {
            if (_sQLiteHelper == null)
            {
                _sQLiteHelper = new Ass2Adapter();
            }
            return _sQLiteHelper;
        }
        private Ass2Adapter()
        {
            sQLiteConnection = new SQLiteConnection(DB_Name);
            CreateUserTable();
        }
        public SQLiteConnection sQLiteConnection
        {
            get;
            private set;
        }
        private void CreateUserTable()
        {
            var sql = @"CREATE TABLE IF NOT EXISTS User(id integer primary key, username varchar(200), password varchar(100))";
            var statement = sQLiteConnection.Prepare(sql);
            statement.Step();
        }
    }
}
