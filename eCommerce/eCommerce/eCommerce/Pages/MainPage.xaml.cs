using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace eCommerce
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            CurrentPageChanged += (sender, args) =>
            {
                var navigationPage = CurrentPage as NavigationPage;
                if (navigationPage != null)
                {
                    var existingPages = navigationPage.Navigation.NavigationStack.ToList();
                    if (existingPages.Count > 1)
                    {
                        for (var i = 1; i < existingPages.Count; i++)
                        {
                            navigationPage.Navigation.RemovePage(existingPages[i]);
                        }
                    }
                }
            };
        }
    }
}
