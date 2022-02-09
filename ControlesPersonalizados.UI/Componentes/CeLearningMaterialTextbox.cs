using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace LogisticDesk.UI.Componentes
{
    class CeLearningMaterialTextbox: Control
    {
        private TextBox textbox = new TextBox();
        private HorizontalAlignment ALNType;
        private int maxchars = 32767;
        private bool readOnly;
        private bool previousReadOnly;
        private bool isPasswordMasked = false;
        private bool Enable = true;
        private System.Windows.Forms.Timer AnimationTimer;
        private bool Focus;
        private float SizeAnimation;
        private float SizeInc_Dec;
        private float PointAnimation;
        private float PointInc_Dec;
        private Color focusColor;
        private Color EnabledFocusedColor;
        private Color EnabledUnFocusedColor;
        private Color DisabledUnfocusedColor;
        private Color textBackColor;

        public CeLearningMaterialTextbox()
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer
            {
                Interval = 1
            };
            this.AnimationTimer = timer1;
            this.Focus = false;
            this.SizeAnimation = 0f;
            this.focusColor = ColorTranslator.FromHtml("#cc00cc");
            this.EnabledUnFocusedColor = ColorTranslator.FromHtml("#dbdbdb");
            this.DisabledUnfocusedColor = ColorTranslator.FromHtml("#e9ecee");
            this.textBackColor = Color.White;
            base.Width = 300;
            this.DoubleBuffered = true;
            //ReadOnly property i will generate later
            this.previousReadOnly = this.ReadOnly;
            //Create Textbox function
            this.AddTextBox();
            base.Controls.Add(this.textbox);
            this.textbox.TextChanged += (sender, args) => this.Text = this.textbox.Text;
            base.TextChanged += (sender, args) => this.textbox.Text = this.Text;
            this.AnimationTimer.Tick += new EventHandler(this.AnimationTick);
        }

        public void AddTextBox()
        {
            this.textBackColor = this.BackColor;
            this.textbox.Text = this.Text;
            this.textbox.Location = new Point(0, 1);
            this.textbox.Size = new Size(base.Width - 21, 30);
            this.textbox.Multiline = false;
            this.textbox.Font = new Font("Century Gothic", 12f);
            this.textbox.ScrollBars = ScrollBars.None;
            this.textbox.BorderStyle = BorderStyle.None;
            this.textbox.TextAlign = HorizontalAlignment.Left;
            this.textbox.BackColor = this.textBackColor;
            this.textbox.UseSystemPasswordChar = this.UseSystemPasswordChar;
            this.textbox.ForeColor = Color.LightGray;
            this.textbox.KeyDown += new KeyEventHandler(this.OnKeyDown);
            this.textbox.GotFocus += (sender, args) => this.Focus = true;
            this.AnimationTimer.Start();
            this.textbox.LostFocus += (sender, args) => this.Focus = false;
            this.AnimationTimer.Start();
        }

        private void AnimationTick(object? sender, EventArgs e)
        {
            if (this.Focus)
            {
                if (this.SizeAnimation < base.Width)
                {
                    this.SizeAnimation += this.SizeInc_Dec;
                    base.Invalidate();
                }
                if (this.PointAnimation > 0f)
                {
                    this.PointAnimation -= this.PointInc_Dec;
                    base.Invalidate();
                }
            }
            else
            {
                if (this.SizeAnimation > 0f)
                {
                    this.SizeAnimation -= this.SizeInc_Dec;
                    base.Invalidate();
                }
                if (this.PointAnimation < (base.Width / 2))
                {
                    this.PointAnimation += this.PointInc_Dec;
                    base.Invalidate();
                }
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.textbox.Focus();
            this.textbox.SelectionLength = 0;
        }

        protected void OnKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                this.textbox.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && (e.KeyCode == Keys.C))
            {
                this.textbox.Copy();
                e.SuppressKeyPress = true;
            }
            if (e.Control && (e.KeyCode == Keys.X))
            {
                this.textbox.Cut();
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage((Image)bitmap);
            graphics.Clear(Color.Transparent);
            this.textbox.BackColor = this.textBackColor;
            this.EnabledFocusedColor = this.focusColor;
            this.textbox.TextAlign = this.TextAlignment;
            this.textbox.UseSystemPasswordChar = this.UseSystemPasswordChar;
            graphics.DrawLine(new Pen((Brush)new SolidBrush(this.IsEnabled ? this.EnabledUnFocusedColor :
                this.DisabledUnfocusedColor)), new Point(0, base.Height - 2), new Point(base.Width, base.Height - 2));
            if (this.IsEnabled)
            {
                graphics.FillRectangle((Brush)new SolidBrush(this.EnabledFocusedColor),
                    this.PointAnimation, base.Height - 3f, this.SizeAnimation, 2f);
            }
            graphics.SmoothingMode = (SmoothingMode)SmoothingMode.AntiAlias;
            e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
            graphics.Dispose();
            bitmap.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Height = 30;
            this.PointAnimation = base.Width / 2;
            this.SizeInc_Dec = base.Width / 18;
            this.PointInc_Dec = base.Width / 36;
            this.textbox.Width = base.Width - 1;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            base.Invalidate();
        }
        public HorizontalAlignment TextAlignment
        {
            get =>
                this.ALNType;
            set
            {
                this.ALNType = value;
                base.Invalidate();
            }
        }

        [Category("Behavior")]
        public int MaxLength
        {
            get =>
                this.maxchars;
            set
            {
                this.maxchars = value;
                this.textbox.MaxLength = this.MaxLength;
                base.Invalidate();
            }
        }

        [Category("Appearance")]
        public Color FocusedColor
        {
            get =>
                this.focusColor;
            set
            {
                this.focusColor = value;
                base.Invalidate();
            }
        }

        [Category("Behavior")]
        public bool IsEnabled
        {
            get =>
                this.Enable;
            set
            {
                this.Enable = value;
                if (this.IsEnabled)
                {
                    this.readOnly = this.previousReadOnly;
                    this.textbox.ReadOnly = this.previousReadOnly;
                    this.textbox.Enabled = true;
                }
                else
                {
                    this.previousReadOnly = this.ReadOnly;
                    this.ReadOnly = true;
                }
            }
        }

        [Category("Behavior")]
        public bool ReadOnly
        {
            get =>
                this.readOnly;
            set
            {
                this.readOnly = value;
                if (this.textbox != null)
                {
                    this.textbox.ReadOnly = value;
                }
            }
        }

        [Category("Behavior")]
        public bool UseSystemPasswordChar
        {
            get =>
                this.isPasswordMasked;
            set
            {
                this.textbox.UseSystemPasswordChar = this.UseSystemPasswordChar;
                this.isPasswordMasked = value;
                base.Invalidate();
            }
        }

        public Color FontColor
        {
            get =>
                this.textbox.ForeColor;
            set { this.textbox.ForeColor = value; Invalidate(); }
        }

        public Font TextFont
        {
            get =>
                this.textbox.Font;
            set { this.textbox.Font = value; Invalidate(); }
        }
    }
}
