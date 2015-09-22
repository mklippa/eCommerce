using System;
using SQLite;

namespace eCommerce.Data.Models
{
    public class CartItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}