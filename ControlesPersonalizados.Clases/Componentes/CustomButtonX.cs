using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticDesk.UI.Componentes
{
    class CustomButtonX: ButtonX
    {
        private Color _OnHoverColorSymbol = Color.Blue;
        private Color _SymbolColor1 = Color.Blue;

        

        public Color SymbolColor1
        {
            get { return _SymbolColor1; }
            set { _SymbolColor1 = value; Invalidate(); }
        }
        public Color OnHoverColorSymbol
        {
            get { return _OnHoverColorSymbol; }
            set { _OnHoverColorSymbol = value; Invalidate(); }
        }



        //method mouse enter  
        protected override void OnMouseEnter(EventArgs e)
        {

            base.OnMouseEnter(e);
            this.SymbolColor = _OnHoverColorSymbol ;
        }
        //method mouse leave  
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.SymbolColor = _SymbolColor1;
        }
        
    }
}
