using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LogisticDesk.UI.Componentes
{
    class RoundButton : Button
    {
        private Image _onHoverbackgroundImage;
        private Image _backgroundImage;

        protected override void OnResize(EventArgs e)
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(2, 2, this.Width - 5, this.Height - 5));
                this.Region = new Region(path);
            }
            base.OnResize(e);
        }
        public RoundButton()
        {
            _onHoverbackgroundImage = BackgroundImage;
            _backgroundImage = BackgroundImage;
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RoundButton
            // 
            this.MouseHover += new System.EventHandler(this.RoundButton_MouseHover);
            this.MouseLeave += new System.EventHandler(this.RoundButton_MouseLeave);
            this.ResumeLayout(false);

        }

        public Image onHoverbackgroundImage
        {
            get =>
               this._onHoverbackgroundImage;
            set { this._onHoverbackgroundImage = value; Invalidate(); }
        }
        public override Image BackgroundImage
        {
            get =>
               this._backgroundImage;
            set { this._backgroundImage = value; Invalidate(); }
        }

        private void RoundButton_MouseHover(object sender, EventArgs e)
        {
            BackgroundImage = _onHoverbackgroundImage;
        }

        private void RoundButton_MouseLeave(object sender, EventArgs e)
        {
            BackgroundImage = _backgroundImage;
        }
    }
}
