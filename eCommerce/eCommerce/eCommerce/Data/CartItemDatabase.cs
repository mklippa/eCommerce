using System.Collections.Generic;
using System.Linq;
using eCommerce.Data.Models;
using eCommerce.Models;
using SQLite;
using Xamarin.Forms;

namespace eCommerce.Data
{
    public class CartItemDatabase
    {
        static readonly object Locker = new object();

        readonly SQLiteConnection _database;

        public CartItemDatabase()
        {
            _database = DependencyService.Get<ISQLite>().GetConnection();
            _database.CreateTable<CartItem>();
        }

        public IEnumerable<CartItem> GetItems()
        {
            lock (Locker)
            {
                return (from i in _database.Table<CartItem>() select i).ToList();
            }
        }

        public CartItem GetItem(int id)
        {
            lock (Locker)
            {
                return _database.Table<CartItem>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(CartItem item)
        {
            lock (Locker)
            {
                if (item.ID != 0)
                {
                    _database.Update(item);
                    return item.ID;
                }
                else
                {
                    return _database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (Locker)
            {
                return _database.Delete<CartItem>(id);
            }
        }
    }
}
