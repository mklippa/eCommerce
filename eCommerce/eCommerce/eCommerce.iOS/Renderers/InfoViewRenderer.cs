using System.ComponentModel;
using System.Drawing;
using CoreGraphics;
using eCommerce.iOS.Renderers;
using eCommerce.iOS.Views;
using eCommerce.Viewes;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(InfoView), typeof(InfoViewRenderer))]

namespace eCommerce.iOS.Renderers
{
    public class InfoViewRenderer : ViewRenderer<InfoView, UIView>
    {
        UIView childView;

        protected override void OnElementChanged(ElementChangedEventArgs<InfoView> e)
        {
            base.OnElementChanged(e);

            var infoView = e.NewElement;
            if (infoView != null)
            {
                var shadowView = new UIView();
                var headerView = new PaddedUIView<UILabel>
                {
                    BackgroundColor = UIColor.Red,
                    Padding = 10f,
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                    Frame = new CGRect(0, 0, 0, 40)
                };
                headerView.NestedView.Text = infoView.HeaderText;
                headerView.NestedView.TextColor = UIColor.White;
                headerView.NestedView.Font = UIFont.BoldSystemFontOfSize(UIFont.LabelFontSize);
                
                var bodyView = new PaddedUIView<UITextView>
                {
                    BackgroundColor = UIColor.White,
                    Padding = 5f,
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
                    Frame = new CGRect(0, 40, 0, 0)
                };
                bodyView.NestedView.Text = infoView.BodyText;
                bodyView.NestedView.TextColor = UIColor.Black;
                bodyView.NestedView.Font = UIFont.SystemFontOfSize(UIFont.SystemFontSize);

                childView = new UIView()
                {
                    BackgroundColor = infoView.BackgroundColor.ToUIColor(),
                    Layer =
                    {
                        CornerRadius = (float)infoView.CornerRadius,
                        BorderColor = infoView.Stroke.ToCGColor(),
                        BorderWidth = (float)infoView.StrokeThickness,
                        MasksToBounds = true
                    },
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
                };

                childView.Add(headerView);
                childView.Add(bodyView);
                shadowView.Add(childView);

                if (infoView.HasShadow)
                {
                    shadowView.Layer.ShadowColor = UIColor.Black.CGColor;
                    shadowView.Layer.ShadowOffset = new SizeF(3, 3);
                    shadowView.Layer.ShadowOpacity = 1;
                    shadowView.Layer.ShadowRadius = 5;
                }

                SetNativeControl(shadowView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == InfoView.CornerRadiusProperty.PropertyName)
                childView.Layer.CornerRadius = (float)this.Element.CornerRadius;
            else if (e.PropertyName == InfoView.StrokeProperty.PropertyName)
                childView.Layer.BorderColor = this.Element.Stroke.ToCGColor();
            else if (e.PropertyName == InfoView.StrokeThicknessProperty.PropertyName)
                childView.Layer.BorderWidth = (float)this.Element.StrokeThickness;
            else if (e.PropertyName == BoxView.ColorProperty.PropertyName)
                childView.BackgroundColor = this.Element.BackgroundColor.ToUIColor();
            else if (e.PropertyName == InfoView.HasShadowProperty.PropertyName)
            {
                if (Element.HasShadow)
                {
                    NativeView.Layer.ShadowColor = UIColor.Black.CGColor;
                    NativeView.Layer.ShadowOffset = new SizeF(3, 3);
                    NativeView.Layer.ShadowOpacity = 1;
                    NativeView.Layer.ShadowRadius = 5;
                }
                else
                {
                    NativeView.Layer.ShadowColor = UIColor.Clear.CGColor;
                    NativeView.Layer.ShadowOffset = new SizeF();
                    NativeView.Layer.ShadowOpacity = 0;
                    NativeView.Layer.ShadowRadius = 0;
                }
            }
        }
    }
}