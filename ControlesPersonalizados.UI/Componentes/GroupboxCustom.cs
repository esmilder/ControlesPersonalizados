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
    class GroupboxCustom: GroupBox
    {
        private Color TitleBackColor_ = Color.SteelBlue;
        private Color TitleForeColor_ = Color.White;
        private Font TitleFont_ = new Font( new FontFamily("Arial"),  +8,   FontStyle.Bold,GraphicsUnit.Pixel); //new Font( Font.FontFamily, Font.Size + 8, FontStyle.Bold);
        private Color BackColor_ = Color.Transparent;
        private int Radious_ = 25;
        private int TitleHeight_ = 100;
        private HatchStyle TitleHatchStyle_ = HatchStyle.Percent60;
        public GroupboxCustom()
        {
            this.DoubleBuffered = true;
            this.Padding = new Padding(10);
            //this.TitleBackColor = Color.SteelBlue;
            //this.TitleForeColor = Color.White;
            //this.TitleFont = new Font(this.Font.FontFamily, Font.Size + 8, FontStyle.Bold);
            //this.BackColor = Color.Transparent;
            //this.Radious = 25;
            //this.TitleHatchStyle = HatchStyle.Percent60;
        }
        public Color TitleBackColor {
            get => TitleBackColor_;
            set
            {
                TitleBackColor_ = value;
                Invalidate();
            }
        }
        public HatchStyle TitleHatchStyle {
            get => TitleHatchStyle_;
            set
            {
                TitleHatchStyle_ = value;
                Invalidate();
            }
        }
        public Font TitleFont {
            get => TitleFont_;
            set
            {
                TitleFont_ = value;
                Invalidate();
            }
        }
        public Color TitleForeColor {
            get => TitleForeColor_;
            set
            {
                TitleForeColor_ = value;
                Invalidate();
            }
        }
        public int Radious {
            get => Radious_;
            set
            {
                Radious_ = value;
                Invalidate();
            }
        }
        public int TitleHeight { get => TitleHeight_;
        set {
                TitleHeight_ = value;
                Invalidate();
            }
        }
        private GraphicsPath GetRoundRectagle(Rectangle b, int r)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(b.X, b.Y, r, r, 180, 90);
            path.AddArc(b.X + b.Width - r - 1, b.Y, r, r, 270, 90);
            path.AddArc(b.X + b.Width - r - 1, b.Y + b.Height - r - 1, r, r, 0, 90);
            path.AddArc(b.X, b.Y + b.Height - r - 1, r, r, 90, 90);
            path.CloseAllFigures();
            return path;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GroupBoxRenderer.DrawParentBackground(e.Graphics, this.ClientRectangle, this);
            var rect = ClientRectangle;
            using (var path = GetRoundRectagle(this.ClientRectangle, Radious))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                rect = new Rectangle(0, 0,
                    rect.Width, TitleHeight);
                if (this.BackColor != Color.Transparent)
                    using (var brush = new SolidBrush(BackColor))
                        e.Graphics.FillPath(brush, path);
                var clip = e.Graphics.ClipBounds;
                e.Graphics.SetClip(rect);
                using (var brush = new HatchBrush(TitleHatchStyle,
                    TitleBackColor,ControlPaint.Light(TitleBackColor)))
                    e.Graphics.FillPath(brush, path);
                using (var pen = new Pen(TitleBackColor, 1))
                    e.Graphics.DrawPath(pen, path);
                TextRenderer.DrawText(e.Graphics, Text, TitleFont, rect, TitleForeColor);
                e.Graphics.SetClip(clip);
                using (var pen = new Pen(TitleBackColor, 1))
                    e.Graphics.DrawPath(pen, path);
            }
        }
    }
}
