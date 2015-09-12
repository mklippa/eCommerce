using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using eCommerce.Enums;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class SearchNavigationPage : NavigationPage
    {
        public SearchNavigationPage()
        {
            Title = "Search";
            Icon = "search.png";
            PushAsync(new SearchPage(SearchPageType.Category));
        }
    }
}
