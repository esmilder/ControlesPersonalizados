using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LogisticDesk.UI.Componentes
{
    class LabelCustomX: DevComponents.DotNetBar.LabelX
    {
        private const int WS_EX_TRANSPARENT = 0x20;
        public LabelCustomX()
        {
            this.SetStyle(ControlStyles.Opaque, true);
        }
        private int opacity = 50;
        [DefaultValue(50)]
        public int Opacity
        {
            get
            {
                return this.opacity;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("value must be between 0 and 100");
                this.opacity = value;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }



        //public enum Angles
        //{
        //    /// <summary>
        //    ///     Normal drawing direction.
        //    /// </summary>
        //    LeftToRight = 0,
        //    /// <summary>
        //    ///     Draw text top to bottom as viewed from the left.
        //    /// </summary>
        //    TopToBottom = 90,
        //    /// <summary>
        //    ///     Draw text from right to left as viewed from above (upside down).
        //    /// </summary>
        //    RightToLeft = 180,
        //    /// <summary>
        //    ///     Draw text bottom to top  as viewed from the right.
        //    /// </summary>
        //    BottomToTop = 270
        //}
        //private Angles _angle = Angles.LeftToRight;
        //private bool _enableGradient;
        //private bool _enableShadow;
        //private Color _endColor = Color.White;
        //private int _endColorAlpha = 255;
        //private LinearGradientMode _GradientDirection = LinearGradientMode.Vertical;
        //private Color _shadowColor = Color.LightGray;
        //private int _shadowOffset = 1;
        //private Color _startColor = Color.Red;
        //private int _startColorAlpha = 255;
        //public LabelCustom()
        //{
        //    SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
        //    this.AutoSize = false;
        //}
        ///// <summary>
        /////     Sets the drawing direction
        ///// </summary>
        //[Description("Sets the drawing direction")]
        //public Angles DrawingDirection
        //{
        //    get => _angle;
        //    set
        //    {
        //        _angle = value;
        //        Invalidate();
        //    }
        //}
        ///// <summary>
        /////     Sets of the shadow
        ///// </summary>
        //[Description("Sets of the shadow")]
        //public Color ShadowColor
        //{
        //    get => _shadowColor;
        //    set
        //    {
        //        _shadowColor = value;
        //        Invalidate();
        //    }
        //}
        ///// <summary>
        /////     Sets the offset of the shadow. Positives move right and down, negatives move left and up.
        ///// </summary>
        //[Description("Sets the offset of the shadow. Positives move right and down, negatives move left and up.")]
        //public int ShadowOffset
        //{
        //    get => _shadowOffset;
        //    set
        //    {
        //        _shadowOffset = value;
        //        Invalidate();
        //    }
        //}
        ///// <summary>
        /////     Enables to shadow
        ///// </summary>
        //[Description("Enables to shadow.")]
        //public bool EnableShadow
        //{
        //    get => _enableShadow;
        //    set
        //    {
        //        _enableShadow = value;
        //        Invalidate();
        //    }
        //}
        ///// <summary>
        /////     Enables the Gradient
        ///// </summary>
        //[Description("Enables the Gradient")]
        //public bool EnableGradient
        //{
        //    get => _enableGradient;
        //    set
        //    {
        //        _enableGradient = value;
        //        Invalidate();
        //    }
        //}
        ///// <summary>
        /////     Sets the direction of the gradient
        ///// </summary>
        //[Description("Sets the direction of the gradient")]
        //public LinearGradientMode GradientDirection
        //{
        //    get => _GradientDirection;
        //    set
        //    {
        //        _GradientDirection = value;
        //        Invalidate();
        //    }
        //}
        ///// <summary>
        /////     Sets the start color of the gradient
        ///// </summary>
        //[Description("Sets the start color of the gradient")]
        //public Color StartColor
        //{
        //    get => _startColor;
        //    set
        //    {
        //        _startColor = value;
        //        Invalidate();
        //    }
        //}
        ///// <summary>
        /////     Sets the end color of the gradient
        ///// </summary>
        //[Description("Sets the end color of the gradient")]
        //public Color EndColor
        //{
        //    get => _endColor;
        //    set
        //    {
        //        _endColor = value;
        //        Invalidate();
        //    }
        //}
        ///// <summary>
        /////     Sets the start alpha color of the gradient
        ///// </summary>
        //[Description("Sets the start alpha color of the gradient")]
        //public int StartColorAlpha
        //{
        //    get => _startColorAlpha;
        //    set
        //    {
        //        _startColorAlpha = value;
        //        if (_startColorAlpha > 255)
        //            _startColorAlpha = 255;
        //        Invalidate();
        //    }
        //}
        ///// <summary>
        /////     Sets the end alpha color of the gradient
        ///// </summary>
        //[Description("Sets the end alpha color of the gradient")]
        //public int EndColorAlpha
        //{
        //    get => _endColorAlpha;
        //    set
        //    {
        //        _endColorAlpha = value;
        //        if (_endColorAlpha > 255)
        //            _endColorAlpha = 255;
        //        Invalidate();
        //    }
        //}
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    if (_enableShadow && _angle == Angles.LeftToRight)
        //    {
        //        var rc0 = new Rectangle(_shadowOffset, _shadowOffset, Width, Height);
        //        var b0 = new SolidBrush(Color.FromArgb(255, _shadowColor));
        //        e.Graphics.DrawString(Text, Font, b0, rc0, ContentAlignmentToStringAlignment(TextAlign));
        //    }
        //    if (_enableGradient && _angle == Angles.LeftToRight)
        //    {
        //        var rc1 = new Rectangle(0, 0, Width, Height);
        //        Brush b = new LinearGradientBrush(rc1, Color.FromArgb(_startColorAlpha, _startColor), Color.FromArgb(_endColorAlpha, _endColor), _GradientDirection);
        //        e.Graphics.DrawString(Text, Font, b, rc1, ContentAlignmentToStringAlignment(TextAlign));
        //    }
        //    else
        //    {
        //        var size = e.Graphics.VisibleClipBounds.Size;
        //        switch (_angle)
        //        {
        //            case Angles.LeftToRight:
        //                e.Graphics.TranslateTransform(0, 0);
        //                e.Graphics.RotateTransform(0);
        //                e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(255, ForeColor)), new RectangleF(0, 0, size.Width, size.Height), ContentAlignmentToStringAlignment(TextAlign));
        //                e.Graphics.ResetTransform();
        //                break;
        //            case Angles.TopToBottom:
        //                e.Graphics.TranslateTransform(size.Width, 0);
        //                e.Graphics.RotateTransform(90);
        //                e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(255, ForeColor)), new RectangleF(0, 0, size.Height, size.Width), ContentAlignmentToStringAlignment(TextAlign));
        //                e.Graphics.ResetTransform();
        //                break;
        //            case Angles.RightToLeft:
        //                e.Graphics.TranslateTransform(size.Width, size.Height);
        //                e.Graphics.RotateTransform(180);
        //                e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(255, ForeColor)), new RectangleF(0, 0, size.Width, size.Height), ContentAlignmentToStringAlignment(TextAlign));
        //                e.Graphics.ResetTransform();
        //                break;
        //            case Angles.BottomToTop:
        //                e.Graphics.TranslateTransform(0, size.Height);
        //                e.Graphics.RotateTransform(270);
        //                e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(255, ForeColor)), new RectangleF(0, 0, size.Height, size.Width), ContentAlignmentToStringAlignment(TextAlign));
        //                e.Graphics.ResetTransform();
        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException();
        //        }
        //    }
        //}
        //private static StringFormat ContentAlignmentToStringAlignment(ContentAlignment ca)
        //{
        //    var format = new StringFormat();
        //    var l2 = (int)Math.Log((double)ca, 2);
        //    format.LineAlignment = (StringAlignment)(l2 / 4);
        //    format.Alignment = (StringAlignment)(l2 % 4);
        //    return format;
        //}

    }
}
