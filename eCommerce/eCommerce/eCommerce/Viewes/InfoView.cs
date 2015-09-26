using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace eCommerce.Viewes
{
    public class InfoView : ContentView
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create<InfoView, double>(p => p.CornerRadius, 0);

        public static readonly BindableProperty StrokeProperty =
            BindableProperty.Create<InfoView, Color>(p => p.Stroke, Color.Transparent);

        public static readonly BindableProperty StrokeThicknessProperty =
            BindableProperty.Create<InfoView, double>(p => p.StrokeThickness, default(double));

        public static readonly BindableProperty HasShadowProperty =
            BindableProperty.Create<InfoView, bool>(p => p.HasShadow, default(bool));

        public static readonly BindableProperty HeaderTextProperty =
            BindableProperty.Create<InfoView, string>(p => p.HeaderText, default(string));

        public static readonly BindableProperty BodyTextProperty =
            BindableProperty.Create<InfoView, string>(p => p.BodyText, default(string));

        public double CornerRadius
        {
            get { return (double) GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public Color Stroke
        {
            get { return (Color) GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public double StrokeThickness
        {
            get { return (double) GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public bool HasShadow
        {
            get { return (bool) GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public string BodyText
        {
            get { return (string)GetValue(BodyTextProperty); }
            set { SetValue(BodyTextProperty, value); }
        }
    }
}
