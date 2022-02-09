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
    public partial class CustomButtonWhitBorder : TextBox
    {

        private Color _bottomBorderColor = Color.FromArgb(64, 64, 64);
        private Color _onFocusbottomBorderColor = Color.Coral;
        private Color _TextColor = Color.FromArgb(64, 64, 64);
        private Color _onFocusTextColor = Color.FromArgb(64, 64, 64);

        public CustomButtonWhitBorder()
        {
            BorderStyle = BorderStyle.None;
            AutoSize = false;
            Controls.Add(new Panel
            {
                Margin = new Padding(0,-5,0,0),
                Height = 2,
                Dock = DockStyle.Bottom,
                BackColor = _bottomBorderColor
            });
            //Add label to control
            InitializeComponent();
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

        public Color OnFocusButtonBorderColor
        {
            get{ return _onFocusbottomBorderColor; }
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


        private void CustomButtonWhitBorder_Leave(object sender, EventArgs e)
        {
            Controls[0].BackColor = _bottomBorderColor;
            ForeColor = _TextColor;
        }

        private void CustomButtonWhitBorder_Enter(object sender, EventArgs e)
        {
            Controls[0].BackColor = _onFocusbottomBorderColor;
            ForeColor = _onFocusTextColor;
        }
        
    }
}
