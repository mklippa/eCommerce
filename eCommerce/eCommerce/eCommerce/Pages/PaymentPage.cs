using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            ToolbarItems.Add(new ToolbarItem("Done", null, async () =>
            {
//                await Navigation.PushAsync(new LoginPage());
            }));

            Title = "Payment";
            Content = new StackLayout
            {
                Spacing = 0,
                Children = {
                    new ContentView
                    {
                        Padding = new Thickness(10),
                        Content = new Label
                        {
                            Text = "Login: "
                        }
                    },
                    new ContentView
                    {
                        Padding = new Thickness(10),
                        Content = new Label
                        {
                            Text = "Bill to: "
                        }
                    },
                    new ContentView
                    {
                        Padding = new Thickness(10),
                        Content = new Picker
                        {
                            Title = "Card Type",
                            Items = { "MasterCard", "Visa" }
                        }
                    },
                    new ContentView
                    {
                        Padding = new Thickness(10),
                        Content = new Entry
                        {
                            Placeholder = "Card Number"
                        }
                    },
                    new ContentView
                    {
                        Padding = new Thickness(10),
                        Content = new Entry
                        {
                            Placeholder = "CVV"
                        }
                    },
                    new ContentView
                    {
                        Padding = new Thickness(10),
                        Content = new Entry
                        {
                            Placeholder = "Ship to"
                        }
                    }
                }
            };
        }
    }
}
