using eCommerce.Converters;
using Xamarin.Forms;

namespace eCommerce.Viewes
{
    public class ProductCell : ViewCell
    {
        public ProductCell()
        {
            // instantiate each of our views
            var image = new Image();
            var cellLayout = new StackLayout();
            var detailsLayout = new StackLayout();
            var nameLabel = new Label();
            var descriptionLabel = new Label();
            var priceLabel = new Label();

            // set bindings
            image.SetBinding(Image.SourceProperty, new Binding("ImageSource", converter: new PathToImageSourceConverter()));
            nameLabel.SetBinding(Label.TextProperty, "Name");
            descriptionLabel.SetBinding(Label.TextProperty, "Description");
            priceLabel.SetBinding(Label.TextProperty, new Binding("Price", stringFormat: "Price: ${0:0.00}"));

            // set properties for desired design
            image.HeightRequest = 70;
            image.WidthRequest = 70;
            descriptionLabel.FontSize =  Device.GetNamedSize(NamedSize.Small, typeof (Label));
            descriptionLabel.TextColor = Color.Gray;
            priceLabel.TextColor = Color.Red;
            cellLayout.Padding = new Thickness(5, 5, 5, 5);
            cellLayout.Orientation = StackOrientation.Horizontal;
            detailsLayout.Padding = new Thickness(5, 0, 0, 0);

            // add views to the view hierarchy
            cellLayout.Children.Add(image);
            cellLayout.Children.Add(detailsLayout);
            detailsLayout.Children.Add(nameLabel);
            detailsLayout.Children.Add(descriptionLabel);
            detailsLayout.Children.Add(priceLabel);
            View = cellLayout;
        }
    }
}
