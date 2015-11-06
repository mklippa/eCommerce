using Android.App;
using Android.Views;
using Android.Widget;
using eCommerce.Droid.Renderers;
using eCommerce.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(InfoPage), typeof(InfoPageRenderer))]

namespace eCommerce.Droid.Renderers
{
    public class InfoPageRenderer : PageRenderer
    {
        Android.Views.View _view;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var page = e.NewElement as InfoPage;

            var activity = this.Context as Activity;

            if (activity != null && page != null)
            {
                _view = activity.LayoutInflater.Inflate(Resource.Layout.InfoPageLayout, this, false);

                var label = _view.FindViewById<TextView>(Resource.Id.label);
                label.Text = page.Heading;

                AddView(_view);
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            if (_view == null)
            {
                return;
            }

            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            _view.Measure(msw, msh);
            _view.Layout(0, 0, r - l, b - t);
        }
    }
}