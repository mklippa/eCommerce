using System;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class ProductImagePage : ContentPage
    {
        private readonly ImageSource _productImageSource;

        public ProductImagePage(ImageSource productImageSource)
        {
            Padding = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0), new Thickness(0));
            _productImageSource = productImageSource;
            BackgroundColor = Color.FromRgba(0, 0, 0, 127);

            var absoluteLayout = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var closeButtom = new Button
            {
                WidthRequest = 50,
                Image = "backspace.png"
            };
            closeButtom.Clicked += OnCloseButtonClicked;
            var image = new Image
            {
                Source = _productImageSource
            };
            AbsoluteLayout.SetLayoutFlags(closeButtom, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(closeButtom, new Rectangle(1f, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0.5f, 0.5f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            absoluteLayout.Children.Add(image); 
            absoluteLayout.Children.Add(closeButtom);

            Content = absoluteLayout;
        }

        private async void OnCloseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
