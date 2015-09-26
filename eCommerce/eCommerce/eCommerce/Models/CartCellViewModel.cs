using System;
using System.Windows.Input;

namespace eCommerce.Models
{
    public class CartCellViewModel : BaseViewModel
    {
        private int _quantity;

        public int CartItemId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity
        {
            get { return _quantity; }
            set { ChangeAndNotify(ref _quantity, value); }
        }
        public float Cost
        {
            get { return Quantity * Price; }
        }
        public Action<object, EventArgs> DeleteClicked { get; set; }
    }
}