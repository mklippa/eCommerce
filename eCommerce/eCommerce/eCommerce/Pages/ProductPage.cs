using eCommerce.Client.Objects;
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
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = _product.Name }
                }
            };
        }
    }
}
