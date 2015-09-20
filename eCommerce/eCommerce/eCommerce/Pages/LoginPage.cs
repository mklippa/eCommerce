using System;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var okButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 100,
                BorderWidth = 1,
                BorderColor = Color.Gray,
                Text = "OK"
            };
            okButton.Clicked += OnOkButtonClicked;

            Content = new StackLayout
            {
                Spacing = 0,
                Children = {
                    new ContentView
                    {
                        Padding = new Thickness(10),
                        Content = new Entry
                        {
                            Placeholder = "Login"
                        }
                    },
                    new ContentView
                    {
                        Padding = new Thickness(10),
                        Content = new Entry
                        {
                            Placeholder = "Password",
                            IsPassword = true,
                        }
                    },
                    new ContentView
                    {
                        Padding = new Thickness(10),
                        Content = okButton
                    }
                }
            };
        }

        private async void OnOkButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaymentPage());
        }
    }
}
