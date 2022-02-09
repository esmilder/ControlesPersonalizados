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
    public partial class TabControlWithoutHeader : UserControl
    {
        public TabControlWithoutHeader()
        {
            InitializeComponent();
        }
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x1328 && !DesignMode)
        //        m.Result = (IntPtr)1;
        //    else
        //        base.WndProc(ref m);
        //}
        
    }
}
