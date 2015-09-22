using eCommerce.Client.Managers;
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
        private readonly ObservableCollection<CartCellViewModel> _cartList;
        private readonly ProductManager _productManager;
        private readonly Picker _qtyPicker;
        private int _selectedCartItemId;

        public CartPage()
        {
            _productManager = new ProductManager();
            _cartList = new ObservableCollection<CartCellViewModel>();
            _qtyPicker = new Picker {IsVisible = false};
            _qtyPicker.Items.Add("1");
            _qtyPicker.Items.Add("2");
            _qtyPicker.Items.Add("3");
            _qtyPicker.SelectedIndexChanged += OnQtyPickerSelectedIndexChanged;

            Title = "Cart";

            var listView = new ListView();
            listView.ItemTapped += OnListViewItemTapped;
            listView.ItemsSource = _cartList;
            listView.ItemTemplate = new DataTemplate(typeof(CartCell));
            listView.RowHeight = 60;
            listView.Footer = new ContentView
            {
                Padding = new Thickness(10),
                Content = new Label
                {
                    HorizontalOptions = LayoutOptions.End,
                    Text = "Total ammount: $10"
                }
            };

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
            var index = _cartList.ToList().FindIndex(i => i.CartItemId == _selectedCartItemId);
            _cartList[index].Quantity = qty;
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

            _cartList.FillWith(items);
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
