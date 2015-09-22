using System.Collections;
using System.Collections.Specialized;
using eCommerce.Client.Managers;
using eCommerce.Converters;
using eCommerce.Extensions;
using eCommerce.Models;
using eCommerce.Viewes;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class CartPage : ContentPage
    {
        private readonly CartViewModel _cartViewModel;
        private readonly ProductManager _productManager;
        private readonly Picker _qtyPicker;
        private int _selectedCartItemId;

        public CartPage()
        {
            _productManager = new ProductManager();

            _cartViewModel = new CartViewModel
            {
                CartList = new ObservableCollection<CartCellViewModel>(),
            };
            this.BindingContext = _cartViewModel;
            
            _qtyPicker = new Picker {IsVisible = false};
            _qtyPicker.Items.Add("1");
            _qtyPicker.Items.Add("2");
            _qtyPicker.Items.Add("3");
            _qtyPicker.SelectedIndexChanged += OnQtyPickerSelectedIndexChanged;

            Title = "Cart";

            var listView = new ListView();
            listView.ItemTapped += OnListViewItemTapped;
            listView.ItemTemplate = new DataTemplate(typeof(CartCell));
            listView.RowHeight = 60;
            listView.SetBinding(ListView.ItemsSourceProperty, "CartList");
            
            var footer = new Label();
            footer.SetBinding(Label.TextProperty, new Binding("TotalAmount", 
                stringFormat: "Total Amount: ${0:0.00}",
                source: _cartViewModel));
            listView.Footer = footer;

            ToolbarItems.Add(new ToolbarItem("Done", null, async () =>
            {
                await Navigation.PushAsync(new LoginPage());
            }));

            Content = new StackLayout
            {
                Children =
                {
                    _qtyPicker,
                    listView
                }
            };
        }

        private void OnQtyPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var qty = int.Parse(_qtyPicker.Items[_qtyPicker.SelectedIndex]);
            var item = App.Database.GetItem(_selectedCartItemId);
            item.Quantity = qty;
            App.Database.SaveItem(item);
            var index = _cartViewModel.CartList.ToList().FindIndex(i => i.CartItemId == _selectedCartItemId);
            _cartViewModel.SetCartItemQty(index, qty);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var items = App.Database.GetItems().Select(i =>
            {
                var product = _productManager.GetById(i.ProductId);
                return new CartCellViewModel
                {
                    CartItemId = i.ID,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = i.Quantity
                };
            }).ToList();

            _cartViewModel.CartList.FillWith(items);
        }

        private void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = (ListView)sender;
            if (listView.SelectedItem == null)
                return;

            var selectedCartItem = (CartCellViewModel)listView.SelectedItem;
            _selectedCartItemId = selectedCartItem.CartItemId;
            _qtyPicker.Focus();
            listView.SelectedItem = null;
        }
    }
}
