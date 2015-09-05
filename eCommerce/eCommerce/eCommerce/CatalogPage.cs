using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace eCommerce
{
    public class CatalogPage : ContentPage
    {
        public CatalogPage()
        {
            Title = "Catalog";
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Catalog Page" }
				}
            };
        }
    }
}
