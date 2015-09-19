using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace eCommerce.Viewes
{
    public class InfoView : ContentView
    {
        public string HeaderText { get; private set; }
        public string BodyText { get; private set; }

        public InfoView(string headerText, string bodyText)
        {
            HeaderText = headerText;
            BodyText = bodyText;
            VerticalOptions = LayoutOptions.FillAndExpand;

            Content = new StackLayout
            {
                Spacing = 0,
                Children = {
                    new ContentView
                    {
                        Padding = new Thickness(5),
                        BackgroundColor = Color.Red,
                        Content = new Label
                        {
                            Text = HeaderText,
                            TextColor = Color.White,
                        }
                    },
                    new ContentView
                    {
                        Padding = new Thickness(5),
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = new Label
                        {
                            Text = BodyText,
                            TextColor = Color.Black,
                            FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                        }
                    }
                }
            };
        }
    }
}
