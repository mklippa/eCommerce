using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace eCommerce.Models
{
    public class CartViewModel : BaseViewModel
    {
        private float _totalAmount;
        private ObservableCollection<CartCellViewModel> _cartList;

        public CartViewModel()
        {
            _cartList = new ObservableCollection<CartCellViewModel>();
            _cartList.CollectionChanged += (sender, args) =>
            {
                TotalAmount = _cartList.Sum(i => i.Cost);
            };
        }

        public ObservableCollection<CartCellViewModel> CartList
        {
            get { return _cartList; }
            set
            {
                _cartList = value;
                TotalAmount = _cartList.Sum(i => i.Cost);
            }
        }

        public float TotalAmount
        {
            get { return _totalAmount; }
            private set { ChangeAndNotify(ref _totalAmount, value); }
        }

        public void SetCartItemQty(int index, int qty)
        {
            _cartList[index].Quantity = qty;
            TotalAmount = _cartList.Sum(i => i.Cost);
        }
    }
}