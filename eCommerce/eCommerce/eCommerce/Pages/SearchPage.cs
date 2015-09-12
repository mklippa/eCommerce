using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using eCommerce.Core.Models;
using eCommerce.Core.Repositories;
using eCommerce.Extensions;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class SearchPage : ContentPage
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly ObservableCollection<Category> _categories;

        public SearchPage()
        {
            _categoryRepository = new CategoryRepository();
            _categories = new ObservableCollection<Category>();

            var searchBar = new SearchBar();
            searchBar.TextChanged += OnSearchBarTextChanged;

            Padding = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0), new Thickness(0));
            Title = "Search";
            Icon = "search.png";
            Content = new StackLayout
            {
                Children = {
                    searchBar,
                    new ListView {ItemsSource = _categories}
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _categories.FillWith(_categoryRepository.GetAll());
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((SearchBar) sender).Text;

            var categories = string.IsNullOrEmpty(text) 
                ? _categoryRepository.GetAll() 
                : _categoryRepository.GetAll().Where(c => c.Name.ToLower().Contains(text.ToLower()));

            _categories.FillWith(categories);
        }
    }
}
