using CoreGraphics;
using eCommerce.iOS.Renderers;
using eCommerce.Pages;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(InfoPage), typeof(InfoPageRenderer))]

namespace eCommerce.iOS.Renderers
{
    public class InfoPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var page = e.NewElement as InfoPage;
            var view = NativeView;

            if (page != null)
            {
                var label = new UILabel(new CGRect(10, 20, 320, 40))
                {
                    Text = page.Heading
                };

                view.Add(label);
            }
        }
    }
}