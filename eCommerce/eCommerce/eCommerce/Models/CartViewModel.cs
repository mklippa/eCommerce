using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eCommerce.Extensions;

namespace eCommerce.Models
{
    public class CartViewModel : BaseViewModel
    {
        private float _totalAmount;
        private readonly ObservableCollection<CartCellViewModel> _cartList;

        public CartViewModel()
        {
            _cartList = new ObservableCollection<CartCellViewModel>();
        }

        public IEnumerable CartList
        {
            get { return _cartList; }
        }

        public float TotalAmount
        {
            get { return _totalAmount; }
            private set { ChangeAndNotify(ref _totalAmount, value); }
        }

        public void SetCartItemQty(int cartItemId, int qty)
        {
            var index = _cartList.ToList().FindIndex(i => i.CartItemId == cartItemId);
            _cartList[index].Quantity = qty;
            TotalAmount = _cartList.Sum(i => i.Cost);
        }

        public void DeleteCartItem(int cartItemId)
        {
            var item = _cartList.FirstOrDefault(i => i.CartItemId == cartItemId);
            if (item != null)
            {
                _cartList.Remove(item);
                TotalAmount = _cartList.Sum(i => i.Cost);
            }
        }

        public void FillWith(IEnumerable<CartCellViewModel> items)
        {
            _cartList.FillWith(items);
            TotalAmount = _cartList.Sum(i => i.Cost);
        }
    }
}