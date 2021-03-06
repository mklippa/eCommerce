﻿using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Client.Objects;
using eCommerce.Data.Models;
using eCommerce.Models;
using eCommerce.Viewes;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class ProductPage : ContentPage
    {
        private readonly Product _product;

        public ProductPage(Product product)
        {
            _product = product;
            Title = "Product";
            var addToCartButton = new Button
            {
                VerticalOptions = LayoutOptions.Start,
                BorderWidth = 1,
                BorderColor = Color.Gray,
                Text = "Add",
                Image = "cart.png"
            };
            addToCartButton.Clicked += OnAddToCartButtonClicked;
            var productImageTapGestureRecognizer = new TapGestureRecognizer();
            productImageTapGestureRecognizer.Tapped += OnProductImageTap;
            var grid = new Grid
            {
                Padding = new Thickness(5, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions = { new RowDefinition { Height = new GridLength(100)} },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(100) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(100) }
                }
            };
            grid.Children.Add(new ContentView
            {
                Content = new Image
                {
                    HeightRequest = 100,
                    WidthRequest = 100,
                    Source = ImageSource.FromResource((_product.ImageSource)),
                    GestureRecognizers = { productImageTapGestureRecognizer }
                }
            }, 0, 0);
            grid.Children.Add(new ContentView
            {
                Content = new Label
                {
                    Text = string.Format("${0:0.00}", _product.Price),
                    TextColor = Color.Red,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                }
            }, 1, 0);
            grid.Children.Add(new ContentView
            {
                Content = addToCartButton
            }, 2, 0);
            Content = new StackLayout
            {
                Spacing = 0,
                Children = {
                    new ContentView
                    {
                        Padding = new Thickness(5),
                        Content = new Label
                        {
                            Text = _product.Name,
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                        },
                    },
                    grid,
                    new ContentView
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Padding = new Thickness(5),
                        Content = new InfoView()
                        {
                            CornerRadius = 10d,
                            StrokeThickness = 1d,
                            Stroke = Color.Gray,
                            HeaderText = _product.Name,
                            BodyText = _product.Description
                        }
                    }
                }
            };
        }

        private async void OnProductImageTap(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductImagePage(ImageSource.FromResource(_product.ImageSource)));
        }

        private void OnAddToCartButtonClicked(object sender, EventArgs e)
        {
            var cartItems = App.Database.GetItems().ToList();

            var cartItem = cartItems.FirstOrDefault(i => i.ProductId == _product.Id);

            if (cartItem == null)
            {
                App.Database.SaveItem(new CartItem
                {
                    ProductId = _product.Id,
                    Quantity = 1,
                });
            }
            else
            {
                cartItem.Quantity += 1;
                App.Database.SaveItem(cartItem);
            }
        }
    }
}
