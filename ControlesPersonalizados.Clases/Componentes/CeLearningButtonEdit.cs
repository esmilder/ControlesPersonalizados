using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LogisticDesk.UI.Componentes
{
    public class CeLearningButtonEdit:Control
    {
        private int radius = 15;
        public TextBox textbox = new TextBox();
        private GraphicsPath shape;
        private GraphicsPath innerRect;
        private Color br;
        private Color _borderColor = Color.Gray;
        private int _borderSize = 1;
        private bool _readOnly = false;
        private Button btn = new Button();

        public CeLearningButtonEdit()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            this.textbox.Parent = this;
            base.Controls.Add(this.textbox);
            this.textbox.BorderStyle = BorderStyle.None;
            textbox.Font = this.Font;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Black;
            this.br = Color.White;
            textbox.BackColor = this.br;
            this.Text = null;
            this.Font = new Font("Century Gothic", 12f);
            base.Size = new Size(135, 33);
            this.DoubleBuffered = true;
            textbox.ReadOnly = this._readOnly;
            textbox.KeyDown += new KeyEventHandler(textbox_KeyDown);
            textbox.TextChanged += new EventHandler(textbox_TextChanged);
            textbox.MouseDoubleClick += new MouseEventHandler(textbox_MouseDoubleClick);
            textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textbox_KeyPress);

            btn.Size = new Size(25, textbox.ClientSize.Height);
            btn.Dock = DockStyle.Right;
            btn.Cursor = Cursors.Default;
            btn.Image = Properties.Resources.Find;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.Transparent;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            textbox.Controls.Add(btn);
            SendMessage(textbox.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private EventHandler onbtnClick;

        public event EventHandler btnClick
        {
            add
            {
                btn.Click += value;
            }
            remove
            {
                btn.Click -= value;
            }
        }

        protected virtual void OnbtnClick(EventArgs e)
        {
            onbtnClick?.Invoke(btn, e);
        }
        private void textbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textbox.SelectAll();
            }
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            this.Text = textbox.Text;
        }

        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                textbox.SelectionStart = 0;
                textbox.SelectionLength = this.Text.Length;
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            textbox.Font = this.Font;
            base.Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            textbox.ForeColor = this.ForeColor;
            base.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            textbox.ReadOnly = this._readOnly;
            this.shape = new MyRectangle((float)base.Width, (float)base.Height, (float)this.radius, 0f, 0f).Path;
            this.innerRect = new MyRectangle(base.Width - 0.5f, base.Height - 0.5f, (float)this.radius, 0.5f, 0.5f).Path;
            if (textbox.Height >= (base.Height - 4))
            {
                base.Height = textbox.Height + 4;
            }
            textbox.Location = new Point(this.radius - 5, (base.Height / 2) - (textbox.Font.Height / 2));
            textbox.Width = base.Width - ((int)(this.radius * 1.5));
            e.Graphics.SmoothingMode = ((SmoothingMode)SmoothingMode.HighQuality);
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage((Image)bitmap);
            Pen pp = new Pen(_borderColor, _borderSize);
            e.Graphics.DrawPath(pp, this.shape);

            using (SolidBrush brush = new SolidBrush(this.br))
            {
                e.Graphics.FillPath((Brush)brush, this.innerRect);
            }
            CeLearningTransparent.MakeTransparent(this, e.Graphics);

            base.OnPaint(e);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            textbox.Text = this.Text;
        }
        public void SelectAll()
        {
            textbox.SelectAll();
        }
        public char PasswordChar
        {
            get =>
                textbox.PasswordChar;
            set
            {
                textbox.PasswordChar = value;
                base.Invalidate();
            }

        }
        public bool UseSystemPasswordChar
        {
            get =>
                textbox.UseSystemPasswordChar;
            set
            {
                textbox.UseSystemPasswordChar = value;
                base.Invalidate();
            }

        }
        public Color Br
        {
            get =>
                this.br;
            set
            {
                this.br = value;
                if (this.br != Color.Transparent)
                {
                    textbox.BackColor = this.br;
                }
                base.Invalidate();
            }
        }
        public override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = Color.Transparent;
        }
        public Color BorderColor
        {
            get =>
                this._borderColor;
            set { this._borderColor = value; Invalidate(); }
        }
        public int textboxRadius
        {
            get =>
                this.radius;
            set { this.radius = value; Invalidate(); }
        }
        public int BorderSize
        {
            get =>
                this._borderSize;
            set { this._borderSize = value; Invalidate(); }
        }
        public bool ReadOnly
        {
            get =>
                this._readOnly;
            set { this._readOnly = value; Invalidate(); }
        }

        public Image btnImage
        {
            get =>
                btn.Image;
            set
            {
                btn.Image = value;
                btn.Invalidate();
            }
        }
    }
}
