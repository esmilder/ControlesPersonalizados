using System.Drawing;
using System.Windows.Forms;

namespace LogisticDesk.UI.Componentes
{
    internal class CeLearningTransparent
    {
        public static void MakeTransparent(Control control, Graphics g)
        {
            Control parent = control.Parent;
            if (parent != null)
            {
                Rectangle rectangle = control.Bounds;
                Control.ControlCollection controls = parent.Controls;
                int index = controls.IndexOf(control);
                Bitmap bitmap = null;
                for (int i = controls.Count - 1; i > index; i--)
                {
                    Control control3 = controls[i];
                    if (control3.Bounds.IntersectsWith(rectangle))
                    {
                        if (bitmap == null)
                        {
                            bitmap = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                        }
                        control3.DrawToBitmap(bitmap, control3.Bounds);
                    }
                }
                if (bitmap != null)
                {
                    g.DrawImage((Image)bitmap, control.ClientRectangle, rectangle, (GraphicsUnit)GraphicsUnit.Pixel);
                    bitmap.Dispose();
                }
            }
        }
    }
}
