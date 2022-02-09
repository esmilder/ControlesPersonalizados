using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticDesk.UI.Componentes
{
    internal static class ExtenssionMethods
    {
        public static Color FromHex(this string hex) =>
            ColorTranslator.FromHtml(hex);
    }
}
