using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eCommerce.Client.Managers;
using eCommerce.Client.Objects;
using eCommerce.Extensions;
using eCommerce.Viewes;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class CartPage : ContentPage
    {
        private readonly ObservableCollection<CartCellViewModel> _cartList;
        private readonly ProductManager _productManager;

        public CartPage()
        {
            _productManager = new ProductManager();
            _cartList = new ObservableCollection<CartCellViewModel>();

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
                    listView
                }
            };
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

            var selectedProduct = (CartCellViewModel)listView.SelectedItem;
            listView.SelectedItem = null;
        }
    }
}
