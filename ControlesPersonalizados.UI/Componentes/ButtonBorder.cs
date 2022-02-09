using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticDesk.UI.Componentes
{
    public partial class ButtonBorder : UserControl
    {
        public ButtonBorder()
        {
            BorderStyle = BorderStyle.None;
            AutoSize = false;
            Controls.Add(new Panel
            {
                Margin = new Padding(0, -5, 0, 0),
                Height = 2,
                Dock = DockStyle.Bottom,
                BackColor = _bottomBorderColor
            });
            Controls[0].MouseHover += CustomButtonWhitBorder_MouseHover;
            Controls[0].MouseLeave += CustomButtonWhitBorder_MouseLeave;
            lbltexto = new Label
            {
                Margin = new Padding(0, 0, 0, 0),
                AutoSize = false,
                Dock = DockStyle.Fill,
                BackColor = _TextBackColor,
                Font = _TextFont,
                TextAlign = _TextAling,
                Cursor = Cursors.Hand
            };
            lbltexto.MouseHover += CustomButtonWhitBorder_MouseHover;
            lbltexto.MouseLeave += CustomButtonWhitBorder_MouseLeave;
            lbltexto.Click += ((object obj, EventArgs args) =>
            {
                if (_AutoChecked)
                {
                    _isChecked = !_isChecked;
                    if (_isChecked)
                        Controls[0].BackColor = _checkedColor;
                    else
                        Controls[0].BackColor = _bottomBorderColor;
                }
            });
            Controls.Add(lbltexto);
            //Add label to control
            InitializeComponent();
            #region Animar Panel
            ////_imageList = CreateImages();
            //_animationTimer = new Timer
            //{
            //    Enabled = false,
            //    Interval = 1
            //};
            //_animationTimer.Tick += AnimateButton;
            #endregion
        }
        private Color _bottomBorderColor = Color.FromArgb(64, 64, 64);
        private Color _onFocusbottomBorderColor = Color.Coral;
        private Color _checkedColor = Color.Coral;
        private Color _TextColor = Color.FromArgb(64, 64, 64);
        private Color _onFocusTextColor = Color.FromArgb(64, 64, 64);
        private string _Text = "";
        private Color _TextBackColor = Color.White;
        private Color _onFocusTextBackColor = Color.White;
        private Font _TextFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
        private ContentAlignment _TextAling = ContentAlignment.MiddleCenter;
        private bool _isChecked = false;
        private bool _AutoChecked = true;
        private Color _disableTextColor = Color.FromArgb(224, 224, 224);
        private Label lbltexto;
        private bool _enabled = true;


        public event EventHandler btnClick
        {
            add
            {
                lbltexto.Click += value;
            }
            remove
            {
                lbltexto.Click -= value;
            }
        }

        private EventHandler onbtnClick;

        protected virtual void ButtonClick(EventArgs e)
        {
            onbtnClick?.Invoke(lbltexto, e);
        }
        //oculta la propiedad borderstyle del control
        [Browsable(false)]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }
        }
        public Color ButtonBorderColor
        {
            get { return _bottomBorderColor; }
            set
            {
                _bottomBorderColor = value;
                Controls[0].BackColor = _bottomBorderColor;
            }
        }
        public Color CheckedBottomBorderColor
        {
            get { return _checkedColor; }
            set
            {
                _checkedColor = value;
            }
        }
        public new object Tag
        {
            get { return lbltexto.Tag; }
            set
            {
                lbltexto.Tag = value;
            }
        }
        public Color TextBackColor
        {
            get { return _TextBackColor; }
            set
            {
                _TextBackColor = value;
                lbltexto.BackColor = _TextBackColor;
            }
        }
        public Color OnFocusTextBackColor
        {
            get { return _onFocusTextBackColor; }
            set
            {
                _onFocusTextBackColor = value;
            }
        }
        public Font TextFont
        {
            get { return _TextFont; }
            set
            {
                _TextFont = value;
                lbltexto.Font = _TextFont;
            }
        }
        public string Texto
        {
            get { return _Text; }
            set
            {
                _Text = value;
                lbltexto.Text = _Text;
            }
        }
        public ContentAlignment TextAling
        {
            get { return _TextAling; }
            set
            {
                _TextAling = value;
                lbltexto.TextAlign = _TextAling;
            }
        }

        public Color OnFocusButtonBorderColor
        {
            get { return _onFocusbottomBorderColor; }
            set
            {
                _onFocusbottomBorderColor = value;
            }
        }
        public Color TextColor
        {
            get { return _TextColor; }
            set
            {
                _TextColor = value;
                lbltexto.ForeColor = _TextColor;
            }
        }
        public Color DisableTextColor
        {
            get { return _disableTextColor; }
            set
            {
                _disableTextColor = value;
            }
        }
        public Color OnFocusTextColor
        {
            get { return _onFocusTextColor; }
            set
            {
                _onFocusTextColor = value;
            }
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                Controls[0].BackColor = _isChecked ? _checkedColor : _bottomBorderColor;
                lbltexto.ForeColor = _isChecked ? _checkedColor : _TextColor;
            }
        }
        public new bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                lbltexto.Enabled = value;
                lbltexto.ForeColor = _enabled ? _TextColor : _disableTextColor;
            }
        }
        [Description("Hace que el botón cambie automáticamente de estado al hacer clic sobre éste")]
        public bool AutoChecked
        {
            get { return _AutoChecked; }
            set
            {
                _AutoChecked = value;
            }
        }
        #region Animar Panel
        //private List<Image> _imageList;
        //private bool _isMouseHover;
        //private int _currentImageIndex = -1;
        //private readonly Timer _animationTimer;
        //private void AnimateButton(object sender, EventArgs e)
        //{
        //    if(_imageList== null)
        //        _imageList = CreateImages();

        //    if (_isMouseHover && _currentImageIndex >= _imageList.Count - 1
        //        || !_isMouseHover && _currentImageIndex <= 0)
        //    {
        //        _animationTimer.Stop();
        //        return;
        //    }

        //    _currentImageIndex += _isMouseHover ? 1 : -1;
        //    Controls[0].BackgroundImage = _imageList[_currentImageIndex];
        //}

        private List<Image> CreateImages()
        {
            var lista = new List<Image>();
            int width = 250;
            int height = 50;
            using (SolidBrush brush = new SolidBrush(_onFocusbottomBorderColor))
            using (SolidBrush whiteBrush = new SolidBrush(_bottomBorderColor))
            {
                for (int i = 0; i <= width; i += 10)
                {
                    var bmp = new Bitmap(width, height);
                    using (Graphics gfx = Graphics.FromImage(bmp))
                    {
                        gfx.FillRectangle(whiteBrush, 0, 0, width, height);
                        gfx.FillRectangle(brush, width / 2 - i / 2, 0, i, height);
                    }
                    lista.Add(bmp);
                }
            }
            return lista;
        }
        #endregion
        private void CustomButtonWhitBorder_MouseLeave(object sender, EventArgs e)
        {
            if (!(Enabled))
                return;
            Controls[0].BackColor = _isChecked ? _checkedColor : _bottomBorderColor;
            lbltexto.ForeColor = _isChecked ? _checkedColor : _TextColor;
            lbltexto.BackColor = _TextBackColor;
            //_isMouseHover = false;
            //if (!_animationTimer.Enabled) _animationTimer.Start();
        }

        private void CustomButtonWhitBorder_MouseHover(object sender, EventArgs e)
        {
            if (!(Enabled))
                return;
            Controls[0].BackColor = _onFocusbottomBorderColor;
            lbltexto.ForeColor = _onFocusTextColor;
            lbltexto.BackColor = _onFocusTextBackColor;
            //_isMouseHover = true;
            //if (!_animationTimer.Enabled) _animationTimer.Start();
        }
    }
}
