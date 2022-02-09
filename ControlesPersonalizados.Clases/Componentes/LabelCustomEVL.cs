using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticDesk.UI.Componentes
{
    class LabelCustomEVL: Label
    {
        public Color _leaveColor;
        public Color _hoverColor;
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LabelCustomEVL
            // 
            this.MouseLeave += new System.EventHandler(this.LabelCustomEVL_MouseLeave);
            this.MouseHover += new System.EventHandler(this.LabelCustomEVL_MouseHover);
            this.ResumeLayout(false);
        }

        public Color HoverColor
        {
            get { return _hoverColor; }
            set
            {
                _hoverColor = value;
                Invalidate();
            }
        }
        public override Color ForeColor
        {
            get { return _leaveColor; }
            set
            {
                _leaveColor = value;
            }
        }

        private void LabelCustomEVL_MouseHover(object sender, EventArgs e)
        {
            this.ForeColor = _hoverColor;
        }

        private void LabelCustomEVL_MouseLeave(object sender, EventArgs e)
        {
            this.ForeColor = _leaveColor;
        }
    }
}
