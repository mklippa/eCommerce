using Android.App;
using Android.Graphics;
using Android.Widget;
using eCommerce.Droid.Renderers;
using eCommerce.Droid.Views;
using eCommerce.Pages;
using eCommerce.Viewes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(InfoView), typeof(InfoViewRenderer))]

namespace eCommerce.Droid.Renderers
{
    public class InfoViewRenderer : ViewRenderer<InfoView, DroidInfoView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<InfoView> e)
        {
            base.OnElementChanged(e);

            var infoView = e.NewElement as InfoView;

            if (infoView == null) return;
            
            var view = new DroidInfoView(this.Context)
            {
                HeaderText = infoView.HeaderText,
                BodyText = infoView.BodyText,
                StrokeThickness = (int)infoView.StrokeThickness,
                CornerRadius = (float)infoView.CornerRadius,
                Stroke = infoView.Stroke.ToAndroid()
            };

            SetNativeControl(view);
        }
    }
}