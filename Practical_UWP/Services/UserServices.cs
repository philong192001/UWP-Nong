
using Practical_UWP.Models;
using Practical_UWP.Adapters;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_UWP.Services
{
    class UserServices
    {
        public  static void CheckLogin()
        {
            {
                SQLiteConnection sQLiteConnection = Ass2Adapter.createInstance().sQLiteConnection;
                string sqlCommand = "select * from User;";
                var stt = sQLiteConnection.Prepare(sqlCommand);
                List<Account> list = new List<Account>();
                while (SQLiteResult.ROW == stt.Step())
                {

                    string name = (string)stt[0];

                    int pass = Convert.ToInt32(stt[1]);
                    list.Add(new Account(username, password));
                }
                return list;
            }
        }
        public static void Register(Account item)
        {
            Ass2Adapter Ass2adapter = Ass2Adapter.createInstance();

            SQLiteConnection sQLiteConnection = Ass2adapter.sQLiteConnection;
            var sqlString = "INSERT INTO User(id,username,password) VALUES(?,?,?)";
            var stt = sQLiteConnection.Prepare(sqlString);
            stt.Bind(1, item.id);
            stt.Bind(2, item.username);
            stt.Bind(3, item.password);
           
            stt.Step();

        }
    }
}
