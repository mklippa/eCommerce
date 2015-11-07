using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace eCommerce.Droid.Views
{
    public class DroidInfoView : LinearLayout
    {
        private TextView _headerTextView;
        private EditText _bodyEditText;
        private Bitmap _maskBitmap;
        private Paint _paint, _maskPaint;

        protected DroidInfoView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            InitComponent();
        }

        public DroidInfoView(Context context) : base(context)
        {
            InitComponent();
        }

        public DroidInfoView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            InitComponent();
        }

        public DroidInfoView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            InitComponent();
        }

        public DroidInfoView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            InitComponent();
        }

        private void InitComponent()
        {
            var inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            if (inflater == null) return;
                
            inflater.Inflate(Resource.Layout.InfoViewLayout, this);
            _headerTextView = FindViewById<TextView>(Resource.Id.headerTextView);
            _bodyEditText = FindViewById<EditText>(Resource.Id.bodyEditText);

            _paint = new Paint(PaintFlags.AntiAlias);

            _maskPaint = new Paint(PaintFlags.AntiAlias | PaintFlags.FilterBitmap);
            _maskPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));

            SetWillNotDraw(false);
        }

        public string HeaderText
        {
            get { return _headerTextView.Text; }
            set { _headerTextView.Text = value; }
        }

        public string BodyText 
        {
            get { return _bodyEditText.Text; }
            set { _bodyEditText.Text = value; } 
        }

        public int StrokeThickness { get; set; }

        public float CornerRadius { get; set; }

        public Color Stroke { get; set; }
        
        public override void Draw(Canvas canvas)
        {
            var rc = new Rect();
            GetDrawingRect(rc);

            var offscreenBitmap = Bitmap.CreateBitmap(rc.Width(), rc.Height(), Bitmap.Config.Argb8888);
            var offscreenCanvas = new Canvas(offscreenBitmap);

            base.Draw(offscreenCanvas);

            if (_maskBitmap == null)
            {
                _maskBitmap = CreateMask(rc.Width(), rc.Height());
            }

            offscreenCanvas.DrawBitmap(_maskBitmap, 0f, 0f, _maskPaint);
            canvas.DrawBitmap(offscreenBitmap, 0f, 0f, _paint);
        }

        private Bitmap CreateMask(int width, int height)
        {
            var mask = Bitmap.CreateBitmap(width, height, Bitmap.Config.Alpha8);
            var canvas = new Canvas(mask);

            var paint = new Paint(PaintFlags.AntiAlias) {Color = Color.White};

            canvas.DrawRect(0, 0, width, height, paint);

            paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
            canvas.DrawRoundRect(new RectF(0, 0, width, height), CornerRadius, CornerRadius, paint);

            return mask;
        }
    }
}