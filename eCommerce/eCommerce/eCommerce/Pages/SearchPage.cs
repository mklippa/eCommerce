using System.Collections.Generic;
using System.Linq;
using eCommerce.Core.Models;
using eCommerce.Core.Repositories;
using Xamarin.Forms;

namespace eCommerce.Pages
{
    public class SearchPage : ContentPage
    {
        private readonly CategoryRepository _categoryRepository;
        private List<string> _categories;
        private readonly ListView _listView;

        public SearchPage()
        {
            _categoryRepository = new CategoryRepository();
            _categories = _categoryRepository.GetAll().Select(c => c.Name).ToList();

            var searchBar = new SearchBar();
            searchBar.TextChanged += OnSearchBarTextChanged;

            _listView = new ListView {ItemsSource = _categories};

            Padding = Device.OnPlatform(new Thickness(0, 20, 0, 0), new Thickness(0), new Thickness(0));
            Title = "Search";
            Icon = "search.png";
            Content = new StackLayout
            {
                Children = {
                    searchBar,
                    _listView
                }
            };
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((SearchBar) sender).Text;

            if (string.IsNullOrEmpty(text))
            {
                _categories = _categoryRepository.GetAll().Select(c => c.Name).ToList();
            }
            else
            {
                _categories = _categoryRepository.GetAll()
                    .Where(c => c.Name.ToLower().Contains(text.ToLower()))
                    .Select(c => c.Name).ToList();
            }
            _listView.ItemsSource = _categories;
        }
    }
}
