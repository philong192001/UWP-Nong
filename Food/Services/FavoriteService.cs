using Food.Adapters;
using Food.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Services
{
    class FavoriteService
    {
        public static List<Item> GetFavourite()
        {
            SQLiteHelper sQLiteHelper = SQLiteHelper.createInstance();
            SQLiteConnection sQLiteConnection = sQLiteHelper.sQLiteConnection;
            var sqlString = "SELECT * FROM Products";
            var stt = sQLiteConnection.Prepare(sqlString);
            List<Item> arr = new List<Item>();
            while (SQLiteResult.ROW == stt.Step())
            {
                var id = Convert.ToInt32(stt[0]);
                var name = (string)stt[1];
                var image = (string)stt[2];
                var description = (string)stt[3];
                var price = Convert.ToInt32(stt[4]);

                arr.Add(new Item(id, name, image, description, price));
            }

            return  arr;
        }

        public static void InsertProduct(Item Detail)
        {
            SQLiteHelper sQLiteHelper = SQLiteHelper.createInstance();

            SQLiteConnection sQLiteConnection = sQLiteHelper.sQLiteConnection;
            var sqlString = "INSERT INTO Products(id,name,image,description,price) VALUES(?,?,?,?,?)";
            var stt = sQLiteConnection.Prepare(sqlString);
            stt.Bind(1, Detail.id);
            stt.Bind(2, Detail.name);
            stt.Bind(3, Detail.image);
            stt.Bind(4, Detail.description);
            stt.Bind(5, Detail.price);
            stt.Step();
            
        }
        public static void deleteProduct(int id)
        {
            SQLiteHelper sQLiteHelper = SQLiteHelper.createInstance();
            SQLiteConnection sQLiteConnection = sQLiteHelper.sQLiteConnection;
            var stt = sQLiteConnection.Prepare("DELETE FROM Products WHERE id = " + id);
            stt.Step();
        }
    }
}
